using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShorteningLink.Application.Interfaces;
using ShorteningLink.Domain;

namespace ShorteningLink.Application.Repositories.URL
{
    public class LinkRepository : ILinkRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<LinkRepository> _logger;

        public LinkRepository(IApplicationDbContext context, ILogger<LinkRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Create(string URL, string shortURL, CancellationToken cancellationToken)
        {
            Link newLink = new Link
            {
                LongURL = URL,
                CreationDate = DateTime.Now,
                VisitCount = default(int),
                ShortURL = shortURL,
            };

            await _context.Link.AddAsync(newLink);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            Link link = await _context.Link.FirstOrDefaultAsync(x => x.Id == id);

            if (link is null)
            {
                _logger.LogWarning("Link does not exist");
                return;
            }

            _context.Link.Remove(link);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Link> Get(string shortUrl, CancellationToken cancellationToken)
        {
            Link link = await _context.Link.FirstOrDefaultAsync(u => u.ShortURL == shortUrl);

            if (link is null)
            {
                _logger.LogWarning("Link does not exist");
                return link;
            }

            link.VisitCount++;
            _context.Link.Update(link);
            await _context.SaveChangesAsync(cancellationToken);

            return link;
        }

        public async Task<List<Link>> GetAll()
        {
            List<Link> urls = await _context.Link.ToListAsync();

            return urls;
        }
    }
}

using ShorteningLink.Domain;

namespace ShorteningLink.Application.Repositories.URL
{
    public interface ILinkRepository
    {
        Task Create(string URL, string shortURL, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<List<Link>> GetAll();
        Task<Link> Get(string shortUrl, CancellationToken cancellationToken);
    }
}

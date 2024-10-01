using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MySqlX.XDevAPI;
using ShorteningLink.Application.Repositories.URL;
using ShorteningLink.Application.Services;
using ShorteningLink.Domain;
using ShorteningLink.Models;
using System.Diagnostics;
using System.Security.Policy;

namespace ShorteningLink.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILinkRepository _repository;
        private readonly IURLShortenerService _urlShortenerService;

        public HomeController(ILogger<HomeController> logger, ILinkRepository repository, IURLShortenerService urlShortenerService)
        {
            _logger = logger;
            _repository = repository;
            _urlShortenerService = urlShortenerService;
        }

        public async Task<IActionResult> Index()
        {
            List<Link> urls = await _repository.GetAll();
            string scheme = HttpContext.Request.Scheme;
            string host = HttpContext.Request.Host.Value;

            ViewBag.ApplicationUrl =  $"{scheme}://{host}";

            return View(urls);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string longUrl, CancellationToken cancellationToken)
        {
            string shortURL = _urlShortenerService.GenerateShortUrl();
            await _repository.Create(longUrl, shortURL, cancellationToken);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _repository.Delete(id, cancellationToken);

            return RedirectToAction("Index");
        }

        [HttpGet("/{shortUrl}")]
        public async Task<IActionResult> RedirectToLongUrl(string shortUrl, CancellationToken cancellationToken)
        {
            Link link = await _repository.Get(shortUrl, cancellationToken);

            if (link is null)            
                return RedirectToAction("Index");
            
            return Redirect(link.LongURL);
        }
    }
}

using ShorteningLink.Application.Enums;

namespace ShorteningLink.Application.Services
{
    public class URLShortenerService : IURLShortenerService
    {
        public string GenerateShortUrl()
        {
            Random random = new Random();
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, (int)ShortLink.Length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

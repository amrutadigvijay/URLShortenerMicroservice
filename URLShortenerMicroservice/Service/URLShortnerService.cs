using System;
using URLShortenerMicroservice.Model;

namespace URLShortenerMicroservice.Service
{
    public class URLShortnerService : IUrlShortnerService
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
       
        private Random _random=new Random();
        Task<string?> GetOriginalUrlAsync(string shortCode)
        {
            throw new NotImplementedException();
        }
        Task<string> ShortenUrlAsync(string originalURL)
        {

            //generate shortcode

            var shortcode = GenerateShortCode();
            // add prefix if needed
            var shorturl = "newgen.ly" + shortcode;

            var mapping = new UrlMapping();
            mapping.shortUrl = shorturl;
            mapping.longUrl = originalURL;

            
            throw new NotSupportedException();
        }

        private string GenerateShortCode(int length = 6)
        {
            return new string(Enumerable.Repeat(Alphabet, length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}

using System;
using URLShortenerMicroservice.Data;
using URLShortenerMicroservice.Model;
using Microsoft.EntityFrameworkCore;

namespace URLShortenerMicroservice.Service
{
    public class URLShortnerService : IUrlShortnerService
    {
        private UrlShortnerContext _context = new UrlShortnerContext();

        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
       
        private Random _random=new Random();
      public async Task<string?> GetOriginalUrlAsync(string shortUrl)
        {
            var response=   await _context.urlMappings.FirstOrDefaultAsync(s=> s.shortUrl==shortUrl);
            if(response!=null)
            {
                return response.longUrl;

            }
            return null;

        }
        public async Task<string> ShortenUrlAsync(string originalUrl)
        {

            //generate shortcode

            var shortcode = GenerateShortCode();
            // add prefix if needed
            var shorturl = "newgen.ly" + shortcode;

            var mapping = new UrlMapping();
            mapping.shortUrl = shorturl;
            mapping.longUrl = originalUrl;

            var response= await _context.urlMappings.AddAsync(mapping);

            await _context.SaveChangesAsync();
           return response.Entity.shortUrl;
        }

        private string GenerateShortCode(int length = 6)
        {
            return new string(Enumerable.Repeat(Alphabet, length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        
        }
    }


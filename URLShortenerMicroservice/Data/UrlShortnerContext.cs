using URLShortenerMicroservice.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace URLShortenerMicroservice.Data
{
    public class UrlShortnerContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<UrlMapping> urlMappings { get; set; }

       protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Data Source=DESKTOP-7RTQMAO;Initial Catalog=WebEF;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}

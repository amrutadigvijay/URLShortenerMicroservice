using System.ComponentModel.DataAnnotations;

namespace URLShortenerMicroservice.Model
{
    public class UrlMapping
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string shortUrl { get; set; } = string.Empty;
        [Required]
        public string longUrl { get; set; } = string.Empty;

    }
}

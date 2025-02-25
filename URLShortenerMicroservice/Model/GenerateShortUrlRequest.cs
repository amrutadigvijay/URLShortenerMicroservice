using System.ComponentModel.DataAnnotations;

namespace URLShortenerMicroservice.Model
{
    /// <summary>
    ///  request data flow objet generate short url method
    /// </summary>
    public class GenerateShortUrlRequest
    {
        /// <summary>
        /// instance of string representing the longUrl.
        /// </summary>
        /// 
        [Required]
        [MinLength(9)]
        public string longUrl { get; set; }
    }
}

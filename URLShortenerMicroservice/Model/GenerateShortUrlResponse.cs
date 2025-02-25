namespace URLShortenerMicroservice.Model
{
    /// <summary>
    /// response model class for generate shortUrl.
    /// </summary>
    public class GenerateShortUrlResponse
    {
        /// <summary>
        /// Instance of string
        /// </summary>
        public string  longUrl { get; set; }
        /// <summary>
        /// Instance of string
        /// </summary>
        public string shortUrl { get; set; }

    }
}

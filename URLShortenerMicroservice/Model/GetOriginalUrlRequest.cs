namespace URLShortenerMicroservice.Model
{
    /// <summary>
    /// Class representing the request attributes for the API GetOriginalUrl.
    /// </summary>
    public class GetOriginalUrlRequest
    {
        /// <summary>
        /// Instance of string
        /// </summary>
        public string shortUrl { get; set; }
    }
}

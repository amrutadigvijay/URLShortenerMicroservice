namespace URLShortenerMicroservice.Model
{
    /// <summary>
    /// Respones model class for the getOriginalUrl
    /// </summary>
    public class GetOriginalUrlResponse : GenerateShortUrlResponse
    {
        /// <summary>
        /// This will be field only f any error or entry not present
        /// </summary>
        public string Message { get; set; }


    }
}

namespace URLShortenerMicroservice.Service
{
    /// <summary>
    /// Interface layer for the URL service.
    /// </summary>
    public interface IUrlShortnerService
    {
/// <summary>
/// method which will perform the shortning of the long url provided.
/// </summary>
/// <param name="originalUrl">Instance of string</param>
/// <returns>Instace of string indicating shortened url for given short url</returns>
        Task<string> ShortenUrlAsync(string originalUrl);

        /// <summary>
        /// Method will return the valid log url for given short url.
        /// </summary>
        /// <param name="shortCode">Instance of string</param>
        /// <returns>Instance of string representing the long url for given short url </returns>
        Task<string?> GetOriginalUrlAsync(string shortCode);
    }
}

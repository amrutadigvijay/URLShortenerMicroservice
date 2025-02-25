using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using URLShortenerMicroservice.Model;
using URLShortenerMicroservice.Service;

namespace URLShortenerMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class URLController : ControllerBase
    {
        /// <summary>
        /// Instance of IUrlShortnerService.
        /// </summary>
        private IUrlShortnerService _urlShortnerService;
        public URLController(IUrlShortnerService urlShortnerService)
        {
            _urlShortnerService = urlShortnerService;
        }
        /// <summary>
        /// This willprovide a short url for given long url.
        /// </summary>
        /// <param name="request">Instance of GenerateShortUrlRequest</param>
        /// <returns>On completion will return the long url with valid statuscode.</returns>
        [HttpPost("generateshortURL")]
        public async Task<IActionResult> genereteShortUrl([FromBody] GenerateShortUrlRequest request)
        {
            if (string.IsNullOrEmpty(request.longUrl))
            {
                return BadRequest("the long url need to be specified");
            }
            try
            {

                var shortUrl = await _urlShortnerService.ShortenUrlAsync(request.longUrl);
                GenerateShortUrlResponse generateShortUrlResponse = new GenerateShortUrlResponse();
                generateShortUrlResponse.longUrl = request.longUrl;
                generateShortUrlResponse.shortUrl = shortUrl;

                return CreatedAtAction(nameof(genereteShortUrl), generateShortUrlResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error, unable to process request" + ex.Message);
            }
        }

        [HttpPost("getOriginalURL")]

        public async Task<IActionResult> GetOriginalUrlRequest([FromBody] GetOriginalUrlRequest req)
        {
            if (string.IsNullOrEmpty(req.shortUrl))
            {
                return BadRequest("the long url need to be specified");
            }
            try
            {


                var longUrl = await _urlShortnerService.GetOriginalUrlAsync(req.shortUrl);
                GetOriginalUrlResponse getOriginalUrlResponse = new GetOriginalUrlResponse();
                getOriginalUrlResponse.shortUrl = req.shortUrl;
                getOriginalUrlResponse.longUrl = longUrl;

                if (longUrl == null)
                {
                    getOriginalUrlResponse.Message = req.shortUrl + "is not present into database";

                    return NotFound(getOriginalUrlResponse);
                }
                else
                {
                    return Ok(getOriginalUrlResponse);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error occured while processing" + ex.Message);
            }
        }
    }
}
    


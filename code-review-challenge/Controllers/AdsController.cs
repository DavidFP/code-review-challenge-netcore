using CodeReviewChallenge.Application;
using CodeReviewChallenge.infrastructure.api;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodeReviewChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {

        private readonly IAdsService _adsService;

        public AdsController(IAdsService adsService)
        {
            _adsService = adsService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<QualityAd>> QualityListing()
        {
            return _adsService.FindQualityAds();
        }
        [HttpGet]
        public ActionResult<IEnumerable<PublicAd>> PublicListing()
        {
            return _adsService.FindPublicAds();
        }

        [HttpGet]
        public ActionResult CalculateScore()
        {
            _adsService.CalculateScores();
            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using code_review_challenge.Application;
using code_review_challenge.infrastructure.api;
using Microsoft.AspNetCore.Mvc;

namespace code_review_challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {

        private IAdsService adsService;

        public AdsController(IAdsService adsService)
        {
            this.adsService = adsService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<QualityAd>> QualityListing()
        {
            return adsService.FindQualityAds();
        }
        [HttpGet]
        public ActionResult<IEnumerable<PublicAd>> PublicListing()
        {
            return adsService.FindPublicAds();
        }

        [HttpGet]
        public ActionResult CalculateScore()
        {
            adsService.CalculateScores();
            return Ok();
        }
    }
}

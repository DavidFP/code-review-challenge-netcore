using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public ActionResult<IEnumerable<QualityAd>> qualityListing()
        {
            return adsService.findQualityAds();
        }
        [HttpGet]
        public ActionResult<IEnumerable<PublicAd>> publicListing()
        {
            return adsService.findPublicAds();
        }

        [HttpGet]
        public ActionResult calculateScore()
        {
            adsService.calculateScores();
            return Ok();
        }
    }
}

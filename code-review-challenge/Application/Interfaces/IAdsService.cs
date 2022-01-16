using CodeReviewChallenge.infrastructure.api;
using System.Collections.Generic;

namespace CodeReviewChallenge.Application
{
    public interface IAdsService
    {
        public List<PublicAd> FindPublicAds();
        public List<QualityAd> FindQualityAds();
        public void CalculateScores();
    }
}

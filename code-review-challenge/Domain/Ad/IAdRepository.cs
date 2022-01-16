using System.Collections.Generic;

namespace CodeReviewChallenge.Domain
{
    public interface IAdRepository
    {
        public IEnumerable<Ad> FindAllAds();

        public void Save(Ad ad);

        public IEnumerable<Ad> FindRelevantAds();

        public IEnumerable<Ad> FindIrrelevantAds();
    }
}

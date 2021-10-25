using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_review_challenge.Domain
{
    public interface IAdRepository
    {
        public List<Ad> findAllAds();

        public void save(Ad ad);

        public List<Ad> findRelevantAds();

        public List<Ad> findIrrelevantAds();
    }
}

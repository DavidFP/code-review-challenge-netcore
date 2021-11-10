using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_review_challenge.Domain
{
    public interface IAdRepository
    {
        public List<Ad> FindAllAds();

        public void Save(Ad ad);

        public List<Ad> FindRelevantAds();

        public List<Ad> FindIrrelevantAds();
    }
}

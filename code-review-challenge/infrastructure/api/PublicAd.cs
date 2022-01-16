using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeReviewChallenge.infrastructure.api
{
    public class PublicAd
    {

        public int Id { get; set; }
        public string Typology { get; set; }
        public string Description { get; set; }
        public List<string> PictureUrls { get; set; }
        public int HouseSize { get; set; }
        public int GardenSize { get; set; }
    }
}

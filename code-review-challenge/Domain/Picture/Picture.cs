using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeReviewChallenge.Domain
{
    public class Picture
    {
        public int Id { get; private set; }
        public string Url { get; private set; }
        public Quality Quality { get; private set; }

        public Picture(int id, string url, Quality quality)
        {
            Id = id;
            Url = url;
            Quality = quality;
        }
    }
}

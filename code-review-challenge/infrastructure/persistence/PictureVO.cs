using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_review_challenge.infrastructure.persistence
{
    public class PictureVO
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Quality { get; set; }
    }
}

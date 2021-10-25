using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_review_challenge.Domain
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




        public string toString()
        {
            return "Picture{" +
                    "id=" + Id +
                    ", url='" + Url + '\'' +
                    ", quality=" + Quality +
                    '}';
        }


        public bool equals(object o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Picture picture = (Picture)o;
            return Equals(Id, picture.Id) && Equals(Url, picture.Url) && Quality == picture.Quality;
        }



    }
}

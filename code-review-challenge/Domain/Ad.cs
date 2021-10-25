using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_review_challenge.Domain
{
    public class Ad
    {
        public int Id { get; private set; }
        public Typology Typology { get; private set; }
        public string Description { get; private set; }
        public List<Picture> Pictures { get; private set; }
        public int? HouseSize { get; private set; }
        public int? GardenSize { get; private set; }
        public int Score { get; private set; }
        public DateTime? IrrelevantSince { get; private set; }

        public Ad(int id,
              Typology typology,
              string description,
              List<Picture> pictures,
              int houseSize,
              int gardenSize,
              int score,
              DateTime? irrelevantSince)
        {
            Id = id;
            Typology = typology;
            Description = description;
            Pictures = pictures;
            HouseSize = houseSize;
            GardenSize = gardenSize;
            Score = score;
            IrrelevantSince = irrelevantSince;
        }

        public Ad(int id,
                  Typology typology,
                  string description,
                  List<Picture> pictures,
                  int? houseSize,
                  int? gardenSize)
        {
            Id = id;
            Typology = typology;
            Description = description;
            Pictures = pictures;
            HouseSize = houseSize;
            GardenSize = gardenSize;
        }

        public void SetScore(int score)
        {
            Score = score;
        }
        public void SetIrrelevantSince(DateTime? irrelevantSince)
        {
            IrrelevantSince = irrelevantSince;
        }

        public bool isComplete()
        {
            return (Typology.GARAGE.Equals(Typology) && !Pictures.Any())
                    || (Typology.FLAT.Equals(Typology) && !Pictures.Any() && Description != null && !string.IsNullOrEmpty(Description) && HouseSize != null)
                    || (Typology.CHALET.Equals(Typology) && !Pictures.Any() && Description != null && !string.IsNullOrEmpty(Description) && HouseSize != null && GardenSize != null);
        }




        public bool equals(object o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Ad ad = (Ad)o;
            return Equals(Id, ad.Id) && Typology == ad.Typology && Equals(Description, ad.Description) && Equals(Pictures, ad.Pictures) && Equals(HouseSize, ad.HouseSize) && Equals(GardenSize, ad.GardenSize) && Equals(Score, ad.Score) && Equals(IrrelevantSince, ad.IrrelevantSince);
        }



        public string toString()
        {
            return "Ad{" +
                    "id=" + Id +
                    ", typology=" + Typology +
                    ", description='" + Description + '\'' +
                    ", pictures=" + Pictures +
                    ", houseSize=" + HouseSize +
                    ", gardenSize=" + GardenSize +
                    ", score=" + Score +
                    ", irrelevantSince=" + IrrelevantSince +
                    '}';
        }
    }
}

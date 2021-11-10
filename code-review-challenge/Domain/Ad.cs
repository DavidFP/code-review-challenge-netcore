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
            return (Typology.GARAGE.Equals(Typology) && Pictures.Any())
                    || (Typology.FLAT.Equals(Typology) && Pictures.Any() &&  !string.IsNullOrEmpty(Description) && HouseSize.HasValue)
                    || (Typology.CHALET.Equals(Typology) && Pictures.Any() && !string.IsNullOrEmpty(Description) && HouseSize.HasValue && GardenSize.HasValue);
        }

        
    }
}

using CodeReviewChallenge.Domain;
using CodeReviewChallenge.infrastructure.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeReviewChallenge.Application
{
    public class AdsService : IAdsService
    {
        private readonly IAdRepository _adRepository;
        public AdsService(IAdRepository adRepository)
        {
            _adRepository = adRepository;
        }
        public List<PublicAd> FindPublicAds()
        {
            IEnumerable<Ad> ads = _adRepository.FindRelevantAds();
            IEnumerable<PublicAd> result = ads.Select(ad => new PublicAd
            {
                Id = ad.Id,
                Description = ad.Description,
                GardenSize = ad.GardenSize ?? (int)decimal.Zero,
                HouseSize = ad.HouseSize ?? (int)decimal.Zero,
                PictureUrls = ad.Pictures.Select(p => p.Url).ToList(),
                Typology = ad.Typology.ToString()
            });
            return result.ToList();
        }


        public List<QualityAd> FindQualityAds()
        {
            IEnumerable<Ad> ads = _adRepository.FindIrrelevantAds();
            IEnumerable<QualityAd> result = ads.Select(ad => new QualityAd
            {
                Id = ad.Id,
                Description = ad.Description,
                GardenSize = ad.GardenSize ?? (int)decimal.Zero,
                HouseSize = ad.HouseSize ?? (int)decimal.Zero,
                PictureUrls = ad.Pictures.Select(p => p.Url).ToList(),
                Typology = ad.Typology.ToString(),
                Score = ad.Score,
                IrrelevantSince = ad.IrrelevantSince
            });
            return result.ToList();
        }


        public void CalculateScores()
        {
            _adRepository.FindAllAds().ToList().ForEach(CalculateScore);
        }

    

        private void CalculateScore(Ad ad)
        {
            int score = Constants.ZERO;

            score += CalculateImagesIncrease(ad.Pictures);

            score += CalculateDescritionIncrease(ad.Description);
          
            if (ad.isComplete())
            {
                score = Constants.FORTY;
            }

            ad.SetScore(score);

            if (ad.Score < Constants.ZERO)
            {
                ad.SetScore(Constants.ZERO);
            }

            if (ad.Score > Constants.ONE_HUNDRED)
            {
                ad.SetScore(Constants.ONE_HUNDRED);
            }

            if (ad.Score < Constants.FORTY)
            {
                ad.SetIrrelevantSince(new DateTime());
            }
            else
            {
                ad.SetIrrelevantSince(null);
            }

            _adRepository.Save(ad);
        }

        private int CalculateImagesIncrease(List<Picture> pictures)
        {
            int score = Constants.ZERO;

            if (pictures.Any())
            {
                score -= Constants.TEN;
            }

            foreach (var picture in pictures)
            {
                if (Quality.HD.Equals(picture.Quality))
                {
                    score += Constants.TWENTY;
                }
                score += Constants.TEN;
            }
            return score;
        }

        private int CalculateDescritionIncrease(string description)
        {
            var score = Constants.ZERO;

            if (!string.IsNullOrWhiteSpace(description))
            {
                score += Constants.FIVE;

                var wordsInDescription = description.Split(" ");
                var wordsCount = wordsInDescription.Length;

                switch (ad.Typology)
                {
                    case Typology.FLAT:
                        if (wordsCount >= Constants.TWENTY && wordsCount <= Constants.FORTY_NINE)
                        {
                            score += Constants.TEN;
                        }
                        if (wordsCount >= Constants.FIFTY)
                        {
                            score += Constants.THIRTY;
                        }
                        break;
                    case Typology.CHALET:
                        if (wordsCount >= Constants.FIFTY)
                        {
                            score += Constants.TWENTY;
                        }
                        break;
                    case Typology.GARAGE:
                        break;
                }

                string[] increaseScoreWords = { "luminoso", "nuevo", "céntrico", "reformado", "ático" };

                foreach (var word in wordsInDescription)
                {
                    var increase = increaseScoreWords.Contains(word)
                                   ? Constants.FIVE
                                   : Constants.ZERO;
                    score += increase;
                }
            }
            return score;
        }
    }
}

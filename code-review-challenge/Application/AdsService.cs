﻿using code_review_challenge.Domain;
using code_review_challenge.infrastructure.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_review_challenge.Application
{
    public class AdsService: IAdsService
    {
        IAdRepository adRepository;
        public AdsService(IAdRepository adRepository)
        {
            this.adRepository = adRepository;
        }
        public List<PublicAd> findPublicAds()
        {
            List<Ad> ads = adRepository.findRelevantAds();
            List<PublicAd> result = new List<PublicAd>();
            foreach(var ad in ads.OrderBy(p=>p.Score))
            {
                PublicAd publicAd = new PublicAd();
                publicAd.Description=ad.Description;
                publicAd.GardenSize=ad.GardenSize ?? 0;
                publicAd.HouseSize=ad.HouseSize ?? 0;
                publicAd.Id=ad.Id;
                publicAd.PictureUrls = ad.Pictures.Select(p=>p.Url).ToList();
                publicAd.Typology= nameof(ad.Typology);

                result.Add(publicAd);
            }
            return result;
        }

        
        public List<QualityAd> findQualityAds()
        {
            List<Ad> ads = adRepository.findIrrelevantAds();

            List<QualityAd> result = new List<QualityAd>();
            foreach (var ad in ads)
            {
                QualityAd qualityAd = new QualityAd();
                qualityAd.Description = ad.Description;
                qualityAd.GardenSize = ad.GardenSize ?? 0;
                qualityAd.HouseSize = ad.HouseSize ?? 0;
                qualityAd.Id = ad.Id;
                qualityAd.PictureUrls = ad.Pictures.Select(p => p.Url).ToList();
                qualityAd.Typology = nameof(ad.Typology);
                qualityAd.Score = ad.Score;
                qualityAd.IrrelevantSince = ad.IrrelevantSince.Value;

                result.Add(qualityAd);
            }

            return result;
        }

        
        public void calculateScores()
        {
            adRepository.findAllAds().ForEach(calculateScore);
        }

        private void calculateScore(Ad ad)
        {
            int score = Constants.ZERO;

            //Calcular puntuación por fotos
            if (!ad.Pictures.Any())
            {
                score -= Constants.TEN; //Si no hay fotos restamos 10 puntos
            }
            else
            {
                foreach(var picture in ad.Pictures)
                {
                    if (Quality.HD.Equals(picture.Quality))
                    {
                        score += Constants.TWENTY; //Cada foto en alta definición aporta 20 puntos
                    }
                    else
                    {
                        score += Constants.TEN; //Cada foto normal aporta 10 puntos
                    }
                }
            }

            //Calcular puntuación por descripción
            var description = ad.Description;

            if (description != null)
            {
                if (string.IsNullOrWhiteSpace(description))
                {
                    score += Constants.FIVE;
                }

                var wds = description.Split(" "); //número de palabras
                if (Typology.FLAT.Equals(ad.Typology))
                {
                    if (wds.Length >= Constants.TWENTY && wds.Length <= Constants.FORTY_NINE)
                    {
                        score += Constants.TEN;
                    }

                    if (wds.Length >= Constants.FIFTY)
                    {
                        score += Constants.THIRTY;
                    }
                }

                if (Typology.CHALET.Equals(ad.Typology))
                {
                    if (wds.Length >= Constants.FIFTY)
                    {
                        score += Constants.TWENTY;
                    }
                }

                if (wds.Contains("luminoso")) score += Constants.FIVE;
                if (wds.Contains("nuevo")) score += Constants.FIVE;
                if (wds.Contains("céntrico")) score += Constants.FIVE;
                if (wds.Contains("reformado")) score += Constants.FIVE;
                if (wds.Contains("ático")) score += Constants.FIVE;
            }

            //Calcular puntuación por completitud
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

            adRepository.save(ad);
        }
    }
}

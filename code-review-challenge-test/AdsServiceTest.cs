using CodeReviewChallenge.Application;
using CodeReviewChallenge.Domain;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodeReviewChallenge_test
{
    public class AdsServiceTest
    {
        private Mock<IAdRepository>adRepository;
        private IAdsService addService;

        [SetUp]
        public void Setup()
        {
            adRepository = new Mock<IAdRepository>();
            addService = new AdsService(adRepository.Object);
        }

        [Test]
        public void CalculateScoresTest()
        {
            adRepository.Setup(t => t.FindAllAds()).Returns(new List<Ad> { IrrelevantAd(), RelevantAd(), RelevantAd2()});

            addService.CalculateScores();
            adRepository.Verify(t => t.FindAllAds(), Times.Once);
            adRepository.Verify(t => t.Save(It.IsAny<Ad>()), Times.Exactly(3));
        }

        [Test]
        public void ListPublicAds() {
            adRepository.Setup(t => t.FindRelevantAds()).Returns(new List<Ad> { RelevantAd() });

            addService.FindPublicAds();
            adRepository.Verify(t => t.FindRelevantAds(), Times.Once);
        }

        [Test]
        public void ListQualityAds()
        {
            adRepository.Setup(t => t.FindIrrelevantAds()).Returns(new List<Ad> { IrrelevantAd(), IrrelevantAd2() });

            addService.FindQualityAds();
            adRepository.Verify(t => t.FindIrrelevantAds(), Times.Exactly(1));
        }

        private Ad RelevantAd()
        {
            return new Ad(1,
                    Typology.FLAT,
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras dictum felis elit, vitae cursus erat blandit vitae. Maecenas eget efficitur massa. Maecenas ut dolor eget enim consequat iaculis vitae nec elit. Maecenas eu urna nec massa feugiat pharetra. Sed eu quam imperdiet orci lobortis fermentum. Sed odio justo, congue eget iaculis.",
                    new List<Picture> { new Picture(1, "http://urldeprueba.com/1", Quality.HD), new Picture(2, "http://urldeprueba.com/2", Quality.HD) },
                    50,
                    null);
        }

        private Ad RelevantAd2()
        {
            return new Ad(1,
                    Typology.FLAT,
                    "Luminoso ipsum ático sit amet, consectetur adipiscing elit. Cras dictum felis elit, vitae cursus erat blandit vitae. Maecenas eget efficitur massa. Maecenas ut dolor eget enim consequat iaculis vitae nec elit. Maecenas eu urna nec massa feugiat pharetra. Sed eu quam imperdiet orci lobortis fermentum. Sed odio justo, congue eget iaculis.",
                    new List<Picture> { new Picture(1, "http://urldeprueba.com/1", Quality.HD), new Picture(2, "http://urldeprueba.com/2", Quality.HD) },
                    50,
                    null);
        }

        private Ad IrrelevantAd()
        {
            return new Ad(1,Typology.FLAT,string.Empty,new List<Picture> { } ,100,null);
        }
        private Ad IrrelevantAd2()
        {
            return new Ad(1, Typology.CHALET, string.Empty, new List<Picture> { }, 100, null);
        }
    }
}
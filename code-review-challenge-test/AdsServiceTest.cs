using code_review_challenge.Application;
using code_review_challenge.Controllers;
using code_review_challenge.Domain;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace code_review_challenge_test
{
    public class AdsServiceTest
    {
        private Mock<IAdRepository> adRepository;
        private IAdsService scoreService;

        [SetUp]
        public void Setup()
        {
            adRepository = new Mock<IAdRepository>();
            scoreService = new AdsService(adRepository.Object);
        }

        [Test]
        public void calculateScoresTest()
        {
            adRepository.Setup(t => t.findAllAds()).Returns(new List<Ad> { irrelevantAd(), relevantAd() });

            scoreService.calculateScores();
            adRepository.Verify(t=>t.findAllAds(), Times.Once);
            adRepository.Verify(t => t.save(It.IsAny<Ad>()), Times.Exactly(2));            
        }

        private Ad relevantAd()
        {
            return new Ad(1,
                    Typology.FLAT,
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras dictum felis elit, vitae cursus erat blandit vitae. Maecenas eget efficitur massa. Maecenas ut dolor eget enim consequat iaculis vitae nec elit. Maecenas eu urna nec massa feugiat pharetra. Sed eu quam imperdiet orci lobortis fermentum. Sed odio justo, congue eget iaculis.",
                    new List<Picture> { new Picture(1, "http://urldeprueba.com/1", Quality.HD), new Picture(2, "http://urldeprueba.com/2", Quality.HD) },
                    50,
                    null);
        }

        private Ad irrelevantAd()
        {
            return new Ad(1,
                    Typology.FLAT,
                    "",
                    new List<Picture> { },
                    100,
                    null);
        }
    }
}
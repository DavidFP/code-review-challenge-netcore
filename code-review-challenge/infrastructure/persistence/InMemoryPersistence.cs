using System.Collections.Generic;

namespace CodeReviewChallenge.infrastructure.persistence
{
    public class InMemoryPersistence
    {
        private ICollection<AdVo> ads;
        private ICollection<PictureVo> pictures;

        public InMemoryPersistence()
        {
            ads = new List<AdVo>
            {
                new AdVo { Typology = "CHALET", Description = "Este piso es una ganga, compra, compra, COMPRA!!!!!", Pictures = new List<int>(), HouseSize = 300 },
                new AdVo { Typology = "FLAT", Description = "Nuevo ático céntrico recién reformado. No deje pasar la oportunidad y adquiera este ático de lujo", Pictures = new List<int> { 4 }, HouseSize = 300 },
                new AdVo { Typology = "CHALET", Description = "", Pictures = new List<int> { 2 }, HouseSize = 300 },
                new AdVo { Typology = "FLAT", Description = "Ático céntrico muy luminoso y recién reformado, parece nuevo", Pictures = new List<int> { 5 }, HouseSize = 300 },
                new AdVo { Typology = "FLAT", Description = "Pisazo,", Pictures = new List<int> { 3, 8 }, HouseSize = 300 },
                new AdVo { Typology = "GARAGE", Description = string.Empty , Pictures = new List<int> { 6 }, HouseSize = 300 },
                new AdVo { Typology = "GARAGE", Description = "Garaje en el centro de Albacete", Pictures = new List<int>(), HouseSize = 300 },
                new AdVo { Typology = "CHALET", Description = "Maravilloso chalet situado en lAs afueras de un pequeño pueblo rural. El entorno es espectacular, las vistas magníficas. ¡Cómprelo ahora!", Pictures = new List<int> { 1, 7 }, HouseSize = 300 }
            };

            pictures = new List<PictureVo>
            {
                new PictureVo { Url = "http://www.idealista.com/pictures/1", Quality = "SD" },
                new PictureVo { Url = "http://www.idealista.com/pictures/2", Quality = "HD" },
                new PictureVo { Url = "http://www.idealista.com/pictures/3", Quality = "SD" },
                new PictureVo { Url = "http://www.idealista.com/pictures/4", Quality = "HD" },
                new PictureVo { Url = "http://www.idealista.com/pictures/5", Quality = "SD" },
                new PictureVo { Url = "http://www.idealista.com/pictures/6", Quality = "SD" },
                new PictureVo { Url = "http://www.idealista.com/pictures/7", Quality = "SD" },
                new PictureVo { Url = "http://www.idealista.com/pictures/8", Quality = "HD" }
            };
        }
    }
}

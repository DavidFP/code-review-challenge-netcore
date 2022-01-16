using System.ComponentModel;

namespace CodeReviewChallenge.Domain
{
    public enum Typology
    {
        [Description("Piso")]
        FLAT = 0,
        [Description("Chalet")]
        CHALET = 1,
        [Description("Garaje")]
        GARAGE = 2,
    }
}

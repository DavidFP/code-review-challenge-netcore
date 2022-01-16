using System.ComponentModel;

namespace CodeReviewChallenge.Domain
{
    public enum Quality
    {
        [Description("Alta definición")]
        HD = 0,
        [Description("Baja Definición")]
        SD = 1
    }
}

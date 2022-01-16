using CodeReviewChallenge.Infrastructure.persistence.ValueObject;
using System;

namespace CodeReviewChallenge.infrastructure.persistence
{
    public class PictureVo : ValueObject<PictureVo>
    {
        public string Url { get; set; }
        public string Quality { get; set; }

        protected override bool EqualsCore(PictureVo other)
        {
            var isEquals = Url.Equals(other.Url, StringComparison.InvariantCultureIgnoreCase) &&
                         Quality.Equals(other.Quality, StringComparison.InvariantCultureIgnoreCase);
            return isEquals;
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}

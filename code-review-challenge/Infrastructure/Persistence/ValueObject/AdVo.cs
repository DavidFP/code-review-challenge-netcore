using CodeReviewChallenge.Infrastructure.persistence.ValueObject;
using System;
using System.Collections.Generic;

namespace CodeReviewChallenge.infrastructure.persistence
{
    public class AdVo : ValueObject<AdVo>
    {
        public string Typology { get; set; }
        public string Description { get; set; }
        public IList<int> Pictures { get; set; }
        public int? HouseSize { get; set; }
        public int? GardenSize { get; set; }
        public int? Score { get; set; }
        public DateTime? IrrelevantSince { get; set; }

        protected override bool EqualsCore(AdVo other)
        {
            var isEquals = this.Typology.Equals(other.Typology, StringComparison.InvariantCultureIgnoreCase) &&
                           this.Description.Equals(other.Description, StringComparison.InvariantCultureIgnoreCase) &&
                           this.HouseSize.Equals(other.HouseSize) &&
                           this.GardenSize.Equals(other.GardenSize);
            return isEquals;
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}

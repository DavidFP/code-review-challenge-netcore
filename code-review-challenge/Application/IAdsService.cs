using code_review_challenge.infrastructure.api;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
public interface IAdsService
{

	public List<PublicAd> FindPublicAds();
	public List<QualityAd> FindQualityAds();
	public void CalculateScores();

}

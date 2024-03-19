using CustomerClaims.Models;

namespace CustomerClaims.Data;

/// <summary>
/// Random ClaimType Test Data
/// </summary>
public class ClaimTypeTestData
{
    public static List<ClaimType> GetTestClaimTypes()
    {
        var claimTypes = new List<ClaimType>
        {
            new ClaimType { Id = 1, Name = "Employer's Liability " },
            new ClaimType { Id = 2, Name = "Public Liability" },
            new ClaimType { Id = 3, Name = "Trustee Indemnity" }
        };

        return claimTypes;
    }
}

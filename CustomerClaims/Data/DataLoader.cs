using CustomerClaims.Models;

namespace CustomerClaims.Data;

public class DataLoader
{
    private readonly List<Claim> _testClaims;
    private readonly List<ClaimType> _testClaimTypes;
    private readonly List<Company> _testCompanies;

    public DataLoader()
    {
        _testClaims = new List<Claim>();
        _testClaimTypes = new List<ClaimType>();
        _testCompanies = new List<Company>();
    }

    public void LoadData()
    {
        // Load test claim data
        _testClaims.AddRange(ClaimTestData.GetTestClaims());

        // Load test claim type data
        _testClaimTypes.AddRange(ClaimTypeTestData.GetTestClaimTypes());

        // Load test company data
        _testCompanies.AddRange(CompanyTestData.GetTestCompanies());
    }

    public List<Claim> GetTestClaims()
    {
        return _testClaims;
    }
    public List<ClaimType> GetTestClaimTypes()
    {
        return _testClaimTypes;
    }

    public List<Company> GetTestCompanies()
    {
        return _testCompanies;
    }
}

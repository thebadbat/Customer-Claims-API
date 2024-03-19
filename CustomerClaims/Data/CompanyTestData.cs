using CustomerClaims.Models;

namespace CustomerClaims.Data;

/// <summary>
/// Random Company Test Data
/// </summary>
public class CompanyTestData
{
    public static List<Company> GetTestCompanies()
    {
        var companies = new List<Company>
        {
            new() {
                Id = 1,
                Name = "ABC Alarms Ltd",
                Address1 = "10 Downing Street",
                Address2 = "Westminster",
                Postcode = "SW1A 2AA",
                Country = "United Kingdom",
                Active = true,
                InsuranceEndDate = DateTime.UtcNow.AddYears(1) // Active insurance for 1 year
            },
            new() {
                Id = 2,
                Name = "XYZ Motor Ltd",
                Address1 = "20 Grosvenor Square",
                Address2 = "Mayfair",
                Postcode = "W1K 2HB",
                Country = "United Kingdom",
                Active = false,
                InsuranceEndDate = DateTime.UtcNow.AddDays(-10) // Expired insurance
            },
            new()
            {
                Id = 3,
                Name = "Investment Group",
                Address1 = "30 The Broadway",
                Address2 = "Ealing",
                Postcode = "W5 2NP",
                Country = "United Kingdom",
                Active = true,
                InsuranceEndDate = DateTime.UtcNow.AddMonths(6) // Active insurance for 6 months
            },
            new()
            {
                Id = 4,
                Name = "Global Steel Group",
                Address1 = "40 St. James's Square",
                Address2 = "St. James's",
                Postcode = "SW1Y 4JU",
                Country = "United Kingdom",
                Active = true,
                InsuranceEndDate = DateTime.UtcNow.AddYears(2) // Active insurance for 2 years
            }
        };

        return companies;
    }
}


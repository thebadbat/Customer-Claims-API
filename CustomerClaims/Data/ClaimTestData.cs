using CustomerClaims.Models;

namespace CustomerClaims.Data;

/// <summary>
/// Random Claims Test Data
/// </summary>
public class ClaimTestData
{
    public static List<Claim> GetTestClaims()  {
        var claims = new List<Claim>
        {
            new ()
            {
                UCR = new Guid("1e685d87-76a0-4c16-b687-4b6750a7c89a"),
                CompanyId = 1,
                ClaimDate = DateTime.UtcNow.AddMonths(-6),
                LossDate = DateTime.UtcNow.AddMonths(-7),
                AssuredName = "John Doe",
                IncurredLoss = 5000.00m,
                Closed = false,
                ClaimTypeId = 1
            },
            new ()
            {
                UCR = new Guid("2a4b6c0d-8e2f-4172-9a23-3f0e0f1d2e4b"),
                CompanyId = 2,
                ClaimDate = DateTime.UtcNow.AddMonths(-3),
                LossDate = DateTime.UtcNow.AddMonths(-4),
                AssuredName = "Jane Smith",
                IncurredLoss = 8000.00m,
                Closed = false,
                ClaimTypeId = 3
            },
            new ()
            {
                UCR = new Guid("3b593a24-9c7d-45fb-896e-5dc8f2fc3b80"),
                CompanyId = 3,
                ClaimDate = DateTime.UtcNow.AddMonths(-2),
                LossDate = DateTime.UtcNow.AddMonths(-3),
                AssuredName = "Alice Johnson",
                IncurredLoss = 3000.00m,
                Closed = true,
                ClaimTypeId = 1
            },
            new ()
            {
                UCR = new Guid("4c02f10e-3c63-4e8e-8497-3dd6f1c2a8d1"),
                CompanyId = 4,
                ClaimDate = DateTime.UtcNow.AddMonths(-10),
                LossDate = DateTime.UtcNow.AddMonths(-11),
                AssuredName = "Bob Brown",
                IncurredLoss = 7000.00m,
                Closed = false,
                ClaimTypeId = 1
            },
            new ()
            {
                UCR = new Guid("5dfe13ab-9a45-4f71-8ae3-6c8922de1f45"),
                CompanyId = 1,
                ClaimDate = DateTime.UtcNow.AddMonths(-4),
                LossDate = DateTime.UtcNow.AddMonths(-5),
                AssuredName = "Emma Wilson",
                IncurredLoss = 6000.00m,
                Closed = false,
                ClaimTypeId = 1
            },
            new ()
            {
                UCR = new Guid("6e811f4b-708c-47dc-b012-977f6fc4b4c8"),
                CompanyId = 2,
                ClaimDate = DateTime.UtcNow.AddMonths(-8),
                LossDate = DateTime.UtcNow.AddMonths(-9),
                AssuredName = "David Lee",
                IncurredLoss = 4000.00m,
                Closed = true,
                ClaimTypeId = 3
            },
            new ()
            {
                UCR = new Guid("7f902a51-d95f-46f4-8322-c92e54137293"),
                CompanyId = 3,
                ClaimDate = DateTime.UtcNow.AddMonths(-7),
                LossDate = DateTime.UtcNow.AddMonths(-8),
                AssuredName = "Sophia Clark",
                IncurredLoss = 5500.00m,
                Closed = false,
                ClaimTypeId = 2
            },
            new ()
            {
                UCR = new Guid("8a401e26-791a-489c-aa05-9d2890b1e5a8"),
                CompanyId = 4,
                ClaimDate = DateTime.UtcNow.AddMonths(-5),
                LossDate = DateTime.UtcNow.AddMonths(-6),
                AssuredName = "James White",
                IncurredLoss = 9000.00m,
                Closed = false,
                ClaimTypeId = 1
            },
            new ()
            {
                UCR = new Guid("9b871c17-6e92-42a1-b3d7-8d4ae5b5a6ef"),
                CompanyId = 1,
                ClaimDate = DateTime.UtcNow.AddMonths(-9),
                LossDate = DateTime.UtcNow.AddMonths(-10),
                AssuredName = "Olivia Green",
                IncurredLoss = 3500.00m,
                Closed = true,
                ClaimTypeId = 2
            },
            new ()
            {
                UCR = new Guid("10c650b9-2fb1-4d9f-bc2b-ec5ee82c4fcf"),
                CompanyId = 2,
                ClaimDate = DateTime.UtcNow.AddMonths(-11),
                LossDate = DateTime.UtcNow.AddMonths(-12),
                AssuredName = "William Davis",
                IncurredLoss = 6200.00m,
                Closed = false,
                ClaimTypeId = 1
            }
        };

        return claims;
    }
}
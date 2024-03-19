using CustomerClaims.Data;
using System.ComponentModel.DataAnnotations;

namespace CustomerClaims.Models;

public class Claim
{
    [Required]
    public Guid UCR { get; set; }

    [Required]
    public int? CompanyId { get; set; }

    [Required]
    public int? ClaimTypeId { get; set; }

    [Required]
    public DateTime? ClaimDate { get; set; }

    [Required]
    public DateTime? LossDate { get; set; }

    [Required]
    [StringLength(100)] // Adjust the length as needed
    public string AssuredName { get; set; }

    [Required]
    [Range(0, double.MaxValue)] // Assuming IncurredLoss cannot be negative
    public decimal IncurredLoss { get; set; }

    [Required]
    public bool Closed { get; set; }

    // Getter-only property to retrieve the claim type name
    public string ClaimTypeName
    {
        get
        {
            // Retrieve test claim types
            var claimTypes = ClaimTypeTestData.GetTestClaimTypes();

            // Find the claim type name based on ClaimTypeId
            foreach (var claimType in claimTypes)
            {
                if (claimType.Id == ClaimTypeId)
                {
                    return claimType.Name;
                }
            }

            // Return "Unknown" if claim type is not found
            return "Unknown";
        }
    }

    // Method to calculate the age of the claim in days
    public int GetClaimAgeInDays()
    {
        if (ClaimDate == null)
        {
            // Handle the case when ClaimDate is null (return 0, throw an exception, etc.)
            // For example:
            throw new InvalidOperationException("ClaimDate cannot be null.");
        }

        TimeSpan age = DateTime.UtcNow - ClaimDate.Value;
        return age.Days;
    }
}

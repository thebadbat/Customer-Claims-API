using CustomerClaims.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerClaims.Controllers;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    // Simulated test data
    private readonly DataLoader _dataLoader;

    public CompanyController(DataLoader dataLoader)
    {
        _dataLoader = dataLoader;
    }

    /// <summary>
    /// Endpoint that returns the status of an insurance policy
    /// </summary>
    /// <param name="companyId"></param>
    /// <returns></returns>

    [HttpGet("InsurancePolicyStatus/{companyId}")]
    public IActionResult GetCompanyInsurancePolicyStatus(int? companyId)
    {
        try
        {
            if (!companyId.HasValue)
            {
                return new BadRequestObjectResult("Company ID is required.");
            }

            // Simulated data retrieval using test date.
            // This logic retrieves claims for the specified company from the DataLoader.
            // In a production environment, this could be replaced with fetching data from a live database 
            // using Entity Framework or Stored Procedures for more dynamic and real-time data retrieval.
            var company = _dataLoader.GetTestCompanies().FirstOrDefault(c => c.Id == companyId);
            if (company == null)
            {
                return NotFound("No company found.");
            }


            // Determine if the company has an active insurance policy using the method from the Company class
            var hasActiveInsurance = company.HasActiveInsurancePolicy();

            // Return the company information along with the insurance policy status could have removed company information
            return Ok(new { Company = company, HasActiveInsurance = hasActiveInsurance });
        }
        catch (Exception ex)
        {
            // Log the exception, generally this would be recorded.
            Console.WriteLine($"An error occurred: {ex.Message}");

            // Return a 500 Internal Server Error response
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
        }
    }

}
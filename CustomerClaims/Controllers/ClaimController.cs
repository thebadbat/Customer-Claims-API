using CustomerClaims.Data;
using CustomerClaims.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CustomerClaims.Controllers;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ClaimController : ControllerBase {

    // Simulated test data
    private readonly DataLoader _dataLoader;

    public ClaimController(DataLoader dataLoader)
    {
        _dataLoader = dataLoader;
    }

    /// <summary>
    /// Endpoint that will give a list of claims for a company
    /// </summary>
    /// <param name="companyId"></param>
    /// <returns></returns>
    [HttpGet("Claims/{companyId}")]
    public IActionResult GetCompanyClaims(int? companyId)
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

            var companyClaims = _dataLoader.GetTestClaims().Where(c => c.CompanyId == companyId.Value).ToList();

            if (companyClaims.Count == 0)
            {
                return NotFound("No claims found for the specified company.");
            }

            // Serialize the data to JSON format
            var json = JsonSerializer.Serialize(companyClaims);

            // Set the content type header to indicate JSON format
            var response = new ContentResult
            {
                Content = json,
                ContentType = "application/json",
                StatusCode = StatusCodes.Status200OK
            };

            return response;

        }
        catch (Exception ex)
        {
            // Log the exception, generally this would be recorded.
            Console.WriteLine($"An error occurred: {ex.Message}");

            // Return a 500 Internal Server Error response
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
        }
    }

    
    /// <summary>
    /// Endpoint to get the age of a claim
    /// </summary>
    /// <param name="ucr"></param>
    /// <returns></returns>
    [HttpGet("AgeOfClaim/{ucr}")]
    public IActionResult GetClaimAge(Guid ucr)
    {
        try
        {
            if (ucr == Guid.Empty)
            {
                return new BadRequestObjectResult("Claim UCR is required.");
            }

            // Simulated data retrieval using test date.
            // Retrieve claim by UCR from DataLoader
            // This logic retrieves claims for the specified company from the DataLoader.
            // In a production environment, this could be replaced with fetching data from a live database 
            // using Entity Framework or Stored Procedures for more dynamic and real-time data retrieval.
            var claim = _dataLoader.GetTestClaims().FirstOrDefault(c => c.UCR == ucr);

            if (claim == null)
            {
                return NotFound("Claim not found.");
            }

            // Calculate claim age in days using the GetClaimAgeInDays method
            var claimAgeInDays = claim.GetClaimAgeInDays();

            // returned claim info, could be remove if not required
            return Ok(new { claim, ClaimAgeInDays = claimAgeInDays });
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"An error occurred: {ex.Message}");

            // Return a 500 Internal Server Error response
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
        }
    }


    /// <summary>
    /// Endpoint to update an existing claim
    /// </summary>
    /// <param name="updatedClaim"></param>
    /// <returns></returns>
    [HttpPut("Update")]
    public IActionResult UpdateClaim([FromBody][Bind("UCR,CompanyId,ClaimTypeId,ClaimDate,LossDate,AssuredName,IncurredLoss,Closed")] Claim updatedClaim)
    {
        /* 
        * This section could benefit from additional validation logic. Currently, there is no explicit validation for properties like CompanyId, ClaimTypeId etc. 
        * Given more time I would consider implementing a validation mechanism, such as custom validation attributes or an ActionFilterAttribute, to ensure data integrity and improve error handling.

        * Without any validation as long has you provide a valid UCR you can set CompanyId/ClaimTypeId to any integer value
        */

        try
        {
            if (updatedClaim == null)
            {
                return BadRequest("Invalid claim data.");
            }

            // Find the claim to update
            var existingClaim = _dataLoader.GetTestClaims().FirstOrDefault(c => c.UCR == updatedClaim.UCR);
            if (existingClaim == null)
            {
                return NotFound("Claim not found.");
            }

            // Update claim properties
            existingClaim.CompanyId = updatedClaim.CompanyId;
            existingClaim.ClaimTypeId = updatedClaim.ClaimTypeId;
            existingClaim.ClaimDate = updatedClaim.ClaimDate;
            existingClaim.LossDate = updatedClaim.LossDate;
            existingClaim.AssuredName = updatedClaim.AssuredName;
            existingClaim.IncurredLoss = updatedClaim.IncurredLoss;
            existingClaim.Closed = updatedClaim.Closed;

            // Save changes for example, if using Entity Framework Core, you would call DbContext.SaveChanges()

            // Return the updated claim
            return Ok(existingClaim);
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"An error occurred: {ex.Message}");

            // Return a 500 Internal Server Error response
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
        }
    }

}
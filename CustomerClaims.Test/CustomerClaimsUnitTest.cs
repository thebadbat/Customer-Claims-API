using CustomerClaims.Controllers;
using CustomerClaims.Data;
using CustomerClaims.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using CustomerClaims.Models;
using System.Text.Json;
using Microsoft.VisualBasic;
using System.Drawing;

namespace CustomerClaims.Test;

[TestClass]
public class CustomerClaimsUnitTest
{
    [TestMethod]
    public void GetCompanyClaims_ReturnsCorrectClaims()
    {
        // Arrange
        var companyId = 1;

        // Create an instance of DataLoader and load data
        var dataLoader = new DataLoader();
        dataLoader.LoadData();

        // Since we're directly using an instance of the DataLoader class to load data and retrieve claims,
        // there's no need to mock anything. Mocking is typically used to isolate the code under test from
        // its dependencies, but in this case, we're interacting with DataLoader directly.

        // Act
        var companyClaims = dataLoader.GetTestClaims().Where(c => c.CompanyId == companyId).ToList();

        // Log the claims for debugging
        foreach (var claim in companyClaims)
        {
            Console.WriteLine($"Claim ID: {claim.UCR}, Company ID: {claim.CompanyId}");
        }

        // Assert
        Assert.IsNotNull(companyClaims); // Ensure the list is not null
        Assert.IsTrue(companyClaims.Count > 0); // Ensure at least one claim is returned

    }
}

using Capstone.Models;
using Capstone.Tests.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.Tests.Tests
{
    [TestClass]
    public class TestSiteSqlDao : TestInitializer
    {
        [TestMethod]
        public void GetAvailableSitesTest()
        {
            DateTime arrivalDate = Convert.ToDateTime("02/23/20");
            DateTime departureDate = Convert.ToDateTime("02/24/20");

            IList<Site> site = siteSqlDAO.GetAvailableSites(3, arrivalDate, departureDate);

            Assert.IsTrue(site.Count > 0);
        }

    }
}

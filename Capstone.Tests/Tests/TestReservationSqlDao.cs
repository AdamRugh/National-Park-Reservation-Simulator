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
    public class TestReservationSqlDao : TestInitializer
    {
        [TestMethod]
        public void AddReservationTest()
        {
            DateTime arrivalDate = Convert.ToDateTime("02/23/20");
            DateTime departureDate = Convert.ToDateTime("02/24/20");

            Assert.IsTrue(reservationSqlDAO.AddReservation(1, "Adams Family", arrivalDate, departureDate) > 0);
        }


    }
}

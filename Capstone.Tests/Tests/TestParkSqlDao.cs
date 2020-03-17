using Capstone.Models;
using Capstone.Tests.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]
    public class TestParkSqlDao : TestInitializer
    {
        [TestMethod]
        public void GetParksTest()
        {
            IList<Park> park = parkSqlDao.GetParks();                           

            Assert.IsTrue(park.Count > 0);
        }
        
    }
}

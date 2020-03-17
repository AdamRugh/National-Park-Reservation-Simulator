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
    public class TestCampgroundSqlDao : TestInitializer
    {
        [TestMethod]

        public void GetCampgroundsTest()
        {
            
            IList<Campground> campgrounds = campgroundSqlDao.GetCampgrounds(1);               

            
            Assert.IsTrue(campgrounds.Count > 0);
        }
    }
}

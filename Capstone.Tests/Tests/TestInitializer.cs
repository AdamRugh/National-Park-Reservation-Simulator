using Capstone.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;

namespace Capstone.Tests.Tests
{
    [TestClass]
    public class TestInitializer
    {
        protected TransactionScope transaction;
        protected ParkSqlDAO parkSqlDao;
        protected CampgroundSqlDAO campgroundSqlDao;
        protected SiteSqlDAO siteSqlDAO;
        protected ReservationSqlDAO reservationSqlDAO;

        protected string ConnectionString
        {
            get
            {
                return "Server=.\\SQLEXPRESS;Database=npcampground;Trusted_Connection=True;";
            }
        }

        protected const string name = "North Hills";
        protected const string location = "Ross";
        protected const string establish_date = "01/01/01";
        protected const int area = 1000;
        protected const int visitors = 22000;
        protected const string discription = "Lots of hills! Merica!";
        protected const string nameCampground = "Mcknight";
        protected const int open_from_mm = 1;
        protected const int open_to_mm = 12;
        protected const decimal daily_fee = 45.00M;
                       

        [TestInitialize]

        public void Setup()
        {
            transaction = new TransactionScope();
            parkSqlDao = new ParkSqlDAO(ConnectionString);
            campgroundSqlDao = new CampgroundSqlDAO(ConnectionString);
            siteSqlDAO = new SiteSqlDAO(ConnectionString);
            reservationSqlDAO = new ReservationSqlDAO(ConnectionString);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmdPark = new SqlCommand($"select count(*) from park where name = '{name}'", connection);
                SqlCommand cmdCampground = new SqlCommand($"select count(*) from campground where park_id in (select park_id from park where name = '{name}')", connection);
                SqlCommand cmdSite = new SqlCommand($"select count(*) from site where campground_id in (select campground_id from campground where name = '{nameCampground}')", connection);

                if (Convert.ToInt32(cmdPark.ExecuteScalar()) == 0)
                {
                    cmdPark = new SqlCommand($"insert into park values('{name}', '{location}', '{establish_date}', {area}, {visitors}, '{discription}')", connection);
                    cmdPark.ExecuteNonQuery();
                }
                
                if (Convert.ToInt32(cmdCampground.ExecuteScalar()) == 0)
                {
                    cmdCampground = new SqlCommand($" insert into campground (park_id, name, open_from_mm, open_to_mm, daily_fee) values((select park_id from park where name = '{name}'), '{nameCampground}', {open_from_mm}, {open_to_mm}, {daily_fee})", connection);
                    cmdCampground.ExecuteNonQuery();
                }

                if (Convert.ToInt32(cmdSite.ExecuteScalar()) == 0)
                {
                    cmdSite = new SqlCommand($" insert into site (campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities) values((select campground_id from campground where name = '{nameCampground}'), 13, 6, 0, 0, 1)", connection);
                    cmdSite.ExecuteNonQuery();
                }

            }

        }
        
        [TestCleanup]
        public void Cleanup()
        {
            transaction.Dispose();
        }

    }
}

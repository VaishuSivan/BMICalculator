using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BMI.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("BmiDBConnectionString")
        {

        }
        public DbSet<ShopModel> shopTables { get; set; }
       
    }
}
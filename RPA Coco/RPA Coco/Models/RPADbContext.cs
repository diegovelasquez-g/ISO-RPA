using Microsoft.IdentityModel.Protocols;
using RPA_Coco.RPA_Process;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RPA_Coco.Models
{
    class RPADbContext : DbContext
    {
        public RPADbContext() : base(GetConnectionString())
        {

        }
        public static string GetConnectionString()
        {
            Helper hp = new Helper();
            string con = hp.Desencriptar(ConfigurationManager.ConnectionStrings["RPAConnection"].ConnectionString);
            return con;
        }
        public DbSet<Variables> Variables { get; set; }
        public DbSet<Process> Process { get; set; }
        public DbSet<LogsType> LogsType { get; set; }
        public DbSet<Logs> Logs { get; set; }

    }
}


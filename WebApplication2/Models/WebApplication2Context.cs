using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class WebApplication2Context : DbContext
    {
        public virtual DbSet<Drugs> Drugs { get; set; }
    }
}
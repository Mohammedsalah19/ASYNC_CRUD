using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASYNC_CRUD.Models.DAL
{
    public class MyDB:DbContext
    {

        public DbSet<Employee> EMP { get; set; }

    }
}
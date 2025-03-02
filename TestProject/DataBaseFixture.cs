using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;

namespace TestProject
{
    public class DataBaseFixture
    {
       public ManagerDbContext Context { get; private set; }
        public DataBaseFixture()
        {
            var options = new DbContextOptionsBuilder<ManagerDbContext>()
                .UseSqlServer("Server=SRV2\\PUPILS;Database=ManagerDB;Trusted_Connection=True;")
                .Options;
            Context = new ManagerDbContext(options);
            Context.Database.EnsureCreated();
        }
        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}

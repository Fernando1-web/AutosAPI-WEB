using Autos.API.Models.EN;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Autos.API.Models.DAL
{
    public class AutosDBContext : DbContext
    {
        public AutosDBContext(DbContextOptions<AutosDBContext> options) : base(options)
        {

        }

        public DbSet<Auto> Autos { get; set; }
    }
}

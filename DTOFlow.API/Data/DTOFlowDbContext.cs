using DTOFlow.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DTOFlow.API.Data
{
    public class DTOFlowDbContext : DbContext
    {
        public DTOFlowDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}

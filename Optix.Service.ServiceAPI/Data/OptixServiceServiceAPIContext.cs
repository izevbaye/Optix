using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Optix.Database.DbContext.Tables;

namespace Optix.Service.ServiceAPI.Data
{
    public class OptixServiceServiceAPIContext : DbContext
    {
        public OptixServiceServiceAPIContext (DbContextOptions<OptixServiceServiceAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Optix.Database.DbContext.Tables.Tbl_Movies> Tbl_Movies { get; set; } = default!;
    }
}

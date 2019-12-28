using Microsoft.EntityFrameworkCore;

namespace allmymoney.cashspend.Models
{
    public  class CashSpendContext: DbContext
    {
        public CashSpendContext(DbContextOptions options):
            base(options)
        {
        }
        public DbSet<CashSpendEntry> CashSpendEntries { get; set; }
    }
}
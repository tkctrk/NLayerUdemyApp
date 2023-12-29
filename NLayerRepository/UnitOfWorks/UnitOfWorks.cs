using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerRepository.UnitOfWorks
{
    public class UnitOfWorks : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWorks(AppDbContext context)
        {
            _context = context;
        }

        public async Task ComitAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Commit()
        {
           _context.SaveChanges();
        }
    }
}

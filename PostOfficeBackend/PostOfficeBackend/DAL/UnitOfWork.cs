using PostOfficeBackend.DAL.IRepositories;
using PostOfficeBackend.DAL.Repositories;
using PostOfficeBackend.Models;
using System.Threading.Tasks;

namespace PostOfficeBackend.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public IRepository<Parcel> Parcels { get; }
        public IRepository<ParcelLocker> ParcelLockers { get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Parcels = new Repository<Parcel>(_context);
            ParcelLockers = new Repository<ParcelLocker>(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

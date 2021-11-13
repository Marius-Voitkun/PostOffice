using PostOfficeBackend.DAL.IRepositories;
using PostOfficeBackend.Models;
using System.Threading.Tasks;

namespace PostOfficeBackend.DAL
{
    public interface IUnitOfWork
    {
        IRepository<Parcel> Parcels { get; }
        IRepository<ParcelLocker> ParcelLockers { get; }

        Task<int> SaveAsync();
    }
}

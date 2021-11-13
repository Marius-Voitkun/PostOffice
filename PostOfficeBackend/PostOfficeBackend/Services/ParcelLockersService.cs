using PostOfficeBackend.DAL;
using PostOfficeBackend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostOfficeBackend.Services
{
    public class ParcelLockersService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ParcelLockersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ParcelLocker>> GetAllAsync()
        {
            return await _unitOfWork.ParcelLockers.GetAllAsync(null, q => q.OrderBy(pl => pl.Code));
        }

        public async Task<ParcelLocker> GetAsync(int id)
        {
            return await _unitOfWork.ParcelLockers.GetAsync(id);
        }

        public async Task AddAsync(ParcelLocker parcelLocker)
        {
            _unitOfWork.ParcelLockers.Add(parcelLocker);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(ParcelLocker parcelLocker)
        {
            _unitOfWork.ParcelLockers.Update(parcelLocker);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var parcelLocker = await _unitOfWork.ParcelLockers.GetAsync(id);
            _unitOfWork.ParcelLockers.Delete(parcelLocker);
            await _unitOfWork.SaveAsync();
        }
    }
}

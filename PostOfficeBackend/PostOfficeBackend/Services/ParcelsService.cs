using PostOfficeBackend.DAL;
using PostOfficeBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PostOfficeBackend.Services
{
    public class ParcelsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ParcelsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Parcel>> GetAllAsync(int? parcelLockerId)
        {
            Expression<Func<Parcel, bool>> filterBy = (parcelLockerId != null) ?
                                                      p => p.ParcelLockerId == parcelLockerId :
                                                      null;

            return await _unitOfWork.Parcels.GetAllAsync(filterBy, q => q.OrderByDescending(p => p.WeightInKg));
        }

        public async Task<Parcel> GetAsync(int id)
        {
            return await _unitOfWork.Parcels.GetAsync(id);
        }

        public async Task AddAsync(Parcel parcel)
        {
            if (parcel.ParcelLockerId == 0)
                parcel.ParcelLockerId = null;

            _unitOfWork.Parcels.Add(parcel);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(Parcel parcel)
        {
            if (parcel.ParcelLockerId == 0)
                parcel.ParcelLockerId = null;

            _unitOfWork.Parcels.Update(parcel);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var parcel = await _unitOfWork.Parcels.GetAsync(id);
            _unitOfWork.Parcels.Delete(parcel);
            await _unitOfWork.SaveAsync();
        }
    }
}

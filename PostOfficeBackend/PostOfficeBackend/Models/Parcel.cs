namespace PostOfficeBackend.Models
{
    public class Parcel
    {
        public int Id { get; set; }

        public string ReceiverName { get; set; }

        public string ReceiverPhone { get; set; }

        public decimal WeightInKg { get; set; }

        public string Info { get; set; }

        public int? ParcelLockerId { get; set; }

        public ParcelLocker ParcelLocker { get; set; }
    }
}

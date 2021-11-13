namespace PostOfficeBackend.Models
{
    public class ParcelLocker
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public short MaxParcelsCount { get; set; }

        public string Town { get; set; }
    }
}


namespace NextpayBackend.Data.Models
{
    public class Payment
    {
        public string Bsb { get; set; }
        public string AccountNumber { get; set; }
        public string accountName { get; set; }
        public string Reference { get; set; }
        public double Amount { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4}", Bsb, AccountNumber, accountName, Reference, Amount);
        }
    }
}

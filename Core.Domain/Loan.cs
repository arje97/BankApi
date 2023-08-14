namespace Core.Domain
{
    public class Loan
    {

        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int Period { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}

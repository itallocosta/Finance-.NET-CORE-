namespace Entities.Entities
{
    public class BankAccount: Base
    {
        public string BankName { get; set; }
        public decimal Overdraft { get; set; }
        public decimal InterestRate { get; set; }

        public bool Active { get; set; }
    }
}

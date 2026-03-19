using System;

namespace OOP_Training
{
    public class CreditCard : BankAccount
    {
        private DateTime gracePeriod;
        private decimal  Debt;
        public CreditCard(int accountNumber) : base(accountNumber)
        {
            Deposit(1000);
        }

        public override void Deposit(decimal amount)
        {
            base.Deposit(amount);
            Debt -= amount;
        }

        public override void Withdraw(decimal amount)
        {
            decimal commission = amount * 0.01m + 50;
            base.Withdraw(amount + commission);
            Debt += amount;
            gracePeriod = DateTime.Now;
        }

        public override void GracePeriod()
        {
            if(Debt > Balance && (DateTime.Now - gracePeriod).TotalMinutes > 1)
            {
                Console.WriteLine($"У тебя долг!!! Он составляет {Debt} рублей!");
                Debt += Debt / 20;
                gracePeriod = DateTime.Now;
            }
        }
        
    }


}

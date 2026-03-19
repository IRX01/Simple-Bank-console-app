using System;

namespace OOP_Training
{
    public class SavingAccount : BankAccount 
    {
        private DateTime percent = DateTime.Now;

        public SavingAccount(int accountNumber) : base(accountNumber)
        {
        }
        //
        //Снятие денег с комиссией
        //
        public override void Withdraw(decimal amount)
        {
            decimal commission = amount * 0.01m;
            base.Withdraw(amount + commission);
            
        }
        //
        //Снятие денег с комиссией
        //

        //
        //Начисление процентов
        // 
        public void ApplyInterest()
        {
            if((DateTime.Now - percent).TotalSeconds >= 5)
            {
                decimal interest = Balance * 0.01m;
                ChangeBalance(interest);
                percent = DateTime.Now;
            }
        }
        //
        //Начисление процентов
        // 
        
        public override void UpdatePercents()
        {
            ApplyInterest();
        }

    }

    
}

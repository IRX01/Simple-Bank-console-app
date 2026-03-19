using System;

namespace OOP_Training
{
    public class BankAccount
    {
        private readonly List<string> OpperationHistory = [];
        public int AccountNumber {get; private set;}
        public decimal Balance {get; private set;}
        public bool AccountWasCreated {get; private set;} = false;

        public BankAccount(int accountNumber)
        {
            AccountNumber = accountNumber;
            AccountWasCreated = true;
        }

        public virtual void Deposit(decimal amount)
        {
            if(amount <= 0)
            {
                Console.WriteLine("Ошибка! Некоректная сумма операции!");
                return;
            }
                
            Balance += amount;
            OpperationHistory.Add($"{DateTime.Now}, Deposit: {amount}");
        }

        public virtual void Withdraw(decimal amount)
        {
            if(amount < 0)
            {
                Console.WriteLine("Ошибка! Некоректная сумма операции!");
                return;
            }
            if (amount > Balance)
            {
                Console.WriteLine("Ошибка! На балансе недостаточно средств!");
                return;
            }
                Balance -= amount;
                OpperationHistory.Add($"{DateTime.Now}, Снято: {amount}");
        }

        protected void ChangeBalance(decimal _amount)
        {
            Balance += _amount;
            OpperationHistory.Add($"{DateTime.Now}, Начислено: {_amount}");
        }
        public void PrintHistory()
        {
            for (int i = 0; i < OpperationHistory.Count; i++)
            {
                Console. WriteLine(OpperationHistory[i]);
            }
        }

        public virtual void UpdatePercents()
        { 
        }
        public virtual void GracePeriod()
        {
        }
    }
}
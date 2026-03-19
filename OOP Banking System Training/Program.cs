using System;
using System.Xml.Serialization;

namespace OOP_Training
{
    public class Program
    {
        static void Main()
        {
            bool game = true, registrationWasBe = false;
            int accountNumber = 1;
            BankAccount currentAccount = null;
            List<BankAccount> Accounts = new List<BankAccount>();;
            


            while (game)
            {
                if (!registrationWasBe)
                {
                    Console.WriteLine("Добро пожаловать в наш банк, что желаете сделать?");
                    Console.WriteLine("1. Открыть брокерский счёт\n2. Открыть накопительный счёт\n 3. Открыть кредитную карту");
                    

                    if(!int.TryParse(Console.ReadLine(), out int choice) || choice > 3)
                    {
                        Console.WriteLine("Ошибка ввода! Введите корректное значение");
                        continue;
                    }
                    else
                    {
                        switch (choice)
                        {
                            case 1:
                            currentAccount = new BankAccount(accountNumber);
                            Accounts.Add(currentAccount);
                            
                            accountNumber++;
                            registrationWasBe = true;
                            break;
                            case 2: 
                            currentAccount = new SavingAccount(accountNumber);
                            Accounts.Add(currentAccount);
                            accountNumber++;
                            registrationWasBe = true;
                            break;
                            case 3:
                            currentAccount = new CreditCard(accountNumber);
                            Accounts.Add(currentAccount);
                            accountNumber++;
                            registrationWasBe = true;
                            break;
                        }
                    }
                    
                }
                else if (registrationWasBe)
                {
                    Console.WriteLine();
                    Console.WriteLine("Выберите действие:\n1)Внести средства\n2)Снять средства\n3)Посмотреть баланс");
                    Console.WriteLine("4)Перевести средства\n5)История операций\n6)Открыть новый счёт\n7)Выбор счёта\n8)Выход");
                    int choise = Convert.ToInt32(Console.ReadLine());

                    switch (choise)
                    {
                        case 1:
                            Console.WriteLine("Введите сумму депозита: ");
                            int deposit = Convert.ToInt32(Console.ReadLine());
                            currentAccount.Deposit(deposit);
                            Console.Clear();
                            Console.WriteLine($"Успешно начислено {deposit}");
                        break;
                        case 2:
                            Console.WriteLine("Введите сумму снятия: ");
                            int withDraw = Convert.ToInt32(Console.ReadLine());
                            currentAccount.Withdraw(withDraw);
                            Console.Clear();
                            Console.WriteLine($"Успешно снято {withDraw}");
                        break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine($"Ваш баланс: {currentAccount.Balance}");
                        break;
                        case 4:
                            if(Accounts.Count < 2)
                            {
                                Console.WriteLine("Ошибка! У вас только 1 счёт");
                                break;
                            }
                            
                            while(true){
                                Console.Clear();

                                    
                                Console.WriteLine("Откуда перевести средства: ");
                                for(int i = 0; i < Accounts.Count; i++)
                                {
                                    Console.WriteLine($"{Accounts[i].AccountNumber}) | {Accounts[i].GetType().Name}");
                                }
                                if(!int.TryParse(Console.ReadLine(), out int givingAccount) 
                                || givingAccount > Accounts.Count 
                                || givingAccount < 1)
                                {
                                    Console.WriteLine("Ошибка ввода! Введите корректное значение");
                                    continue;
                                }
                                Console.WriteLine("Куда перевести средства: ");
                                for(int i = 0; i < Accounts.Count; i++)
                                {
                                    if(Accounts[i].AccountNumber == givingAccount) 
                                    continue;
                                    Console.WriteLine($"{Accounts[i].AccountNumber}) | {Accounts[i].GetType().Name}");
                                }
                                if(!int.TryParse(Console.ReadLine(), out int receivingAccount) 
                                || receivingAccount > Accounts.Count 
                                || receivingAccount < 1)
                                {
                                    Console.WriteLine("Ошибка ввода! Введите корректное значение");
                                    continue;
                                }
                                Console.Write("Укажите сумму перевода: ");
                                if(!int.TryParse(Console.ReadLine(), out int summTransaction) || summTransaction < 1)
                                {
                                    Console.WriteLine("Ошибка ввода! Введите корректное значение");
                                    continue;
                                }
                                if(Accounts[givingAccount - 1].Balance < summTransaction)
                                {
                                    Console.WriteLine("Ошибка! Недостаточно средств!");
                                    continue;
                                }    
                                else
                                {
                                    Accounts[givingAccount - 1].Withdraw(summTransaction);
                                    Accounts[receivingAccount - 1].Deposit(summTransaction);
                                    Console.WriteLine("Перевод успешно произведен!");
                                    break;
                                }
                            }
                        break;
                        case 5:
                        Console.Clear();
                            currentAccount.PrintHistory();
                        break;
                        case 6:
                            registrationWasBe = false; 
                        break;
                        case 7:
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Ваши счета:");

                                for(int i = 0; i < Accounts.Count; i++)
                                {
                                    Console.WriteLine($"{i+1}) | {Accounts[i].GetType().Name}");
                                }
                                Console.WriteLine("Выберите счёт: ");
                                if(!int.TryParse(Console.ReadLine(), out int choice) || choice > Accounts.Count || choice < 1)
                                {
                                    Console.WriteLine("Ошибка ввода! Введите корректное значение");
                                    continue;
                                }
                                else
                                {
                                    currentAccount = Accounts[choice - 1];
                                    Console.WriteLine($"Вы переключились на аккаунт {currentAccount.GetType().Name}");
                                    break;
                                }
                            }
                                
                        break;
                        case 8:
                            game = false;
                            break;
                    }
                    currentAccount.UpdatePercents();
                    currentAccount.GracePeriod();
                }
            }  
        }
    }
}

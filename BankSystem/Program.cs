// See https://aka.ms/new-console-template for more information


using BankSystem;

Console.WriteLine("Hello, World!");
var user = new User("name");
var balance = 1;
var sourceAcountId = Guid.NewGuid();
var bank = new Bank();

bank.CreateAccount(user, balance);
bank.AddBalance(user, balance);


/*
bank.GetMoney(accID, balance);
bank.GetBalance(accID);
bank.SendMoney(accID, sourceAcountId, balance);
*/

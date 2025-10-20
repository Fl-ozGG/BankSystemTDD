// See https://aka.ms/new-console-template for more information


using BankSystem;

Console.WriteLine("Hello, World!");
var user = new User("name");
var balance = 1;
var sourceAcountId = Guid.NewGuid();
var bank = new Bank();
/*
var accID = bank.CreateAccount(user, balance).Id;
bank.GetMoney(accID, balance);
bank.GetBalance(accID);
bank.AddBalance(accID, balance);
bank.SendMoney(accID, sourceAcountId, balance);
*/

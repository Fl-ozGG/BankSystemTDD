// See https://aka.ms/new-console-template for more information


using BankSystem;

Console.WriteLine("Hello, World!");
var user = new User("igna");
var user1 = new User("alvaro");
var balance = 1;

var bank = new Bank();

bank.CreateAccount(user, balance);
bank.AddBalanceToAccount(user, balance);
bank.WithdrawBalanceFromAccount(user, balance);
bank.GetAccountBalance(user);
bank.SendBalance(user, user1.Id, balance);


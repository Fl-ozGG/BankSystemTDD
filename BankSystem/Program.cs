// See https://aka.ms/new-console-template for more information


using BankSystem;

Console.WriteLine("Hello, World!");
var user = new User("name");
var balance = 1;
var sourceAcountId = Guid.NewGuid();
var bank = new Bank();

bank.CreateAccount(user, balance);
bank.AddBalanceToAccount(user, balance);
bank.WithdrawBalanceFromAccount(user, balance);
bank.GetAccountBalance(user);


/*
bank.SendBalance(accID, sourceAcountId, balance);
*/

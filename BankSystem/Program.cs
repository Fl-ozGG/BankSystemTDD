// See https://aka.ms/new-console-template for more information


using BankSystem;


var igna = new User("igna");
var alvaro = new User("alvaro");
var balance = 100;
var balanceToAdd = 20;
var balanceToWithdraw = 100;
var bank = new Bank();

bank.CreateAccount(igna, balance);
bank.CreateAccount(alvaro, balance);
bank.GetAccountBalance(igna);
bank.AddBalanceToAccount(igna, balanceToAdd);
bank.GetAccountBalance(igna);
bank.WithdrawBalanceFromAccount(igna, balanceToWithdraw);
bank.GetAccountBalance(igna);
bank.SendBalance(igna, alvaro.Id, 50);
bank.GetAccountBalance(igna);
bank.GetAccountBalance(alvaro);




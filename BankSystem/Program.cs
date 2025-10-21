// See https://aka.ms/new-console-template for more information


using BankSystem;


var bank = new Bank();

var igna = new User("igna");
var alvaro = new User("alvaro");

var amountIgna = 100;
var amountAlvaro = 150;

var cashToSend = 50;

var response = bank.CreateAccount(igna, amountIgna);

if (!response.data.Succesfull)
{
    Console.WriteLine($"Error: {response.data.msg}");
    return; 
}
var acc = response.account!;
var response2 = bank.CreateAccount(alvaro, amountAlvaro);
if (!response2.data.Succesfull)
{
    Console.WriteLine($"Error: {response2.data.msg}");
    return; 
}
var acc2 = response2.account!;

acc.Deposit(50);
acc.Withdraw(20);
acc.Transfer(acc2, cashToSend);
Console.WriteLine(acc.Balance);
Console.WriteLine(acc2.Balance);





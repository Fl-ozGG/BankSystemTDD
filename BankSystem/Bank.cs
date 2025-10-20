using System.Runtime.CompilerServices;
using BankSystemTest;

namespace BankSystem;

public class Bank
{
    private List<Account> _accounts = new List<Account>();

    public Result CreateAccount(User user, int balance)
    {
        if(user == null) throw new Exception("User does not exist");
        if (balance > 0)
        {
            var acc = new Account(user, balance); 
            _accounts.Add(acc);
            return new Result
            {
                Succesfull = true, msg = "Account created successfully!"
            };
        }
        else
        {
            return new Result
            {
                Succesfull = false, msg = "Your balance must be higher than 0."
            };
        }
    }

    public Result AddBalance(User user, int balance)
    {
        if (user == null) throw new Exception("User does not exist");
        if (balance > 0)
        {
            var acc = _accounts.First(el => el.User == user);
            acc.AddBalance(balance);
            return new Result
            {
                Succesfull = true, msg = "Balance added successfully!"
            };
        }
        else
        {
            return new Result
            {
                Succesfull = false, msg = "You must add more than 0 currency to your balance."
            };
        }
        
    }

    public Result WithdrawBalance(User user, int desiredAmount)
    {
        if(user == null)  throw new Exception("User does not exist");
        var acc = _accounts.First(el => el.User == user);
        if(desiredAmount <= 0) return new Result{Succesfull = false, msg = "Desired amount must be greater than 0."};
        if (acc.GetBalance() < desiredAmount)
        {
            return new Result
            {
                Succesfull = false, msg = "Your balance must be higher than the desired amount."
            };
        }
        else
        {
            acc.Withdraw(desiredAmount);
            return new Result
            {
                Succesfull = true, msg = "Balance updated successfully!"
            };
        }
    }
    
    
    
}
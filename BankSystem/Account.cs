using BankSystemTest;

namespace BankSystem;

public class Account
{
    private User _user;
    public User User => _user;
    private decimal _balance;
    public decimal Balance => _balance;

    public Account(User user, int balance)
    {
        _user = user;
        _balance = balance;
    }

    public Result Deposit(decimal cashAmount)
    {
        if(cashAmount > 0)
        {
            _balance += cashAmount;
            return new Result
            {
                Succesfull = true, msg = "Cash added successfully!"
            };
        }
        return new Result
        {
            Succesfull = false, msg = "You must add more than 0 currency to your balance."
        };
    }

    public Result Withdraw(decimal cashAmount)
    {
        if(cashAmount <= 0) return new Result{Succesfull = false, msg = "Desired amount must be greater than 0."};
        if(cashAmount > _balance) return new Result{Succesfull = false, msg = "You cannot withdraw more than your actual amount."};
        _balance -= cashAmount;
        return new Result
        {
            Succesfull = true, msg = "Balance updated successfully!"
        };
    }

    public Result Transfer(Account account, int amount)
    {
        if (Withdraw(amount).Succesfull)
        {
            return account.Deposit(amount);
        }
        return new Result
        {
            Succesfull = false, msg = "You were not able to withdraw more than your actual amount to transfer."
        };
    }
    
    

    
}
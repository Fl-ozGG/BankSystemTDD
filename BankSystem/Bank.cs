
using BankSystemTest;

namespace BankSystem;

public class Bank
{
    private readonly List<Account> _accounts = new List<Account>();

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

    public Result AddBalanceToAccount(User user, int balance)
    {
        if (user == null) throw new Exception("User does not exist");
        if (balance > 0)
        {
            var acc = _accounts.First(el => el.User.Id == user.Id);
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

    public Result WithdrawBalanceFromAccount(User user, int desiredAmount)
    {
        if(user == null)  throw new Exception("User does not exist");
        var acc = _accounts.First(el => el.User.Id == user.Id);
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
            acc.WithdrawBalance(desiredAmount);
            return new Result
            {
                Succesfull = true, msg = "Balance updated successfully!"
            };
        }
    }

    public int GetAccountBalance(User user)
    {
        return  _accounts.First(el => el.User.Id == user.Id).GetBalance();
        
    }

    public Result SendBalance(User user, Guid userId, int balance)
    {
        var fromAccount = _accounts.Find(el => el.User.Id == user.Id);
        if(fromAccount == null) throw new Exception("The Account you are using does not exist you need to create one first.");
        var toAccount = _accounts.Find(el => el.User.Id == userId);
        if(toAccount == null) throw new Exception("The user you are trying to reach does not exist");
       
        if (WithdrawBalanceFromAccount(fromAccount.User, balance).Succesfull==false)
        {
            return WithdrawBalanceFromAccount(fromAccount.User, balance);
        }

        if (AddBalanceToAccount(toAccount.User, balance).Succesfull == false)
        {
            return AddBalanceToAccount(toAccount.User, balance);
        }
        return new Result
        {
            Succesfull = true, msg = "Balance sent successfully!"
        };

    }
    
}
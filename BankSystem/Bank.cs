
using BankSystemTest;

namespace BankSystem;

public class Bank
{
    private readonly List<Account> _accounts = new List<Account>();

    public Account GetAccount(Guid id)
    {
        return _accounts.First(el => el.User.Id == id);
    }

    public (Result data, Account? account) CreateAccount(User user, int balance)
    {
        if(user == null) throw new Exception("User is not valid");
        if (balance > 0)
        {
            var acc = new Account(user, balance); 
            _accounts.Add(acc);
            return (new Result
            {
                Succesfull = true, msg = "Account created successfully!"
            },acc);
        }
        else
        {
            return (new Result
            {
                Succesfull = false, msg = "Your balance must be higher than 0."
            },null);
        }
    }
    
    
    
}
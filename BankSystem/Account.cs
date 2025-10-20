namespace BankSystem;

public class Account
{
    public User User;
    private Guid Id;
    private int _balance;
    public Account(User user, int balance)
    {
        User = user;
        Id = Guid.NewGuid();
        _balance = balance;
    }

    public void AddBalance(int balance)
    {
        _balance += balance;
    }

    public int GetBalance()
    {
        return _balance;
    }
    
    public void Withdraw(int amount)
    {
        _balance -= amount;
    }
}
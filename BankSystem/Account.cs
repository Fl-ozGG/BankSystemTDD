namespace BankSystem;

public class Account
{
    private User _user;
    public User User => _user;
    private int _balance;
    public Account(User user, int balance)
    {
        _user = user;
        _balance = balance;
    }
    public void AddBalance(int balance)
    {
        _balance += balance;
    }
    public void WithdrawBalance(int amount)
    {
        _balance -= amount;
    }
    public int GetBalance()
    {
        return _balance;
    }
    
}
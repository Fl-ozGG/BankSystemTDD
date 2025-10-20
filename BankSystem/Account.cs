namespace BankSystem;

public class Account
{
    public Guid userId;
    private Guid Id;
    private int _balance;
    public Account(User user, int balance)
    {
        userId = user.Id;
        //Id = Guid.NewGuid();
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
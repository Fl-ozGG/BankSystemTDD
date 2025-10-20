namespace BankSystem;

public class User
{
    private string _name;
    private Guid _id;
    public User(string name)
    {
        _name = name;
        _id = Guid.NewGuid();
        
    }
}
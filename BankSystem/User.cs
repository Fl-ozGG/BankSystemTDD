namespace BankSystem;

public class User
{
    public string Name;
    public Guid Id { get; init; }

    public User(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
        
    }
}
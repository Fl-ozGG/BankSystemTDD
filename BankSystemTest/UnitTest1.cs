using BankSystem;

namespace BankSystemTest;

public class UnitTest1
{
    [Fact]
    public void CreateAccount_ShouldReturnFalse_IfBalanceIsZero()
    {
        //Arrange
        var bank = new Bank();
        var user = new User("igna");
        var balance = 0;
        
        //Act
        var result = bank.CreateAccount(user, balance);
        
        //Assert
        Assert.False(result.Succesfull);
        Assert.Equal("Your balance must be higher than 0.",result.msg);
    }
    [Fact]
    public void CreateAccount_ShouldReturnTrue_IfBalanceIsHigherThan0()
    {
        //Arrange
        var bank = new Bank();
        var user = new User("igna");
        var balance = 100;
        
        //Act
        var result = bank.CreateAccount(user, balance);
        
        //Assert
        Assert.True(result.Succesfull);
        Assert.Equal("Account created successfully!",result.msg);
        
        
    }
    
    [Fact]
    public void AddBalance_ShouldReturnFalse_IfBalanceIsZero()
    {
        //Arrange
        var bank = new Bank();
        var user = new User("igna");
        var balance = 0;
        
        //Act
        var result = bank.AddBalance(user, balance);
        
        //Assert
        Assert.False(result.Succesfull);
        Assert.Equal("You must add more than 0 currency to your balance.", result.msg);
    }
    
    
    
}
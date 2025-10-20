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

    [Fact]
    public void WithdrawBalance_ShouldReturnFalse_IfDesiredAmountIsHigherThanBalance()
    {
        //Arrange
        var bank = new Bank();
        var user = new User("igna");
        var desiredAmount = 100;
        bank.CreateAccount(user, 50);
        
        //Act
        var result = bank.WithdrawBalance(user, desiredAmount);
        
        //Assert
        Assert.False(result.Succesfull);
        Assert.Equal("Your balance must be higher than the desired amount.", result.msg);
    }

    [Fact]
    public void WithdrawBalance_ShouldReturnFalse_IfDesiredAmountIsLowOrEqualTo0()
    {
        //Arrange
        var bank = new Bank();
        var user = new User("igna");
        var desiredAmount = 0;
        bank.CreateAccount(user, 50);
        
        //Act
        var result = bank.WithdrawBalance(user, desiredAmount);
        
        //Assert
        Assert.False(result.Succesfull);
        Assert.Equal("Desired amount must be greater than 0.", result.msg);
        
    }
}
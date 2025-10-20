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
        var result = bank.AddBalanceToAccount(user, balance);
        
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
        var result = bank.WithdrawBalanceFromAccount(user, desiredAmount);
        
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
        var result = bank.WithdrawBalanceFromAccount(user, desiredAmount);
        
        //Assert
        Assert.False(result.Succesfull);
        Assert.Equal("Desired amount must be greater than 0.", result.msg);
        
    }
    [Fact]
    public void GetAccountBalance_MustReturnBalance()
    {
        //Arrange
        var bank = new Bank();
        var user = new User("igna");
        bank.CreateAccount(user, 100);
        var result = bank.GetAccountBalance(user);
        bank.AddBalanceToAccount(user, 50);
        var resultAfterAddBalance = bank.GetAccountBalance(user);
        
        Assert.Equal(100, result);
        Assert.Equal(150, resultAfterAddBalance);
    }

    [Fact]
    public void SendBalance_ShouldUpdate_FromAccount()
    {
        //Arrange
        var bank = new Bank();
        var user = new User("igna");
        var user2 = new User("alvaro");
        bank.CreateAccount(user, 100);
        bank.CreateAccount(user2, 200);
        var balanceToSend = 50;
        
        //Act
        bank.SendBalance(user, user2.Id, balanceToSend);
        
        //Assert
        var resultAfterSend = bank.GetAccountBalance(user);
        Assert.Equal(50, resultAfterSend);
    }
    [Fact]
    public void SendBalance_ShouldUpdate_ToAccount()
    {
        //Arrange
        var bank = new Bank();
        var user = new User("igna");
        var user2 = new User("alvaro");
        bank.CreateAccount(user, 100);
        bank.CreateAccount(user2, 200);
        var balanceToSend = 50;
        
        //Act
        bank.SendBalance(user, user2.Id, balanceToSend);
        
        //Assert
        var resultAfterSend = bank.GetAccountBalance(user2);
        Assert.Equal(250, resultAfterSend);
    }

    [Fact]
    public void SendBalance_ShouldReturnFalse_IfBalanceIsZero()
    {
        
    }
    
    
    [Fact]
    public void SendBalanceShouldReturnFalse_IfFromAccountBalanceIsNotEnough()
    {
        
    }

    
}
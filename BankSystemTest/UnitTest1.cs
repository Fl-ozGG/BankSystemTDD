using BankSystem;

namespace BankSystemTest;

public class UnitTest1
{
    [Fact]
    public void CreateAccount_ShouldReturnFalse_IfBalanceIsZero()
    {
        //Arrange
        var bank = new Bank();
        var igna = new User("igna");
        var amountIgna = 0;
        
        //Act
        var response = bank.CreateAccount(igna, amountIgna);
        
        //Assert
        Assert.False(response.data.Succesfull);
        Assert.Equal("Your balance must be higher than 0.",response.data.msg);
    }
    
    [Fact]
    public void CreateAccount_ShouldReturnTrue_IfBalanceIsHigherThan0()
    {
        //Arrange
        var bank = new Bank();
        var igna = new User("igna");
        var amountIgna = 10;

        //Act
        var response = bank.CreateAccount(igna, amountIgna);
        
        //Assert
        Assert.True(response.data.Succesfull);
        Assert.Equal("Account created successfully!",response.data.msg);   
    }
    
    [Fact]
    public void Deposit_ShouldReturnFalse_IfDepositAmountIsZero()
    {
        //Arrange
        var bank = new Bank();
        var igna = new User("igna");
        var amountIgna = 100;
        var amountToAdd = 0;
        var response = bank.CreateAccount(igna, amountIgna);
        var acc = response.account!;
        
        //Act
        acc.Deposit(amountToAdd);
        
        //Assert
        Assert.False(response.data.Succesfull);
        Assert.Equal("You must add more than 0 currency to your balance.",response.data.msg);
    }

    [Fact]
    public void Withdraw_ShouldReturnFalse_IfDesiredAmountIsHigherThanBalance()
    {
        //Arrange
        var bank = new Bank();
        var igna = new User("igna");
        var amountIgna = 50;
        var amountToWithdraw = 100;
        var response = bank.CreateAccount(igna, amountIgna);
        var acc = response.account!;
        
        //Act
        var result = acc.Withdraw(amountToWithdraw);
        
        //Assert
        Assert.False(result.Succesfull);
        Assert.Equal("You cannot withdraw more than your actual amount.",result.msg);
    }
    
    [Fact]
    public void Withdraw_ShouldReturnFalse_IfDesiredAmountIsEqualTo0()
    {
        //Arrange
        var bank = new Bank();
        var igna = new User("igna");
        var amountIgna = 50;
        var amountToWithdraw = 0;
        var response = bank.CreateAccount(igna, amountIgna);
        var acc = response.account!;
        
        //Act
        var result = acc.Withdraw(amountToWithdraw);
        
        //Assert
        Assert.False(result.Succesfull);
        Assert.Equal("Desired amount must be greater than 0.",result.msg);
    }
    
    [Fact]
    public void Transfer_ShouldUpdate_Accounts()
    {
        //Arrange
        var bank = new Bank();
        var igna = new User("igna");
        var alvaro = new User("alvaro");
        var amountIgna = 100;
        var amountAlvaro = 150;
        
        var responseIgna = bank.CreateAccount(igna, amountIgna);
        var responseAlvaro = bank.CreateAccount(igna, amountAlvaro);
        var accIgna = responseIgna.account!;
        var accAlvaro = responseAlvaro.account!;
        
        //Act

        var result = accIgna.Transfer(accAlvaro, 50);
        
        //Assert
        Assert.Equal(50, accIgna.Balance);
        Assert.Equal(200,accAlvaro.Balance);
    }
    

    [Fact]
    public void Transfer_ShouldReturnFalse_IfFromAccountHasLessBalanceThanCashAmountToSend()
    {
        //Arrange
        var bank = new Bank();
        var igna = new User("igna");
        var alvaro = new User("alvaro");
        var amountIgna = 100;
        var amountAlvaro = 150;
        
        var responseIgna = bank.CreateAccount(igna, amountIgna);
        var responseAlvaro = bank.CreateAccount(igna, amountAlvaro);
        var accIgna = responseIgna.account!;
        var accAlvaro = responseAlvaro.account!;
        
        //Act

        var result = accIgna.Transfer(accAlvaro, 150);
        
        //Assert
        Assert.False(result.Succesfull);
        Assert.Equal("You were not able to withdraw more than your actual amount to transfer.",result.msg);
    }


    
}
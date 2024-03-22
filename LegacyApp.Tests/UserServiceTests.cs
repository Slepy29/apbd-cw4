namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUserReturnsFalseWhenFirstNAmeIsEmpty()
    {
        // Arrange
        var userService = new UserService();
        
        // Act
        var result = userService.AddUser(
            null,
            "123",
            "123@gmail.com",
            DateTime.Now,
            1);

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_throws()
    {
        // Arrange
        var userService = new UserService();
        
        // Act
        Action result = () =>  userService.AddUser(
            "jan",
            "123",
            "123@gmail.com",
            DateTime.Now,
            100);

        // Assert
        Assert.Throws<ArgumentException>(result);
    }
}
using ContactManager.Models;

public class ContactTests
{
    [Fact]
    public void CanChangeName()
    {
        // Arrange
        var contact = new Contact { Name = "Old Name" };

        // Act
        contact.Name = "New Name";

        // Assert
        Assert.Equal("New Name", contact.Name);
    }
}

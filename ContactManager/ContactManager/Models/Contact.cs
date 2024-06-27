using System.ComponentModel.DataAnnotations;

public class Contact
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
    public string Name { get; set; } = string.Empty;

    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters")]
    public string Email { get; set; } = string.Empty;

    [Phone(ErrorMessage = "Invalid Phone Number")]
    [StringLength(15, ErrorMessage = "Phone number cannot be longer than 15 characters")]
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}

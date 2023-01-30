using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthService.Application;

[Table("Users")]
public class User {
    [Key]
    public Guid id { get; set; }
    
    [Required]
    [EmailAddress]
    public string? email { get; set; }
    
    [Required]
    [MinLength(3)]
    [MaxLength(20)]
    public string? Username { get; set; }

    [MinLength(12)]
    [MaxLength(256)]
    public string? Password { get; set; }
}
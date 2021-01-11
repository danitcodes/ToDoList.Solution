//this file is a rouping of properties & data annotations - a data model for user registration
using System.ComponentModel.DataAnnotations;

namespace ToDoList.ViewModels
{
  public class RegisterViewModel //  standard naming convention to end each ViewModel's file name w/ ViewModel
  {
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
  }
}
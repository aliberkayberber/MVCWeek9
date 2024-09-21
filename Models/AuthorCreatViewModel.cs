using System.ComponentModel.DataAnnotations;

namespace MVCWeek9.Models;

public class AuthorCreatViewModel
{
    [Required (ErrorMessage ="Boş bırakılamaz.")]
    public string FirstName {get;set;}

    [Required (ErrorMessage ="Boş bırakılamaz.")]
    public string LastName {get;set;}

    [Required (ErrorMessage ="Boş bırakılamaz.")]
    public DateTime DateOfBirth {get;set;}
    
}
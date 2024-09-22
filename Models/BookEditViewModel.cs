using System.ComponentModel.DataAnnotations;

namespace MVCWeek9.Models;

public class BookEditViewModel  // to exchange data from Bookcontroller to Edit view
{
    public int Id {get; set;}

    [Required]
    public int AuthorId {get; set;}  // author referans

    [Required]
    public string Title {get; set;}

    [Required]
    public string Genre {get; set;}

}
using System.ComponentModel.DataAnnotations;
using MVCWeek9.Entities;

namespace MVCWeek9.Models;

public class BookCreatViewModel
{
    [Required (ErrorMessage ="Kitabın adını girmek zorunludur.")]
    public string Title {get;set;}

    [Required (ErrorMessage ="Kitabın türünü girmek zorunludur.")]
    public string Genre {get; set;}
    public int AuthorId{get;set;}
}
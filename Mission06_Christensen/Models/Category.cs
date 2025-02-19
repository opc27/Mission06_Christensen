using System.ComponentModel.DataAnnotations;

namespace Mission06_Christensen.Models;

public class Category
{
    // category table
    [Key]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}
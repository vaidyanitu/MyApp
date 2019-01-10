using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmnilTest.ViewModels
{
  public class ContestantViewModel
  {
    public int Id { get; set; }
    public string FullName { get; set; }
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime DateOfBirth { get; set; }
    public string District { get; set; }
    public string Gender { get; set; }
  }
}

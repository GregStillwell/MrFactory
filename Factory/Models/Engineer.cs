using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Factory.Models
{
  public class Engineer
  {
    public int EngineerId {get; set;}
    [Required(ErrorMessage = "Cannot leave engineer's name empty!")]
    public string Name {  get; set;}
    public List<EngineerMachine> JoinEntities {get; set;}
  }
}
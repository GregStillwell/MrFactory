using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Factory.Models
{
  public class Engineer
  {
    [Required]
    public int EngineerId {get; set;}
    [Required]
    public string Name {get; set;}
    public string Description {get; set;  }
    public List<CourseStudent> JoinEntities {get; set;}
  }
}
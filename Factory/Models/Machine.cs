using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
      [Required(ErrorMessage = "Cannot leave machine Model empty")]
    public string Model { get; set; }
    public List<EngineerMachine> JoinEntities { get; set; }
  }
}
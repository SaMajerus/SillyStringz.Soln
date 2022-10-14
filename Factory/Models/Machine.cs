using System.Collections.Generic; 
using System; 

namespace Factory.Models 
{ 
  public class Machine 
  { 
    // public Machine() 
    // { 
    //   this.JoinPlrSprt = new HashSet<SportMachine>(); 
    //   this.JoinSmstrPlyr = new HashSet<SemesterMachine>(); 
    // } 

    public int MachineId { get; set; } 
    public string Name { get; set; } 
    // public int EngrId_Engineer { get; set; } 
    // public virtual ICollection<SportMachine> JoinPlrSprt { get; set; } 
    // public virtual ICollection<SemesterMachine> JoinSmstrPlyr { get; set; } 
  } 
} 
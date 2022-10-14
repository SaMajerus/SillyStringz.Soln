using System.Collections.Generic; 
using System; 

namespace Factory.Models 
{ 
  public class Machine 
  { 
    public Machine() 
    { 
      this.JoinMachEngr = new HashSet<EngineerMachine>(); 
      this.JoinLicMach = new HashSet<LicenseMachine>(); 
    } 

    public int MachineId { get; set; } 
    public string Name { get; set; } 
    // public int EngrId_Engineer { get; set; }  //Stores value of 'EngrId' field of a given Engineer. 
    public virtual ICollection<EngineerMachine> JoinMachEngr { get; set; } 
    public virtual ICollection<LicenseMachine> JoinLicMach { get; set; } 
  } 
} 
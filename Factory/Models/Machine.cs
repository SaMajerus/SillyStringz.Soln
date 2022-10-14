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

    public int MachineId { get; set; }  //Properties named 'Id' or 'typenameId' are automatically recognized as Primary Keys.
    public string Name { get; set; } 
    public int EngrId { get; set; }  //Stores value of 'EngineerId' field of a given Engineer. 
    public virtual ICollection<EngineerMachine> JoinMachEngr { get; set; } 
    public virtual ICollection<LicenseMachine> JoinLicMach { get; set; } 
  } 
} 
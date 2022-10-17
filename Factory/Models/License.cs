using System.Collections.Generic; 
using System; 

namespace Factory.Models 
{ 
  public class License 
  { 
    public License() 
    { 
      this.JoinLicEngr = new HashSet<LicenseEngineer>(); 
      this.JoinLicMach = new HashSet<LicenseMachine>(); 
    } 
    
    public int LicenseId { get; set; }  //Properties named 'Id' or 'typenameId' are automatically recognized as Primary Keys.
    public string Title { get; set; } 
    public int EngrId { get; set; }  //Stores value of 'EngrId' field of a given Engineer.
    public int MachineId { get; set; }  //Stores value of 'MachineId' field of a given Machine.
    public virtual ICollection<LicenseEngineer> JoinLicEngr { get; set; } 
    public virtual ICollection<LicenseMachine> JoinLicMach { get; set; } 
  } 
} 
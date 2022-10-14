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
    
    public int LicenseId { get; set; } 
    // public int EngrId_Engineer { get; set; }  //Stores value of 'EngrId' field of a given Engineer. 
    public string Title { get; set; } 
    public virtual ICollection<LicenseEngineer> JoinLicEngr { get; set; } 
    public virtual ICollection<LicenseMachine> JoinLicMach { get; set; } 
  } 
} 
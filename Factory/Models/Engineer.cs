using System.Collections.Generic; 
using System; 

namespace Factory.Models 
{ 
  public class Engineer 
  { 
    public Engineer() 
    { 
      this.JoinMachEngr = new HashSet<EngineerMachine>(); 
      this.JoinLicEngr = new HashSet<LicenseEngineer>(); 
    } 

    public int EngrId { get; set; } 
    public string Name { get; set; } 
    public virtual ICollection<EngineerMachine> JoinMachEngr { get; set; } 
    public virtual ICollection<LicenseEngineer> JoinLicEngr { get; set; } 
  } 
} 
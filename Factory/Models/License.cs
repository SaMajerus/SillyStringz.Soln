using System.Collections.Generic; 
using System; 

namespace Factory.Models 
{ 
  public class License 
  { 
    // public License() 
    // { 
    //   this.JoinSmstrSprt = new HashSet<LicenseSport>(); 
    //   this.JoinSmstrPlyr = new HashSet<LicensePlayer>(); 
    // } 
    
    public int LicenseId { get; set; } 
    // public int EngrId_Engineer { get; set; } 
    public string Title { get; set; } 
    // public virtual ICollection<LicenseSport> JoinSmstrSprt { get; set; } 
    // public virtual ICollection<LicensePlayer> JoinSmstrPlyr { get; set; } 
  } 
} 
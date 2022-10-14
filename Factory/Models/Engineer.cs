using System.Collections.Generic; 
using System; 

namespace Factory.Models 
{ 
  public class Engineer 
  { 
    // public Engineer() 
    // { 
    //   this.JoinPlrSprt = new HashSet<EngineerPlayer>(); 
    //   this.JoinSmstrSprt = new HashSet<SemesterEngineer>(); 
    // } 

    public int EngrId { get; set; } 
    public string Name { get; set; } 
    // public virtual ICollection<EngineerPlayer> JoinPlrSprt { get; set; } 
    // public virtual ICollection<SemesterEngineer> JoinSmstrSprt { get; set; } 
  } 
} 
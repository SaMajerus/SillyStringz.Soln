namespace Factory.Models
{
  public class LicenseMachine
  {
    public int LicenseMachineId { get; set; }
    public int LicenseId { get; set; }
    public int MachineId { get; set; }    
    public virtual License License { get; set; }
    public virtual Machine Machine { get; set; }
  }
}
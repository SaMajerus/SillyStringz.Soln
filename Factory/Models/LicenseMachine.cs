namespace Factory.Models
{
  public class LicenseMachine
  {
    public int LicenseMachineId { get; set; }  //Properties named 'Id' or 'typenameId' are automatically recognized as Primary Keys.
    public int LicenseId { get; set; }
    public int MachineId { get; set; }    
    public virtual License License { get; set; }
    public virtual Machine Machine { get; set; }
  }
}
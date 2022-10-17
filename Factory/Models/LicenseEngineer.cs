namespace Factory.Models
{
  public class LicenseEngineer
  { 
    public int LicenseEngineerId { get; set; }  //Properties named 'Id' or 'typenameId' are automatically recognized as Primary Keys.
    public int LicenseId { get; set; }
    public int EngineerId { get; set; }
    public virtual License License { get; set; }
    public virtual Engineer Engineer { get; set; }
  }
}
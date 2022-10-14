namespace Factory.Models
{
  public class LicenseEngineer
  { 
    public int EngrLicenseId { get; set; }
    public int LicenseId { get; set; }
    public int EngrId { get; set; }
    public virtual License License { get; set; }
    public virtual Engineer Engineer { get; set; }
  }
}
namespace Factory.Models
{
  public class EngineerMachine
  {       
    public int EngineerMachineId { get; set; }  //Properties named 'Id' or 'typenameId' are automatically recognized as Primary Keys. 
    public int MachineId { get; set; }
    public int EngineerId { get; set; }
    public virtual Machine Machine { get; set; }
    public virtual Engineer Engineer { get; set; }
  }
}
using BusManagement.Models;

public class Bus:BaseModel
{
    public int Id { get; set; }
    public string DoorNumber { get; set; }
    public string PlateNumber { get; set; }
    public string Photo { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsDeleted { get; set; }
}
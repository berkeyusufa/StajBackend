using BusManagement.Models;
namespace BusManagement.Models;
public class Task : BaseModel
{
    public int Id { get; set; }
    public int DriverId { get; set; }
    public Driver Driver { get; set; }  // Driver tanımı burada olmalı
    public int BusId { get; set; }
    public Bus Bus { get; set; }  // Bus tanımı da olmalı
    public DateTime TaskDate { get; set; }
    public int RouteId { get; set; }
    public BusRoute Route { get; set; }
}
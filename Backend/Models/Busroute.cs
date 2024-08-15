using BusManagement.Models;

public class BusRoute: BaseModel
{
    public string RouteName { get; set; }
    public string RouteID { get; set; }
    public int RegionId { get; set; }
}

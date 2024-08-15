using BusManagement.Models;

public class TaskViewModel
{
    public int SelectedTaskId { get; set; } // Bu özelliği ekleyin
    public int SelectedDriverId { get; set; }
    public int SelectedBusId { get; set; }

    public List<BusManagement.Models.Task> Tasks { get; set; }
    public Driver Driver { get; set; }
    public Bus Bus { get; set; }
    public List<Driver> Drivers { get; set; }
    public List<Bus> Buses { get; set; }
    public DateTime TaskDate { get; set; }
}

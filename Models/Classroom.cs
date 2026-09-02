namespace orm.Models;

public class Classroom
{
    public int Id { get; set; }
    public string Building { get; set; }
    public string BuildingSection { get; set; }
    public string RoomNumber { get; set; }
    public int Floor { get; set; }
    public int Capacity { get; set; }
}

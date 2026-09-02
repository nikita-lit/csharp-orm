namespace orm.Models;

public class Subject
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public int Credits { get; set; }
    public int? ClassroomId { get; set; }
    public Classroom Classroom { get; set; }
    public ICollection<Student> Students { get; set; }
    public ICollection<Lecturer> Lecturers { get; set; }
}

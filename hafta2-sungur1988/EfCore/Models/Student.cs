namespace EfCore.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual School School { get; set; }
        public virtual Classroom Classroom { get; set; }
    }
}

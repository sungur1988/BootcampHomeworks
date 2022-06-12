namespace EfCore.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}

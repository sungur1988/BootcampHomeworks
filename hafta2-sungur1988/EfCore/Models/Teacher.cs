namespace EfCore.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}

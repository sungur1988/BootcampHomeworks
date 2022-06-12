namespace DependecyInjectionISP.Models
{
    public class RunningDog : IBark, IRun
    {
        public void Bark()
        {
            Console.WriteLine("Bark");
        }

        public void Run()
        {
            Console.WriteLine("runnig");
        }
    }
}

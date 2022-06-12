namespace DependecyInjectionISP.Models
{
    public class WalkingDog : IBark, IWalk
    {
        public void Bark()
        {
            Console.WriteLine("Bark");
        }

        public void Walk()
        {
            Console.WriteLine("walking");
        }
    }
}

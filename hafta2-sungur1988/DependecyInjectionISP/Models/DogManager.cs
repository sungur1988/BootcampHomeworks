namespace DependecyInjectionISP.Models
{
    public class DogManager
    {
        private readonly IRun _run;
        private readonly IWalk _walk;
        public DogManager(IRun run,IWalk walk)
        {
            _run = run;
            _walk = walk;
        }
        public void Run()
        {
            _run.Run();
        }
        public void Walk()
        {
            _walk.Walk();
        }
    }
}

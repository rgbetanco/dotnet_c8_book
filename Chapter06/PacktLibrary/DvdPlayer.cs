using static System.Console;
namespace PacktLibrary
{
    public class DvdPlayer : IPlayable
    {
        public void pause()
        {
            WriteLine("Pausing the video");
        }

        public void play()
        {
            WriteLine("Playing the video");
        }
    }
}
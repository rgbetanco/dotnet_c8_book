using static System.Console;
namespace PacktLibrary
{
    public interface IPlayable
    {
         void play();
         void pause();

        void stop()
        {
            WriteLine("Stopping the video");
        }

    }
}
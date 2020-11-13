namespace WorkWithEFCore
{
    public class ConsoleLoggerProvider: ILoggerProvider 
    {
        public ILogger CreateLogger(string categoryName){
            return new ConsoleLogger();
        }
        public void Dispose(){}
    }
    public class ConsoleLogger: ILogger
    {
        public IDisposable BeginScope<TState>(TState state){
            return null;
        }
    }
}
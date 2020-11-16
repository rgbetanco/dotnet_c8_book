using System;
using Microsoft.Extensions.Logging;
using static System.Console;
namespace WorkWithEFCore
{
    public class ConsoleLoggerProvider : ILoggerProvider 
    {
        public ILogger CreateLogger(string categoryName){
            return new ConsoleLogger();
        }
        public void Dispose(){ }
    }
    public class ConsoleLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state){
            return null;
        }
        public bool IsEnabled(LogLevel logLevel){
            switch (logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Information:
                case LogLevel.None:
                    return false;
                case LogLevel.Debug:
                case LogLevel.Warning:
                case LogLevel.Error:
                case LogLevel.Critical:
                default:
                    return true;
            };
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter){
            if (eventId.Id == 20101){
                //log the level and the event identifier
                Write($"Level: {logLevel}, Event ID: {eventId.Id}");
                //Only output the state or the exception if they exist
                if(state != null){
                    Write($"State: {state}");
                }
                if(exception != null){
                    Write($"Exception: {exception.Message}");
                }
                WriteLine();
            }
        }
    }
}
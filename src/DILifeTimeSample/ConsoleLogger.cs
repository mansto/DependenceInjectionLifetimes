using DILifeTimeSample.Contracts;
using System;

namespace DILifeTimeSample
{
    public class ConsoleLogger : ILogger
    {
        public ITransient Transient { get; }
        public IScoped Scoped { get; }
        public ISingleton Singleton { get; }
        public ISingletonInstance SingletonInstance { get; }

        public ConsoleLogger(
            ITransient transient,
            IScoped scoped,
            ISingleton singleton,
            ISingletonInstance instance)
        {
            Transient = transient;
            Scoped = scoped;
            Singleton = singleton;
            SingletonInstance = instance;
        }

        public void Log(Action<string> logAction)
        {
            logAction?.Invoke($"{nameof(Transient)}: {Transient.Id}");
            logAction?.Invoke($"{nameof(Scoped)}: {Scoped.Id}");
            logAction?.Invoke($"{nameof(Singleton)}: {Singleton.Id}");
            logAction?.Invoke($"{nameof(SingletonInstance)}: {SingletonInstance.Id}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DILifeTimeSample.Contracts
{
    public interface ILogger
    {
        void Log(Action<string> logAction);
    }
}

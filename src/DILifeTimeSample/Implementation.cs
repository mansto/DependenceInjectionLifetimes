using DILifeTimeSample.Contracts;
using System;

namespace DILifeTimeSample
{
    public class Implementation : ITransient, IScoped, ISingleton, ISingletonInstance
    {
        public Guid Id { get; private set; }

        public Implementation()
            :this(Guid.NewGuid())
        {

        }
        public Implementation(Guid guid)
        {
            Id = guid;
        }
    }
}

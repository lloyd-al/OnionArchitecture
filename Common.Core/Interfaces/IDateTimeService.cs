using System;

namespace OnionArchitecture.Common.Core.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}

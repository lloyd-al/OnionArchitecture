using System;
using OnionArchitecture.Common.Core.Interfaces;


namespace OnionArchitecture.Common.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}

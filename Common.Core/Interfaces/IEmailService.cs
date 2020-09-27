using System.Threading.Tasks;
using OnionArchitecture.Common.Core.Entities;

namespace OnionArchitecture.Common.Core.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailRequest request);
        Task SendWelcomeEmailAsync(WelcomeEmailRequest request);
    }
}

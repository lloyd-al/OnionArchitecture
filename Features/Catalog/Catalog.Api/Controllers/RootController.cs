using System;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Common.Core.Interfaces;


namespace OnionArchitecture.Catalog.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RootController : ControllerBase
    {
        protected readonly ILoggerManager _logger;

        public RootController(ILoggerManager logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}

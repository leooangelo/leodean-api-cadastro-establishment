using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MS.Establishment.Domain.Helpers;
using System;
using System.Linq;

namespace MS.Establishment.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _log;

        private Guid? AppEstablishmentId;

        public BaseController(ILogger<BaseController> log)
        {
            _log = log;
        }

        public BaseController(ILogger<BaseController> log, IHttpContextAccessor httpContextAccessor)
        {
            _log = log;
        }

        protected IActionResult CustomResponse(object result = null)
        {
            if (result == null || (ConvertToListHelper.Try(result) && !ConvertToListHelper.Any(result)))
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}
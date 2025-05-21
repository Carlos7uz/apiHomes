using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace apiHomes.Controllers
{
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly JsonSerializerOptions _settings = new()
        {
            WriteIndented = true
        };

        public PingController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var response = await Task.FromResult(new
            {
                AppName = AppDomain.CurrentDomain.FriendlyName,
                Environment = _config["Environment"],
                DateTimeOffset.Now,
                Git = new
                {
                    ThisAssembly.Git.Branch,
                    ThisAssembly.Git.Commit,
                    ThisAssembly.Git.CommitDate,
                    ThisAssembly.Git.IsDirty,
                    ThisAssembly.Git.Sha
                }
            });

            return new JsonResult(response, _settings);
        }
    }
}

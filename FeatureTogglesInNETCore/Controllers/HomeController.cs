using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureTogglesInNETCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IFeatureManager _featureManager;

        public HomeController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }
        
        [HttpGet("FeatureA")]
        [FeatureGate(MyFeatureFlags.FeatureA)]
        public IActionResult GetA()
        {
            return Ok("Feature A works!");
        }

        [HttpGet("FeatureB")]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> GetB()
        {
            if (await _featureManager.IsEnabledAsync(nameof(MyFeatureFlags.FeatureA)))
            {
                return Ok("Feature B is enabled");
            }

            return Ok("Feature B is NOT enabled");
        }

        [HttpGet("FeatureC")]
        [FeatureGate(MyFeatureFlags.FeatureC)]
        public IActionResult GetC()
        {
            return Ok("Feature C works");
        }
    }
}
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
            return Ok("Home controller works!");
        }

        [HttpGet("FeatureB")]
        [ApiExplorerSettings(IgnoreApi = false)]
        public IActionResult GetB()
        {
            return Ok("Home controller works!");
        }

        [HttpGet("FeatureC")]
        [FeatureGate(MyFeatureFlags.FeatureC)]
        public IActionResult GetC()
        {
            return Ok("Feature C works");
        }
    }
}
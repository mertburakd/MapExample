using MapExample.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MapExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public StoreController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("FindNearestStore")]
        public IActionResult FindNearestStore(decimal userLatitude, decimal userLongitude)
        {
            try
            {
                var nearestList = _dbContext.Stores.ToList();
                var nearestStore=
                    nearestList.OrderBy(s => CalculateDistance(s.Latitude, s.Longitude, userLatitude, userLongitude))
                    .FirstOrDefault();

                if (nearestStore == null)
                    return NotFound();

                return Ok(nearestStore);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        private decimal CalculateDistance(decimal lat1, decimal lon1, decimal lat2, decimal lon2)
        {
            double r = 6371; 
            double dLat = (double)DegreeToRadian((double)lat2 - (double)lat1);
            double dLon = (double)DegreeToRadian((double)lon2 - (double)lon1);
            double a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(DegreeToRadian((double)lat1)) * Math.Cos(DegreeToRadian((double)lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = r * c;
            return (decimal)d;
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}

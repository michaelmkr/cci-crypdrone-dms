using CrypDrone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrypDrone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DronesController : ControllerBase
    {
        private List<Drone> droneList = new List<Drone>();
        private IMemoryCache _memoryCache;
        public DronesController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            droneList = memoryCache.Get("list") as List<Drone>;
            if (droneList == null) droneList = new List<Drone>();
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Drone> Get()
        {
            return droneList;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Drone Get(int id)
        {
            return droneList[id];
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Drone value)
        {
            droneList.Add(value);
            _memoryCache.Set("list", droneList);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Drone value)
        {
            int index = droneList.FindIndex(d => d.droneId == id);
            droneList.RemoveAt(index);
            droneList.Add(value);
            _memoryCache.Set("list", droneList);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            int index = droneList.FindIndex(d => d.droneId == id);
            droneList.RemoveAt(index);
            _memoryCache.Set("list", droneList);
        }
    }
}

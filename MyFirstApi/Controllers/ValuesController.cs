using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private string[] _values = new string[] {"value1", "value2", "value3"};

        [HttpGet]
        public IEnumerable<string> get()
        {
            return _values;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            id--;

            if(id > 2)
            {
                return NotFound();
            }

            return Ok(_values[id]);
        }

    }
}

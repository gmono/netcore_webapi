using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiteDB;
namespace webapi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TestModel Get(string id)
        {
            using(var db=new LiteDatabase(@"MyLite.db"))
            {
                var dataset=db.GetCollection<TestModel>("UserInfo");
                var testdata=new TestModel()
                {
                    Name="高子健",
                    Nicks=new string[]{"Gmono","上清","月落"},
                    BirthDay=new DateTime(1997,4,11),
                    UserId="gaozijian",
                    PassWord="testpassword"
                };
                dataset.Insert(testdata);
                testdata.PassWord="testpass";
                dataset.Update(testdata);
                dataset.EnsureIndex(x=>x.UserId);

                var result=dataset.Find(x=>x.UserId==id.ToString());
                return result.First();
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

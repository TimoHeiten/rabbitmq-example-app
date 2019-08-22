using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using Udemy.Merchant.Bus.Messages;
using Udemy.Merchant.Bus.Model;
using Udemy.Merchant.Rest.Model;

namespace Udemy.Merchant.Rest.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IBus _bus;
        public ValuesController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet]
        [Route("products")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var request = new ProductRequest();
            try
            {
                var response = await _bus.RequestAsync<ProductRequest, ProductResponse>(request);
                return Ok(response.Products);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest($"failed to catch response:\n{ex.Message}");
            }
            
        }


        [HttpPut("order")]
        public async Task<ActionResult> PutOrder(OrderInput order)
        {
            try
            {
                order.CustomerId = int.Parse(HttpContext.Request.Headers["CustomerId"]);
                await _bus.PublishAsync<PutOrderNotification>(
                    new PutOrderNotification
                    {
                        Order = new OrderMessage
                        {
                            ProductIds = order.ProductIds,
                            CustomerId = order.CustomerId,
                            SupplierId = order.SupplierId
                        }
                    }
                );

                return Ok(order);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest($"{ex}");
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

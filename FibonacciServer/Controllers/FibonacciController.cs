using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FibonacciServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        private readonly IReversedCollection<RowOfNumbers> _fibonacciReversedRows;
        private readonly ILogger<FibonacciController> _logger;
        public FibonacciController(ILogger<FibonacciController> logger, IReversedCollection<RowOfNumbers> fibonacciReversedRows)
        {
            _logger = logger;
            _fibonacciReversedRows = fibonacciReversedRows;
        }
      [HttpGet]
      public ActionResult GetReversedNumbers()
        {
            ICollection<RowOfNumbers> numbers = _fibonacciReversedRows.GetReversedResults();
            if (numbers.Count <= 0)
            {
                return NotFound();
            }
            return Ok(numbers);
        }
        [HttpPost]
        public ActionResult PostNumbers([FromBody] string text)
        {
            if ( text == null||text==" ")
            {
                return BadRequest();
            }
            ICollection<RowOfNumbers> numbers;
            try
            {
                 numbers = _fibonacciReversedRows.Add(TextTransformator.TakeNumbersFromText(text));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            if (numbers.Count <= 0)
            {
                return BadRequest("No Fibonacci rows were found");
            }
            return Ok(numbers);
        }
        [HttpDelete]
        public ActionResult ClearRows()
        {
            try
            {
                _fibonacciReversedRows.Clear();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}

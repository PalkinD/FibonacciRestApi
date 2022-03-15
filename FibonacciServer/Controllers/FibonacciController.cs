using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NLog;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FibonacciServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        private readonly IReversedCollection<RowOfNumbers> _fibonacciReversedRows;
        private readonly ILogger<FibonacciController> _logger;
        private static Logger _fileLogger;
        public FibonacciController(ILogger<FibonacciController> logger, IReversedCollection<RowOfNumbers> fibonacciReversedRows)
        {
            _fileLogger = LogManager.GetCurrentClassLogger();
            _logger = logger;
            _fibonacciReversedRows = fibonacciReversedRows;
        }
      [HttpGet]
      public ActionResult GetAllReversedNumbers()
        {
            _logger.LogInformation($"GetReverseNumbers was used at {DateTime.Now:hh:mm:ss}");
            if (_fibonacciReversedRows.Count <= 0)
            {
                _logger.LogError(NotFound().ToString());
                return NotFound();
            }
            return Ok(_fibonacciReversedRows.GetReversedResults());
        }
        [HttpGet("{id}")]
        public ActionResult GetOneArrayOfReversedNumbers(int id)
        {
            _logger.LogInformation($"GetOneArrayOfReversedNumbers was used at {DateTime.Now:hh:mm:ss}");
            if (_fibonacciReversedRows.Count <= 0)
            {
                _logger.LogError(NotFound().ToString());
                return NotFound();
            }
            string result;
            try
            {
                result = _fibonacciReversedRows.GetOneReversedResult(id);
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }
        [HttpPost]
        public ActionResult PostNumbers([FromBody] string text)
        {
            string message = $"PostNumbers was used at {DateTime.Now:hh:mm:ss}";
            doubleLogInfo(message);

            if ( text == null||text==" ")
            {
                _logger.LogError("Empty request was sent");
                return BadRequest("Empty Request");
            }
            message = text + " such string was sent";
            doubleLogInfo(message);

            List<RowOfNumbers> numbers;
            try
            {
                 numbers = _fibonacciReversedRows.Add(TextMaster.TakeNumbersFromText(text));
            }catch(Exception ex)
            {
                doubleLogError(ex.Message);
                return BadRequest(ex.Message);
            }
            if (numbers.Count <= 0)
            {
                message = "No Fibonacci rows were found";
                doubleLogError(message);
                return BadRequest(message);
            }
            message = "Maden reversed rows :"+TextMaster.GetResultsInText(numbers);
            doubleLogInfo(message);

            return Ok(TextMaster.GetResultsInText(numbers));
        }
        [HttpDelete]
        public ActionResult ClearRows()
        {
            _logger.LogInformation($"ClearRows was used at {DateTime.Now:hh:mm:ss}");
            try
            {
                _fibonacciReversedRows.Clear();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteOneArrayOfRows(int id)
        {
            _logger.LogInformation($"DeleteOneArrayOfRows was used at {DateTime.Now:hh:mm:ss}");
            if (_fibonacciReversedRows.Count <= 0)
            {
                _logger.LogError(NotFound().ToString());
                return NotFound();
            }
            try
            {
                _fibonacciReversedRows.Delete(id);
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        private void doubleLogInfo(string message)
        {
            _logger.LogInformation(message);
            _fileLogger.Info(message);
        }
        private void doubleLogError(string message)
        {
            _logger.LogError(message);
            _fileLogger.Error(message);
        }
    }
}

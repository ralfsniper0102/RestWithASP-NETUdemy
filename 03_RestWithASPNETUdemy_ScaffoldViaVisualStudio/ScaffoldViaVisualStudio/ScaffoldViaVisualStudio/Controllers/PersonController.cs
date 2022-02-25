using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace ScaffoldViaVisualStudio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {


        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var sub = (ConvertToDecimal(firstNumber)) - (ConvertToDecimal(secondNumber));
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(div.ToString());
            }
            return BadRequest("Invalid Input");
        }


        [HttpGet("avg/{firstNumber}/{secondNumber}")]
        public IActionResult Averag(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var avg = ((ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2);
                return Ok(avg.ToString());
            }
            return BadRequest("Invalid Input");
        }


        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var avg = (ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber));
                return Ok(avg.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sqrt/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var sqrt = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(sqrt.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                 out decimalValue))
            {
                return decimalValue;
            }


            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }
    }
}

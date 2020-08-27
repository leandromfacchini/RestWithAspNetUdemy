using System;
using Microsoft.AspNetCore.Mvc;

namespace Calculadora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        [HttpGet("soma/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid input!");

            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

            return Ok(sum.ToString());
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid input!");

            var subtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

            return Ok(subtraction);
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid input!");

            var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

            return Ok(multiplication);
        }


        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid input!");

            var secondNumberConvert = ConvertToDecimal(secondNumber);

            if (secondNumberConvert.Equals(0)) return BadRequest("Invalid operator!");

            var division = ConvertToDecimal(firstNumber) / secondNumberConvert;

            return Ok(division);
        }


        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;

            if (decimal.TryParse(number, out decimalValue)) return decimalValue;

            return 0;
        }

        private bool IsNumeric(string number)
        {
            return double.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out double valor);
        }
    }
}
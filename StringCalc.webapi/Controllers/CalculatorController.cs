using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StringCalc.core;

namespace StringCalc.webapi.Controllers 
{
    [Route("api/calculator")]
    public class CalculatorController : Controller
    {
        private readonly IStringCalculator _calculator = null;

        public CalculatorController(IStringCalculator calculator) {
            _calculator = calculator;
        }
        
        [HttpGet("add/{values}")]
        public int Add(string values) 
        {
            return _calculator.Add(values);
        }
    }
}
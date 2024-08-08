using Microsoft.AspNetCore.Mvc;
using WebApplication1.Modells;
using System.Globalization;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("API/PESSOA")]
    public class PessoaController : ControllerBase
    {

        [HttpPost]
        [Route("ReceberDados")]
        public IActionResult ReceberDados(Pessoa _pessoa)
        {
            if (_pessoa.Altura <= 0 || _pessoa.Peso <= 0)
            {
                return BadRequest("Peso e altura devem ser maiores que zero.");
            }

            double IMC = _pessoa.CalcularIMC();
            return Ok($"{_pessoa.Nome.ToString(CultureInfo.InvariantCulture)} tem {_pessoa.Altura.ToString("F2", CultureInfo.InvariantCulture)} metros e tem IMC igual a {IMC.ToString(CultureInfo.InvariantCulture)}");
        }


        [HttpPost]
        [Route("ConsultarTabelaIMC")]
        public IActionResult ConsultarTabelaIMC(Pessoa _pessoa) 
        {
            if (_pessoa.Altura <= 0 || _pessoa.Peso <= 0)
            {
                return BadRequest("Peso e altura devem ser maiores que zero.");
            }

            double IMC = _pessoa.CalcularIMC();

            if (IMC < 18.5)
            {
                return Ok("Muito abaixo do peso.");
            }

            else if(IMC >= 18.6 && IMC <= 24.9)
            {
                return Ok("Abaixo do peso");
            }

            else if (IMC >= 25 && IMC <= 29.9)
            {
                return Ok("Acima do peso");
            }

            else if (IMC >= 30 && IMC <= 34.9)
            {
                return Ok("Obsedidade grau I");
            }

            else if (IMC >= 35 && IMC <= 39.9)
            {
                return Ok("Obsedidade grau II");
            }
            return Ok("Obesidade grau III");
        }
    }
}

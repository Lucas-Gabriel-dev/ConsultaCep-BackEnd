using System.Net;
using ConsultaCep.src.Context;
using ConsultaCep.src.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsultaCep.src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultarCepController : ControllerBase
    {
        private readonly CepContext _context;

        public ConsultarCepController(CepContext context)
        {
            _context = context;
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> GetPlaceInDatabase(string cep)
        {
            try
            {
                string numberCep = cep;
                cep = "";

                foreach (var item in numberCep)
                {
                    if(item != '-')
                    {
                        cep += item;
                    }
                }


                if(cep.Length != 8 || string.IsNullOrWhiteSpace(cep))
                {
                    return BadRequest(new {
                        msg = "Invalid CEP"
                    });
                }

                var logradouro = _context.Ceps.FirstOrDefault(x => x.cep == cep);

                if(logradouro == null)
                {
                    return NotFound(new {
                        msg = "Cep not found"
                    });
                }

                return Ok(logradouro);
            } catch (System.Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("uf/{uf}")]
        public async Task<IActionResult> AllCepsInRegion(string uf)
        {
            try
            {
                if(uf.Length != 2 || string.IsNullOrWhiteSpace(uf))
                {
                    return BadRequest(new {
                        msg = "UF is invalid!"
                    });
                }

                var allCeps = _context.Ceps.Where(x => x.uf == uf.ToUpper()).ToList();

                if(!allCeps.Any())
                {
                    return NotFound(new{
                        msg = "No record found"
                    });
                }

                return Ok(allCeps);
            } catch (System.Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPost("AddCep/{cep}")]
        public async Task<IActionResult> AddCep(string cep)
        {   
            try
            {
                string numberCep = cep;
                cep = "";

                foreach (var item in numberCep)
                {
                    if(item != '-')
                    {
                        cep += item;
                    }
                }

                if(cep.Length != 8 || string.IsNullOrWhiteSpace(cep))
                {
                    return BadRequest(new {
                        msg = "Invalid CEP"
                    });
                }

                var checkCepAdded = _context.Ceps.FirstOrDefault(x => x.cep == cep);

                if(checkCepAdded != null)
                {
                    return BadRequest(new {
                        msg = "The Cep has already been added to the database!",
                        checkCepAdded
                    });
                }
                
                string viaCepUrl = $"https://viacep.com.br/ws/{cep}/json/";

                WebClient client = new WebClient();
                string result = client.DownloadString(viaCepUrl);

                Cep jsonRetorno = JsonConvert.DeserializeObject<Cep>(result);

                if(!jsonRetorno.uf.Any()){
                    return BadRequest(new {
                        msg = "Cep not found"
                    });
                }

                jsonRetorno.cep = cep;

                await _context.Ceps.AddAsync(jsonRetorno);
                await _context.SaveChangesAsync();

                return Ok(jsonRetorno);
            } catch (System.Exception error)
            {
                return BadRequest(error);
            }
        }

    }
}
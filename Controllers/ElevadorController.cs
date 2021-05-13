using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProvaAdmissionalCSharpApisul.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElevadorController : ControllerBase
    {
        [HttpGet]
        public List<ElevadorDTO> Get()
        {
            ElevadorService elevador = new ElevadorService();                        
            return elevador.elevadores;
        }

        [HttpGet]
        [Route("AndarMenosUtilizado")]
        public List<int> AndarMenosUtilizado()
        {
            ElevadorService elevador = new ElevadorService();
            return elevador.andarMenosUtilizado();
        }

        [HttpGet]
        [Route("ElevadorMaisFrequentado")]
        public List<char> ElevadorMaisFrequentado()
        {
            ElevadorService elevador = new ElevadorService();            
            return elevador.elevadorMaisFrequentado();
        }
        [HttpGet]
        [Route("PeriodoMaiorFluxoElevadorMaisFrequentado")]
        public List<char> PeriodoMaiorFluxoElevadorMaisFrequentado()
        {
            ElevadorService elevador = new ElevadorService();            
            return elevador.periodoMaiorFluxoElevadorMaisFrequentado();
        }
        [HttpGet]
        [Route("ElevadorMenosFrequentado")]
        public List<char> ElevadorMenosFrequentado()
        {
            ElevadorService elevador = new ElevadorService();            
            return elevador.elevadorMenosFrequentado();
        }
        [HttpGet]
        [Route("PeriodoMenorFluxoElevadorMenosFrequentado")]
        public List<char> PeriodoMenorFluxoElevadorMenosFrequentado()
        {
            ElevadorService elevador = new ElevadorService();            
            return elevador.periodoMenorFluxoElevadorMenosFrequentado();
        }

        [HttpGet]
        [Route("PeriodoMaiorUtilizacaoConjuntoElevadores")]
        public List<char> PeriodoMaiorUtilizacaoConjuntoElevadores()
        {
            ElevadorService elevador = new ElevadorService();            
            return elevador.periodoMaiorUtilizacaoConjuntoElevadores();
        }

        [HttpGet]
        [Route("PercentualDeUsoElevadorA")]
        public float PercentualDeUsoElevadorA()
        {
            ElevadorService elevador = new ElevadorService();
            return elevador.percentualDeUsoElevadorA();
        }

        [HttpGet]
        [Route("PercentualDeUsoElevadorB")]
        public float PercentualDeUsoElevadorB()
        {
            ElevadorService elevador = new ElevadorService();
            return elevador.percentualDeUsoElevadorB();
        }

        [HttpGet]
        [Route("PercentualDeUsoElevadorC")]
        public float PercentualDeUsoElevadorC()
        {
            ElevadorService elevador = new ElevadorService();
            return elevador.percentualDeUsoElevadorC();
        }

        [HttpGet]
        [Route("PercentualDeUsoElevadorD")]
        public float PercentualDeUsoElevadorD()
        {
            ElevadorService elevador = new ElevadorService();
            return elevador.percentualDeUsoElevadorD();
        }

        [HttpGet]
        [Route("PercentualDeUsoElevadorE")]
        public float PercentualDeUsoElevadorE()
        {
            ElevadorService elevador = new ElevadorService();
            return elevador.percentualDeUsoElevadorE();
        }
    }
}

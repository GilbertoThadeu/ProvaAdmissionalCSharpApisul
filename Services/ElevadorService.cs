using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ProvaAdmissionalCSharpApisul
{
    public class ElevadorService : IElevadorService
    {
        public List<ElevadorDTO> elevadores { get; set; }

        private void CarregaElevador()
        {

            try
            {
                if (elevadores == null)
                {
                    string conteudoArquivo = System.IO.File.ReadAllText(@"input.json");
                    elevadores = JsonSerializer.Deserialize<List<ElevadorDTO>>(conteudoArquivo);
                }
            }
            catch
            {
                elevadores = new List<ElevadorDTO>();
            }
        }

        private float percentualDeUsoElevador(char elevador)
        {
            float usoTotal, usoElevador, retorno;

            CarregaElevador();

            usoTotal = elevadores.Count();
            usoElevador = elevadores.Where(x => x.elevador.Equals(elevador)).Count();

            if (usoElevador == 0)
                retorno = 0.00f;
            else
                retorno = usoElevador * 100 / usoTotal;
            return float.Parse(retorno.ToString("0.00"));
        }

        public List<int> andarMenosUtilizado()
        {
            CarregaElevador();

            List<int> retorno = new List<int>();

            var query = elevadores.GroupBy(
                x => Math.Floor(x.andar),
                x => x.andar,
                (baseAndar, andares) => new
                {
                    Key = baseAndar,
                    Count = andares.Count(),
                    Min = andares.Min(),
                    Max = andares.Max()
                }).OrderBy(x => x.Key);

            foreach (var item in query)
            {
                if (retorno.Count == 0)
                {
                    retorno.Add(Convert.ToUInt16(item.Key));
                }
                else if (item.Count == retorno[retorno.Count - 1])
                {
                    retorno.Add(Convert.ToUInt16(item.Key));
                }
                else
                    break;
            }

            return retorno;
        }

        public List<char> elevadorMaisFrequentado()
        {
            int totalAnterior = 0;
            CarregaElevador();

            List<char> retorno = new List<char>();

            var query = elevadores.GroupBy(
                x => x.elevador).Select(x => new
                {
                    nome = x.Key,
                    total = x.Count()
                }).OrderByDescending(x => x.total);

            foreach (var item in query)
            {
                if (retorno.Count == 0)
                {
                    retorno.Add(Convert.ToChar(item.nome));
                    totalAnterior = item.total;
                }
                else if (item.total == totalAnterior)
                {
                    retorno.Add(Convert.ToChar(item.nome));
                }
                else
                    break;
            }

            return retorno;
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            int incidenciaAnterior = 0;
            List<char> retorno = new List<char>();
            CarregaElevador();

            var query = elevadores.GroupBy(x => x.elevador).Select(x => new
            {
                elevador = x.Key,
                quantidade = x.Count(),
                turnos = x.GroupBy(z => z.turno).Select(x => new
                {
                    periodo = x.Key,
                    incidencia = x.Count()
                }).OrderByDescending(x => x.incidencia)
            }).OrderByDescending(x => x.quantidade);

            foreach (var item in query)
            {
                if (retorno.Count == 0)
                {
                    foreach (var turnoAtual in item.turnos)
                    {
                        if (retorno.Count == 0)
                        {
                            retorno.Add(turnoAtual.periodo);
                            incidenciaAnterior = turnoAtual.incidencia;
                        }
                        else if (incidenciaAnterior == turnoAtual.incidencia)
                        {
                            retorno.Add(turnoAtual.periodo);
                        }
                        else
                            break;
                    }
                }
                else
                {
                    foreach (var turnoAtual in item.turnos)
                    {
                        if (incidenciaAnterior == turnoAtual.incidencia)
                        {
                            retorno.Add(turnoAtual.periodo);
                        }
                        else
                            break;
                    }
                }
            }

            retorno = retorno.Distinct().ToList();

            return retorno;
        }

        public List<char> elevadorMenosFrequentado()
        {
            int totalAnterior = 0;
            CarregaElevador();

            List<char> retorno = new List<char>();

            var query = elevadores.GroupBy(
                x => x.elevador).Select(x => new
                {
                    nome = x.Key,
                    total = x.Count()
                }).OrderBy(x => x.total);

            foreach (var item in query)
            {
                if (retorno.Count == 0)
                {
                    retorno.Add(Convert.ToChar(item.nome));
                    totalAnterior = item.total;
                }
                else if (item.total == totalAnterior)
                {
                    retorno.Add(Convert.ToChar(item.nome));
                }
                else
                    break;
            }

            return retorno;
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            int incidenciaAnterior = 0;
            List<char> retorno = new List<char>();
            CarregaElevador();

            var query = elevadores.GroupBy(x => x.elevador).Select(x => new
            {
                elevador = x.Key,
                quantidade = x.Count(),
                turnos = x.GroupBy(z => z.turno).Select(x => new
                {
                    periodo = x.Key,
                    incidencia = x.Count()
                }).OrderBy(x => x.incidencia)
            }).OrderBy(x => x.quantidade);

            foreach (var item in query)
            {
                if (retorno.Count == 0)
                {
                    foreach (var turnoAtual in item.turnos)
                    {
                        if (retorno.Count == 0)
                        {
                            retorno.Add(turnoAtual.periodo);
                            incidenciaAnterior = turnoAtual.incidencia;
                        }
                        else if (incidenciaAnterior == turnoAtual.incidencia)
                        {
                            retorno.Add(turnoAtual.periodo);
                        }
                        else
                            break;
                    }
                }
                else
                {
                    foreach (var turnoAtual in item.turnos)
                    {
                        if (incidenciaAnterior == turnoAtual.incidencia)
                        {
                            retorno.Add(turnoAtual.periodo);
                        }
                        else
                            break;
                    }
                }
            }

            retorno = retorno.Distinct().ToList();

            return retorno;
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            int totalAnterior = 0;
            CarregaElevador();

            List<char> retorno = new List<char>();

            var query = elevadores.GroupBy(
                x => x.turno).Select(x => new
                {
                    nome = x.Key,
                    total = x.Count()
                }).OrderByDescending(x => x.total);

            foreach (var item in query)
            {
                if (retorno.Count == 0)
                {
                    retorno.Add(Convert.ToChar(item.nome));
                    totalAnterior = item.total;
                }
                else if (item.total == totalAnterior)
                {
                    retorno.Add(Convert.ToChar(item.nome));
                }
                else
                    break;
            }

            return retorno;
        }

        public float percentualDeUsoElevadorA()
        {
            return percentualDeUsoElevador('A');
        }

        public float percentualDeUsoElevadorB() { return percentualDeUsoElevador('B'); }

        public float percentualDeUsoElevadorC() { return percentualDeUsoElevador('C'); }

        public float percentualDeUsoElevadorD() { return percentualDeUsoElevador('D'); }

        public float percentualDeUsoElevadorE() { return percentualDeUsoElevador('E'); }
    }
}

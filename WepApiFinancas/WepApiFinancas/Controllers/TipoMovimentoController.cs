﻿using BancoDeDadosFinancas;
using Newtonsoft.Json.Linq;
using RegraDeNegocioFinancas;
using System.Threading.Tasks;
using System.Web.Http;

namespace WepApiFinancas.Controllers
{
    [RoutePrefix("tipomovimento")]
    public class TipoMovimentoController : ApiController
    {

        [HttpPost]
        [ActionName("obtemporcodigo")]
        public async Task<IHttpActionResult> ObtemPorCodigo([FromBody] JObject jsonData)
        {
            dynamic json = jsonData;
            int codigo = json.Codigo;

            var resposta = new TipoMovimentoNegocio().PegaPorCodigo(codigo);

            if (resposta == null) return Ok(new ADSResposta(false, "TipoMovimento não encontrada.", resposta));

            return Ok(new ADSResposta(true, objeto: resposta));
        }

        [HttpPost]
        [ActionName("salvar")]
        public async Task<IHttpActionResult> Salvar([FromBody] JObject jsonData)
        {
            TipoMovimentoView tipomovimento = jsonData.SelectToken("TipoMovimento").ToObject<TipoMovimentoView>();

            return Ok((new TipoMovimentoNegocio().Salvar(tipomovimento)));
        }

        [HttpPost]
        [ActionName("obtem")]
        public async Task<IHttpActionResult> Obtem()
        {
            var resposta = new TipoMovimentoNegocio().PegaTodas();

            if (resposta == null || resposta.Count == 0)
            {
                return Ok(new ADSResposta(false, "Nenhum registro encontrado.", resposta));
            }

            return Ok(new ADSResposta(true, "", resposta));
        }

        [HttpPost]
        [ActionName("excluir")]
        public async Task<IHttpActionResult> Excluir([FromBody] JObject jsonData)
        {
            TipoMovimentoView tipomovimento = jsonData.SelectToken("TipoMovimento").ToObject<TipoMovimentoView>();

            return Ok((new TipoMovimentoNegocio().Excluir(tipomovimento)));
        }

    }
}


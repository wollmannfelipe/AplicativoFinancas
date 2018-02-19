using BancoDeDadosFinancas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RegraDeNegocioFinancas
{
    public class TipoMovimentoNegocio
    {
        public ADSResposta Salvar(TipoMovimentoView c)
        {
            var db = DBCore.InstanciaDoBanco();

            TipoMovimento novo = null;

            if (!c.Codigo.Equals("0"))
            {
                var id = int.Parse(c.Codigo);
                novo = db.TipoMovimento.Where(w => w.Codigo.Equals(id)).FirstOrDefault();
                novo.Descricao = c.Descricao;
            }
            else
            {
                novo = db.TipoMovimento.Create();
                novo.Descricao = c.Descricao;

                db.TipoMovimento.Add(novo);
            }

            try
            {
                db.SaveChanges();

                c.Codigo = novo.Codigo.ToString();

                return new ADSResposta(true, objeto: c);
            }
            catch (Exception ex)
            {
                return new ADSResposta(false, ex.Message, c);
            }
        }

        public ADSResposta Excluir(TipoMovimentoView c)
        {
            try
            {
                using (var db = DBCore.NovaInstanciaDoBanco())
                {
                    var id = int.Parse(c.Codigo);
                    var conta = db.TipoMovimento.Where(w => w.Codigo.Equals(id)).FirstOrDefault();

                    if (conta == null)
                    {
                        return new ADSResposta(sucesso: false, mensagem: "Tipo Movimento não encontrada.", objeto: c);
                    }

                    db.TipoMovimento.Remove(conta);

                    db.SaveChanges();

                    return new ADSResposta(sucesso: true, objeto: conta);
                }
            }
            catch (Exception ex)
            {
                return new ADSResposta(false, ex.Message, c);
            }
        }

        public TipoMovimentoView ConverteParaView(TipoMovimento c)
        {
            if (c == null) return null;

            return new TipoMovimentoView
            {
                Codigo = c.Codigo.ToString(),
                Descricao = c.Descricao
            };
        }

        public List<TipoMovimentoView> PegaTodas()
        {
            var tipomovimento = DBCore.InstanciaDoBanco().TipoMovimento.ToList();

            var resposta = new List<TipoMovimentoView>();
            foreach (var c in tipomovimento)
            {
                resposta.Add(ConverteParaView(c));
            }

            return resposta;
        }

        public TipoMovimentoView PegaPorCodigo(int id)
        {
            var conta = DBCore.InstanciaDoBanco().TipoMovimento
                .Where(w => w.Codigo.Equals(id))
                .FirstOrDefault();

            TipoMovimentoView resposta = null;

            if (conta != null)
            {
                resposta = ConverteParaView(conta);
            }

            return resposta;
        }
    }
}
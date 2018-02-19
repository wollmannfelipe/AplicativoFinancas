﻿using BancoDeDadosFinancas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RegraDeNegocioFinancas
{
    public class ContaNegocio
    {
        public ADSResposta Salvar(ContaView c)
        {
            var db = DBCore.InstanciaDoBanco();

            Conta novo = null;

            if (!c.Codigo.Equals("0"))
            {
                var id = int.Parse(c.Codigo);
                novo = db.Contas.Where(w => w.Codigo.Equals(id)).FirstOrDefault();
                novo.Descricao = c.Descricao;
            }
            else
            {
                novo = db.Contas.Create();
                novo.Descricao = c.Descricao;

                db.Contas.Add(novo);
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

        public ADSResposta Excluir(ContaView c)
        {
            try
            {
                using (var db = DBCore.NovaInstanciaDoBanco())
                {
                    var id = int.Parse(c.Codigo);
                    var conta = db.Contas.Where(w => w.Codigo.Equals(id)).FirstOrDefault();

                    if (conta == null)
                    {
                        return new ADSResposta(sucesso: false, mensagem: "Conta não encontrada.", objeto: c);
                    }

                    db.Contas.Remove(conta);

                    db.SaveChanges();

                    return new ADSResposta(sucesso: true, objeto: conta);
                }
            }
            catch (Exception ex)
            {
                return new ADSResposta(false, ex.Message, c);
            }
        }

        public ContaView ConverteParaView(Conta c)
        {
            if (c == null) return null;

            return new ContaView
            {
                Codigo = c.Codigo.ToString(),
                Descricao = c.Descricao
            };
        }

        public List<ContaView> PegaTodas()
        {
            var contas = DBCore.InstanciaDoBanco().Contas.ToList();

            var resposta = new List<ContaView>();
            foreach (var c in contas)
            {
                resposta.Add(ConverteParaView(c));
            }

            return resposta;
        }

        public ContaView PegaPorCodigo(int id)
        {
            var conta = DBCore.InstanciaDoBanco().Contas
                .Where(w => w.Codigo.Equals(id))
                .FirstOrDefault();

            ContaView resposta = null;

            if (conta != null)
            {
                resposta = ConverteParaView(conta);
            }

            return resposta;
        }
    }
}
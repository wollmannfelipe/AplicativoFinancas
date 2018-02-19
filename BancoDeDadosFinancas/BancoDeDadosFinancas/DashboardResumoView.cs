using System.Collections.Generic;

namespace BancoDeDadosFinancas
{
    public class DashBoardResumoView
    {
        public DashBoardResumo DashBoardResumo { get; set; }
        public List<ExtratoCategoriaView> Categorias { get; set; }
    }

    public class DashBoardResumo
    {
        public decimal DespesasAberto { get; set; }
        public decimal ReceitasAberto { get; set; }
        public decimal SaldoContas { get; set; }
    }
}
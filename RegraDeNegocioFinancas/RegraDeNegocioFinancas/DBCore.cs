namespace RegraDeNegocioFinancas
{
    using BancoDeDadosFinancas;

    public static class DBCore
    {
        private static DBContext ctx;

        public static DBContext InstanciaDoBanco()
        {
            if (ctx == null)
            {
                ctx = new DBContext();
            }

            return ctx;
        }

        public static DBContext NovaInstanciaDoBanco()
        {
            return new DBContext();
        }
    }
}
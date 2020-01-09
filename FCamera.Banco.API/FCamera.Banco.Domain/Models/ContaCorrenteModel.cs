namespace FCamera.Banco.Domain
{
    public class ContaCorrenteModel
    {
        public int NumeroConta { get; set; }

        public string Correntista { get; set; }

        public float Saldo { get; set; } = 0;

        public ContaCorrenteModel(string corre, int nConta)
        {
            NumeroConta = nConta;
            Correntista = corre;
        }
    }
}

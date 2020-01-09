using System.Collections.Generic;

namespace FCamera.Banco.Domain
{
    public class LancamentosModel
    {
        private ContaCorrenteModel _c1;

        public LancamentosModel(ContaCorrenteModel c1)
        {
            _c1 = c1;
        }

        public bool Deposita(ContaCorrenteModel c2, double valor, out string message)
        {
            if (valor > 0)
            {
                c2.Saldo += (float)valor;
            }

            message = "SEU SALDO ATUAL É : " + c2.Saldo.ToString();
            return true;
        }

        public bool Transfere(double valor, ContaCorrenteModel c2, out List<string> message)
        {
            message = new List<string>();
            string msg;
            string msgSaque;
            if (c2 == null || valor > _c1.Saldo)
            {
                return false;
            }
            Saque(valor, out msgSaque);
            message.Add(msgSaque);

            Deposita(c2, valor, out msg);
            message.Add(msg);

            message.Add("transferiencia feita com sucesso");
            return true;
        }

        public bool Saque(double valor, out string message)
        {
            if (valor > 0 || _c1.Saldo > valor)
            {
                _c1.Saldo -= (float)valor;
            }
            message = "RETIRADO DO :" + valor.ToString() + " SALDO ATUAL É : " + _c1.Saldo.ToString();
            return true;
        }
    }
}

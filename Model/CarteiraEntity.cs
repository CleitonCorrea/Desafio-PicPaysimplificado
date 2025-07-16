namespace PicPaySimplificado.Model
{
    public class CarteiraEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public decimal SaldoConta { get; set; }
        public UserType TipoUsuario{ get; set; }

        public CarteiraEntity(string nome, string cpfCnpj, string email, string senha, decimal saldoConta, UserType TipoUsuario)
        {
            Nome = nome;
            CpfCnpj = cpfCnpj;
            Email = email;
            Senha = senha;
            SaldoConta = saldoConta;
            TipoUsuario = TipoUsuario;
        }

        //DebitarSaldo method is not implemented yet
        public void DebitarSaldo(decimal valor)
        {
            SaldoConta -= valor;
        }

        //CreditarSaldo method is not implemented yet
        public void CreditarSaldo(decimal valor)
        {
            SaldoConta += valor;
        }

        private CarteiraEntity()
        {
            // EF Core requires a parameterless constructor for entity instantiation
        }

    }


}

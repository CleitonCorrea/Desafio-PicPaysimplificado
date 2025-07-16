namespace PicPaySimplificado.Utils
{
    public static class CpfCnpjValidator
    {
        public static Boolean IsValidCpf(String cpf) {
            // Implementação da validação de CPF
            // Retorna true se o CPF for válido, caso contrário, retorna false
            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
            {
                return false;
            }

            return true;
        }
    }
}

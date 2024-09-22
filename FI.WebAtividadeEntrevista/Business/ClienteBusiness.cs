using FI.AtividadeEntrevista.BLL;
using FI.AtividadeEntrevista.DML;

public static class ClienteBusiness
{
    public static bool ValidarCliente(Cliente cliente, out string erro)
    {
        bool ret = true;
        erro = string.Empty;

        if (!ValidarCPF(cliente.Cpf))
        {
            ret = false;
            erro = "Número de CPF inválido.";
        }

        if (CPFExistente(cliente.Cpf))
        {
            ret = false;
            erro = "CPF já cadastrado.";
        }

        return ret;
    }

    private static bool ValidarCPF(string cpf)
    {
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf;
        string digito;
        int soma;
        int resto;
        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");
        if (cpf.Length != 11)
            return false;
        tempCpf = cpf.Substring(0, 9);
        soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = resto.ToString();
        tempCpf = tempCpf + digito;
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = digito + resto.ToString();
        return cpf.EndsWith(digito);

    }

    private static bool CPFExistente(string cpf)
    {
        BoCliente cli = new BoCliente();

        return cli.VerificarExistencia(cpf);
    }
}

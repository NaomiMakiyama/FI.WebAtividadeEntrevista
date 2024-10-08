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
            erro = "N�mero de CPF inv�lido.";
        }

        if (CPFExistente(cliente.Cpf))
        {
            ret = false;
            erro = "CPF j� cadastrado.";
        }

        return ret;
    }

    private static bool ValidarCPF(string cpf)
    {
        return Utils.ValidarCPF(cpf);
    }

    private static bool CPFExistente(string cpf)
    {
        BoCliente cli = new BoCliente();

        return cli.VerificarExistencia(cpf);
    }
}

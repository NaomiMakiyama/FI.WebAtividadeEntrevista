using FI.AtividadeEntrevista.BLL;
using FI.AtividadeEntrevista.DML;

public static class BeneficiarioBusiness
{
    public static bool ValidarBeneficiario(Beneficiario beneficiario, out string erro)
    {
        bool ret = true;
        erro = string.Empty;

        if (!ValidarCPF(beneficiario.Cpf))
        {
            ret = false;
            erro = "Número de CPF inválido.";
        }

        if (CPFExistente(beneficiario.Cpf))
        {
            ret = false;
            erro = "CPF já cadastrado.";
        }

        return ret;
    }

    private static bool ValidarCPF(string cpf)
    {
        return Utils.ValidarCPF(cpf);
    }

    private static bool CPFExistente(string cpf)
    {
        BoBeneficiario cli = new BoBeneficiario();

        return cli.VerificarExistencia(cpf);
    }
}
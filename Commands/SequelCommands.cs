namespace CEP_HTTP_REQUEST.Commands
{
    internal static class SequelCommands
    {
        internal static string InsertData => 
            @"INSERT INTO bankcep (cep, estado, cidade, bairro, rua, servico) 
                VALUES (@cep, @estado, @cidade, @bairro, @rua, @servico)";
    }
}

using ModalGR_CofreEletronico.ModalGR;


var Cofre = new CofreEletronico();
string senhaCriptografada1;
string senhaCriptografada2;
string senhaCriptografada3;
string senhaTextoPuro1;
string senhaTextoPuro2;
string senhaTextoPuro3;

try
{

    Cofre.ExibeTitulo();

    senhaTextoPuro1 = RepeteEnquantoEntradaInvalida("Digite a primeira senha");
    senhaCriptografada1 = Cofre.PrimeiraCriptografia(senhaTextoPuro1);
    Console.WriteLine("Senha criptografada: " + senhaCriptografada1);
    Console.WriteLine();


    senhaTextoPuro2 = RepeteEnquantoEntradaInvalida("Digite a segunda senha");
    senhaCriptografada2 = Cofre.SegundaCriptografia(senhaTextoPuro2);
    Console.WriteLine("Senha criptografada: " + senhaCriptografada2);
    Console.WriteLine();


    senhaTextoPuro3 = RepeteEnquantoEntradaInvalida("Digite a terceira senha");
    senhaCriptografada3 = Cofre.TerceiraCriptografia(senhaTextoPuro3);
    Console.WriteLine("Senha criptografada: " + senhaCriptografada3);
    Console.WriteLine();


    static string RepeteEnquantoEntradaInvalida(string mensagem)
    {
        bool opcaoValida = true;
        string textoDigitado;
        do
        {
            if (opcaoValida == false)
            {
                Console.WriteLine("\nA senha não pode ser vazia.\n");
            }

            Console.Write(mensagem + ": ");
            textoDigitado = Console.ReadLine();

            opcaoValida = !string.IsNullOrWhiteSpace(textoDigitado);
        } while (opcaoValida == false);

        return textoDigitado;
    }
}
catch (Exception ex)
{
    Console.WriteLine("Erro: " + ex.Message);
}





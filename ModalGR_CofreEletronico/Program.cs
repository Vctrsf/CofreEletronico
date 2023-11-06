using ModalGR_CofreEletronico.ModalGR;


var Cofre = new CofreEletronico(); //Criação do objeto da classe CofreEletronico
string senhaCriptografada1; 
string senhaCriptografada2; 
string senhaCriptografada3;         //Declaração de variáveis
string senhaTextoPuro1; 
string senhaTextoPuro2; 
string senhaTextoPuro3;

Cofre.ExibeTitulo();   //Exibe o titulo escrito na classe "CofreEletronico"

Console.Write("Digite a primeira senha: ");                         //Pede pro usuário inserir a senha
senhaTextoPuro1 = Console.ReadLine();                               //Registra a senha que o usuário colocou
senhaCriptografada1 = Cofre.PrimeiraCriptografia(senhaTextoPuro1);  //Declara a senha criptografada como primeira criptografia feita pela método "PrimeiraCriptografia"
Console.WriteLine("Senha criptografada: " + senhaCriptografada1);   //Mostra ao usuario a o retorno da senha criptografada
Console.WriteLine();

Console.Write("Digite a segunda senha: ");
senhaTextoPuro2 = Console.ReadLine();
senhaCriptografada2 = Cofre.SegundaCriptografia(senhaTextoPuro2);
Console.WriteLine("Senha criptografada: " + senhaCriptografada2);
Console.WriteLine();

Console.Write("Digite a terceira senha: ");
senhaTextoPuro3 = Console.ReadLine();
senhaCriptografada3 = Cofre.TerceiraCriptografia(senhaTextoPuro3);
Console.WriteLine("Senha criptografada: " + senhaCriptografada3);





using ModalGR_CofreEletronico.ModalGR;


var Cofre = new CofreEletronico();
string senhaCriptografada1; 
string senhaCriptografada2; 
string senhaCriptografada3;
string senhaTextoPuro1; 
string senhaTextoPuro2; 
string senhaTextoPuro3;

Cofre.ExibeTitulo();

Console.Write("Digite a primeira senha: ");
senhaTextoPuro1 = Console.ReadLine();
senhaCriptografada1 = Cofre.PrimeiraCriptografia(senhaTextoPuro1);
Console.WriteLine("Senha criptografada: " + senhaCriptografada1);
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





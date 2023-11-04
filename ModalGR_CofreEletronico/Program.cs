using ModalGR_CofreEletronico.ModalGR;


var Cofre = new CofreEletronico();
string senhaCriptografada1 = "";
string senhaCriptografada2 = "";
string senhaCriptografada3 = "";
string senhaEscrita1;
string senhaEscrita2;
string senhaEscrita3;
Cofre.ExibeTitulo();
Cofre.PrimeiraCriptografia(senhaCriptografada1);
Cofre.SegundaCriptografia(senhaCriptografada2);
Cofre.TerceiraCriptografia(senhaCriptografada3);

Console.Write("Insira sua senha: ");
senhaEscrita1 = Console.ReadLine();
Console.WriteLine("Senha criptografada: " + senhaCriptografada1);
Console.WriteLine();

Console.Write("Insira sua senha: ");
senhaEscrita2 = Console.ReadLine();
Console.WriteLine("Senha criptografada: " + senhaCriptografada2);
Console.WriteLine();

Console.Write("Insira sua senha: ");
senhaEscrita3 = Console.ReadLine();
Console.WriteLine("Senha criptografada: " + senhaCriptografada3);




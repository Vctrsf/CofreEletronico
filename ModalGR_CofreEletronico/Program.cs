using ModalGR_CofreEletronico.ModalGR;


var Cofre = new CofreEletronico();
string senha1 = "";
string senha2 = "";
string senha3 = "";
string senhaEscrita1;
string senhaEscrita2;
string senhaEscrita3;
Cofre.ExibeTitulo();
Cofre.PrimeiraCriptografia(senha1);
Cofre.SegundaCriptografia(senha2);
Cofre.TerceiraCriptografia(senha3);

Console.Write("Insira sua senha: ");
senhaEscrita1 = Console.ReadLine();
Console.WriteLine("Senha criptografada: " + senha1);
Console.WriteLine();

Console.Write("Insira sua senha: ");
senhaEscrita2 = Console.ReadLine();
Console.WriteLine("Senha criptografada: " + senha2);
Console.WriteLine();

Console.Write("Insira sua senha: ");
senhaEscrita3 = Console.ReadLine();
Console.WriteLine("Senha criptografada: " + senha3);




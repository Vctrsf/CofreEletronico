using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using ModalGR_CofreEletronico.ModalGR;

namespace ModalGR_CofreEletronico.ModalGR
{
    class CofreEletronico
    {
        //Declaração da chave secreta determinada pela documentação
        private const string _abacaxi = "#modalGR#GPTW#top#maiorEmpresaTecnologia#baixadaSantista";
        //Cria um objeto privado a partir da classe "ServicoDeCriptografia
        private ServicoDeCriptografia servicoCripto = new ServicoDeCriptografia(_abacaxi);          

        public void ExibeTitulo()       
        {
            Console.WriteLine("=======================================================");
            Console.WriteLine();
            Console.WriteLine("                 COFRE ELETRÔNICO                     ");
            Console.WriteLine();
            Console.WriteLine("   Desafio prático - Processo de Formação ModalGR 2024");
            Console.WriteLine();
            Console.WriteLine("=======================================================");


        }

        //Retorna a criptografia da senha digitada usando o algoritmo escrito a partir do método "CriptografaComVetor1".
        public string PrimeiraCriptografia(string senhaTextoPuro1)
        {
            //Armazena o resultado da criptografia feita pelo método "CriptografiaComVetor1"
            //a partir da senha inserida pelo usuário.
            string resultado = servicoCripto.CriptografaComVetor1(senhaTextoPuro1); 
            return resultado;                                                       
        }

        //Retorna a criptografia da senha digitada usando o algoritmo escrito a partir do método "CriptografaComVetor2".
        public string SegundaCriptografia(string senhaTextoPuro2)
        {
            //Armazena o resultado da criptografia feita pelo método "CriptografiaComVetor2" 
            //a partir da senha inserida pelo usuário. 
            string resultado = servicoCripto.CriptografaComVetor2(senhaTextoPuro2);    
            return resultado;
        }

        //Retorna a criptografia da senha digitada usando o algoritmo escrito a partir do método "CriptografaComVetor3".
        public string TerceiraCriptografia(string senhaTextoPuro3)
        {
            //Armazena o resultado da criptografia feita pelo método "CriptografiaComVetor2" 
            //a partir da senha inserida pelo usuário.  
            string resultado = servicoCripto.CriptografaComVetor3(senhaTextoPuro3);   
            return resultado;
        }

    }
}

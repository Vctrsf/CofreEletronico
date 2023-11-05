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
        ServicoDeCriptografia servicoCripto = new ServicoDeCriptografia();

        const string chave = "#modalGR#GPTW#top#maiorEmpresaTecnologia#baixadaSantista";
        string initVector;
        
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

        public string PrimeiraCriptografia(string senhaTextoPuro1)
        {
            string resultado = servicoCripto.CriptografaAES(senhaTextoPuro1, chave, initVector);

            return resultado;
        }

        
        public string SegundaCriptografia(string senhaTextoPuro2)
        {
            
            string resultado = servicoCripto.CriptografaAES(senhaTextoPuro2, chave, initVector);

            return resultado;
        }

        public string TerceiraCriptografia(string senhaTextoPuro3)
        {
           string resultado = servicoCripto.CriptografaAES(senhaTextoPuro3, chave, initVector);
            
            return resultado;
        }

     }
}

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
        private const string _abacaxi = "#modalGR#GPTW#top#maiorEmpresaTecnologia#baixadaSantista";
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

        public string PrimeiraCriptografia(string senhaTextoPuro1)
        {
            string resultado = servicoCripto.CriptografaComVetor1(senhaTextoPuro1);

            return resultado;
        }


        public string SegundaCriptografia(string senhaTextoPuro2)
        {

            string resultado = servicoCripto.CriptografaComVetor2(senhaTextoPuro2);

            return resultado;
        }

        public string TerceiraCriptografia(string senhaTextoPuro3)
        {
            string resultado = servicoCripto.CriptografaComVetor3(senhaTextoPuro3);

            return resultado;
        }

    }
}

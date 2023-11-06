using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.Loader;

namespace ModalGR_CofreEletronico.ModalGR
{
    //Classe responsável por fazer a criptografia das senhas inseridas pelo usuário, usando 3 vetores diferentes.
    public class ServicoDeCriptografia
    {
        private byte[] _chaveDeCriptografia;
        private byte[] _vetor1;                 //Declaração das variáveis necessárias para atribuição dos vetores e da chave secreta
        private byte[] _vetor2;
        private byte[] _vetor3;

        //Método construtor da classe que assegura a execução do método "DefineChave" para que os campos de vetores e chave estejam devidamente preenchidos
        //se os campos não estiverem preenchidos, o algoritmo de encriptação falhará miservalmente
        public ServicoDeCriptografia(string banana) 
        {
            DefineChave(banana);
        }

        private void DefineChave(string chaveTextoPuro)
        {
            //Transforma o "textoPuro" (texto inserido pelo usuário) em um array de bytes através
            //da classe estática "Encoding", com métodos uteis para codificação e decodificação de dados
            var chaveArrayDeBytes = Encoding.UTF8.GetBytes(chaveTextoPuro);         

            //Aplica um cálculo matemático de HASH e obtém um código resultante que mantém uma correspondência com a fonte de dados fornecida, que no caso é a váriavel "chaveArrayDeBytes"
            _chaveDeCriptografia = SHA256.Create().ComputeHash(chaveArrayDeBytes);  


            string IV1 = "ZbyzlmF79ygI7cU";     //Declaração de strings com valores fixos para serem usadas como base dos vetores do algoritmo de encriptação 
            string IV2 = "NltFbEpQ4otbmUz";     //com o uso da classe "Encoding".       
            string IV3 = "Z1IhlzCLq5I9OWG";

            var arrayV1 = Encoding.UTF8.GetBytes(IV1);      //Transofrma o valor fixo das variáveis "IV1", "IV2", "IV3" em um array de bytes.
            var arrayV2 = Encoding.UTF8.GetBytes(IV2);      
            var arrayV3 = Encoding.UTF8.GetBytes(IV3);

            _vetor1 = MD5.Create().ComputeHash(arrayV1);
            _vetor2 = MD5.Create().ComputeHash(arrayV2);    //Realiza o calculo matemático HASH a partir do array de bytes anteriormente transformados a partir das variáveis
            _vetor3 = MD5.Create().ComputeHash(arrayV3);    //"arrayV1", "arrayV2", "arrayV3"

        }

        //Método que faz a criptografia do valor inserido pelo usuário com o array de bytes do primeiro vetor.
        public string CriptografaComVetor1(string textoPuro)
        {
            string resultado = EncryptStringToBytes_Aes(textoPuro, _vetor1);
            return resultado;
        }

        //Método que faz a criptografia do valor inserido pelo usuário com o array de bytes do segundo vetor.
        public string CriptografaComVetor2(string textoPuro)
        {
            string resultado = EncryptStringToBytes_Aes(textoPuro, _vetor2);
            return resultado;
        }


        //Método que faz a criptografia do valor inserido pelo usuário com o array de bytes do terceiro vetor.

        public string CriptografaComVetor3(string textoPuro)
        {
            string resultado = EncryptStringToBytes_Aes(textoPuro, _vetor3);
            return resultado;
        }


        private string EncryptStringToBytes_Aes(string plainText, byte[] vetorQualquer)
        {
            // Verifica se o valor de "plainText" é nulo, e se sim, retorna um erro.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");

            byte[] encrypted;

            // Cria um objeto do tipo AES
            // com uma chave e vetores especificados.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _chaveDeCriptografia;
                aesAlg.IV = vetorQualquer;

                //Cria um encriptador para realizar o algoritmo do stream.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Cria as streams usadas pela incriptação.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Escreve todos os dados no stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Retorna todos os bytes encriptados a partir da stream de memória.
            string resultado = Convert.ToBase64String(encrypted);

            return resultado;
        }

        private string DecryptStringFromBytes_Aes(string cipherTextString, byte[] vetorQualquer)
        {
            // Verifica os dados de entrada.
            if (string.IsNullOrWhiteSpace(cipherTextString))
                throw new ArgumentNullException("cipherText");

            byte[] cipherText = Convert.FromBase64String(cipherTextString);

            // Declara a string usada para guardar o texto decriptado.
            string plaintext = null;

            // Cria um objeto AES com a chave e vetor especificados.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _chaveDeCriptografia;
                aesAlg.IV = vetorQualquer;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Cria as streams usados para a decriptação.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Lê os bytes decriptados da stream de decriptação e as coloca em uma string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}


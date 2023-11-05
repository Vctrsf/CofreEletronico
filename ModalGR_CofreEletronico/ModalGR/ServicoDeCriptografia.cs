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
    public class ServicoDeCriptografia
    {
        private byte[] _chaveDeCriptografia;
        private byte[] _vetor1;
        private byte[] _vetor2;
        private byte[] _vetor3;

        public ServicoDeCriptografia(string banana)
        {
            DefineChave(banana);
        }

        private void DefineChave(string chaveTextoPuro)
        {
            var chaveArrayDeBytes = Encoding.UTF8.GetBytes(chaveTextoPuro);
            _chaveDeCriptografia = SHA256.Create().ComputeHash(chaveArrayDeBytes);

            string IV1 = "ZbyzlmF79ygI7cU";
            string IV2 = "NltFbEpQ4otbmUz";
            string IV3 = "Z1IhlzCLq5I9OWG";

            var arrayV1 = Encoding.UTF8.GetBytes(IV1);
            var arrayV2 = Encoding.UTF8.GetBytes(IV2);
            var arrayV3 = Encoding.UTF8.GetBytes(IV3);

            _vetor1 = MD5.Create().ComputeHash(arrayV1);
            _vetor2 = MD5.Create().ComputeHash(arrayV2);
            _vetor3 = MD5.Create().ComputeHash(arrayV3);

        }

        public string CriptografaComVetor1(string textoPuro)
        {
            string resultado = EncryptStringToBytes_Aes(textoPuro, _vetor1);
            return resultado;
        }

        public string CriptografaComVetor2(string textoPuro)
        {
            string resultado = EncryptStringToBytes_Aes(textoPuro, _vetor2);
            return resultado;
        }

        public string CriptografaComVetor3(string textoPuro)
        {
            string resultado = EncryptStringToBytes_Aes(textoPuro, _vetor3);
            return resultado;
        }


        private string EncryptStringToBytes_Aes(string plainText, byte[] vetorQualquer)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");

            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _chaveDeCriptografia;
                aesAlg.IV = vetorQualquer;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            string resultado = Convert.ToBase64String(encrypted);

            return resultado;
        }

        private string DecryptStringFromBytes_Aes(string cipherTextString, byte[] vetorQualquer)
        {
            // Check arguments.
            if (string.IsNullOrWhiteSpace(cipherTextString))
                throw new ArgumentNullException("cipherText");

            byte[] cipherText = Convert.FromBase64String(cipherTextString);

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _chaveDeCriptografia;
                aesAlg.IV = vetorQualquer;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}


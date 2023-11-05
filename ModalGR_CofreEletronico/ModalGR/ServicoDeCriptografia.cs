using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace ModalGR_CofreEletronico.ModalGR
{
    public class ServicoDeCriptografia
    {
        public string CriptografaAES(string textoPuro, string chave, string initVector)
        {
            byte[] chaveEncriptadaEmBytes;

            using (var algoritmoAES = new AesCryptoServiceProvider())
            {


                algoritmoAES.Key = Convert.FromBase64String(chave);
                algoritmoAES.IV = Convert.FromBase64String(initVector);
                ICryptoTransform encriptador = algoritmoAES.CreateEncryptor(algoritmoAES.Key, algoritmoAES.IV);

                using (MemoryStream streamDeMemoria = new MemoryStream())
                {
                    using (CryptoStream encriptadorDeStream = new CryptoStream(streamDeMemoria, encriptador, CryptoStreamMode.Write))
                    {

                        using (StreamWriter escritorDeStream = new StreamWriter(encriptadorDeStream))
                        {
                            escritorDeStream.Write(textoPuro);
                        }

                        chaveEncriptadaEmBytes = streamDeMemoria.ToArray();
                    }
                }
            }

            string chaveEncriptadaEmTexto = Convert.ToBase64String(chaveEncriptadaEmBytes);
            return chaveEncriptadaEmTexto;
        }
    }
}

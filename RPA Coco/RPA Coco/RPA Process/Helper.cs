using RPA_Coco.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RPA_Coco.RPA_Process
{
    class Helper
    {
        public string GetUserName()
        {
            try
            {
                string userName = Environment.UserName.ToUpper();
                return userName;
            }
            catch (Exception e)
            {
                Logs log = new Logs();
                log.LogsTypeId = 1;
                log.ProcessId = 3;
                log.Message = e.Message;
                log.InnerException = e.InnerException.ToString();
                log.CreatedBy = "RPA";
                log.CreatedDate = DateTime.Now;
                SaveLog(log);
                return "";
            }
        }

        public bool FileExists(string RutaArchivo)
        {
            try
            {
                if (File.Exists(RutaArchivo))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception xcptn)
            {
                return false;
            }
        }

        //Function Delete File
        public bool DeleteFile(string RutaArchivo)
        {
            try
            {
                if (FileExists(RutaArchivo))
                {
                    File.Delete(RutaArchivo);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception xcptn)
            {
                return false;
            }
        }

        //Funcion Copy File
        public bool CopyFile(string RutaArchivoOrigen, string RutaArchivoDestino)
        {
            try
            {
                if (FileExists(RutaArchivoOrigen))
                {
                    if (DeleteFile(RutaArchivoDestino))
                    {
                        File.Copy(RutaArchivoOrigen, RutaArchivoDestino);
                    }
                    else
                    {
                        File.Copy(RutaArchivoOrigen, RutaArchivoDestino);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception xcptn)
            {
                return false;
            }
        }

        //Funcion crea folder
        public bool CreateFolder(string Ruta)
        {
            try
            {
                if (!Directory.Exists(Ruta))
                {
                    Directory.CreateDirectory(Ruta);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception xcptn)
            {
                return false;
            }
        }

        //Function Directory Exists true or false
        public bool DirectoryExists(string Ruta)
        {
            try
            {
                if (Directory.Exists(Ruta))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception xcptn)
            {
                return false;
            }
        }

        //Function Retorn Date by count of days
        public string ReturnDatebyCountDays(int CountDays, string FormatDate)
        {
            try
            {
                return DateTime.Now.AddDays(CountDays).ToString(FormatDate);
            }
            catch (Exception xcptn)
            {
                throw;
            }
        }

        //Funcion para eliminar todos los archivos de un folder
        public bool DeleteFolderFiles(string RutaArchivos)
        {
            try
            {
                List<string> FilesInFolder = new List<string>();
                DirectoryInfo FilesInFolderPath = new DirectoryInfo(RutaArchivos);
                foreach (var item in FilesInFolderPath.GetFiles())
                {
                    FilesInFolder.Add(item.FullName);
                }
                if (FilesInFolder != null)
                {
                    foreach (string Archivo in FilesInFolder)
                    {
                        bool IsDeleted = DeleteFile(Archivo);
                        if (!IsDeleted)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Funcion que retorna listado de archivos en una carpeta
        public List<string> FilesInPath(string Ruta)
        {
            List<string> Archivos = new List<string>();
            try
            {
                DirectoryInfo FilesInFolderPath = new DirectoryInfo(Ruta);
                foreach (var item in FilesInFolderPath.GetFiles())
                {
                    Archivos.Add(item.FullName);
                }
                return Archivos;
            }
            catch (Exception)
            {
                return Archivos;
            }
        }

        //Eventos que suceden en los catch
        public void SaveLog(Logs log)
        {
            try
            {
                RPADbContext db = new RPADbContext();
                Logs model = new Logs()
                {
                    ProcessId = log.ProcessId,
                    LogsTypeId = log.LogsTypeId,
                    Message = log.Message,
                    InnerException = log.InnerException,
                    CreatedBy = "RPA AHT InContact",
                    CreatedDate = DateTime.Now,
                    Enabled = true
                };
                db.Logs.Add(model);
                db.SaveChanges();
            }
            catch (Exception)
            {

            }
        }


        //Encription Method
        public string Encriptar(string Texto)
        {
            byte[] AESKey = Convert.FromBase64String("dgmPm08DrWorxd9KegZBUxMVqk1qZ3OvcfrG0NNvzFc=");
            byte[] IVKey = Convert.FromBase64String("BP+F/KNyKj/Hbwr5m1FN6g==");

            using (Aes myAes = Aes.Create())
            {

                // Encrypt the string to an array of bytes.
                byte[] encrypted = EncryptStringToBytes_Aes(Texto, AESKey, IVKey);
                return Convert.ToBase64String(encrypted);
            }
        }

        //Decryption Method
        public string Desencriptar(string TextoEncriptado)
        {
            byte[] AESKey = Convert.FromBase64String("dgmPm08DrWorxd9KegZBUxMVqk1qZ3OvcfrG0NNvzFc=");
            byte[] IVKey = Convert.FromBase64String("BP+F/KNyKj/Hbwr5m1FN6g==");

            using (Aes myAes = Aes.Create())
            {
                return DecryptStringFromBytes_Aes(Convert.FromBase64String(TextoEncriptado), AESKey, IVKey);
            }
        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

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
            return encrypted;
        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

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

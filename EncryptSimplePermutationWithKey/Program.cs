using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EncryptSimplePermutationWithKey
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:\n 1 Закодировать текст\n 2 Раскодировать текст\n 3 Завершить работу");
                var str = Console.ReadLine();
                switch (str)
                {
                    case "1":
                        EncryptText();
                        break;
                    case "2":
                        DecryptText();
                        break;
                    case "3":
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неверный код действия");
                        break;
                }
            }
        }
        static void EncryptText()
        {
            Console.WriteLine("Введите ключ ");
            string Key = Console.ReadLine();
            try
            {
                var i = 1 / Key.Length;
                Console.WriteLine("Введите путь к файлу с кодируемым текстом");
                var path = Console.ReadLine();
                string NormalText = "";
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    NormalText = sr.ReadToEnd();
                }
                var NewText = MakeEncryptText(Key, NormalText);
                Console.WriteLine("Введите путь к файлу с закодированным текстом");
                path = Console.ReadLine();
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(Key);
                    sw.WriteLine(NewText);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static string MakeEncryptText(string Key, string NormalText)
        {
            string NewText = "";
            var step = (int)Math.Ceiling((decimal)NormalText.Length / Key.Length);
            Dictionary<int, string> EncryptedText = new Dictionary<int, string>(Key.Length);
            for (var i=0; i<Key.Length; i++)
            {
                if ((i+1)*step>NormalText.Length)
                {
                    EncryptedText.Add(Key[i], NormalText.Substring(i * step));
                }
                else
                {
                    EncryptedText.Add(Key[i], NormalText.Substring(i * step, step));
                }                
            }
            char[] sortKey = Key.ToCharArray();
            Array.Sort(sortKey);
            for (var i=0; i<step;i++)
            {
                for(var j=0; j< sortKey.Length; j++)
                {
                    if (EncryptedText[sortKey[j]].Length>i)
                    {
                        NewText += EncryptedText[sortKey[j]][i];
                    }
                }
            }                        
            return NewText;
        }
        static void DecryptText()
        {
            try
            {
                Console.WriteLine("Введите путь к файлу с закодированным текстом");
                var path = Console.ReadLine();
                string Key = "";
                string EncryptText = "";
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    Key = sr.ReadLine();
                    var i = 1 / Key.Length;
                    EncryptText = sr.ReadToEnd();
                }
                var NewText = MakeDecryptText(Key, EncryptText);
                Console.WriteLine("Введите путь к файлу с раскодированным текстом");
                path = Console.ReadLine();
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(NewText);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static string MakeDecryptText(string Key, string EncryptText)
        {
            

            string NewText = "";            
            return NewText;
        }
    }
}

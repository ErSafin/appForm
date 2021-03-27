using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.IO.Compression;


namespace Anketa
{
    public partial class EntryAnketa
    {
        public static void ZipAnketa()
        {
            Console.WriteLine("АРХИРОВАНИЕ АНКЕТЫ: Введите Ф.И.О.:");
            string NameFile = Console.ReadLine();

            string arcPath1 = @"D:\TXT\" + NameFile.Trim() + ".txt";
            string ZipFile = @"D://TXT/" + NameFile.Trim() + ".zip";
            try
            {
                using (FileStream arcPath = new FileStream(arcPath1, FileMode.Open))
                {
                    using (FileStream zip = File.Create(ZipFile))
                    {
                        using (GZipStream CompStream = new GZipStream(zip, CompressionMode.Compress))
                        {
                            arcPath.CopyTo(CompStream);
                            Console.WriteLine($"Анкета {NameFile} помещена в архив.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();
        }
        public static string BeginMessage(string MessWelcome, string MessPath)
        {
            Console.WriteLine(MessWelcome);
            string NameFile = Console.ReadLine();

            NameFile = NameFile.Trim() + ".txt";
            string NameDir = MessPath + NameFile;
            return NameDir;
        }


        public static void DelAnketa()
        {
            string NameDir = BeginMessage("УДАЛЕНИЕ АНКЕТЫ: Введите Ф.И.О.:", @"D:\TXT\");
            try
            {
                FileInfo DelFile = new FileInfo(NameDir);
                if (DelFile.Exists)
                {
                    DelFile.Delete();
                    Console.WriteLine($"Анкета {NameDir} УДАЛЕНА.");
                }
                else
                    Console.WriteLine($"Файл {NameDir} не найден.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();
        }
        public static void FindAnketa() 
        {
                string NameDir = BeginMessage ("ПОИСК АНКЕТЫ: Введите Ф.И.О.:", @"D:\TXT\");
                string[] InData = new string[7];
                InData = ToRead(NameDir);
                if (InData != null)
                {
                   Console.WriteLine("-----------------------------------------------------------");
                   for (int i = 0; i < InData.Length; i++)
                        Console.WriteLine(InData[i]);
                }
                else
                    Console.WriteLine($"Анкета: {NameDir} не существует.");
            
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();
        }

            // Список анкет
            // вызов из основного модуля
      public static void SpAnketa(int TodayNum)
        {
            Regex file = new Regex(@".*\.txt$");
            DirectoryInfo dr = new DirectoryInfo(@"D:\TXT\");
            SpisokAnk(dr, file, TodayNum);
        }
        static void SpisokAnk(DirectoryInfo dr, Regex file, int FlagToday)
            {
                FileInfo[] fi = dr.GetFiles();
                Console.WriteLine($"Список доступных файлов (анкет) в каталоге {dr}" + (FlagToday==1 ? " на сегодня: " + DateTime.Now.ToShortDateString() : " "));
                Console.WriteLine("--------------------------------------------------------");
                foreach (FileInfo info in fi)
                {
                    if (file.IsMatch(info.Name))
                    {
                       if (FlagToday == 1) // выбрать файлы за сегодня
                        {
                          if (info.CreationTime.Date == DateTime.Now.Date)
                            Console.WriteLine("{0,-10} | {1}", info.Directory.Name, info.Name);
                        }
                      else
                        Console.WriteLine("{0,-10} | {1}", info.Directory.Name, info.Name);
                    }
                }
                DirectoryInfo[] dirs = dr.GetDirectories();
                foreach (DirectoryInfo directoryInfo in dirs)
                {
                    SpisokAnk(directoryInfo, file, FlagToday);
                }
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();
        }

        // Чтение из текстового файла
        static string[] ToRead(string NameFilePath)
            {
                try
                {
                    StreamReader str = new StreamReader(NameFilePath, System.Text.Encoding.Default);
                    string[] InData = new string[7];
                    string Line;
                    int i = 0;
                    while ((Line = str.ReadLine()) != null)
                    {
                        InData[i] = Line;
                        i++;
                    }
                    str.Close();
                    return InData;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
    


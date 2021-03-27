using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Anketa
{
public partial class EntryAnketa
    {
     public static void ToSave(string NameFile, string[] Qs, string[] Data, bool overWrite)
        {
            try
            {
               StreamWriter str = new StreamWriter(NameFile, overWrite);
                for (int i = 0; i < Data.Length; i++)
                {
                    str.WriteLine(Qs[i]+Data[i]);
                }
                str.WriteLine("");
                str.WriteLine("Анкета заполнена: " + DateTime.Now);
                str.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static void AddAnketa()
        {
            int numQ = 0;
            string text = "";

            string[] hlp =
             {
                "Сохранить анкету",
                "Вернуться к вопросу",
                "Ввести заново"
             };

//TODO: сделать возврат к предыдущему вопросу;
//       ввод заново текущего вопроса;
//       выход из этого пункта меню;
//       обнуление буфера при вводе след.вопроса

            string[] Qst = new string[5]
             {
               "Вопрос 1: Ф.И.О.:",
               "Вопрос 2: Дата рождения (ДД.ММ.ГГГГ): ",
               "Вопрос 3: Любимый язык программирования: ",
               "Вопрос 4: Опыт программирования (ГГ,ММ): ",
               "Вопрос 5: Мобильный телефон:"
             };

            string[] Ans = new string[5]; //массив для ответов
            string[] lang = {"PHP","JavaScript","C++","Java","C#","Python","Ruby"};
            while (numQ <= 4)
            {
                while (string.IsNullOrEmpty(text))
                {
                    Console.WriteLine(Qst[numQ]);
                    if (numQ == 2)
                    {
                        Console.Write("Выбрать из : ");
                        for (int k = 0; k < lang.Length; k++)
                              Console.Write($"{lang[k]} ");
                        Console.WriteLine("-->");
                    }
                    text = Console.ReadLine();

                    switch (numQ)
                    {
                        case 0: //ФИО
                            if (text.Length > 128)
                            {
                                Console.WriteLine("Превышение допустимого количества символов.");
                                text = Ans[numQ];
                            }
                            else
                                Ans[numQ] = text;
                            break;
                        case 1: //Дата рождения
                            DateTime result;
                            if (!DateTime.TryParseExact(text, "dd.mm.yyyy", null, System.Globalization.DateTimeStyles.None, out result))
                            {
                                text = Ans[numQ];
                                Console.WriteLine("Неверный формат даты.");
                            }
                            else
                                Ans[numQ] = text;
                            break;
                        case 2: //Язык программирования
                            foreach (string s in lang)
                            {
                                if (text.ToUpper().Contains(s.ToUpper())) //приведение ответа к заглавным
                                    Ans[numQ] = text;
                            }                             
                            text = Ans[numQ];
                            break;

                        case 3: // опыт программирования
                            if (float.TryParse(text, out float TxtInt))
                            {
                                Ans[numQ] = text;
                            }
                            else
                            {
                                text = Ans[numQ];
                                Console.WriteLine("Введите число.");
                            }
                            break;
                        case 4: // мобильный телефон
                            if (int.TryParse(text, out int NumPh))
                            {
                                Ans[numQ] = text;
                            }
                            else
                            {
                                text = Ans[numQ];
                                Console.WriteLine("Введите номер.");
                            }
                             break;
                    }


                }
                Ans[numQ] = text;
                text = "";
                numQ += 1;
            }
            Console.WriteLine("Сохранить анкету: Y / N ?");
            string YN = Console.ReadLine();
            switch (YN.ToUpper())
            {
                case "Y": // Сохранение в файл 
                    string PathFileName = @"D:\TXT\" + Ans[0] + ".txt";
                    bool NewFile = false; // перезаписать файл
                    ToSave(PathFileName,Qst, Ans, NewFile);
                    break;

                case "N": // Выход в основное меню
                    Console.WriteLine("Анкета НЕ сохранена.");
                    break;
            }
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();
        }



    }
}

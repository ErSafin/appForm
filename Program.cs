using System;


namespace Anketa
{
    public class Program
    {
        static void MainMenu()
        {
            string[] Menu =
            {
              "0. Помощь",
              "1. Заполнить анкету",
              "2. Найти анкету",
              "3. Статистика анкет",
              "4. Удалить анкету",
              "5. Список файлов анкет",
              "6. Список файлов за сегодня",
              "7. Запаковать анкету",
              "8. Выход"
            };

            bool DoFlag = true;
            while (DoFlag)
            {
                Console.WriteLine("Введите пункт меню (0 - Помощь):");
                string PartMenu = Console.ReadLine();

                if (int.TryParse(PartMenu, out int NumMenu))
                {
                    // контроль вызываемых пунктов меню
                    if (NumMenu >= 0 && NumMenu < Menu.Length)
                    {
                        switch (NumMenu)
                        {
                            case 0:  // help
                                Console.WriteLine("Список доступных функций:");
                                for (int i = 0; i < Menu.Length; i++)
                                    Console.WriteLine(Menu[i]);
                                break;
                            case 1: // Заполнить анкету
                                EntryAnketa.AddAnketa();
                                break;
                            case 2: //Поиск анкеты по имени файла
                                EntryAnketa.FindAnketa();
                                break;
                            case 3: //Статистика
                                    // TODO: сделать выборку по статистике

                                break;
                            case 4: //Удаление анкеты
                                EntryAnketa.DelAnketa();
                                break;
                            case 5: //Список файлов анкет
                                EntryAnketa.SpAnketa(0);
                                break;
                            case 6: //Список файлов анкет за сегодня
                                EntryAnketa.SpAnketa(1);
                                break;
                            case 7: //Запаковать анкету
                                EntryAnketa.ZipAnketa();
                                break;
                            case 8:  // Выход
                                DoFlag = false;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Несуществующий пункт меню. Повторите ввод.");
                        Console.WriteLine("---------------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("Введена не цифра.Повторите ввод.");
                    Console.WriteLine("---------------------------------------------");
                }
            }
        }
        public static void Main(string[] args)
        {

            MainMenu();
            //Console.ReadKey();
        }
    }
}

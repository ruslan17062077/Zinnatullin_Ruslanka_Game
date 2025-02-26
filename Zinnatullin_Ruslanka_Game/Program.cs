using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinnatullin_Ruslanka_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int user_HP = 100;
            int strela = 5;
            List<string> ivent = new List<string>() { "зелье", "зелье", "зелье" };
            int altn = 0;
            List<string> vesh = new List<string>() {"золото", "зелье", "стрелы" };
            Random rand = new Random();
            List<string> map = new List<string>() { "Монстр", "Ловушка", "Сундук", "Торговец", "Пустая комната" };
            List<string> dungeonMap = new List<string>(); 
            for(int i = 0; i <=8; i++)
            {
                dungeonMap.Add(map[rand.Next(0, 5)]);
            }
            dungeonMap.Add("Босс");
            Console.WriteLine("Ваши комнаты");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            foreach(string maps in dungeonMap)
            {
                Console.WriteLine(maps);
            }


            foreach (string maps in dungeonMap)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Ивентарь  ");
                foreach (string item in ivent)
                {
                    Console.WriteLine(item); 
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Золото {altn}   ");

                if (user_HP < 0)
                {
                    Console.WriteLine("Вы умерли");
                    break;
                }
                Console.WriteLine($"Комната {maps}");
                if (maps == "Монстр")
                {
                    if (user_HP < 0)
                    {
                        Console.WriteLine("Вы умерли");
                    }
                    else
                    {
                        Console.WriteLine($"ваше здоровье {user_HP}");
                    }
                    int mob_HP = rand.Next(19, 50);
                    Console.WriteLine($"Здоровье монстра {mob_HP}");


                    while (user_HP > 0 && mob_HP > 0)
                    {
                        Console.WriteLine(" Использовать меч: 1");
                        Console.WriteLine(" Использовать лук: 2");
                        Console.WriteLine(" Использовать зелье: 3");
                        string orushie = Console.ReadLine();

                        if (orushie == "1")
                        {
                            mob_HP -= rand.Next(9, 20);
                            user_HP -= rand.Next(4, 15);
                            Console.WriteLine($"Использовано меч, осталось здоровья: {user_HP}, у монстра {mob_HP}");


                        }
                        else if(orushie == "2")
                        {
                            if (strela > 0)
                            {
                                mob_HP -= rand.Next(9, 20);
                                user_HP -= rand.Next(4, 15);
                                Console.WriteLine($"Использовано меч, осталось здоровья: {user_HP}, у монстра {mob_HP}");
                            }
                            else
                            {
                                Console.WriteLine("Стрел нет ");
                            }

                        }
                        else if (orushie == "3")
                        {
                            if(ivent.Count != 0)
                            {
                                ivent.Remove(ivent.Last());
                                user_HP += 10;
                                
                            }
                            else
                            {
                                Console.WriteLine("Зелья нет");
                            }
                        }
                    }
                }
                else if (maps == "Ловушка")
                {
                    if (user_HP < 0)
                    {
                        Console.WriteLine("Вы умерли");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"ваше здоровье {user_HP}");
                    }
                    int hp = rand.Next(9, 20);
                    Console.WriteLine($"Вы попали в ловушку и потеряли {hp}");
                    user_HP -= hp;
                }
            
                else if (maps == "Сундук")
                {
                    if (user_HP < 0)
                    {
                        Console.WriteLine("Вы умерли");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"ваше здоровье {user_HP}");
                    }
                    int a = rand.Next(10, 57);
                    int b = rand.Next(10, 57);
                    Console.WriteLine($"Реши {a} + {b} ");
                    int otvet = a + b;
                    int otvet_user = int.Parse(Console.ReadLine());
                    if (otvet_user == otvet)
                    {
                        int i = rand.Next(0, 3);
                        Console.WriteLine($"Вы получили {vesh[i]}");
                        if(vesh[i] == "золото"){
                            altn += 5;
                            }
                        else if (vesh[i] == "зелье")
                        {
                            ivent.Add(vesh[i]);
                        }
                        else if (vesh[i] == "стрелы")
                        {
                            strela += 5;
                        }


                    }
                    else
                    {
                        Console.WriteLine("Учись неуч");

                    }
                   

                }
                else if (maps == "Торговец")
                {
                    if (ivent.Count < 5)
                    {
                        Console.WriteLine("Хочешь купить зелье ??? 30 алтын");
                        Console.WriteLine("Да 1");
                        Console.WriteLine("Нет 2");
                        int i = int.Parse(Console.ReadLine());
                        if(i == 1)
                        {
                            if(altn >= 30)
                            {
                                altn -= 30;
                                ivent.Add("зелье");
                                Console.WriteLine("Куплено ");
                            }
                            else
                            {
                                Console.WriteLine("Золота не хватает");
                            }
                           
                        }
                    }
                    else
                    {
                        Console.WriteLine("Инвентарь переполнен ничего не продам");
                    }
                    
                }
                if (maps == "Босс")
                {
                    if (user_HP < 0)
                    {
                        Console.WriteLine("Вы умерли");
                    }
                    else
                    {
                        Console.WriteLine($"ваше здоровье {user_HP}");
                    }
                    int mob_HP = rand.Next(19, 100);
                    Console.WriteLine($"Здоровье Босса {mob_HP}");


                    while (user_HP > 0 && mob_HP > 0)
                    {
                        if (user_HP < 0)
                        {
                            Console.WriteLine("Вы умерли");
                            break;
                        }
                      
                        Console.WriteLine(" Использовать меч: 1");
                        Console.WriteLine(" Использовать лук: 2");
                        Console.WriteLine(" Использовать зелье: 3");
                        string orushie = Console.ReadLine();

                        if (orushie == "1")
                        {
                            mob_HP -= rand.Next(9, 20);
                            user_HP -= rand.Next(4, 15);
                            Console.WriteLine($"Использовано меч, осталось здоровья: {user_HP}, у Босса {mob_HP}");
                            if(mob_HP < 0)
                            {
                                Console.WriteLine("Вы выйграли");
                                break;
                            }

                        }
                        else if(orushie == "2")
                        {
                            if (strela > 0)
                            {
                                mob_HP -= rand.Next(9, 20);
                                user_HP -= rand.Next(4, 15);
                                Console.WriteLine($"Использовано меч, осталось здоровья: {user_HP}, у Босса {mob_HP}");
                            }
                            else
                            {
                                Console.WriteLine("Стрел нет ");
                            }

                        }
                           else if (orushie == "3")
                        {
                            if (ivent.Count != 0)
                            {
                                ivent.Remove(ivent.Last());
                                user_HP += 10;

                            }
                            else
                            {
                                Console.WriteLine("Зелья нет");
                            }
                        }
                    }
                }



            }
            
        }
    }
}

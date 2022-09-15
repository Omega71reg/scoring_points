/*
Завершается чемпионат Российской футбольной премьер-лиги. Сыграны все матчи, кроме последнего. 
В последнем матче команда A принимает у себя дома команду B. 
От результата этого матча может зависеть, какое место займёт команда A по итогам чемпионата.

Определите, на каком месте закончит чемпионат команда A в случае победы, ничьей или поражения в своём последнем матче.

По правилам футбола, если матч заканчивается победой одной из команд, то победившая команда получает три очка, 
а проигравшая — ноль очков. 
Если матч заканчивается ничьей, то обе команды получают по одному очку. 
Команды ранжируются в турнирной таблице в порядке убывания набранных очков, в случае равенства очков у двух и более команд они ранжируются по алфавиту.

Входные данные
В первой строке записано целое число n — количество команд в премьер-лиге (2≤n≤20).
 В следующих n строках приводится положение команд в турнирной таблице до того, 
как состоялся последний матч, в формате «название команды» «количество набранных очков». 
Названия команд имеют длину от 3 до 12 и состоят только из заглавных латинских букв. 
Гарантируется, что команды в таблице упорядочены по убыванию количества очков, 
а при равенстве очков — по алфавиту. Названия всех команд различны. 
Количество очков каждой команды лежит в пределах от 0 до 99.

Распределение очков между командами не обязательно описывает ситуацию, 
возможную в реальности — в рамках данной задачи не нужно обращать внимание на это и проверять входные данные на корректность.

В последней строке входных данных написано, какой матч ещё не сыгран. Его описание имеет формат «название команды 
A»-«название команды B». Названия команд A и B различны и присутствуют в турнирной таблице.

Выходные данные
Выведите три целых числа через пробел — на каком месте закончит чемпионат команда A в случае победы, ничьей или поражения в матче с командой B.


Примеры
входные данныеСкопировать
7
ZENIT 65
SOCHI 56
DINAMO 53
CSKA 50
KRASNODAR 49
LOKOMOTIV 48
AKHMAT 41
KRASNODAR-AKHMAT

4 5 5
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Championat3();
        }

        static void Championat3()
        {
            int kKomand = int.Parse(Console.ReadLine());
            string[] spisokKomand = new string[kKomand];
            string str = "";
            int count = 0;
            do
            {
                str = Console.ReadLine();
                spisokKomand[count] = int.Parse(str.Substring(str.LastIndexOf(' '))).ToString()+" ";
                spisokKomand[count] += str.Substring(0, str.LastIndexOf(' '));
                count++;
            } while (count < kKomand);

            string[] win = new string[spisokKomand.Length];
            Array.Copy(spisokKomand,win, spisokKomand.Length);
            string[] loss = new string[spisokKomand.Length];
            Array.Copy(spisokKomand, loss, spisokKomand.Length);
            string[] draw = new string[spisokKomand.Length];
            Array.Copy(spisokKomand, draw, spisokKomand.Length);

            string oponent = Console.ReadLine();
            string[] s = oponent.Split('-');
            string komanda1 = s[0];
            string komanda2 = s[1];
            int n = 0;
            string result = "";
            for (int i = 0; i < spisokKomand.Length; i++)//win
            {
                if (win[i].Contains(komanda1))
                {
                    n = int.Parse(win[i].Substring(0, win[i].IndexOf(' '))) + 3;
                    win[i] =  n + win[i].Substring(win[i].LastIndexOf(' '));
                }
            }
            for (int i = 0; i < loss.Length; i++)//loss
            {
                if (loss[i].Contains(komanda2))
                {
                    n = int.Parse(loss[i].Substring(0, loss[i].IndexOf(' '))) + 3;
                    loss[i] = n + loss[i].Substring(loss[i].LastIndexOf(' '));
                }
            }
            for (int i = 0; i < draw.Length; i++)//draw
            {
                if (draw[i].Contains(komanda1)|| draw[i].Contains(komanda2))
                {
                    n = int.Parse(draw[i].Substring(0, draw[i].IndexOf(' '))) + 1;
                    draw[i] = n + draw[i].Substring(draw[i].LastIndexOf(' '));
                }
            }
            Array.Sort(win);
            Array.Reverse(win);
            Array.Sort(loss);
            Array.Reverse(loss); 
            Array.Sort(draw);
            Array.Reverse(draw);

            for (int i = 0; i < kKomand; i++)
            {
                if (win[i].Contains(komanda1))
                result += i + 1+" ";
            }
            for (int i = 0; i < kKomand; i++)
            {
                if (draw[i].Contains(komanda1))
                    result += i + 1+" ";
            }
            for (int i = 0; i < kKomand; i++)
            {
                if (loss[i].Contains(komanda1))
                result += i + 1;
            }
            Console.WriteLine(result);

            Console.WriteLine();
        }

        static void Championat2()
        {
            int kol_vo = int.Parse(Console.ReadLine());
            string str = "";
            string[] spisokKomand = new string[kol_vo];
            int[] score = new int[kol_vo];

            int count = 0;
            do
            {
                str = Console.ReadLine();
                score[count] = int.Parse(str.Substring(str.LastIndexOf(' ')));
                spisokKomand[count] = str.Substring(0, str.LastIndexOf(' '));
                count++;
            } while (count < kol_vo);

            string oponent = Console.ReadLine();
            string[] s = oponent.Split('-');
            string komanda1 = s[0];
            string komanda2 = s[1];
            int[] result = new int[3];

            List<string> spisokWin = new List<string>(spisokKomand);
            List<int> scoreWin = new List<int>(score);
            List<string> spisokLoss = new List<string>(spisokKomand);
            List<int> scoreLoss = new List<int>(score);
            List<string> spisokNichya = new List<string>(spisokKomand);
            List<int> scoreNichya = new List<int>(score);

            for (int i = 0; i < kol_vo; i++)//если win
            {
                if (spisokWin[i] == komanda1)
                {
                    scoreWin[i] += 3;
                    break;
                }
            }
            Sort(spisokWin, scoreWin);
            for (int i = 0; i < kol_vo; i++)//если loss
            {
                if (spisokLoss[i] == komanda2)
                {
                    scoreLoss[i] += 3;
                    break;
                }
            }
            Sort(spisokLoss, scoreLoss);
            for (int i = 0; i < kol_vo; i++)//если Nichya
            {
                if (spisokNichya[i] == komanda2||spisokNichya[i]==komanda1)
                {
                    scoreNichya[i] += 1;
                }
            }
            Sort(spisokNichya, scoreNichya);


            Console.WriteLine();
        }
        static void Sort(List<string> spisokKomand, List<int> score)
        {
            int temp = 0;
            string temp1 = "";
            for (int i = 0; i < spisokKomand.Count; i++)
            {
                for (int j = 0; j < spisokKomand.Count-1; j++)
                {
                    if (score[j] < score[j + 1])
                    {
                        temp = score[j + 1];
                        temp1 = spisokKomand[j + 1];
                        score[j + 1] = score[j];
                        spisokKomand[j + 1] = spisokKomand[j];
                        score[j] = temp;
                        spisokKomand[j] = temp1;

                    }
                }
            }
        }


    }
}
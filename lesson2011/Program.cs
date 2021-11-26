using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Office.Interop.Excel;


namespace lesson2011
{
    class Program
    {
        static Random random;
        public static Dictionary<int, Students> student;
        public static LQueue<Toss> tosses = new LQueue<Toss>();
        static Program()
        {
            random = new Random();
            student = new Dictionary<int, Students>();
        }
        static void Write(string str)
        {
            string sout = "";
            if (File.Exists(loterystudents))
            {
                StreamReader sr = new StreamReader(loterystudents);
                sout = sr.ReadToEnd();
                sr.Close();
            }
            StreamWriter sw = new StreamWriter(loterystudents);
            sw.Write(sout + str);
            sw.Close();
        }
        static string loterystudents = "loterystudents";
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            var text = new StreamReader("Students.txt");
            var Student = new Dictionary<int, Students>();
            int countstudents = 0;
            while (text.ReadLine() != null)
            {
                countstudents++;
            }
            text = new StreamReader("Students.txt");
            for (int i = 1; i <= countstudents; i++)
            {
                string[] prikolnenkotemp = text.ReadLine().Split();
                string name = prikolnenkotemp[0];
                string affiliation = prikolnenkotemp[1];
                Student.Add(i, new Students(name, affiliation));
            }
            foreach (int key1 in student.Keys)
            {
                Console.WriteLine($"{key1}. {student[key1]}");
            }

            Console.WriteLine("\nTrue-начать; False-выйти:");
            bool lotery = Convert.ToBoolean(Console.ReadLine());
            while (lotery)
            {
                Console.WriteLine("Название:\nКоличество билетов:");
                string name = Console.ReadLine();
                int coltickets;
                if (!int.TryParse(Console.ReadLine(), out coltickets))
                {
                    coltickets = 0;
                }
                Console.WriteLine("Количество студентов,которые хотят принять участие в розыгрыше:");
                int colstudents;
                if (!int.TryParse(Console.ReadLine(), out colstudents))
                {
                    colstudents = 0;
                }
                List<int> bilet = new List<int>();
                Console.WriteLine($"Номера студентов (в количестве {colstudents}):");
                for (int i = 0; i < colstudents; i++)
                {
                    int numberofstudent;
                    if (int.TryParse(Console.ReadLine(), out numberofstudent) && !bilet.Contains(numberofstudent))
                    {
                        bilet.Add(numberofstudent);
                    }
                    else
                    {
                        Console.WriteLine("вы что-то вводите неправильно");
                        i = coltickets;
                    }
                }
                Console.WriteLine("\nНажмите enter, чтобы провести розыгрыш.");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    foreach (Toss toss in tosses)
                    {
                        foreach (int index in toss.Winners)
                        {
                            student[index].ratio *= Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    double ratiosumma = 0;
                    foreach (int index in bilet)
                    {
                        ratiosumma += student[index].ratio;
                    }
                    Stack<int> numberofWinners = new Stack<int>();
                    for (int i = 0; i < coltickets; i++)
                    {
                        Dictionary<double, int> temp = new Dictionary<double, int>();
                        double summa = 0;
                        foreach (int index in bilet)
                        {
                            summa += student[index].ratio / ratiosumma;
                            temp.Add(summa, index);
                        }
                        double numberofWinner = random.NextDouble();
                        foreach (double range in temp.Keys)
                        {
                            if (numberofWinner < range)
                            {
                                numberofWinners.Push(temp[range]);
                                bilet.Remove(numberofWinners.Peek());
                                ratiosumma -= student[numberofWinners.Peek()].ratio;
                                break;
                            }
                        }
                    }
                    tosses.Enqueue(new Toss(name, coltickets, numberofWinners));
                    Write(tosses.Peek().ToString());
                }
                Console.WriteLine("Информация по трём последним розыгрышам:");
                foreach (Toss toss in tosses)
                {
                    Console.WriteLine(toss);
                }
                foreach (Toss toss in tosses)
                {
                    foreach (int index in toss.Winners)
                    {
                        student[index].ratio = 1;
                    }
                }

                Console.WriteLine("Задание 2");
                try
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    Workbook workbook = excel.Workbooks.Open($"{Environment.CurrentDirectory}1.Болезни.xlsx");
                    Worksheet worksheet = workbook.Worksheets[1];
                    object[,] readRange = worksheet.Range["A2", "B10"].Value2;
                    Dictionary<string, string> deseases = new Dictionary<string, string>();
                    for (int i = 1; i <= readRange.GetLength(0); i++)
                    {
                        deseases.Add(readRange[i, 1].ToString().ToLower(), readRange[i, 2].ToString());
                    }
                    workbook.Close();
                    workbook = excel.Workbooks.Open($"{Environment.CurrentDirectory}2.Общее.xlsx");
                    worksheet = workbook.Worksheets[1];
                    readRange = worksheet.Range["G2", "G35"].Value2;
                    for (int i = 1; i <= readRange.Length; i++)
                    {
                        string readString = readRange[i, 1].ToString().ToLower();
                        foreach (var desease in deseases)
                        {
                            if (readString.Contains(desease.Key))
                            {
                                readRange[i, 1] = desease.Value;
                                break;
                            }
                        }
                    }
                    worksheet.Range["H2", "H35"].Value2 = readRange;
                    workbook.Save();
                    workbook.Close();
                    excel.Quit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}


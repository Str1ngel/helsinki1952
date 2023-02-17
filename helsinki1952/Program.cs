using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Data.SqlTypes;
using System.Net.Http;

namespace helsinki1952
{
    internal class Program
    {
        public static List<Reading> sportList = new List<Reading>();
        public static List<Reading> tmpList = new List<Reading>();

        public static Dictionary<int, int> olimPointCalcDic = new Dictionary<int, int>() {
            {1, 7},
            {2, 5},
            {3, 4},
            {4, 3},
            {5, 2},
            {6, 1}
        };
        public static Dictionary<string, int> sportNameMedalCountDic = sportNameMedalCountDic = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            Reader("../../data/helsinki.txt");
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7("../../data/helsinki2.txt", "kajakkenu", "kajak-kenu");
            Feladat8();
            Console.ReadKey();
        }
        static public void Feladat8()
        {
            Console.WriteLine("8. feladat:");

            int maxIndex = 0;

            for (int i = 1; i < sportList.Count; i++)
            {
                if (sportList[i].athletes > sportList[maxIndex].athletes)
                {
                    maxIndex = i;
                }
            }

            Console.WriteLine($"Helyezés: {sportList[maxIndex].racerPlace}\n" + 
                $"Sportág: {sportList[maxIndex].sportName}\n" +
                $"Versenyszám: {sportList[maxIndex].sportCompatition}\n" +
                $"Sportolók száma: {sportList[maxIndex].athletes}");
        }
        static public void Feladat7(string fileLocation, string oldData, string newData)
        {
            FileStream fs = new FileStream(fileLocation, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < sportList.Count; i++)
            {
                tmpList.Add(sportList[i]);

                if (sportList[i].sportName == oldData)
                {
                    tmpList[i].sportName = newData;
                }

                sw.WriteLine($"{tmpList[i].racerPlace} " +
                    $"{tmpList[i].athletes} " +
                    $"{tmpList[i].sportName} " +
                    $"{tmpList[i].sportCompatition}");
            }
            sw.Close();
            fs.Close();
        }
        static public void Feladat6()
        {
            Console.WriteLine("6. feladat:");

            List<string> sportNameMaxList = new List<string>();
            List<int> sportMedalCountMaxList = new List<int>();

            bool isDraw = false;

            foreach (Reading i in sportList)
            {
                if (sportNameMedalCountDic.ContainsKey(i.sportName))
                {
                    sportNameMedalCountDic[i.sportName] += +1;
                }
                else
                {
                    sportNameMedalCountDic.Add(i.sportName, +1);
                }
            }

            foreach (var i in sportNameMedalCountDic.OrderByDescending(key => key.Value))
            {
                sportNameMaxList.Add(i.Key);
                sportMedalCountMaxList.Add(i.Value);
            }

            if (sportMedalCountMaxList[0] == sportMedalCountMaxList[1])
            {
                isDraw = true;
            }

            Console.WriteLine((isDraw) ? "Egyenlő volt az érmek száma" : $"{sportNameMaxList[0]} sportágban szereztek több érmet");
        }
        static public void Feladat5()
        {
            Console.WriteLine("5. feladat:");

            int counter = 0;

            foreach (var i in sportList)
            {
                switch (i.racerPlace)
                {
                    case 1:
                        counter += olimPointCalcDic[1];
                        break;
                    case 2:
                        counter += olimPointCalcDic[2];
                        break;
                    case 3:
                        counter += olimPointCalcDic[3];
                        break;
                    case 4:
                        counter += olimPointCalcDic[4];
                        break;
                    case 5:
                        counter += olimPointCalcDic[5];
                        break;
                    case 6:
                        counter += olimPointCalcDic[6];
                        break;
                }
            }
            Console.WriteLine($"Olimpiai pontok száma: {counter}");
        }
        static public void Feladat4()
        {
            Console.WriteLine("4. feladat:");

            int goldCount = 0;
            int silverCount = 0;
            int bronzeCount = 0;

            foreach (var i in sportList)
            {
                switch (i.racerPlace)
                {
                    case 1:
                        goldCount++;
                        break;
                    case 2:
                        silverCount++;
                        break;
                    case 3:
                        bronzeCount++;
                        break;
                }
            }

            int medalsSum = goldCount + silverCount + bronzeCount;

            Console.WriteLine(
                $"Arany: {goldCount}\n"+
                $"Ezüst: {silverCount}\n"+
                $"Bronze: {bronzeCount}\n"+
                $"Összesen: {medalsSum}");
        }
        static public void Feladat3()
            => Console.WriteLine($"3. feladat:\n" +
                $"Pontszerző helyezések száma: {sportList.Count}");
        static public void Reader(string fileLocation)
        {
            StreamReader sr = new StreamReader(fileLocation);
            while (!sr.EndOfStream)
            {
                sportList.Add(new Reading(sr.ReadLine()));
            }
            sr.Close();
        }
    }
}

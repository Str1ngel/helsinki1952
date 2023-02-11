using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace helsinki1952
{
    internal class Program
    {
        public static List<Reading> sportList = new List<Reading>();

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
            Console.ReadKey();
        }
        static public void Feladat8()
        {
            Console.WriteLine("8. feladat:");
        }
        static public void Feladat6()
        {
            List<string> sportNameMaxList = new List<string>();
            List<int> sportMedalCountMaxList = new List<int>();
            bool isDraw = false;
            Console.WriteLine("6. feladat:");
            for (int i = 0; i < sportList.Count; i++)
            {
                if (sportNameMedalCountDic.ContainsKey(sportList[i].sportName))
                {
                    sportNameMedalCountDic[sportList[i].sportName] += +1;
                }
                else
                {
                    sportNameMedalCountDic.Add(sportList[i].sportName, +1);
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
            int medalsSum = 0;
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
            medalsSum = goldCount + silverCount + bronzeCount;
            Console.WriteLine(
                $"Arany: {goldCount}\n"+
                $"Ezüst: {silverCount}\n"+
                $"Bronze: {bronzeCount}\n"+
                $"Összesen: {medalsSum}\n"
                );
        }
        static public void Feladat3()
        {
            Console.WriteLine($"3. feladat:\n" +
                $"Pontszerző helyezések száma: {sportList.Count}");
        }
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

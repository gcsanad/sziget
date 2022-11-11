using System;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            const char TENGER_JEL = '*';
            const char SZIGET_JEL = 'O';
            const char HAJO_JEL = '█';


            /*
            char[,] tenger = new char[SOROK_SZAMA, OSZLOPOK_SZAMA];
            */
            //todo Itt majd be kell kérni a játékostól a pálya méretét - Ezt Zoli intézi majd
            const int SOROK_SZAMA = 20;
            const int OSZLOPOK_SZAMA = 60;
            char[,] tenger = new char[SOROK_SZAMA, OSZLOPOK_SZAMA];

            for (int sorIndex = 0; sorIndex < tenger.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < tenger.GetLength(1); oszlopIndex++)
                {
                    tenger[sorIndex, oszlopIndex] = TENGER_JEL;
                }
            }


            int szigetszam = 0;
            int szigetszel = 0;
            bool vanESzomszed = false;
            Random vel = new Random();
            for (int i = 0; i < 50; i++)
            {

                //Szélen lévő szigetek keresése
                int veloszlop = vel.Next(tenger.GetLength(1));
                int velsor = vel.Next(tenger.GetLength(0));
                if (veloszlop == 0 || veloszlop == 59)
                {
                    szigetszel += 1;
                }
                else if (velsor == 0 || velsor== 19)
                {
                    szigetszel += 1;
                }
                else if (veloszlop == 0 || veloszlop == 59 && velsor == 0 || velsor == 19)
                {
                    szigetszel += 1;
                }

                //Szomszédos szigetek keresése
                try
                {
                    if (tenger[velsor + 1, veloszlop] == SZIGET_JEL)
                    {
                        vanESzomszed = true;
                    }
                    else if (tenger[velsor - 1, veloszlop] == SZIGET_JEL)
                    {
                        vanESzomszed = true;
                    }
                    else if (tenger[velsor, veloszlop+1] == SZIGET_JEL)
                    {
                        vanESzomszed = true;
                    }
                    else if (tenger[velsor, veloszlop-1] == SZIGET_JEL)
                    {
                        vanESzomszed = true;
                    }
                }
                catch (Exception)
                {

                    continue;
                }
                szigetszam += 1;
                tenger[vel.Next(tenger.GetLength(0)), vel.Next(tenger.GetLength(1))] = SZIGET_JEL;
            }
            Megjelenit(tenger);



            static void Megjelenit(char[,] terkep)
            {
                Console.Clear();
                for (int sorIndex = 0; sorIndex < terkep.GetLength(0); sorIndex++)
                {
                    for (int oszlopIndex = 0; oszlopIndex < terkep.GetLength(1); oszlopIndex++)
                    {
                        Console.Write(terkep[sorIndex, oszlopIndex]);
                    }
                    Console.WriteLine();
                }
            }
            static void Hajo(char[,] terkep, int kx, int ky)
            {
                terkep[kx, ky] = HAJO_JEL;
            }
            
            //1) Hány sziget van a tengeren?

            Console.WriteLine($"{szigetszam}db sziget van!");

            //2) Hány sziget van a tenger szélén?

            Console.WriteLine($"{szigetszel}db sziget van a tenger szélén!");

            //3) Van-e olyan sziget, ami mellett közvetlenül másik sziget is van?
            string vaneszomszed = "";
            if (vanESzomszed == true)
            {
                vaneszomszed = "Van(nak)";
            }
            else if (vanESzomszed == false)
            {
                vaneszomszed = "Nincs(enek)";
            }
            Console.WriteLine($"{vaneszomszed}szomszédos sziget(ek)!");
            Console.ReadKey();
            //4) Hajó készítése!




            
            Console.ReadKey();

        }


    }
}

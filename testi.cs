using System;
using System.IO;
using System.Collections.Generic;

class Ohke_tietovisaA
{
    public string kyssari = string.Empty;
    public string syotto = string.Empty;
    public string valikoima = string.Empty;

    static void Main()
    {

        Console.WriteLine("Aloitus:");

        //string vastausTesti = Console.ReadLine();
        //Console.WriteLine("Vastaus:" + vastausTesti);


        string filePath = "Ohke_tietovisaA.csv";



        List<(string Question, string[] Valinnat, string Answer)> csvData = new List<(string, string[], string)>();

        StreamReader reader = new StreamReader(filePath);

        /*
        string headerLine = reader.ReadLine();
        Console.WriteLine("headerLine1: " + headerLine);
        headerLine = reader.ReadLine();
        Console.WriteLine("headerLine2: " + headerLine);
        */

        string line;
        while ((line = reader.ReadLine()) != null)
        {
            //Console.WriteLine("line: " + line);

            string[] values = line.Split(',');
            if (values.Length >= 5)
            {

                string kyssari = values[0];
                string[] valikoima = new string[3];
                valikoima[0] = values[1];
                valikoima[1] = values[2];
                valikoima[2] = values[3];
                //valikoima[3] = values[4];

                string syotto = values[4];

                //Console.WriteLine("kyssari: " + kyssari);

                csvData.Add((kyssari, valikoima, syotto));
            }
        }

        //Console.WriteLine("csvData:" + csvData.Count);


        foreach (var kyssari in csvData)
        {
            Console.WriteLine(kyssari.Question);
            //Console.WriteLine("Vaihtoehdot:");

            for (int i = 0; i < kyssari.Valinnat.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {kyssari.Valinnat[i]}");
            }

            Console.WriteLine("Valitse oikea vaihtoehto");
            string? vastaus = Console.ReadLine();


            int vastausNumero;
            bool onNumero = int.TryParse(vastaus, out vastausNumero);


            Console.WriteLine("----------------");

            if (onNumero && vastausNumero >= 1 && vastausNumero <= 3)
            {
                string valittuVastaus = kyssari.Valinnat[vastausNumero - 1];

                // Tarkistetaan vastaus
                if (valittuVastaus.Equals(kyssari.Answer, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Oikein!");
                }
                else
                {
                    Console.WriteLine("Väärin.");
                }

            }
            else
            {
                Console.WriteLine("Virheellinen valinta.");
            }

            Console.WriteLine("----------------");
            Thread.Sleep(1000);


        }
    }
}

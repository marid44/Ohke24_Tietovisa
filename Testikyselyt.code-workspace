using System;
using System.IO;
using System.Collections.Generic;

class Ohke_tietovisaA
{
    static void Main()
    {
        string filePath = "Ohke_tietovisaA.csv";
        List<(string Kysymys, string[] Vaihtoehdot, string Vastaus)> csvData = new List<(string, string[], string)>();

        using (StreamReader reader = new StreamReader(filePath))

        {
            string? headerLine = reader.ReadLine();

            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] values = line.Split(',');
                if (values.Length >= 6)
                {
                    string kysymys = values[0];
                    string[] vaihtoehdot = new string[3];
                    vaihtoehdot[0] = values[1];
                    vaihtoehdot[1] = values[2];
                    vaihtoehdot[2] = values[3];
                    string vastaus = values[4];
                    csvData.Add((kysymys, vaihtoehdot, vastaus));
                }
            }
        }
        foreach (var kysymyspari in csvData)
        {
            Console.WriteLine(kysymyspari.Kysymys);
            Console.WriteLine("Vaihtoehdot:");

            for (int i = 0; i < kysymyspari.Vaihtoehdot.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {kysymyspari.Vaihtoehdot[i]}");
            }
            Console.WriteLine("Valitse oikea vaihtoehto");
            string? vastaus = Console.ReadLine();

            int vastausNumero;
            bool onNumero = int.TryParse(vastaus, out vastausNumero);
            if (onNumero && vastausNumero >= 1 && vastausNumero <= 4)
            {
                string valittuVastaus = kysymyspari.Vaihtoehdot[vastausNumero - 1];

                // Tarkistetaan vastaus
                if (valittuVastaus.Equals(kysymyspari.Vastaus, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Oikein!");
                }
                else
                {
                    Console.WriteLine($"Väärin. Oikea vastaus on: {kysymyspari.Vastaus}");
                }
            }
            else
            {
                Console.WriteLine("Virheellinen valinta, yritä uudelleen.");
            }
        }
    }
}

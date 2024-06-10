namespace JAEscobarOraciones;

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        string path = "~/../../../../LeerArchivo.txt";
        string fileContent = string.Empty;
        Dictionary<int, string> map = new Dictionary<int, string>();
        List<int> cantidadLetras = new List<int>();
        List<string> parrafos = new List<string>();
        int parraf = 0, length = 0;
        string line = string.Empty;
        if (File.Exists(path))
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        parraf++;
                        map.Add(parraf, line);
                    }
                }
                foreach (KeyValuePair<int, string> cadenas in map.ToList())
                {
                    Console.WriteLine(cadenas.Value);
                    fileContent = cadenas.Value;
                    string[] valor = fileContent.Split(new string[] {" ", "," }, StringSplitOptions.None);
                    parrafos.Add((from texto in valor where texto.Length == valor.Max(v => v.Length) select texto).FirstOrDefault());
                    for (int i = 0; i < fileContent.Length; i++)
                    {
                        if (fileContent[i] != ' ')
                        {
                            length++;
                        }
                    }
                    Console.WriteLine($"parrafo {cadenas.Key} contiene {length} letras");
                    Console.WriteLine("------------------------------------");
                    cantidadLetras.Add(length);
                    length = 0;
                }
                Console.WriteLine($"La media es: {(float)(cantidadLetras.Sum() / cantidadLetras.Count)}");
                Console.WriteLine();
            }
        }
        Console.WriteLine($"Cantidad de parrafos: {parraf}");
        Console.WriteLine($"La palabra más large es: {(from value in parrafos where value.Length == parrafos.Max(v => v.Length) select value).FirstOrDefault()}");
        Console.ReadKey();
    }
}

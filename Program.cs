namespace JAEscobarOraciones;

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        string path = "~/../../../../LeerArchivo.txt";
        string fileContent = string.Empty;
        Dictionary<int, string> map = new Dictionary<int, string>();
        List<int> cantidadLetras = new List<int>();
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
                    fileContent = cadenas.Value;
                    for (int i = 0; i < fileContent.Length; i++)
                    {
                        if (fileContent[i] != ' ')
                        {
                            length++;
                        }
                    }
                    Console.WriteLine($"parrafo {cadenas.Key} contiene {length} letras");
                    cantidadLetras.Add(length);
                    length = 0;
                }
                Console.WriteLine($"La media es: {(float)(cantidadLetras.Sum() / cantidadLetras.Count)}");
            }
        }
        Console.WriteLine($"Cantidad de parrafos: {parraf}");
        Console.ReadKey();
    }
}

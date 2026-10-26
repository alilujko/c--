using System;
using System.ComponentModel.DataAnnotations;

namespace main;

class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Впишіть посилання на фалй: ");
        string url_file = Console.ReadLine();

        Compiler.Start_compiling(url_file);

    }
}
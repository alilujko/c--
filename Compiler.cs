using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Net.Mail;

namespace main;

class Compiler
{

    static Dictionary<string, object>zmini = new Dictionary<string, object>();

    public static void Start_compiling(string file)
    {
        using(StreamReader f = new StreamReader(file))
        {
            string line;

            while ((line = f.ReadLine()) != null)
            {
                string[] code = line.Split(".");

                if(code[0] == "Console")
                {
                    string[] code2 = code[1].Split("(");
                    if(code2[0] == "print")
                    {
                        string arg = code2[1].Replace(")", "").Trim();
                        if (arg.StartsWith("'"))
                        {
                            Console.WriteLine(arg.Trim('\''));
                        }
                        else
                        {
                            Console.WriteLine(zmini[arg]);
                        }
                    }else if(code2[0] == "input")
                    {
                        string[] code2_input = code[1].Split("(");
                        string[] code3_input = code2_input[1].Split("'");
                        Console.Write(code3_input[1]);
                        Console.ReadLine();
                    }else if(code2[0] == "pause")
                    {
                        string[] code2_pause = code[1].Split("(");
                        string num = code2_pause[1].Replace(")", "").Trim();
                        Thread.Sleep(Convert.ToInt32(num));
                    }
                }

                string[] codex = line.Split(" ", 4);

                if(codex[0] == "let" && codex.Length == 4)
                {
                    zmini[codex[1]] = codex[3].Trim('\'');
                }

                string[] koment = line.Split(" ");

                if(koment[0] == "//")
                {
                    continue;
                }

            }
        }
    }
}
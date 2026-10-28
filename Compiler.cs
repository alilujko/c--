using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Net.Mail;
using System.Globalization;

namespace main;

class Compiler
{

    static Dictionary<string, object>zmini = new Dictionary<string, object>();

    public static bool Checked_zmina(string[] lst)
    {  
        string arg = lst[1].Replace(")", "").Trim();
        if (arg.StartsWith("'"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static string get_text(string[] lst2)
    {
        string arg = lst2[1].Replace(")", "").Trim();
        return arg;
    }

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
                        if(Checked_zmina(code2) == false)
                        {
                            string arg = code2[1].Replace(")", "").Trim();
                            Console.WriteLine(arg);
                        }
                        else
                        {
                            string arg = code2[1].Replace(")", "").Trim();
                            Console.WriteLine(zmini[arg]);
                        }
                    }else if(code2[0] == "input")
                    {
                        string[] code2_input = code[1].Split("(");
                        if(Checked_zmina(code2_input) == false)
                        {
                            string arg_input = code2_input[1].Replace(")", "").Trim();
                            Console.Write(arg_input);
                        }
                        else
                        {
                            string arg_input = code2_input[1].Replace(")", "").Trim();
                            Console.Write(zmini[arg_input]);
                        }
                        Console.ReadLine();
                    }else if(code2[0] == "pause")
                    {
                        string[] code2_pause = code[1].Split("(");
                        if(Checked_zmina(code2_pause) == false)
                        {
                            string arg_num = code2_pause[1].Replace(")", "").Trim();
                            Thread.Sleep(Convert.ToInt32(arg_num));
                        }
                        else
                        {
                            string arg_num = code2_pause[1].Replace(")", "").Trim();
                            Thread.Sleep(Convert.ToInt32(zmini[arg_num]));
                        }
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasePlugin;
using BasePlugin.Interfaces;
using BasePlugin.Records;

namespace QuadraticEquation
{

    public class QuadraticEquationPlugin : IPlugin
    {
        public static string _Id = "QuadraticEquation";
        public string Id => _Id;
        public PluginOutput Execute(PluginInput input)
        {
            string[] words = input.Message.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            int count = words.Length;
            if (count == 3)
            {
                try
                {
                    double a = double.Parse(words[0]);
                    double b = double.Parse(words[1]);
                    double c = double.Parse(words[2]);
                    double equation =( Math.Pow(b, 2) - 4) * a * c;
                    if (equation < 0)
                    {

                        return new PluginOutput("No real roots exist.");
                    }

                    double x1 = (-b + Math.Sqrt(equation)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(equation)) / (2 * a);
                    string result = x1.ToString() + " " + x2.ToString();
                    return new PluginOutput(result);

                }
                catch
                {
                    return new PluginOutput("Enter only numbers.");
                }


            }
            else
            {
                return new PluginOutput("Error! Enter only 3 value.");
            }

        }
    }
}

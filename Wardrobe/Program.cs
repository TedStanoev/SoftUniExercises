using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string color = input[0];
                List<string> clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();

                    foreach (string item in clothes)
                    {
                        if (!wardrobe[color].ContainsKey(item))
                        {
                            wardrobe[color][item] = 1;
                        }
                        else
                        {
                            wardrobe[color][item]++;
                        }
                    }
                }
                else
                {
                    foreach (string item in clothes)
                    {
                        if (!wardrobe[color].ContainsKey(item))
                        {
                            wardrobe[color][item] = 1;
                        }
                        else
                        {
                            wardrobe[color][item]++;
                        }
                    }
                }
            }

            wardrobe.OrderByDescending(c => c.Value.Count).ThenBy(ci => ci.Value.Values).ToDictionary(c => c.Key, c => c.Value);

            string[] output = Console.ReadLine().Split().ToArray();
            string desiredColor = output[0];
            string desiredClothing = output[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var clothing in color.Value)
                {
                    if (color.Key == desiredColor && clothing.Key == desiredClothing)
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value}");
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram
{
    class Program
    {
        static void Main(string[] args)
        {
            int wendy = 0;
            int bob = 0;

            string colors = "wwwbbbwww";
            List<string> p = new List<string>();
            string playerset = string.Empty;
            foreach (char c in colors.ToCharArray())
            {
                if (playerset == string.Empty)
                {
                    playerset = playerset + c;
                }
                else if (playerset[0] == c)
                {
                    playerset = playerset + c;

                }
                else
                {
                    p.Add(playerset);
                    playerset = c.ToString();
                }
                
            }

            p.Add(playerset);


            foreach (string s in p)
            {
                if (s.Length > 2)
                {
                    if (s.Substring(0, 1) == "w")
                    {
                        wendy += s.Length - 2;
                    }
                    else
                    {
                        bob += s.Length - 2;
                    }
                }
            }

            string res = "";
            if(wendy > bob)
            {
                res = "Wendy";
            }
            else
            {
                res = "Bob";
            }




            long v = repeatedString("aba", 10);


            numberNeeded("CDE", "ABC");

            List<string> a = new List<string>()
            {
                "tea",
            "tea",
            "aaa"
        };


            List<string> b = new List<string>()
                  {
                "ate",
            "toe",
            "bbb"
        };

            for(int i =0; i <a.Count; i++)
            {
                Console.WriteLine(IsAnagramFast(a[i], b[i]));
            }

        }


        public static long repeatedString(string s, long n)
        {
            int i = 0;
            foreach (char c in s.ToCharArray())
            {
                if (c == 'a')
                {
                    i++;
                }
            }

            long div = n / Convert.ToInt64(s.Length);
            long rem = n % Convert.ToInt64(s.Length);

            long tot = div * i;

            string sub = s.Substring(0, Convert.ToInt32(rem));

            i = 0;
            foreach (char c in sub.ToCharArray())
            {
                if(c == 'a')
                {
                    i++;
                }
            }
            return tot + i;
        }


        public static int numberNeeded(string first, string second)
    {
        IDictionary<char, int> map = new Dictionary<char, int>();
        int count = 0;
        for (int i = 0; i < first.Length; i++)
        {
            if (!map.ContainsKey(first[i]))
            {
                map[first[i]] = 1;
            }
            else
            {
                int cur = map[first[i]];
                map[first[i]] = cur + 1;
            }
        }
        for (int i = 0; i < second.Length; i++)
        {
            if (map.ContainsKey(second[i]))
            {
                int cur = map[second[i]];
                if (cur == 1)
                {
                    map.Remove(second[i]);
                }
                else
                {
                    map[second[i]] = cur - 1;
                }
            }
            else
            {
                count++;
            }
        }

        foreach (int? i in map.Values)
        {
            count = count + i.Value;
        }

        return count;
    }


    private static string IsAnagramFast(string a, string b)
        {
            if (a.Length != b.Length)
            {
                return "-1";
            }
            if(a == b)
            {
                return "0";
            }

            var aFrequency = CalculateFrequency(a);
            var bFrequency = CalculateFrequency(b);


            bool nocharneed = true;
            int charchar = 0;
            foreach (var key in aFrequency.Keys)
            {
                if (!bFrequency.ContainsKey(key)) { nocharneed = false; charchar = charchar + aFrequency[key]; }
                else
                {

                    if (aFrequency[key] != bFrequency[key])
                    {
                        nocharneed = false;
                    }
                }             
            }

            if(nocharneed)
            {
                return "0";
            }
            return charchar.ToString();
        }

        private static Dictionary<char, int> CalculateFrequency(string input)
        {
            var frequency = new Dictionary<char, int>();
            foreach (var c in input)
            {
                if (!frequency.ContainsKey(c))
                {
                    frequency.Add(c, 0);
                }
                ++frequency[c];
            }
            return frequency;
        }
    }
}

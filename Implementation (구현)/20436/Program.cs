using System.Text;

namespace _20436
{
    class Program
    {
        static List<List<char>> qwerty = new List<List<char>>()
        {
            new List<char>() { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' },
            new List<char>() { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' },
            new List<char>() {'z', 'x', 'c', 'v', 'b', 'n', 'm' }
        };

        static List<char> vowel = new List<char>() { 'y', 'u', 'i', 'o', 'p', 'h', 'j', 'k', 'l', 'b', 'n', 'm' };

        static int left_x, left_y, right_x, right_y;
        static int sumR = 0;
        static int sumL = 0;
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            sb.Append(Console.ReadLine());
            var str = sb.ToString().Split(' ');
            char sl = char.Parse(str[0]);
            char sr = char.Parse(str[1]);

            sb.Clear();
            sb.Append(Console.ReadLine());

            for (int i = 0; i < qwerty.Count; i++)
            {
                for (int j = 0; j < qwerty[i].Count; j++)
                {
                    if (qwerty[i][j] == sl)
                    {
                        left_x = i;
                        left_y = j;
                    }
                    else if (qwerty[i][j] == sr)
                    {
                        right_x = i;
                        right_y = j;
                    }
                }
            }

            for (int k = 0; k < sb.Length; k++)
            {
                int current_x = 0, current_y = 0;
                for (int i = 0; i < qwerty.Count; i++)
                {
                    for (int j = 0; j < qwerty[i].Count; j++)
                    {
                        if (qwerty[i][j] == sb[k])
                        {
                            current_x = i;
                            current_y = j;
                        }
                    }
                }

                if (vowel.Contains(sb[k]))
                {
                    sumR += Math.Abs(right_x - current_x) + Math.Abs(right_y - current_y) + 1;
                    right_x = current_x;
                    right_y = current_y;
                }
                else
                {
                    sumL += Math.Abs(left_x - current_x) + Math.Abs(left_y - current_y) + 1;
                    left_x = current_x;
                    left_y = current_y;
                }
            }

            Console.WriteLine(sumR + sumL);

        }
    }
}

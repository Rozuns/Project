using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rextester
{
    public  class Program
    {

        // Разрешени символи {M}
        static char[] M = new char[] { 'Г','З','Л','П','У', 'Ч', 'Ь', 'А', 'Д', 'И', 'М', 'Р', 'Ф', 'Ш', 'Ю', 'Б', 'Е', 'Й', 'Н', 'С', 'Х', 'Щ', 'Я', 'В', 'Ж', 'К', 'О', 'Т', 'Ц', 'Ъ', ' ' };
        static int n = M.Length;
        // Определяне на позицията на даден символ в {M}
        static int ReturnPosition(char c)
        {
            for (int i = 0; i < n; i++)
            {
                if (c == M[i])
                {
                    return i + 1;
                }
            }
            return -1;
        }

        // Шифроване
        static string Encrypt(string P, string K)
        {
            int i;
            // Инициализиране на C
            string C = "";
            // Позиция на символа от P в {M}
            int posM;
            // Позиция на символа от К в {M}
            int posK;

            // Обхождане на P
            for (i = 0; i < P.Length; i++)
            {
                posM = ReturnPosition(P[i]);

                // Проверка за невалиден символ
                if (posM == -1)
                {
                    Console.WriteLine("НЕВАЛИДЕН СИМВОЛ");
                    return string.Empty;
                }

                // Циклично използване на ключа
                if (i < K.Length)
                {
                    posK = ReturnPosition(K[i]);
                }
                else
                {
                    posK = ReturnPosition(K[i % K.Length]);
                }

                // Добавяне на символ към C
                C += M[(posM + posK) % n - 1];
            }

            return C;
        }

        // Дешифриране
       static string Decrypt(string C, string K)
        {
            int i;
            // Инициализиране на P
            string P = "";
            // Позиция на символа от C в {M}
            int posM;
            // Позиция на символа от К в {M}
            int posK;

            // Обхождане на C
            for (i = 0; i < C.Length; i++)
            {
                posM = ReturnPosition(C[i]);

                // Циклично използване на ключа
                if (i < K.Length)
                {
                    posK = ReturnPosition(K[i]);
                }
                else
                {
                    posK = ReturnPosition(K[i % K.Length]);
                }

                // Добавяне на символ към P
                int d = (posM - posK) % n - 1;
                if (d >= 0)
                    P += M[d];
                else
                    P += M[d + n];
            }

            return P;
        }

       public static void Main ( string[] args )
        {
            //Console.OutputEncoding = Encoding.UTF8;
            string P;
            string K;
            string C;
            string P1;
            string choice;

            bool isDone = false;
            while (!isDone)
            {
                Console.WriteLine("1. Криптиране");
                Console.WriteLine("2. Декриптиране");
                Console.WriteLine("3. Спиране на програмата");
                Console.WriteLine("Моля изберете метод");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Въведете P: ");
                        P = Console.ReadLine().ToUpper();
                        Console.Write("Въведете K: ");
                        K = Console.ReadLine().ToUpper();

                        C = Encrypt(P, K);                       
                        Console.WriteLine();
                        Console.WriteLine("C: " + C);                       
                        break;
                    case "2":
                        Console.Write("Въведете C: ");
                        C = Console.ReadLine().ToUpper();
                        Console.Write("Въведете K: ");
                        K = Console.ReadLine().ToUpper();
                        P1 = Decrypt(C, K);
                        Console.WriteLine();                       
                        Console.WriteLine("P1: " + P1);
                        break;
                        case "3":
                        isDone = true;
                        break;
                    default:
                        Console.WriteLine("Моля изберете от менюто");
                        break;
                }
            }
        }
    }

}

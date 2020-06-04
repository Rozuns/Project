

    class Program
    {

        // ��������� ������� {M}
        static char[] M = new char[] { '�' '�' '�' '�' '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', ' ' };
        static int n = M.Length;
        // ���������� �� ��������� �� ����� ������ � {M}
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

        // ���������
        static string Encrypt(string P, string K)
        {
            int i;
            // �������������� �� C
            string C = "";
            // ������� �� ������� �� P � {M}
            int posM;
            // ������� �� ������� �� � � {M}
            int posK;

            // ��������� �� P
            for (i = 0; i < P.Length; i++)
            {
                posM = ReturnPosition(P[i]);

                // �������� �� ��������� ������
                if (posM == -1)
                {
                    Console.WriteLine("��������� ������");
                    return string.Empty;
                }

                // �������� ���������� �� �����
                if (i < K.Length)
                {
                    posK = ReturnPosition(K[i]);
                }
                else
                {
                    posK = ReturnPosition(K[i % K.Length]);
                }

                // �������� �� ������ ��� C
                C += M[(posM + posK) % n - 1];
            }

            return C;
        }

        // �����������
        static string Decrypt(string C, string K)
        {
            int i;
            // �������������� �� P
            string P = "";
            // ������� �� ������� �� C � {M}
            int posM;
            // ������� �� ������� �� � � {M}
            int posK;

            // ��������� �� C
            for (i = 0; i < C.Length; i++)
            {
                posM = ReturnPosition(C[i]);

                // �������� ���������� �� �����
                if (i < K.Length)
                {
                    posK = ReturnPosition(K[i]);
                }
                else
                {
                    posK = ReturnPosition(K[i % K.Length]);
                }

                // �������� �� ������ ��� P
                int d = (posM - posK) % n - 1;
                if (d >= 0)
                    P += M[d];
                else
                    P += M[d + n];
            }

            return P;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string P;
            string K;
            string C;
            string P1;
            string choice;

            bool isDone = false;
            while (!isDone)
            {
                Console.WriteLine("1. ����������");
                Console.WriteLine("2. ������������");
                Console.WriteLine("3. ������� �� ����������");
                Console.WriteLine("���� �������� �����");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("�������� P: ");
                        P = Console.ReadLine().ToUpper();
                        Console.Write("�������� K: ");
                        K = Console.ReadLine().ToUpper();

                        C = Encrypt(P, K);                       
                        Console.WriteLine();
                        Console.WriteLine("C: " + C);                       
                        break;
                    case "2":
                        Console.Write("�������� C: ");
                        C = Console.ReadLine().ToUpper();
                        Console.Write("�������� K: ");
                        K = Console.ReadLine().ToUpper();
                        P1 = Decrypt(C, K);
                        Console.WriteLine();                       
                        Console.WriteLine("P1: " + P1);
                        break;
                        case "3":
                        isDone = true;
                        break;
                    default:
                        Console.WriteLine("���� �������� �� ������");
                        break;
                }
            }
        }
    }


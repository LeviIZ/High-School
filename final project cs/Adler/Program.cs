//17/06/15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Timers;
using System.Threading;
using System.Media;
using System.Diagnostics;

namespace Adler
{
    class Program
    {
        //1. merge sort
        public static void merge_sort(int[] p, int a, int b, int c)
        {
            if (!(a == b && a == c && b == c))
            {
                int[] d = new int[c - a + 1]; // temp array
                int j = 0, k, x = a, y = b + 1;//x - pointer on the start left part and y - pointer on the start right part

                // main loop for merge sort
                for (int i = a; i <= c; i++)
                {
                    //part 1
                    if (x <= b && y <= c)
                    {
                        if (p[x] >= p[y])
                            d[j++] = p[y++];
                        else
                            d[j++] = p[x++];
                    }

                    //part 2
                    else if (x == b + 1 && y <= c)
                        d[j++] = p[y++];

                    //part 3
                    else
                        d[j++] = p[x++];
                }// end for

                //copy from d to p
                for (k = a, j = 0; k <= c; k++)
                    p[k] = d[j++];
            }
        }

        // 2 rec (recursion)
        public static void rec(int[] p, int d, int q)
        {
            int k = (d + q) / 2;
            if (d < k)
            {
                rec(p, d, k);
                rec(p, k + 1, q);
                merge_sort(p, d, k, q);
            }
            else
                merge_sort(p, d, k, q);
        }

        //3
        public static int Timer_second()
        {
            DateTime dt = DateTime.Now;

            return dt.Second;

        }

        //4
        public static int Timer_minute()
        {
            DateTime dt = DateTime.Now;

            return dt.Minute;

        }

        //5
        public static int Timer_millisecond()
        {
            DateTime dt = DateTime.Now;

            return dt.Millisecond;

        }

        //6
        public static void Write_to_file(string name_file, int K, int R)
        {
            //K- the number of elements, r- segment, for examples [1,R)
            int u = 0;
            string str;
            Random rnd = new Random();

            //open
            StreamWriter y = new StreamWriter("D:\\"+name_file);

            for (int h = 0; h < K; h++)
            {
                u = rnd.Next(1, R);
                str = u.ToString();
                y.WriteLine(str);
            }

            //close
            y.Close();
        }

        //7
        public static void Read_from_file(string name_file, int K, int[] p)
        {

            //open
            TextReader x = new StreamReader("D:\\"+name_file);

            //reading of random numbers from the file to the array p[]
            for (int i = 0; i < K; i++)
            {
                string str = x.ReadLine();
                p[i] = int.Parse(str);
            }

            //close
            x.Close();
        }

        //8
        public static void Time_print(int minute_start, int second_start, int minute_end, int second_end, out int minute, out int second)
        {
            if (minute_start <= minute_end && second_start <= second_end)
            {
                minute = (minute_end - minute_start);
                second = (second_end - second_start);
            }
            else if (minute_start > minute_end && second_start <= second_end)
            {
                minute = (60 - (minute_start - minute_end));
                second = (second_end - second_start);
            }
            else if (minute_start > minute_end && second_start > second_end)
            {
                minute = (60 - (minute_start - minute_end));
                second = (1000 - (second_start - second_end));
            }
            else if (minute_start <= minute_end && second_start > second_end)
            {
                minute = minute_end - minute_start - 1;
                second = (1000 - (second_start - second_end));
            }
            else
            {
                minute = (minute_end - minute_start - 1);
                second = (60 - (second_start - second_end));
            }

            //temp
            /*
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(minute + " minutes ");
            Console.Write(second + " seconds ");
            Console.ResetColor();
            */

        }

        //9
        public static void Write_to_file_out(string name_file, int[] p)
        {
            //K- the number of elements, r- segment, for examples [1,r)

            //open
            StreamWriter y = new StreamWriter("D:\\"+name_file);
            
            for(int h = 0; h < p.Length; h++)
            {
                y.WriteLine(p[h]+"\n");
            }

            //close
            y.Close();
        }

        //10 - choose1
        public static int Menu(int ar)
        {
            int R = 0, K = 0;

            //menu
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("                                       MENU:\n\n\n                       ***   Project of Amachya Adler   ***\n\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n\nPlease insert number to continue: " + "\n\n");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" 1 ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("to choose in Random" + "\n");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" 2 ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("to choose in Manual" + "\n\n\n    ");
                    Console.ForegroundColor = ConsoleColor.White;
                    int F = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\n\n\n" + "                          ***  Please wait !  ***");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Console.Clear();


                    if (F == 1)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(30, 5);
                                Console.WriteLine("Enter your segment: ");
                                R = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.Write("\n\n" + " wrong! please choose number");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                        }

                        while (true)
                        {
                            try
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(25, 11);
                                Console.WriteLine("Enter the number of items: ");
                                K = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.Write("\n\n" + " error! please choose number");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                        }

                        Console.ResetColor();
                        Console.Clear();

                        //call write to file my data
                        Write_to_file("input_dat.txt", K, R);
                    }
                    else if (F == 2)
                    {
                        K = Print_Manual("input_dat.txt");
                    }
                    else
                    {
                        Console.Write("\n\n" + " wrong! choose 1 or 2");
                        Thread.Sleep(2000);
                        Console.Clear();
                        K = 3;
                    }                 
                    break;
                }
                catch (System.OverflowException)
                {
                    Console.Write("\n\n" + " wrong! choose 1 or 2");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                catch (System.FormatException)
                {
                    Console.Write("\n\n" + " wrong! choose 1 or 2");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            if (K == 3)
                K = Menu(ar);
            return K;
        }

        //11
        public static int Print_Manual(string name_file)
        {
            //open
            StreamWriter y = new StreamWriter("D:\\" + name_file);
            string str;

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 5);
            Console.WriteLine("Enter the number of items: ");
            int K = int.Parse(Console.ReadLine());
            Console.ResetColor();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 5);
            Console.WriteLine("Enter your the numbers: "+"\n");

            for (int i = 0; i < K; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" \n");
                int j = int.Parse(Console.ReadLine());
                str = j.ToString();
                y.WriteLine(str);
            }
            //close
            y.Close();

            Console.ResetColor();
            Console.Clear();

            return K;
        }

        //12 - choose2
        public static void Menu2(int[] p0, int[] p)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\n\n\nPlease insert number to continue: " + "\n\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" 1 ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("if you want to see your array" + "\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" 2 ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("to exit" + "\n\n\n    ");
            Console.ForegroundColor = ConsoleColor.White;
            int F = int.Parse(Console.ReadLine());
            Console.ResetColor();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.ResetColor();
            Thread.Sleep(2000);
            Console.Clear();

            if (F == 1)
            {
                //before a merge sort print p[]
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + "YOUR ARRAY BEFORE THE ORDERING:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int i = 0; i < p.Length; i++)
                {
                    Console.Write(p0[i] + " ");
                }
                Console.WriteLine("\n\n");
                Console.ResetColor();
                Thread.Sleep(2000);

                //after a merge sort print p[]
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("YOUR ARRAY AFTER THE ORDERING:");
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < p.Length; i++)
                {
                    Console.Write(p[i] + " ");
                }
                Console.WriteLine();
                Console.ResetColor();
                Thread.Sleep(2000);

                Process.Start("D:\\output_dat.txt");
            }

            else if (F == 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\n\n\n\n\n\n                      ***  Bye,  My best regards !   ***\n\n\n");
                Console.ResetColor();
                Thread.Sleep(5000);
                Console.WriteLine();
                Console.Clear();
            }

            else
            {
                Console.Write("\n\n" + " wrong! choose 1 or 2");
                Thread.Sleep(5000);
                Console.Clear();
                Menu2(p0,p);
            }
        }


        //0 main method
        static void Main(string[] args)
        {
            int K = 0, ar = 0;
            
            //create K random numbers from the segment [1,r) and write to the file "input_dat.txt"
            Random rnd = new Random();
            
            //sound
            SoundPlayer Tslil = new SoundPlayer(@"D:\q.wav");

            //Home screen
            Tslil.Play();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(35, 5);
            Console.WriteLine("Hello");
            Thread.Sleep(1000);
            Console.SetCursorPosition(17, 7);
            Console.WriteLine("This program series all set by the scale");
            Console.SetCursorPosition(25, 9);
            Console.WriteLine("Follow the instructions");
            Console.ResetColor();
            Thread.Sleep(6000);
            Console.Clear();

            K = Menu(ar);

            
            int[] p = new int[K]; // array with non ranged numbers (the size of array is K)
            int[] p0 = new int[K]; // array before the ordering


            //read my numbers from the file to the array p[]
            Read_from_file("input_dat.txt", K, p);
            

            int a, b, c, N, M, da;// M - external for; N - internal for
            M = (int)Math.Ceiling((Math.Log(K) / Math.Log(2)));


            //color
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nsize of array is: " + K + "\n");
            Console.ResetColor();
            Thread.Sleep(2000);

            //integer
            int minute, second, millisecond;
            int millisecond_start, second_start, minute_start;
            int millisecond_end, second_end, minute_end;

            //copy array p to p0
            for (int i = 0; i < p.Length; i++)
            {
                p0[i] = p[i];
            }
            

            //start timer for merge
            millisecond_start = Timer_millisecond();
            second_start = Timer_second();
            minute_start = Timer_minute();

            //loop main
            for (int v = 0; v < M; v++)
            {
                //init
                a = 0;
                b = (int)Math.Pow(2, v) - 1;
                c = (int)Math.Pow(2, v + 1) - 1;
                if (c > K - 1)
                {
                    c = K - 1;
                }

                N = (int)Math.Ceiling(Math.Pow(2, (Math.Log(K) / Math.Log(2)) - 1 - v));

                //temp
                //Console.WriteLine("\na="+a+" b="+b+" c="+c+"  N="+N);

                for (int i = 0; i < N; i++)
                {
                    //call
                    merge_sort(p, a, b, c);

                    //update
                    da=(int)Math.Pow(2, v + 1);
                    a = a + da < K ? a + da : K - 1;
                    b = b + da < K ? b + da : K - 1;
                    c = c + da < K ? c + da : K - 1;


                }
            }

            //end timer for merge
            millisecond_end = Timer_millisecond();
            second_end = Timer_second();
            minute_end = Timer_minute();


            //print time (for merge)
            Time_print(minute_start, second_start, minute_end, second_end, out minute, out second);
            Time_print(second_start, millisecond_start, second_end, millisecond_end, out second, out millisecond);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nquick sorting: ");
            Console.Write(minute + " minutes and ");
            Console.Write(second + " seconds and ");
            Console.Write(millisecond + " milliseconds\n\n");
            Console.ResetColor();
            
            //call output_dat
            Write_to_file_out("output_dat.txt", p);

            //start timer for bubble sort ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //read my numbers from the file to the array p[]
            Read_from_file("input_dat.txt", K, p);

            //timer
            millisecond_start = Timer_millisecond();
            second_start = Timer_second();
            minute_start = Timer_minute();
            
            for (int i = 0; i < p.Length-1 ; i++)
            {
                for (int j = 0; j < p.Length-1; j++)
                {
                    if (p[j + 1] < p[j])
                    {
                        int temp = p[j];
                        p[j] = p[j + 1];
                        p[j + 1] = temp;
                    }
                }
            }

            //end timer for bubble sort
            millisecond_end = Timer_millisecond();
            second_end = Timer_second();
            minute_end = Timer_minute();


            Time_print(minute_start, second_start, minute_end, second_end, out minute, out second);
            Time_print(second_start, millisecond_start, second_end, millisecond_end, out second, out millisecond);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("bubble sort: ");
            Console.Write(minute + " minutes and ");
            Console.Write(second + " seconds and " );
            Console.Write(millisecond + " millisecond\n\n");
            Console.ResetColor();
            //end timer for bubble sort ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            
            
            //start timer for recursion
            millisecond_start = Timer_millisecond();
            second_start = Timer_second();
            minute_start = Timer_minute();

            //call recursion
            rec(p, 0, p.Length - 1);

            //end timer for recursion
            millisecond_end = Timer_millisecond();
            second_end = Timer_second();
            minute_end = Timer_minute();


            //call Time_print
            Time_print(minute_start, second_start, minute_end, second_end, out minute, out second);
            Time_print(second_start, millisecond_start, second_end, millisecond_end, out second, out millisecond);

            //print timer for recursion
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("sort by recursion: ");
            Console.Write(minute + " minutes and ");
            Console.Write(second + " seconds and ");
            Console.Write(millisecond + " millisecond\n\n\n");
            Console.ResetColor();
            Thread.Sleep(1000);
            

            //check my array
            int mone = 0;
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < p.Length - 1; i++)
            {
                if (p[i] <= p[i + 1])
                    mone++;
            }
            if (mone == p.Length - 1)
                Console.WriteLine("Enjoy!\n");
            Console.ResetColor();
            Thread.Sleep(5000);

            Menu2(p0,p);
            
        }
    }
}

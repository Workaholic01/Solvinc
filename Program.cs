using PPIC3.PSCA.ITDept.Baseline.API.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Console_Framework
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Decrypt("fc0iUkg331qk3V8HY6MWvQ=="));
            //Console.ReadLine();

            //int[] ar = { 10, 20, 20, 10, 10, 30, 50, 10, 20 };
            //sockMerchant(9, ar);

            //countingValleys(8, "UDDDUDUU");
            //int[] arr = { 0,0,1,0,0,1,0};
            //jumpingOnClouds(arr);
            //int[] arr = { -4,3,-9,0,4,1};
            //plusMinus(arr);

            //staircase(6);
            int[] arr = { 1, 2, 5, 7, 9 };
            miniMaxSum(arr);
            Console.Read();


        }

        static int jumpingOnClouds(int[] c)
        {
            int noOfJumps = 0;
            int j = 1;
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 0)
                {
                    if (j == c.Length)
                        break;

                    if (c[i] == c[j])
                        noOfJumps++;
                }
                j++;
            }

            return noOfJumps;


        }
        private static int countingValleys(int n, string s)
        {
            int noOfValleys = 0;
            int level = 0;
            int temp = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'U')
                    level++;
                if (s[i] == 'D')
                    level--;

                if (level == 0 && s[i] == 'U')
                    noOfValleys++;

            }

            return noOfValleys;


        }
        private static int sockMerchant(int numberOfSocks, int[] ar)
        {
            int noOfPairs = 0;

            if (ar.Length <= 1)
                return 0;
            List<int> arrOfUniqueColors = ar.Distinct().ToList();
            for (int i = 0; i < arrOfUniqueColors.Count; i++)
            {
                int count = ar.Where(x => x == arrOfUniqueColors[i]).Count();

                if (count % 2 == 0)
                    noOfPairs += count / 2;
                else
                    noOfPairs += (count - 1) / 2;
            }

            return noOfPairs;
        }
        static int simpleArraySum(int[] ar)
        {
            return ar.Sum();
        }

        // Complete the compareTriplets function below.
        static List<int> compareTriplets(List<int> a, List<int> b)
        {
            int ptsA = 0;
            int ptsB = 0;

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] > b[i])
                    ptsA += 1;
                else if (a[i] < b[i])
                    ptsB += 1;
            }

            return new List<int>() { ptsA, ptsB };

        }

        // Complete the aVeryBigSum function below.
        static long aVeryBigSum(long[] ar)
        {
            return ar.Sum();

        }

        /*
     * Complete the 'diagonalDifference' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

        public static int diagonalDifference(List<List<int>> arr)
        {
            int primarySum = 0;
            int secondarySum = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < arr[i].Count; j++)
                {
                    if (i == j)
                        primarySum += arr[i][j];

                }
            }
            int m = arr.Count;
            for (int i = 0; i < arr.Count; i++)
            {
                m = m - 1;
                for (int j = 0; j < arr[i].Count; j++)
                {
                    if (j == m)
                        secondarySum += arr[i][j];

                }
            }

            return Math.Abs(primarySum - secondarySum);
        }

        //Given an array of integers, calculate the fractions of its elements that are positive, negative, and are zeros.Print the decimal value of each fraction on a new line.
        //Note: This challenge introduces precision problems.The test cases are scaled to six decimal places, though answers with absolute error of up to are acceptable.
        //For example, given the array  there are  elements, two positive, two negative and one zero.Their ratios would be , and.It should be printed as
        static void plusMinus(int[] arr)
        {
            int arLength = arr.Length;

            decimal positive = arr.Where(z => z > 0).Count();
            decimal negative = arr.Where(z => z < 0).Count();
            decimal Zeros = arr.Where(z => z == 0).Count();

            Console.WriteLine(positive / arLength);
            Console.WriteLine(negative / arLength);
            Console.WriteLine(Zeros / arLength);

        }

        //#
        //##
        //###
        //####
        static void staircase(int n)
        {
            int temp = n;
            for (int i = 0; i < n; i++)
            {
                temp = temp - 1;
                for (int j = 0; j < n; j++)
                {
                    if (j >= temp)
                        Console.Write("#");
                    else
                        Console.Write(" ");

                }
                Console.WriteLine();
            }

        }

        // Complete the miniMaxSum function below.
        static void miniMaxSum(int[] arr)
        {
            long result1 = 0;
            long result2 = 0;
            long max = arr.Max();
            long min = arr.Min();
            for (int i = 0; i < arr.Length; i++)
            {
                result1 += arr[i];
                result2 += arr[i];
            }
            Console.WriteLine("{0} {1}", result1 - max, result2 - min);

            long sum = arr.Sum();
            long minSum = sum - arr.Max();
            long maxSum = sum - arr.Min();

            Console.WriteLine(minSum + " " + maxSum);

        }


        // Complete the birthdayCakeCandles function below.
        static int birthdayCakeCandles(int[] ar)
        {

            int max = ar.Max();
            return ar.Where(x => x == max).Count();
        }

        /*
     * Complete the timeConversion function below.
     */
        static string timeConversion(string s)
        {
            DateTime d = DateTime.Parse(s);

            return d.ToString("HH:mm:sss");
        }
        public static string Decrypt(string cipherText)
        {
            //todo pick this from app.config
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(ApplicationConfigurations.EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}

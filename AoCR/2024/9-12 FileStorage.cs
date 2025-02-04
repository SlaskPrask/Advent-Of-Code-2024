﻿namespace AoCR.Old
{
    public class _9
	{
        public static long Day9()
        {
            string[] input = File.ReadAllLines("../../../Input.txt");

            long res = 0;

            for (int i = 0; i < input.Length; i++)
            {
                List<long> format = new List<long>();
                for (int j = 0; j < input[i].Length; j++)
                {
                    int data = int.Parse(char.ToString(input[i][j]));
                    for (int k = 0; k < data; k++)
                    {
                        if (j % 2 == 0)
                        {
                            format.Add(j / 2);
                        }
                        else
                        {
                            format.Add(-1);
                        }
                    }
                }

                //Compact

                HashSet<long> skip = new();
                for (int j = format.Count - 1; j >= 0; j--)
                {
                    if (format[j] != -1)
                    {
                        int fileSize = 1;
                        long data = format[j];
                        if (skip.Contains(data))
                        {
                            continue;
                        }
                        skip.Add(data);
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (format[k] != data)
                            {
                                break;
                            }
                            fileSize++;
                        }

                        for (int l = 0; l < j - fileSize; l++)
                        {
                            if (format[l] == -1)
                            {
                                int emptySize = 1;
                                for (int k = l + 1; k < format.Count; k++)
                                {
                                    if (format[k] != -1)
                                    {
                                        break;
                                    }
                                    emptySize++;
                                }
                                if (emptySize >= fileSize)
                                {
                                    for (int k = 0; k < fileSize; k++)
                                    {
                                        format[k + l] = data;
                                        format[j - k] = -1;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                // Checksum
                for (int j = 0; j < format.Count; j++)
                {
                    if (format[j] == -1)
                    {
                        continue;
                    }
                    res += format[j] * j;
                }
            }

            return res;
        }
    }
}
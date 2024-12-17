using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoCR.Old
{
    public class _17
    {
        public enum Operands
        {
            Division = 0,
            BitwiseXOR = 1,
            Mod8 = 2,
            JumpNotZero = 3,
            BitwiseXORBC = 4,
            Out = 5,
            DivToB = 6,
            DivToC = 7,
        }

        public static long GetComboOperand(long op, long ra, long rb, long rc)
        {
            switch (op)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return op;
                case 4:
                    return ra;
                case 5:
                    return rb;
                default:
                    return rc;
            }
        }

        public static string Day17()
        {
            string[] input = File.ReadAllLines("../../../Input.txt");
            List<int> instructions = new List<int>();
            string inst = "";

            Regex regex = new Regex(@": (.*)");
            long regBOrig = 0;
            long regCOrig = 0;

            for (int i = 0; i < input.Length; i++)
            {
                Match match = regex.Match(input[i]);
                switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        regBOrig = long.Parse(match.Groups[1].Value);
                        break;
                    case 2:
                        regCOrig = long.Parse(match.Groups[1].Value);
                        break;
                    case 4:   
                        inst = match.Groups[1].Value + ",";

                        foreach (char c in inst)
                        {
                            string ch = "" + c;
                            if (c != ',')
                            {
                                instructions.Add(int.Parse(ch));
                            }
                        }

                        break;
                    default:
                        break;
                }
            }

            int bestMatch = 0;

            Parallel.For(4110801692, 889603462988699, (i) =>
            {
                long regA = i;
                long regB = regBOrig;
                long regC = regCOrig;
                string res = "";
                bool doBreak = false;
                for (int j = 0; j < instructions.Count; j += 2)
                {
                    int operand = instructions[j + 1];
                    switch ((Operands)instructions[j])
                    {
                        case Operands.Division:
                            regA = (long)(regA / Math.Pow(2, GetComboOperand(operand, regA, regB, regC)));
                            break;
                        case Operands.BitwiseXOR:
                            regB ^= operand;
                            break;
                        case Operands.Mod8:
                            regB = GetComboOperand(operand, regA, regB, regC) % 8;
                            break;
                        case Operands.JumpNotZero:
                            if (regA != 0)
                            {
                                j = operand - 2;
                            }
                            break;
                        case Operands.BitwiseXORBC:
                            regB ^= regC;
                            break;
                        case Operands.Out:
                            res += (GetComboOperand(operand, regA, regB, regC) % 8).ToString();
                            if (res.Length - 1 > inst.Length || res[res.Length - 1] != inst[res.Length - 1])
                            {
                                doBreak = true;
                                break;
                            }
                            res += ',';
                            break;
                        case Operands.DivToB:
                            regB = (long)(regA / Math.Pow(2, GetComboOperand(operand, regA, regB, regC)));
                            break;
                        case Operands.DivToC:
                            regC = (long)(regA / Math.Pow(2, GetComboOperand(operand, regA, regB, regC)));
                            break;
                        default:
                            break;
                    }
                    if (doBreak)
                    {
                        break;
                    }
                }

                if (res.Length > bestMatch)
                {
                    bestMatch = res.Length;
                    Console.WriteLine(inst + ":" + i.ToString() + ": " + res);
                }

                if (res == inst)
                {
                    Console.WriteLine("!!!!!!!!!!!!: " + (i).ToString());
                }
            });
          
            return "?";
        }
    }
}

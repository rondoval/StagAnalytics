using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagAnalytics
{
    class OSCStatistics
    {
        List<Frame> frames;
        double[] msTable;
        int[] rpmTable;
        int[,] multipliers;

        int minLpgTemp = -100;
        int minReducerTemp = -100;

        bool FindFrames(Frame f)
        {
            return f.lpgTemp > minLpgTemp && f.reducerTemp > minReducerTemp;
        }

        public enum Mode
        {
            LPG,
            PB
        }

        public OSCStatistics(OSCFile file)
        {
            frames = new List<Frame>();
            this.msTable = file.MSTable;
            this.rpmTable = file.RPMTable;
            this.multipliers = file.getMultipliers();
            addFrames(file);
        }

        public void addFrames(OSCFile file)
        {
            frames.AddRange(file.getClosedLoopFrames());
        }

        int[] getRPMBorder()
        {
            int[] rpmBorder = new int[rpmTable.Length];
            for (int i = 0; i < rpmBorder.Length - 1; i++)
            {
                rpmBorder[i] = (rpmTable[i] + rpmTable[i + 1]) / 2;
            }
            rpmBorder[rpmBorder.Length - 1] = 50000; // unlikely
            return rpmBorder;
        }

        double[] getMSBorder()
        {
            double[] msBorder = new double[msTable.Length];

            for (int i = 0; i < msBorder.Length - 1; i++)
            {
                msBorder[i] = (msTable[i] + msTable[i + 1]) / 2.0;
            }
            msBorder[msBorder.Length - 1] = 1000; // unlikely
            return msBorder;
        }

        public double[] getMsTable()
        {
            return msTable;
        }

        public int[] getRpmTable()
        {
            return rpmTable;
        }

        public int minLpgTemperature
        {
            set { minLpgTemp = value; }
        }

        public int minReducerTemperature
        {
            set { minReducerTemp = value; }
        }

        /* returns the multiplier stats are based on */
        public int[,] getMultipliers()
        {
            return multipliers;
        }

        /* returns avg. of STFT+LTFT for each multiplier table entry */
        public double[,] getAvgCorrections(Mode mode)
        {
            double[] msBorder = getMSBorder();
            int[] rpmBorder = getRPMBorder();

            double[,] correction = new double[msTable.Length, rpmTable.Length];
            int[,] correctionCount = new int[msTable.Length, rpmTable.Length];

            foreach (Frame f in frames.FindAll(FindFrames))
            {
                if ((mode == Mode.LPG && f.isLPG) || (mode == Mode.PB && !f.isLPG))
                {
                    int crpm = f.revolutionsPM;
                    double inj = f.injectionTimePB;

                    int i = 0;
                    while (inj > msBorder[i]) i++;
                    int j = 0;
                    while (crpm > rpmBorder[j]) j++;

                    correction[i, j] += f.correction;
                    correctionCount[i, j]++;
                }
            }

            for (int i = rpmTable.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < msTable.Length; j++)
                {
                    correction[j, i] /= correctionCount[j, i];
                }
            }

            return correction;
        }

        public double[,] getPBQuota()
        {
            //TODO refactor
            double[] msBorder = getMSBorder();
            int[] rpmBorder = getRPMBorder();

            double[,] quota = new double[msTable.Length, rpmTable.Length];
            int[,] quotaCount = new int[msTable.Length, rpmTable.Length];

            foreach (Frame f in frames.FindAll(FindFrames))
            {
                if (f.isLPG)
                {
                    int crpm = f.revolutionsPM;
                    double inj = f.injectionTimePB;

                    int i = 0;
                    while (inj > msBorder[i]) i++;
                    int j = 0;
                    while (crpm > rpmBorder[j]) j++;

                    quota[i, j] += f.injectionTimeTotalPB - f.injectionTimePB;//(f.injectionTimeTotalPB) / (f.injectionTimeTotalPB + f.injectionTimePB) * 100;
                    quotaCount[i, j]++;
                }
            }

            for (int i = rpmTable.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < msTable.Length; j++)
                {
                    quota[j, i] /= quotaCount[j, i];
                }
            }

            return quota;
        }

        /* return count of samples gathered for each multiplier table entry */
        int[,] getAvgCorrectionCount(Mode mode)
        {
            double[] msBorder = getMSBorder();
            int[] rpmBorder = getRPMBorder();

            int[,] correctionCount = new int[msTable.Length, rpmTable.Length];

            foreach (Frame f in frames.FindAll(FindFrames))
            {
                if ((mode == Mode.LPG && f.isLPG) || (mode == Mode.PB && !f.isLPG))
                {
                    int crpm = f.revolutionsPM;
                    double inj = f.injectionTimePB;

                    int i = 0;
                    while (inj > msBorder[i]) i++;
                    int j = 0;
                    while (crpm > rpmBorder[j]) j++;

                    correctionCount[i, j]++;
                }
            }

            return correctionCount;
        }

        /* calculates diff between two correction tables.
         * Matrix substract really */
        public static double[,] calcCorrectionDiff(double[,] pbCorrections, double[,] lpgCorrections)
        {
            double[,] diff = new double[lpgCorrections.GetLength(0), lpgCorrections.GetLength(1)];
            for (int i = 0; i < diff.GetLength(0); i++)
            {
                for (int j = 0; j < diff.GetLength(1); j++)
                {
                    diff[i, j] = lpgCorrections[i, j] - pbCorrections[i, j];
                }
            }

            return diff;
        }

        /* return new multiplier based on privided corrections table */
        public int[,] calcNewMultiplier(double[,] diff)
        {
            int[,] newMultiplier = new int[multipliers.GetLength(0), multipliers.GetLength(1)];
            for (int i = 0; i < newMultiplier.GetLength(0); i++)
            {
                for (int j = 0; j < newMultiplier.GetLength(1); j++)
                {
                    if (Double.IsNaN(diff[i, j]))
                    {
                        newMultiplier[i, j] = multipliers[i, j];
                    }
                    else {
                        newMultiplier[i, j] = (int)Math.Round(multipliers[i, j] * (1 + diff[i, j] / 100.0), 0);
                    }
                }
            }

            return newMultiplier;
        }

        /* Number of samples stats text */
        public string[,] prepSampleQtyText()
        {
            int[,] numPbSamples = getAvgCorrectionCount(Mode.PB);
            int[,] numLpgSamples = getAvgCorrectionCount(Mode.LPG);
            string[,] samplesText = new string[numPbSamples.GetLength(0), numPbSamples.GetLength(1)];

            for (int i = 0; i < samplesText.GetLength(0); i++)
            {
                for (int j = 0; j < samplesText.GetLength(1); j++)
                {
                    if (numPbSamples[i, j] != 0 && numLpgSamples[i, j] != 0) {
                       samplesText[i, j] = "PB: " + numPbSamples[i, j] + " LPG: " + numLpgSamples[i, j];
                    }
                }
            }

            return samplesText;
        }
    }
}

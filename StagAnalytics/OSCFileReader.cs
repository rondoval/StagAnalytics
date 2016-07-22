using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StagAnalytics
{
    /* represents a single frame of data from *.osc file */
    class Frame
    {
        const int numCylinders = 6;
        const int numBanks = 2;
        double manifoldPressure;
        double lpgPressure;
        int lpgTemperature;
        int reducerTemperature;
        int internalTemperature;
        int RPM;
        double voltage;

        double[] totalPBInjectionTime = new double[numCylinders];
        double[] pbInjectionTime = new double[numCylinders];
        double[] lpgInjectionTime = new double[numCylinders];
        double avgTotalPB, avgPB, avgLPG;

        bool lpgON, closedLoop;

        double[] stft = new double[numBanks];
        double[] ltft = new double[numBanks];

        public Frame(BinaryReader file)
        {
            // FW 2.0.4, SW 0.20.3.7353 constructor
            file.ReadUInt16(); // unknown
            file.ReadUInt16(); // unknown
            manifoldPressure = file.ReadUInt16() / 100.0;
            lpgPressure = file.ReadUInt16() / 100.0;
            lpgTemperature = file.ReadInt16();
            reducerTemperature = file.ReadInt16();
            internalTemperature = file.ReadInt16();
            RPM = file.ReadUInt16();
            voltage = file.ReadUInt16() / 1000.0;

            file.ReadBytes(6); // unknown

            // Total PB injection times (before emulation)
            for(int i=0; i<numCylinders; i++)
            {
                uint injection = file.ReadUInt32();
                totalPBInjectionTime[i] = injection / 200.0;
                avgTotalPB += totalPBInjectionTime[i];
            }
            avgTotalPB /= numCylinders;

            // PB injection times (emulated)
            for(int i=0; i<numCylinders; i++)
            {
                uint injection = file.ReadUInt32();
                pbInjectionTime[i] = injection / 200.0;
                avgPB += pbInjectionTime[i];
            }
            avgPB /= numCylinders;

            // LPG injection times
            for(int i =0; i<numCylinders; i++)
            {
                uint injection = file.ReadUInt32();
                lpgInjectionTime[i] = injection / 200.0;
                avgLPG += lpgInjectionTime[i];
            }
            avgLPG /= numCylinders;

            byte[] constant = file.ReadBytes(9);
            if (!constant.SequenceEqual(new byte[] { 0x09, 0x00, 0x00, 0x00, 0x00, 0x5e, 0x00, 0x00, 0x00 })) {
                throw new ArgumentException("File format unrecognized - fixed sequence mismatch");
            }

            lpgON = file.ReadBoolean(); // LPG enabled and running
            file.ReadBoolean();
            file.ReadUInt32(); // pb total avg inj time?

            constant = file.ReadBytes(12);
            if(!constant.SequenceEqual(new byte[] { 0,0,0,0,0,0,0,0,0,0,0,0})) {
     //           throw new ArgumentException("File format unrecognized - fixed sequence mismatch");
       //TODO cos tu jest
            }

            file.ReadUInt16();
        }

        public void readOBDData(BinaryReader file, int frameLen)
        {
            while(frameLen > 0)
            {
                byte PID = file.ReadByte();
                byte len = file.ReadByte();
                byte[] val = file.ReadBytes(len);

                frameLen -= 2;
                frameLen -= len;

                switch (PID)
                {
                    case 3: // fuel system status
                        closedLoop = (val[0] == 2 && val[1] == 2);
                        break;
                    case 6: // STFT bank 1
                        stft[0] = (val[0] - 128) * 100.0 / 128.0;
                        break;

                    case 7: // LTFT bank 1
                        ltft[0] = (val[0] - 128) * 100.0 / 128.0;
                        break;

                    case 8: // STFT bank 2
                        stft[1] = (val[0] - 128) * 100.0 / 128.0;
                        break;

                    case 9: // LTFT bank 2
                        ltft[1] = (val[0] - 128) * 100.0 / 128.0;
                        break;
                }
            }
        }

        public double injectionTimePB
        {
            get { return avgPB; }
        }

        public double injectionTimeTotalPB
        {
            get { return avgTotalPB; }
        }

        public bool isLPG
        {
            get { return lpgON; }
        }

        public bool isClosedLoop
        {
            get { return closedLoop; }
        }

        public double correction
        {
            get { return (stft[0] + ltft[0] + stft[1] + ltft[1]) / 2; }
        }

        public int revolutionsPM
        {
            get { return RPM; }
        }

        public int lpgTemp
        {
            get { return lpgTemperature; }
        }

        public int reducerTemp
        {
            get { return reducerTemperature; }
        }
    }

    /* represents multiplier table from *.osc file */
    class MultiplierTable
    {
        int[,] multiplier;

        int[] rpmTable;
        double[] msTable;

        public MultiplierTable(BinaryReader file)
        {
            int maxRPMIndices = file.ReadByte();
            int maxMSIndices = file.ReadByte();

            int rpmIndices = file.ReadByte();
            int msIndices = file.ReadByte();
            file.ReadBytes(4); // unknown - skala do wykresu?

            // read table of RPM values used
            rpmTable = new int[rpmIndices];
            for (int i = 0; i < maxRPMIndices; i++)
            {
                int rpm = file.ReadUInt16();
                if (i < rpmIndices)
                {
                    rpmTable[i] = rpm;
                }
            }

            // read table of opening time values used
            msTable = new double[msIndices];
            for(int i=0; i< maxMSIndices; i++)
            {
                int ms = file.ReadUInt16();
                if(i<msIndices)
                {
                    msTable[i] = ms / 200.0;
                }
            }

            multiplier = new int[msIndices, rpmIndices];
            for (int i=0; i<rpmIndices; i++)
            {
                for(int j=0; j<msIndices; j++)
                {
                    int multi = file.ReadUInt16();
                    multiplier[j, i] = multi;
                    file.ReadByte(); // unsure, usually 0
                }
            }

        }

        public int[] RPMTable
        {
            get { return rpmTable; }
        }

        public double[] MSTable
        {
            get { return msTable; }
        }

        public int[,] Multiplier
        {
            get { return multiplier; }
        }
    }

    /* represents additional petrol portion table from *.osc file */
    class ExtraPetrol
    {
        int[,] petrol;

        int[] rpmTable;
        double[] msTable;

        public ExtraPetrol(BinaryReader file)
        {
            int maxRPMIndices = file.ReadByte();
            int maxMSIndices = file.ReadByte();

            int rpmIndices = file.ReadByte();
            int msIndices = file.ReadByte();
            file.ReadBytes(4); // unknown

            // read table of RPM values used
            rpmTable = new int[rpmIndices];
            for (int i = 0; i < maxRPMIndices; i++)
            {
                int rpm = file.ReadUInt16();
                if (i < rpmIndices)
                {
                    rpmTable[i] = rpm;
                }
            }

            // read table of opening time values used
            msTable = new double[msIndices];
            for (int i = 0; i < maxMSIndices; i++)
            {
                int ms = file.ReadUInt16();
                if (i < msIndices)
                {
                    msTable[i] = ms / 200.0;
                }
            }

            petrol = new int[rpmIndices, msIndices];
            for (int i = 0; i < rpmIndices; i++)
            {
                for (int j = 0; j < msIndices; j++)
                {
                    petrol[i, j] = file.ReadByte();
                }
            }

        }
    }

    /* represents 1D correction table from *.osc file, e.g. gas temp. correction */
    class CorrectionTable1D
    {
        int[] indexTable; // cisnienie, temp etc.
        int[] valueTable; // korekta w %

        public CorrectionTable1D(BinaryReader file)
        {
            int maxElem = file.ReadByte();
            int lElem = file.ReadByte();

            indexTable = new int[lElem];

            for(int i =0; i<maxElem; i++)
            {
                int elem = file.ReadInt16();
                if(i<lElem)
                {
                    indexTable[i] = elem;
                }
            }

            valueTable = new int[lElem];
            for (int i=0; i<lElem; i++)
            {
                valueTable[i] = file.ReadByte() - 128;
            }

        }
    }

    class OSCFile
    {
        Frame[] frames;
        MultiplierTable multiplier;
        ExtraPetrol petrol;
        CorrectionTable1D pressureCorrection;
        CorrectionTable1D gasTemperatureCorrection;
        CorrectionTable1D reducerTemperatureCorrection;

        public OSCFile(BinaryReader file)
        {
            char[] fileID = file.ReadChars(8);
            if(!fileID.SequenceEqual(new char[] { 'U','g','i','c','_','O','s','c'})) {
                throw new ArgumentException("File format not recognized");
            }
            file.ReadBytes(4); // some var header
            file.ReadBytes(79); // seems to be some fixed data
            file.ReadBytes(160 * 18); // seems to be some table
            byte check = file.ReadByte(); // usually is 2
            if(check!=2)
            {
                throw new ArgumentException("This byte is supposed to be 2");
            }
            // Now, some variable length structure
            ushort strucLen = file.ReadUInt16();
            file.ReadBytes(strucLen); // no idea, seems to vary very little between files

            // OSC Data Frames
            uint frameBlockLen = file.ReadUInt32(); // number of bytes used for data frames
            const uint frameLen = 125; // each frame is fixed 125 bytes
            uint numFrames = frameBlockLen / frameLen;
            frames = new Frame[numFrames];
            for (uint i=0; i< numFrames; i++)
            {
                frames[i] = new Frame(file);
            }

            file.ReadBytes(72);

            // multiplier table
            file.ReadBytes(16);
            multiplier = new MultiplierTable(file);

            file.ReadBytes(16);
            petrol = new ExtraPetrol(file);

            file.ReadBytes(16);
            pressureCorrection = new CorrectionTable1D(file);

            file.ReadBytes(16);
            gasTemperatureCorrection = new CorrectionTable1D(file);

            file.ReadBytes(16);
            reducerTemperatureCorrection = new CorrectionTable1D(file);

            file.ReadBytes(78);
            file.ReadBytes(512); // jakaś tabela
            file.ReadBytes(5);

            file.ReadUInt16(); // reducer min switch temp
            file.ReadBytes(14);
            file.ReadUInt16(); // max RPM on LPG
            file.ReadBytes(14);
            file.ReadUInt16(); // cisnienie robocze
            file.ReadBytes(6);
            file.ReadUInt16(); // cisnienie minimalne

            file.ReadBytes(369);
            file.ReadBytes(256); // unknown fixed table
            file.ReadBytes(85);

            string producent = new string(file.ReadChars(19));
            string model = new string(file.ReadChars(15));
            int rokProdukcji = file.ReadUInt16();
            string kodSilnika = new string(file.ReadChars(15));
            int pojemnosc = file.ReadUInt16();
            int moc = file.ReadUInt16();
            string VIN = new string(file.ReadChars(18));
            int przebieg = file.ReadByte() * 256 * 256 + file.ReadByte() * 256 + file.ReadByte();
            string reduktor = new string(file.ReadChars(30));
            double dysza = file.ReadUInt16() / 10.0;
            string imie = new string(file.ReadChars(15));
            string nazwisko = new string(file.ReadChars(15));
            string telefon = new string(file.ReadChars(15));
            string email = new string(file.ReadChars(62));
            string www = new string(file.ReadChars(49));
            file.ReadBytes(4);

            // OBD
            int obdLength = file.ReadInt32();
            while (obdLength > 0)
            {
                int frameNumber = file.ReadInt32();
                int frameLength = file.ReadByte();
                obdLength -= 5;
                obdLength -= frameLength;

                if (frameNumber < frames.Length) //TODO unsure why this is required but last OBD data tends to be for num_of_frames+1
                {
                    frames[frameNumber].readOBDData(file, frameLength);
                }
            }

            // rest is unknown

            file.Close();
        }

        public int[] RPMTable
        {
            get { return multiplier.RPMTable; }
        }

        public double[] MSTable
        {
            get { return multiplier.MSTable; }
        }

        public int[,] getMultipliers()
        {
            return multiplier.Multiplier;
        }

        public List<Frame> getLPGFrames()
        {
            List<Frame> lpgFrames = new List<Frame>();

            foreach(Frame f in frames)
            {
                if(f.isLPG && f.isClosedLoop)
                {
                    lpgFrames.Add(f);
                }
            }
            return lpgFrames;
        }

        public List<Frame> getPBFrames()
        {
            List<Frame> pbFrames = new List<Frame>();
            
            foreach(Frame f in frames)
            {
                if(!f.isLPG && f.isClosedLoop)
                {
                    pbFrames.Add(f);
                }
            }

            return pbFrames;
        }

        public List<Frame> getClosedLoopFrames()
        {
            List<Frame> clFrames = new List<Frame>();

            foreach(Frame f in frames)
            {
                if(f.isClosedLoop)
                {
                    clFrames.Add(f);
                }
            }

            return clFrames;
        }

    }

}

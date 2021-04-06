using System;
using System.Collections.Generic;
using System.Text;

namespace CoC_character_maker
{
    class Char
    {
        public int STR, CON, SIZ, DEX, APP, EDU, INT, POW, luck, sanity, HP, build, MOV, age, CR, assets;
        public double cash, S_LVL;
        public string DB, name, residence, sex, job;
        //set initial stats
        public Char(int[] stats)
        {
            this.STR = stats[0];
            this.CON = stats[1];
            this.SIZ = stats[2];
            this.DEX = stats[3];
            this.APP = stats[4];
            this.EDU = stats[5];
            this.INT = stats[6];
            this.POW = stats[7];
            this.luck = stats[8];

            this.HP = (this.CON + this.SIZ) / 5;
            this.sanity = this.POW;
            if (this.STR >= this.SIZ && this.DEX >= this.SIZ)
            {
                this.MOV = 9;
            }
            else if (this.STR >= this.SIZ || this.DEX >= this.SIZ)
            {
                this.MOV = 8;
            }
            else
            {
                this.MOV = 7;
            }
            int STRSIZ = this.STR + this.SIZ;
            if (STRSIZ <= 64)
            {
                this.DB = "-2";
                this.build = -2;
            }
            else if (STRSIZ <= 84)
            {
                this.DB = "-1";
                this.build = -1;
            }
            else if (STRSIZ <= 124)
            {
                this.DB = "0";
                this.build = 0;
            }
            else if (STRSIZ <= 164)
            {
                this.DB = "+1d4";
                this.build = 1;
            }
            else if (STRSIZ <= 204)
            {
                this.DB = "+1d6";
                this.build = 2;
            }
            else if (STRSIZ <= 284)
            {
                this.DB = "+2d6";
                this.build = 3;
            }
            else if (STRSIZ <= 364)
            {
                this.DB = "+3d6";
                this.build = 4;
            }
            else
            {
                this.DB = "+4d6";
                this.build = 5;
            }

        }
        public void ExtraData(string[] stringData, int[] intData) //string name, string job, int age, string sex, string residence, int CR
        {
            this.name = stringData[0];
            this.job = stringData[1];
            this.age = intData[0];
            this.sex = stringData[2];
            this.residence = stringData[3];
            this.CR = intData[1];
            if (this.CR <= 0)
            {
                this.cash = 0.25;
                this.assets = 0;
                this.S_LVL = 0.25;
            }
            else if (this.CR <= 9)
            {
                this.cash = this.CR / 2;
                this.assets = this.CR * 5;
                this.S_LVL = 1;
            }
            else if (this.CR <= 49)
            {
                this.cash = this.CR;
                this.assets = this.CR * 25;
                this.S_LVL = 5;
            }
            else if (this.CR <= 89)
            {
                this.cash = this.CR * 3;
                this.assets = this.CR * 250;
                this.S_LVL = 25;
            }
            else if (this.CR <= 98)
            {
                this.cash = this.CR * 10;
                this.assets = this.CR * 1000;
                this.S_LVL = 125;
            }
            else
            {
                this.cash = 25000;
                this.assets = 2500000;
                this.S_LVL = 2500;
            }
        }
        static public int[] GenerateStats()
        {
            int[] stats = new int[9];
            for (int i = 0; i <= 8; i++)
            {
                if (i == 2 || i == 5 || i == 6)
                {
                    stats[i] = twoDsixPlusSix();
                } else
                {
                    stats[i] = threeDsix();
                }
            } 
            return stats;
        }
        static private int threeDsix()
        {
            Random rnd = new Random();
            int Num = (rnd.Next(1, 7) + rnd.Next(1, 7) + rnd.Next(1, 7))*5;
            return Num;
        }
        static private int twoDsixPlusSix()
        {
            Random rnd = new Random();
            int Num = (rnd.Next(1, 7) + rnd.Next(1, 7) + 6)*5;
            return Num;
        }
        static public int[] Gabe()
        {
            int[] stats = { 15, 15, 15, 15, 15, 0, 0, 15, 15 };
            return stats;
        }

    }
}

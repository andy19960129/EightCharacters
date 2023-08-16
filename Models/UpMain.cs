using EightCharacters.Models.Enums;
using System;
using System.Collections.Generic;

namespace EightCharacters.Models
{
    public class UpMain
    {
        public TenUpMain tenUpMain { get; set; }

        public double proportion { get; set; }

        public YinYang yinYang { get; set; }

        public FiveWay fiveWay { get; set; }

        public int Temperature { get; set; }

        public UpMain(TenUpMain _tenUpMain, double _proportion)
        {
            tenUpMain = _tenUpMain;
            proportion = _proportion;
            switch (tenUpMain)
            {
                case TenUpMain.A:
                    yinYang = YinYang.Yang;
                    fiveWay = FiveWay.Wood;
                    Temperature = 3;
                    break;
                case TenUpMain.B:
                    yinYang = YinYang.Yin;
                    fiveWay = FiveWay.Wood;
                    Temperature = 1;
                    break;
                case TenUpMain.C:
                    yinYang = YinYang.Yang;
                    fiveWay = FiveWay.Fire;
                    Temperature = 7;
                    break;
                case TenUpMain.D:
                    yinYang = YinYang.Yin;
                    fiveWay = FiveWay.Fire;
                    Temperature = 5;
                    break;
                case TenUpMain.E:
                    yinYang = YinYang.Yang;
                    fiveWay = FiveWay.Earth;
                    Temperature = 1;
                    break;
                case TenUpMain.F:
                    yinYang = YinYang.Yin;
                    fiveWay = FiveWay.Earth;
                    Temperature = -1;
                    break;
                case TenUpMain.G:
                    yinYang = YinYang.Yang;
                    fiveWay = FiveWay.Metal;
                    Temperature = -1;
                    break;
                case TenUpMain.H:
                    yinYang = YinYang.Yin;
                    fiveWay = FiveWay.Metal;
                    Temperature = -3;
                    break;
                case TenUpMain.I:
                    yinYang = YinYang.Yang;
                    fiveWay = FiveWay.Water;
                    Temperature = -5;
                    break;
                case TenUpMain.J:
                    yinYang = YinYang.Yin;
                    fiveWay = FiveWay.Water;
                    Temperature = -7;
                    break;
            }
        }

        public bool CanHelp(TenUpMain _tenUpMain)
        {
            if (yinYang == YinYang.Yang)
            {
                if(tenUpMain == _tenUpMain)
                    return true;

                if (tenUpMain + 1 == _tenUpMain)
                    return true;

                if (TenUpMain.IsDefined(typeof(TenUpMain), tenUpMain.GetHashCode() + 2))
                {
                    if (tenUpMain + 2 == _tenUpMain)
                        return true;
                }
                else
                {
                    if (tenUpMain - 8 == _tenUpMain)
                        return true;
                }
                    
                if (TenUpMain.IsDefined(typeof(TenUpMain), tenUpMain.GetHashCode() + 3))
                {
                    if (tenUpMain + 3 == _tenUpMain)
                        return true;
                }
                else
                {
                    if (tenUpMain - 7 == _tenUpMain)
                        return true;
                }
                    
            }
            else
            {
                if (tenUpMain - 1 == _tenUpMain)
                    return true;

                if (tenUpMain == _tenUpMain)
                    return true;

                if (TenUpMain.IsDefined(typeof(TenUpMain), tenUpMain.GetHashCode() + 1))
                {
                    if (tenUpMain + 1 == _tenUpMain)
                        return true;
                }
                else
                {
                    if (tenUpMain - 9 == _tenUpMain)
                        return true;
                }

                if (TenUpMain.IsDefined(typeof(TenUpMain), tenUpMain.GetHashCode() + 2))
                {
                    if (tenUpMain + 2 == _tenUpMain)
                        return true;
                }
                else
                {
                    if (tenUpMain - 8 == _tenUpMain)
                        return true;
                }
                    
            }
            return false;
        }

        public bool CanBeHelpBy(TenUpMain _tenUpMain)
        {
            if (yinYang == YinYang.Yang)
            {
                if (TenUpMain.IsDefined(typeof(TenUpMain), tenUpMain.GetHashCode() - 2))
                {
                    if (tenUpMain - 2 == _tenUpMain)
                        return true;
                }
                else
                {
                    if (tenUpMain + 8 == _tenUpMain)
                        return true;
                }

                if (TenUpMain.IsDefined(typeof(TenUpMain), tenUpMain.GetHashCode() - 1))
                {
                    if (tenUpMain - 1 == _tenUpMain)
                        return true;
                }
                else
                {
                    if (tenUpMain + 9 == _tenUpMain)
                        return true;
                }
                    
                if (tenUpMain == _tenUpMain)
                    return true;

                if (tenUpMain + 1 == _tenUpMain)
                    return true;

            }
            else
            {
                if (TenUpMain.IsDefined(typeof(TenUpMain), tenUpMain.GetHashCode() - 3))
                {
                    if (tenUpMain - 3 == _tenUpMain)
                        return true;
                }
                else
                {
                    if (tenUpMain + 7 == _tenUpMain)
                        return true;
                }

                if (TenUpMain.IsDefined(typeof(TenUpMain), tenUpMain.GetHashCode() - 2))
                {
                    if (tenUpMain - 2 == _tenUpMain)
                        return true;
                }
                else
                {
                    if (tenUpMain + 8 == _tenUpMain)
                        return true;
                }
                    
                if (tenUpMain - 1 == _tenUpMain)
                    return true;

                if (tenUpMain == _tenUpMain)
                    return true;

            }
            return false;
        }

    }
}

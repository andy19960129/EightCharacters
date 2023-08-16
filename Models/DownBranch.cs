using EightCharacters.Models.Enums;

namespace EightCharacters.Models
{
    public class DownBranch
    {
        public TwelveDownBranch twelveDownBranch { get; set; }

        public FourSeasons fourSeasons { get; set; }

        public List<UpMain> upMains { get; set; }

        public int Temperature { get; set; }

        public DownBranch(TwelveDownBranch _twelveDownBranch)
        {
            twelveDownBranch = _twelveDownBranch;
            upMains = new List<UpMain>();
            switch (twelveDownBranch)
            {
                case TwelveDownBranch.A:
                    fourSeasons = FourSeasons.Spring;
                    upMains.Add(new UpMain(TenUpMain.A, 0.7));
                    upMains.Add(new UpMain(TenUpMain.C, 0.3));
                    Temperature = 3;
                    break;
                case TwelveDownBranch.B:
                    fourSeasons = FourSeasons.Spring;
                    upMains.Add(new UpMain(TenUpMain.B, 1));
                    Temperature = 1;
                    break;
                case TwelveDownBranch.C:
                    fourSeasons = FourSeasons.Spring;
                    upMains.Add(new UpMain(TenUpMain.E, 0.5));
                    upMains.Add(new UpMain(TenUpMain.B, 0.3));
                    upMains.Add(new UpMain(TenUpMain.J, 0.2));
                    Temperature = 2;
                    break;
                case TwelveDownBranch.D:
                    fourSeasons = FourSeasons.Summer;
                    upMains.Add(new UpMain(TenUpMain.C, 0.7));
                    upMains.Add(new UpMain(TenUpMain.G, 0.3));
                    Temperature = 7;
                    break;
                case TwelveDownBranch.E:
                    fourSeasons = FourSeasons.Summer;
                    upMains.Add(new UpMain(TenUpMain.D, 1));
                    Temperature = 5;
                    break;
                case TwelveDownBranch.F:
                    fourSeasons = FourSeasons.Summer;
                    upMains.Add(new UpMain(TenUpMain.F, 0.5));
                    upMains.Add(new UpMain(TenUpMain.D, 0.3));
                    upMains.Add(new UpMain(TenUpMain.B, 0.2));
                    Temperature = 6;
                    break;
                case TwelveDownBranch.G:
                    fourSeasons = FourSeasons.Fall;
                    upMains.Add(new UpMain(TenUpMain.G, 0.7));
                    upMains.Add(new UpMain(TenUpMain.I, 0.3));
                    Temperature = -1;
                    break;
                case TwelveDownBranch.H:
                    fourSeasons = FourSeasons.Fall;
                    upMains.Add(new UpMain(TenUpMain.H, 1));
                    Temperature = -3;
                    break;
                case TwelveDownBranch.I:
                    fourSeasons = FourSeasons.Fall;
                    upMains.Add(new UpMain(TenUpMain.E, 0.5));
                    upMains.Add(new UpMain(TenUpMain.H, 0.3));
                    upMains.Add(new UpMain(TenUpMain.D, 0.2));
                    Temperature = -2;
                    break;
                case TwelveDownBranch.J:
                    fourSeasons = FourSeasons.Winter;
                    upMains.Add(new UpMain(TenUpMain.I, 0.7));
                    upMains.Add(new UpMain(TenUpMain.A, 0.3));
                    Temperature = -5;
                    break;
                case TwelveDownBranch.K:
                    fourSeasons = FourSeasons.Winter;
                    upMains.Add(new UpMain(TenUpMain.J, 1));
                    Temperature = -7;
                    break;
                case TwelveDownBranch.L:
                    fourSeasons = FourSeasons.Winter;
                    upMains.Add(new UpMain(TenUpMain.F, 0.5));
                    upMains.Add(new UpMain(TenUpMain.J, 0.3));
                    upMains.Add(new UpMain(TenUpMain.H, 0.2));
                    Temperature = -6;
                    break;
            }
        }
    }
}

using EightCharacters.Models;


namespace EightCharacters.ViewModels.Home
{
    public class IndexViewModel
    {
        public UpMain yearMain { get; set; }

        public DownBranch yearBranch { get; set; }

        public UpMain monthMain { get; set; }

        public DownBranch monthBranch { get; set; }

        public UpMain dayMain { get; set; }

        public DownBranch dayBranch { get; set; }

        public UpMain hourMain { get; set; }

        public DownBranch hourBranch { get; set; }

        public ICollection<double> tenUpMainEnergyProportion { get; set; }

        public ICollection<double> tenUpMainSeasonProportion { get; set; }

        public ICollection<double> tenUpMainEnergyPower { get; set; }

        public double totalEnergy { get; set; }

        public double totalTemperature { get; set; }

        public IndexViewModel()
        {
            tenUpMainEnergyProportion = new List<double>();
            tenUpMainSeasonProportion = new List<double>();
            tenUpMainEnergyPower = new List<double>();
        }
    }
}

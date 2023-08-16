using EightCharacters.Models;
using EightCharacters.Models.Enums;
using EightCharacters.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics;

namespace EightCharacters.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private UpMain yearMain ;

        private DownBranch yearBranch ;

        private UpMain monthMain ;

        private DownBranch monthBranch ;

        private UpMain dayMain ;

        private DownBranch dayBranch ;

        private UpMain hourMain ;

        private DownBranch hourBranch ;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? hourMainlist, int? dayMainlist, int? monthMainlist, int? yearMainlist
            , int? hourBranchlist, int? dayBranchlist, int? monthBranchlist, int? yearBranchlist)
        {
            ICollection<SelectListItem> UpMainlist = Enum.GetValues(typeof(TenUpMain))
                        .Cast<TenUpMain>()
                        .Select(x => new SelectListItem
                        {
                            Text = EnumExtenstion.GetDescription(x),
                            Value = ((int)x).ToString()
                        })
                        .ToList();
            ICollection<SelectListItem> DownBranchlist = Enum.GetValues(typeof(TwelveDownBranch))
                        .Cast<TwelveDownBranch>()
                        .Select(x => new SelectListItem
                        {
                            Text = EnumExtenstion.GetDescription(x),
                            Value = ((int)x).ToString()
                        })
                        .ToList();
            ViewBag.UpMainlist = UpMainlist;
            ViewBag.DownBranchlist = DownBranchlist;

            IndexViewModel indexViewModel = new IndexViewModel();
            if (hourMainlist is not null)
                hourMain = new UpMain((TenUpMain)hourMainlist,1);
            if (dayMainlist is not null)
                dayMain = new UpMain((TenUpMain)dayMainlist, 1);
            if (monthMainlist is not null)
                monthMain = new UpMain((TenUpMain)monthMainlist, 1);
            if (yearMainlist is not null)
                yearMain = new UpMain((TenUpMain)yearMainlist, 1);
            if (hourBranchlist is not null)
                hourBranch = new DownBranch((TwelveDownBranch)hourBranchlist);
            if (dayBranchlist is not null)
                dayBranch = new DownBranch((TwelveDownBranch)dayBranchlist);
            if (monthBranchlist is not null)
                monthBranch = new DownBranch((TwelveDownBranch)monthBranchlist);
            if (yearBranchlist is not null)
                yearBranch = new DownBranch((TwelveDownBranch)yearBranchlist);

            indexViewModel.yearMain = yearMain;
            indexViewModel.yearBranch = yearBranch;
            indexViewModel.monthMain = monthMain;
            indexViewModel.monthBranch = monthBranch;
            indexViewModel.dayMain = dayMain;
            indexViewModel.dayBranch = dayBranch;
            indexViewModel.hourMain = hourMain;
            indexViewModel.hourBranch = hourBranch;
            GetTenUpMainProportion(indexViewModel);
            GetTotalEnergy(indexViewModel);
            GetTotalTemperature(indexViewModel);
            return View("Index", indexViewModel);
        }

        public void GetTenUpMainProportion(IndexViewModel indexViewModel)
        {
            for (int i = 0; i < 10; i++)
            {
                double e = 0;
                double s = 0;
                if (yearMain is not null && yearMain.tenUpMain == (TenUpMain)i)
                    e += yearMain.proportion;
                if (monthMain is not null && monthMain.tenUpMain == (TenUpMain)i)
                    e += monthMain.proportion;
                if (dayMain is not null && dayMain.tenUpMain == (TenUpMain)i)
                    e += dayMain.proportion;
                if (hourMain is not null && hourMain.tenUpMain == (TenUpMain)i)
                    e += hourMain.proportion;
                if(yearBranch is not null)
                    foreach(UpMain t in yearBranch.upMains)
                        if (t.tenUpMain == (TenUpMain)i)
                            e += t.proportion;
                if (monthBranch is not null)
                    foreach (UpMain t in monthBranch.upMains)
                    {
                        if (t.tenUpMain == (TenUpMain)i)
                            e += t.proportion;
                        if (t.CanHelp((TenUpMain)i))
                            s += t.proportion;
                    }
                if (dayBranch is not null)
                    foreach (UpMain t in dayBranch.upMains)
                        if (t.tenUpMain == (TenUpMain)i)
                            e += t.proportion;
                if (hourBranch is not null)
                    foreach (UpMain t in hourBranch.upMains)
                        if (t.tenUpMain == (TenUpMain)i)
                            e += t.proportion;
                indexViewModel.tenUpMainEnergyProportion.Add(e);
                indexViewModel.tenUpMainSeasonProportion.Add(s);
                indexViewModel.tenUpMainEnergyPower.Add(Math.Round(e *(1+(0.2*s)), 3));
            }
        }

        public void GetTotalEnergy(IndexViewModel indexViewModel)
        {
            if (dayMain is not null)
            {
                double d = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (dayMain.CanBeHelpBy((TenUpMain)i))
                        d += indexViewModel.tenUpMainEnergyPower.ElementAt(i);
                    else
                        d -= indexViewModel.tenUpMainEnergyPower.ElementAt(i);
                }
                indexViewModel.totalEnergy = Math.Round(d, 3);
            }
        }

        public void GetTotalTemperature(IndexViewModel indexViewModel)
        {
            if (monthBranch is not null)
            {
                double d = 0;
                FiveWay fiveWay = FiveWay.Earth;
                if (monthBranch.fourSeasons == FourSeasons.Spring)
                    fiveWay = FiveWay.Wood;
                else if (monthBranch.fourSeasons == FourSeasons.Summer)
                    fiveWay = FiveWay.Fire;
                else if (monthBranch.fourSeasons == FourSeasons.Fall)
                    fiveWay = FiveWay.Metal;
                else if (monthBranch.fourSeasons == FourSeasons.Winter)
                    fiveWay = FiveWay.Water;

                if(yearMain is not null)
                {
                    if (yearMain.fiveWay == fiveWay)
                        d += yearMain.Temperature * 1.2;
                    else
                        d += yearMain.Temperature;
                }
                if (monthMain is not null)
                {
                    if (monthMain.fiveWay == fiveWay)
                        d += monthMain.Temperature * 1.2;
                    else
                        d += monthMain.Temperature;
                }
                if (dayMain is not null)
                {
                    if (dayMain.fiveWay == fiveWay)
                        d += dayMain.Temperature * 1.2;
                    else
                        d += dayMain.Temperature;
                }
                if (hourMain is not null)
                {
                    if (hourMain.fiveWay == fiveWay)
                        d += hourMain.Temperature * 1.2;
                    else
                        d += hourMain.Temperature;
                }
                if (yearBranch is not null)
                {
                    if (yearBranch.fourSeasons == monthBranch.fourSeasons)
                        d += yearBranch.Temperature * 1.2;
                    else
                        d += yearBranch.Temperature;
                }
                d += monthBranch.Temperature * 1.2;
                if (dayBranch is not null)
                {
                    if (dayBranch.fourSeasons == monthBranch.fourSeasons)
                        d += dayBranch.Temperature * 1.2;
                    else
                        d += dayBranch.Temperature;
                }
                if (hourBranch is not null)
                {
                    if (hourBranch.fourSeasons == monthBranch.fourSeasons)
                        d += hourBranch.Temperature * 1.2;
                    else
                        d += hourBranch.Temperature;
                }
                indexViewModel.totalTemperature = Math.Round(d, 3);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StellarisModSelector
{
    class Program
    {
        static void Main(string[] args)
        {
            SettingsManager setMng = new SettingsManager();
            var lastMods = setMng.GetLastLoadedMods();
            var allMods = Helpers.GetDownloadedModIds();
            Console.WriteLine("Last selected mods: ");
            var tasks = lastMods.AsParallel().Select(modid => PrintWithName(modid)).ToArray();
            Task.WaitAll(tasks);
            Console.WriteLine();
            Console.WriteLine("Available mods: ");
            tasks = allMods.AsParallel().Select(modid => PrintWithName(modid)).ToArray();
            Task.WaitAll(tasks);
            Console.WriteLine();
            // create json for selected pack and one for all mods
            ModSelectorManager mng = new ModSelectorManager();
            mng.Packs.Add(new ModPack { Name = "Selected", Mods = lastMods });
            mng.Packs.Add(new ModPack { Name = "All", Mods = allMods });
            Console.WriteLine(mng.CreateJson());
            mng.SaveSettings();
            setMng.SetMods(mng.GetPackByName("All"));
            Console.WriteLine("Done!");
            Console.ReadKey(true);
        }

        static async Task PrintWithName(string modId)
        {
            string name = await Helpers.DownloadModNameById(modId);
            Console.WriteLine($"{name} ({modId})");
        }
    }

    
    //      last_mods={
    //"mod/ugc_1085097357.mod"
    //"mod/ugc_1085848794.mod"
    //"mod/ugc_1085907846.mod"
    //"mod/ugc_1128927140.mod"
    //"mod/ugc_1154513894.mod"
    //"mod/ugc_684509615.mod"
    //"mod/ugc_695222285.mod"
    //"mod/ugc_702164152.mod"
    //"mod/ugc_719712462.mod"
    //"mod/ugc_779729987.mod"
    //"mod/ugc_787237639.mod"
    //"mod/ugc_799999383.mod"
    //"mod/ugc_803452214.mod"
    //"mod/ugc_803491311.mod"
    //"mod/ugc_803553012.mod"
    //"mod/ugc_804946681.mod"
    //"mod/ugc_808478850.mod"
    //"mod/ugc_810204739.mod"
    //"mod/ugc_836295988.mod"
    //"mod/ugc_864541681.mod"
    //"mod/ugc_899815648.mod"
    //"mod/ugc_914872677.mod"
    //"mod/ugc_959094804.mod"
    //}

}

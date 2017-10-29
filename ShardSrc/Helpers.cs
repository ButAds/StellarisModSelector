using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StellarisModSelector
{
    public class Helpers
    {
        public readonly static string SteamBaseURL = @"https://steamcommunity.com/sharedfiles/filedetails/?id=";
        private readonly static string TitleRegex = @"<div class=\""workshopItemTitle\"">(.*)<\/div>";

        /// <summary>
        /// root dir for the stellaris data
        /// </summary>
        public static String UserStellarisDir
        {
            get
            {
                // TODO handle other OS 
                // This is currently only for windows
                return $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\Paradox Interactive\Stellaris";
            }
        }

        /// <summary>
        /// Full file path to settings.txt
        /// </summary>
        public static String SettingsFilePath
        {
            // TODO handle other OS 
            // This is currently only for windows
            get { return $@"{UserStellarisDir}\Settings.txt"; }
        }

        /// <summary>
        /// path to the mods directory
        /// </summary>
        public static String ModsDir
        {
            // TODO handle other OS 
            // This is currently only for windows
            get { return $@"{UserStellarisDir}\mod"; }
        }

        /// <summary>
        /// Full path the file for save mod packs/sets
        /// </summary>
        public static String ModPackFile
        {
            // TODO handle other OS 
            // This is currently only for windows
            get { return $@"{UserStellarisDir}\packs.json"; }
        }

        /// <summary>
        /// Downloads the name of the mod from the workshop page
        /// </summary>
        /// <param name="modId">The id of the mod</param>
        /// <returns>Mod name</returns>
        public static async Task<string> DownloadModNameById(string modId)
        { 
            string data = await new WebClient().DownloadStringTaskAsync(SteamBaseURL + modId);
            Match match = Regex.Match(data, TitleRegex, RegexOptions.IgnoreCase);

            // Here we check the Match instance.
            if (match.Success)
                return match.Groups[1].Value;
            else
                return modId;
        }

        /// <summary>
        /// Reads mod ids from the ./mods directory
        /// </summary>
        /// <returns>IEnumerable with all ids of the mods in the workshop</returns>
        public static IEnumerable<string> GetDownloadedModIds()
        {
            string[] files = Directory.GetFiles(Helpers.ModsDir, "*.mod");
            foreach(string f in files)
            {
                int start = f.IndexOf('_') + 1;
                int length = f.LastIndexOf('.') - start;
                yield return f.Substring(start, length);
            }
        }
    }
}

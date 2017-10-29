using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace StellarisModSelector
{
    public class SettingsManager
    {
        public bool CheckIfSettingsFileExists()
        {
            return File.Exists(Helpers.SettingsFilePath);
        }

        public IEnumerable<string> GetLastLoadedMods()
        {
            bool readingMods = false;
            List<string> rtn = new List<string>();
            IEnumerable<string> data = File.ReadLines(Helpers.SettingsFilePath);
            foreach (string d in data)
            {
                // start element of mod list
                if (d.Equals("last_mods={")) { readingMods = true; continue; }

                // end element of mod list
                if (readingMods && d.Equals("}")) break;

                // read mod id
                if (readingMods)
                {
                    // example line: \t"mod/ugc_1085097357.mod"
                    int start = d.IndexOf('_') + 1;
                    int length = d.LastIndexOf('.') - start;
                    rtn.Add(d.Substring(start, length));
                }
            }
            return rtn;
        }

        public void SetMods(ModPack pack)
        {
            bool writingMods = false;
            IEnumerable<string> data = File.ReadLines(Helpers.SettingsFilePath);
            List<string> linesToWrite = new List<string>();
            foreach (string d in data)
            {
                // start element of mod list
                if (d.Equals("last_mods={")) writingMods = true;

                // end element of mod list
                if (writingMods && d.Equals("}"))
                { writingMods = false; linesToWrite.AddRange(GetModsListForSettingsFile(pack)); }

                // read mod id
                if (!writingMods) linesToWrite.Add(d);
            }

            File.WriteAllLines(Helpers.SettingsFilePath, linesToWrite.ToArray());
        }

        private IEnumerable<string> GetModsListForSettingsFile(ModPack pack)
        {
            return pack.Mods.Select(m => $"\t\"mod/ugc_{m}.mod\"");
        }
    }
}

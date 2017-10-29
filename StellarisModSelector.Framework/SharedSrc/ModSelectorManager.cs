using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace StellarisModSelector
{
    public class ModPack
    {
        public string Name { get; set; }
        public IEnumerable<string> Mods { get; set; }
    }

    public class ModSelectorManager
    {
        public List<ModPack> Packs { get; private set; } = new List<ModPack>();

        public string CheckLastLoadedModsISExistingPack(IEnumerable<string> lastLoadedMods)
        {
            var found = Packs.Where(p => p.Mods.SequenceEqual(lastLoadedMods));
            return found.Any() ? found.FirstOrDefault().Name : string.Empty;
        }

        public IEnumerable<string> GetPackNames()
        {
            return Packs.Select(p => p.Name);
        }

        public ModPack GetPackByName(string name)
        {
            if (!Packs.Where(p => p.Name.Equals(name)).Any())
                throw new ArgumentException("Given pack name does not exist", "name");

            return Packs.Where(p => p.Name.Equals(name)).First();
        }

        public void AddOrUpdatePack(string name, IEnumerable<string> mods)
        {
            AddOrUpdatePack(new ModPack { Name = name, Mods = mods });
        }

        public void AddOrUpdatePack(ModPack pack)
        {
            // get the pack
            RemovePackByName(pack.Name);
            Packs.Add(pack);
        }

        public bool RemovePackByName(string name)
        {
            var pack = Packs.Where(p => p.Name.Equals(name));
            if (!pack.Any())
                return false;
            Packs.Remove(pack.First());
            return true;
        }

        public void LoadSettings()
        {
            string data = ReadJson(Helpers.ModPackFile);
            CreateObjects(data);
        }

        public void SaveSettings()
        {
            string json = CreateJson();
            WriteJson(Helpers.ModPackFile, json);
        }

        public string CreateJson()
        {
            return JsonConvert.SerializeObject(Packs.Where(mp => mp.Name != "Temp"));
        }

        public void CreateObjects(string json)
        {
            Packs = JsonConvert.DeserializeObject<List<ModPack>>(json);
            if(Packs == null)
            {
                Packs = new List<ModPack>();
            }
        }


        public void WriteJson(string fullFilePath, string json)
        {
            File.WriteAllText(fullFilePath, json);
        }

        public string ReadJson(string fullFilePath)
        {
            if (File.Exists(fullFilePath)) { 
            return File.ReadAllText(fullFilePath);
            }
            return "";
        }
    }
}

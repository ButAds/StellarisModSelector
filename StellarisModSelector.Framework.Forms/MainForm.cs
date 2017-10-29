using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListBox;

namespace StellarisModSelector.Framework.Forms
{
    public partial class MainForm : Form
    {

        private SettingsManager setManager = new SettingsManager();
        private ModSelectorManager modManager = new ModSelectorManager();

        public MainForm()
        {
            InitializeComponent();

            modManager.LoadSettings();

            ReloadMods();
            ReloadPacks();

            SetSelectedMods();
        }

        private void exportPackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadMods();
        }

        private void ReloadPacks()
        {
            cbPacks.Items.Clear();
            cbPacks.Items.Add("All");
            cbPacks.Items.Add("None");
            cbPacks.Items.AddRange(modManager.GetPackNames().ToArray());
        }

        private void ReloadMods()
        {
            lbDownloadedMods.Items.Clear();
            var modIds = Helpers.GetDownloadedModIds();
            lbDownloadedMods.Items.AddRange(new ObjectCollection(lbDownloadedMods, modIds.ToArray()));
            //var modNames = modIds.AsParallel().Select(modid => GetWorkshopTitle(modid)).ToArray();
            //Task.WaitAll(modNames);
        }

        private async Task UpdateIdToModTitle()
        {

        }

        private async Task<string> GetWorkshopTitle(string modId)
        {
           return await Helpers.DownloadModNameById(modId);
        }

        private void SetSelectedMods()
        {
            //var name = cbPacks.SelectedItem.ToString();

        }

        private void cbPacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSelectedMods();
        }
    }
}

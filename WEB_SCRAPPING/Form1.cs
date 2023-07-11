//WEB SCRAPPING NBA TEAMS CREATE BY HUSSEIN BOURGI AND AMIR BAZZI 
using System.ComponentModel;

namespace WEB_SCRAPPING
{
    public partial class Form1 : Form
    {
        private NBA_SCRAPPER teamScraper;
        private List<NBA_SCRAPPER.Player> players;
        private Progress<int> scrappingProgress;
        public Form1()
        {
            InitializeComponent();
            teamScraper = new NBA_SCRAPPER();
            scrappingProgress = new Progress<int>(UpdateProgressBar);
            Load_TeamsAsync();
        }
        private async Task Load_TeamsAsync()
        {
            var teamNames = await teamScraper.GetTeamNamesAsync();
            foreach (string name in teamNames)
            {
                comboBoxTeams.Items.Add(name);
            }
        }
        private async Task PopulateDataGridViewAsync()
        {
            await Task.Delay(2000); // Add a delay if needed

            if (players != null && players.Any())
            {
                dataGridView.DataSource = new BindingList<NBA_SCRAPPER.Player>(players);
            }
            else
            {
                dataGridView.DataSource = null;
                MessageBox.Show("No players found for the selected team.");
            }
        }

        private void UpdateProgressBar(int progressPercentage)
        {
            progressBar.Value = progressPercentage;
        }
        //Scrap Button 
        private async void ScrapBtn_Click(object sender, EventArgs e)
        {
            string selectedTeam = comboBoxTeams.SelectedItem?.ToString();
            string abbreviation = await teamScraper.GetTeamAbbreviationAsync(selectedTeam);

            if (!string.IsNullOrEmpty(selectedTeam) && !string.IsNullOrEmpty(abbreviation))
            {
                try
                {
                    players = await teamScraper.GetTeamPlayersAsync(abbreviation, scrappingProgress);
                    await PopulateDataGridViewAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred while scraping team players: " + ex.Message);
                }
            }
        }
        //Export Button 
        private async void ExportBtn_Click(object sender, EventArgs e)
        {
            if (players != null && players.Any())
            {
                string selectedTeam = comboBoxTeams.SelectedItem?.ToString();
                string teamName = selectedTeam.Replace(" ", ""); // Remove spaces from the team name
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = $"{teamName}_Players.xlsx"; // Set the file name

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = saveFileDialog.FileName;
                        await EXPORT.ExportDataGridViewToExcelAsync(dataGridView, filePath);
                        MessageBox.Show("DataGridView exported to Excel successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting DataGridView to Excel: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("No players found to export.");
            }
        }
    }
}

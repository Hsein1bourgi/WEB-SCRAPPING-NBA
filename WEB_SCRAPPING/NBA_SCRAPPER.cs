using AngleSharp.Html.Parser;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace WEB_SCRAPPING
{
    internal class NBA_SCRAPPER
    {
        public async Task<List<string>> GetTeamNamesAsync()
        {
            List<string> teamNames = new List<string>();

            // Download the HTML content from the website asynchronously
            string url = "https://www.espn.com/nba/teams";
            string htmlContent = await DownloadHtmlContentAsync(url);

            // Parse the HTML content to extract team names
            var doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            // XPath expression to select team names
            string xpath = "//*[@id='fittPageContainer']/div[3]/div/div/div[1]/div[2]//h2";
            var teamNodes = doc.DocumentNode.SelectNodes(xpath);
            if (teamNodes != null)
            {
                foreach (var teamNode in teamNodes)
                {
                    string teamName = teamNode.InnerText;
                    teamNames.Add(teamName);
                }
            }

            return teamNames;
        }
        public async Task<List<Player>> GetTeamPlayersAsync(string teamName, IProgress<int> progress)
        {
            List<Player> players = new List<Player>();

            // Download the HTML content
            string url = $"https://www.espn.com/nba/team/roster/_/name/{Uri.EscapeDataString(teamName.ToLower())}";
            string htmlContent = await DownloadHtmlContentAsync(url);

            // Parse the HTML content
            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(htmlContent);

            var playerRows = document.QuerySelectorAll("#fittPageContainer div.Table__Scroller tr.Table__TR");
            int totalPlayers = playerRows.Length;
            int currentPlayer = 0;

            foreach (var playerRow in playerRows)
            {
                var cells = playerRow.QuerySelectorAll("td");

                if (cells.Length >= 8)
                {
                    string name = cells[1].TextContent;
                    string position = cells[2].TextContent;
                    int age = int.Parse(cells[3].TextContent);
                    string salary = cells[7].TextContent;

                    Player player = new Player
                    {
                        Name = name,
                        Position = position,
                        Age = age,
                        Salary = salary
                    };

                    players.Add(player);
                }

                // Report progress
                currentPlayer++;
                int progressPercentage = (int)((currentPlayer / (double)totalPlayers) * 100);
                progress.Report(progressPercentage);
            }

            return players;
        }

        private async Task<string> DownloadHtmlContentAsync(string url)
        {
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }
        public async Task<string> GetTeamAbbreviationAsync(string teamName)
        {
            Dictionary<string, string> teamAbbreviations = new Dictionary<string, string>
            {
                { "Atlanta Hawks", "atl" },
                { "Boston Celtics", "bos" },
                { "Brooklyn Nets", "bkn" },
                { "Charlotte Hornets", "cha" },
                { "Chicago Bulls", "chi" },
                { "Cleveland Cavaliers", "cle" },
                { "Dallas Mavericks", "dal" },
                { "Denver Nuggets", "den" },
                { "Detroit Pistons", "det" },
                { "Golden State Warriors", "gsw" },
                { "Houston Rockets", "hou" },
                { "Indiana Pacers", "ind" },
                { "LA Clippers", "lac" },
                { "Los Angeles Lakers", "lal" },
                { "Memphis Grizzlies", "mem" },
                { "Miami Heat", "mia" },
                { "Milwaukee Bucks", "mil" },
                { "Minnesota Timberwolves", "min" },
                { "New Orleans Pelicans", "nop" },
                { "New York Knicks", "nyk" },
                { "Oklahoma City Thunder", "okc" },
                { "Orlando Magic", "orl" },
                { "Philadelphia 76ers", "phi" },
                { "Phoenix Suns", "phx" },
                { "Portland Trail Blazers", "por" },
                { "Sacramento Kings", "sac" },
                { "San Antonio Spurs", "sas" },
                { "Toronto Raptors", "tor" },
                { "Utah Jazz", "uta" },
                { "Washington Wizards", "was" }
            };

            if (teamAbbreviations.TryGetValue(teamName, out string abbreviation))
            {
                return abbreviation;
            }

            return string.Empty;
        }
        public class Player
        {
            public string Name { get; set; }
            public string Position { get; set; }
            public int Age { get; set; }
            public string Salary { get; set; }
        }
    }
}

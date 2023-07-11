using OfficeOpenXml;

namespace WEB_SCRAPPING
{
    internal class EXPORT
    {
        public static async Task ExportDataGridViewToExcelAsync(DataGridView dataGridView, string filePath)
        {
            await Task.Run(() =>
            {
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Players");

                    // Fill the header row with column names
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = dataGridView.Columns[i].HeaderText;
                    }

                    // Fill the data rows with cell values
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1].Value = dataGridView.Rows[i].Cells[j].Value;
                        }
                    }

                    // Auto-fit the columns
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Save the Excel package to the specified file path
                    package.SaveAs(new FileInfo(filePath));
                }
            });
        }
    }
}

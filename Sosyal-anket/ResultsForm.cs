using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sosyal_anket
{
    public partial class ResultsForm : Form
    {
        private readonly List<SurveyResult> results;

        public ResultsForm(List<SurveyResult> results)
        {
            InitializeComponent();
            this.results = results ?? new List<SurveyResult>();
        }

        private void ResultsForm_Load(object? sender, EventArgs e)
        {
            // Bind to a BindingList to show read-only snapshot
            var binding = new BindingList<SurveyResult>(results);
            dgvResults.DataSource = binding;
            tslInfo.Text = $"Cəmi nəticə: {results.Count}";
        }

        private void btnSaveCsv_Click(object? sender, EventArgs e)
        {
            try
            {
                if (results == null || results.Count == 0)
                {
                    MessageBox.Show("Yadda saxlanılacaq nəticə yoxdur.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string fileName = $"SurveyResults_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                string fullPath = Path.Combine(desktop, fileName);

                var sb = new StringBuilder();
                // header
                sb.AppendLine("Name;Age;Gender;Education;Working;City;InternetHours;SocialMediaActive;FavoritePlatform;EgovUsage");

                foreach (var r in results)
                {
                    string line = string.Join(";",
                        EscapeCsv(r.Name),
                        r.Age.ToString(),
                        EscapeCsv(r.Gender),
                        EscapeCsv(r.Education),
                        r.Working ? "Yes" : "No",
                        EscapeCsv(r.City),
                        EscapeCsv(r.InternetHours),
                        EscapeCsv(r.SocialMediaActive),
                        EscapeCsv(r.FavoritePlatform),
                        EscapeCsv(r.EgovUsage)
                    );
                    sb.AppendLine(line);
                }

                File.WriteAllText(fullPath, sb.ToString(), Encoding.UTF8);
                tslInfo.Text = $"CSV saxlandı: {fullPath}";
                MessageBox.Show($"CSV faylı Desktop-a yazıldı:\n{fullPath}", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CSV faylı yazılarkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string EscapeCsv(string? value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            // Simple escape for semicolon-containing fields: wrap in quotes and double quotes inside
            if (value.Contains(";") || value.Contains("\"") || value.Contains("\n") || value.Contains("\r"))
            {
                return $"\"{value.Replace("\"", "\"\"")}\"";
            }
            return value;
        }
    }
}

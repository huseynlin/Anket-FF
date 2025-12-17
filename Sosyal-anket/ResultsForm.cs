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

        private class SurveyResultView
        {
            public string Name { get; set; } = string.Empty;
            public int Age { get; set; }
            public string Gender { get; set; } = string.Empty;
            public string Education { get; set; } = string.Empty;
            public string Working { get; set; } = string.Empty;
            public string City { get; set; } = string.Empty;
            public string InternetHours { get; set; } = string.Empty;
            public string SocialMediaActive { get; set; } = string.Empty;
            public string FavoritePlatform { get; set; } = string.Empty;
            public string EgovUsage { get; set; } = string.Empty;
        }

        public ResultsForm(List<SurveyResult> results)
        {
            InitializeComponent();
            this.results = results ?? new List<SurveyResult>();
        }

        private void ResultsForm_Load(object? sender, EventArgs e)
        {
            var viewList = results.Select(r => new SurveyResultView
            {
                Name = r.Name,
                Age = r.Age,
                Gender = r.Gender,
                Education = r.Education,
                Working = r.Working ? "Bəli" : "Xeyr",
                City = r.City,
                InternetHours = r.InternetHours,
                SocialMediaActive = r.SocialMediaActive,
                FavoritePlatform = r.FavoritePlatform,
                EgovUsage = r.EgovUsage
            }).ToList();

            var binding = new BindingList<SurveyResultView>(viewList);
            dgvResults.DataSource = binding;
            var headers = new Dictionary<string, string>
            {
                [nameof(SurveyResultView.Name)] = "Ad",
                [nameof(SurveyResultView.Age)] = "Yaş",
                [nameof(SurveyResultView.Gender)] = "Cins",
                [nameof(SurveyResultView.Education)] = "Təhsil",
                [nameof(SurveyResultView.Working)] = "İşləyir",
                [nameof(SurveyResultView.City)] = "Şəhər",
                [nameof(SurveyResultView.InternetHours)] = "Günlük internet saatı",
                [nameof(SurveyResultView.SocialMediaActive)] = "Sosial şəbəkə aktivliyi",
                [nameof(SurveyResultView.FavoritePlatform)] = "Ən çox istifadə olunan platforma",
                [nameof(SurveyResultView.EgovUsage)] = "eGov istifadə"
            };

            int displayIndex = 0;
            foreach (var kvp in headers)
            {
                if (dgvResults.Columns.Contains(kvp.Key))
                {
                    var col = dgvResults.Columns[kvp.Key];
                    col.HeaderText = kvp.Value;
                    col.DisplayIndex = displayIndex++;
                }
            }

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
            if (value.Contains(";") || value.Contains("\"") || value.Contains("\n") || value.Contains("\r"))
            {
                return $"\"{value.Replace("\"", "\"\"")}\"";
            }
            return value;
        }
    }
}

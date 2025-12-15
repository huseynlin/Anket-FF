using System;

namespace Sosyal_anket
{
    public class SurveyResult
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Education { get; set; } = string.Empty;
        public bool Working { get; set; }
        public string City { get; set; } = string.Empty;

        public string InternetHours { get; set; } = string.Empty;
        public string SocialMediaActive { get; set; } = string.Empty;
        public string FavoritePlatform { get; set; } = string.Empty;
        public string EgovUsage { get; set; } = string.Empty;
    }
}

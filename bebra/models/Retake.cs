using System;

namespace bebra.models
{
    public class Retake
    {
        public int id { get; set; }
        public string NameOfRetake { get; set; }
        public int professor { get; set; }
        public DateTime RetakeDate { get; set; }
        public string RetakePlace { get; set; }
        public string RetakeAud { get; set; }

    }
}

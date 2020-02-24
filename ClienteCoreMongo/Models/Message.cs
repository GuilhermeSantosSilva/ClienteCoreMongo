using System;

namespace ClienteCoreMongo.Models
{
    [Serializable]
    public class Message
    {
        public string CssClassName { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}

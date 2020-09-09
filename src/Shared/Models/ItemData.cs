namespace NoteToSelf.Shared.Models
{
    using System;
    using System.Collections.Generic;

    public class ItemData
    {
        public int Id { get; set; }
        public int X { get; set; }
        public float Y { get; set; }
        public string Text { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsTopItem { get; set; } = false;
        public List<string> ClassList { get; set; } = new List<string>();
    }
}

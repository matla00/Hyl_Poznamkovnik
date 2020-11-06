using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Hyl_Poznamkovnik.Model
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Date_created { get; set; }
        public DateTime Date_edited { get; set; }
    }
}

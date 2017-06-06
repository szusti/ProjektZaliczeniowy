using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model {
    public class Film {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public List<string> Hours { get; private set; }

        public Film(int id, string title, List<string> hours) {
            Id = id;
            Title = title;
            Hours = hours;
        }
    }
}

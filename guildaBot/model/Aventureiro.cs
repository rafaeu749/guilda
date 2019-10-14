using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildaRPG.Model {
    class Aventureiro {

        public long Id { get; set; }
        public string Nome { get; set; }
        public char Sexo { get; set; }
        public List<Classe> Classes { get; set; }
        public int Nivel { get; set; }
        public int XP { get; set; }
        public Casa Casa { get; set; }
        public Faccao Faccao { get; set; }
        public int Renome { get; set; }
        public Tesouro Tesouro { get; set; }
        public Dinheiro Dinheiro { get; set; }
        public List<Item> ItensMagicos { get; set; }
        public string ImagemURL { get; set; }
        public DateTime Update { get; set; }
    }
}

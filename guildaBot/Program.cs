using GuildaRPG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace guildaBot
{
    class Program
    {
        /*
        static void Main(string[] args) {
            try
            {
                TimeSpan ts;

                Aventureiro av = new Aventureiro()
                {
                    Id = 555,
                    Nome = "Belmor",
                    Sexo = 'M',
                    Classes = new List<Classe>()
                    {
                        new Classe() { Nome = "Sorcerer", SubClasse = "Storm", Nivel = 12 },
                        new Classe() { Nome = "Cleric", Nivel = 2 },
                    },
                    Nivel = 14,
                    XP = 0,
                    Casa = Casa.SUPERBIA,
                    Faccao = Faccao.HARPISTAS,
                    Renome = 1,
                    Tesouro = new Tesouro { T1 = 1, T2 = 20, T3 = 2, T4 = 0 },
                    Dinheiro = new Dinheiro { PP = 1, PO = 10, EP = 20, SP = 100, CP = 1000 },
                    ItensMagicos = new List<Item>()
                    {
                        new Item() { Nome = "Anel da Sorte", Tier=1, Tesouro=10, Descricao = "whiskas sache"  },
                        new Item() { Nome = "Pérola do Poder", Tier=2, Tesouro=20, Descricao = "whiskas sache 2", URL = "https://www.dndbeyond.com/magic-items/pearl-of-power" }
                    },
                    ImagemURL = "https://cdn.discordapp.com/attachments/537414311908343818/620084281812713473/Belmor.jpg",
                    Update = DateTime.Now
                };
                // JsonConvert.SerializeObject(av);

                Stopwatch sw = new Stopwatch();

                sw.Start();

                List<Aventureiro> lA = JsonConvert.DeserializeObject<List<Aventureiro>>(System.IO.File.ReadAllText(@"C:\Rafaeu\guilda\docs\data\aventureiros.json"));

                sw.Stop();
                ts = sw.Elapsed;
                Console.WriteLine("== DONE {0} registros ==", lA.Count);
                Console.WriteLine("Runtime {0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

                sw.Reset();
                sw.Start();

                for (int index = 0; index < lA.Count; index++)
                {
                    Aventureiro aventureiro = lA[index];
                    aventureiro.Dinheiro.PO = 17;
                    aventureiro.Dinheiro.CP = 18;
                    aventureiro.ItensMagicos.Add(new Item()
                    {
                        Nome = "Item de Teste",
                        Descricao = "Descrição fajuta!",
                        Tesouro = 24,
                        Tier = 2
                    });
                    //if (aventureiro.Id == 999)
                    //{
                    //    lA[index] = av;
                    //}
                }

                sw.Stop();
                ts = sw.Elapsed;
                Console.WriteLine("== DONE {0} registros ==", lA.Count);
                Console.WriteLine("Runtime {0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);


                sw.Reset();
                sw.Start();

                string contents = JsonConvert.SerializeObject(lA);

                sw.Stop();
                ts = sw.Elapsed;
                Console.WriteLine("== DONE {0} Length ==", contents.Length);
                Console.WriteLine("Runtime {0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

                System.IO.File.WriteAllText(@"C:\Rafaeu\guilda\docs\data\aventureiros.json", contents);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            Console.Read();
        }
        //*/
    }
}


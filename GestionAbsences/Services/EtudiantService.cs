using GestionAbsences.Models;

namespace GestionAbsences.Services
{ 

    public static class EtudiantService
    {
        static List<Etudiant> EtudiantList { get; }
        static int nextId = nextId++;
        

        static EtudiantService()
        {
            EtudiantList = new List<Etudiant>
            {
                new Etudiant {Id = 1, Name = "TAGBE Bandana", Formation = "FE" },
                new Etudiant {Id = 2, Name = "DEVALOIS Paul", Formation = "FA" },
                new Etudiant {Id = 3, Name = "PORTUGAL Lucas", Formation = "FA"},
                new Etudiant {Id = 4, Name = "ALEXANDERS Karl",Formation = "FE" }

            };
           
        }

        public static List<Etudiant> GetEtudiants() => EtudiantList;

        public static Etudiant? Get(int id) => EtudiantList.FirstOrDefault(e => e.Id == id);

        public static void Add(Etudiant etudiant)
        {
            etudiant.Id = nextId++;
            EtudiantList.Add(etudiant);
        }

        public static void Delete(int id) 
        {
            var etudiant = Get(id);
            if (etudiant != null)
            {
                return;

              
            }
            EtudiantList.Remove(etudiant);
        }

        public static void Update(Etudiant etudiant)
        {
            var index = EtudiantList.FindIndex(e => e.Id == etudiant.Id);
            if (index == -1)
            {
                return;
            }
            EtudiantList[index] = etudiant;
        }
    }
}


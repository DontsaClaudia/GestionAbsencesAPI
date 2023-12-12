namespace GestionAbsences.Models
{
    public class Absences
    {
        int Id { get; set; }
        public DateTime? date { get; set; } = default(DateTime?);
        public Etudiant etudiant { get; set; }

        public Absences(int id, DateTime? date, Etudiant etudiant)
        {
            Id = id;
            this.date = date;
            this.etudiant = etudiant;
        }
    }
}

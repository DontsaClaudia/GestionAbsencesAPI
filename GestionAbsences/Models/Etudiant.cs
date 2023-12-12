using System.Runtime.CompilerServices;

namespace GestionAbsences.Models
{
    /// <summary>
    /// Représente un etudiant
    /// </summary>
    public class Etudiant
    {
        /// <summary>
        /// Identifiant unique de l'etudiant
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Non de l'étudiant
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Formation de l'étudiant
        /// </summary>
        public string? Formation { get; set; }

        
    }

    
}

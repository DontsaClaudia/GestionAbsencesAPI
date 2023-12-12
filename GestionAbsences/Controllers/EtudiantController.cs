using Microsoft.AspNetCore.Mvc;
using GestionAbsences.Models;
using GestionAbsences.Services;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace GestionAbsences.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EtudiantController : ControllerBase
    {

        
        public EtudiantController() { }

        /// <summary>
        /// Permet de recuperer la liste des etudiants
        /// </summary>
        /// <returns> Liste des etudiants</returns>
        //  Get all action
        [HttpGet(Name = "GetEtudiants")]
        [ProducesResponseType(typeof(List<Etudiant>), StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Etudiant> Get()
        {
            return EtudiantService.GetEtudiants();
        }
           

        // Get By Id action
        [HttpGet("{id}")]
        public ActionResult<Etudiant> Get( int id)
        {
            var etudiant = EtudiantService.Get(id);
            if (etudiant == null)
            {
                return NotFound();
            }
            return Ok(etudiant);
        }
        // POST action
        [HttpPost]
        public  IActionResult Create(Etudiant etudiant)
        {
            string jsonEtudiant = System.Text.Json.JsonSerializer.Serialize(EtudiantService.GetEtudiants());
            string etudiant_list = "F:/MS2D1/Dot_Net_Csharp/mes_notes/Csharp/GestionAbsences/GestionAbsences/etudiant_list.json";
            System.IO.File.WriteAllText(etudiant_list, jsonEtudiant);

            EtudiantService.Add(etudiant);
            return CreatedAtAction(nameof(Get),new {id =  etudiant.Id},  etudiant);
        }

        //PUT action 
        [HttpPut("{id}")]
        public IActionResult Update(int id, Etudiant etudiant)
        {
            if (id != etudiant.Id)
            {
                return BadRequest();
            }
            var existingEtudiant = EtudiantService.Get(id);
            if (existingEtudiant == null)
            {
                return NotFound();
            }
            EtudiantService.Update(etudiant);
            return NoContent();
           
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var etudiant = EtudiantService.Get(id);
            if (etudiant is null)
            {
                return NotFound();
            }
            EtudiantService.Delete(id);
            return NoContent();
        }
    }
}

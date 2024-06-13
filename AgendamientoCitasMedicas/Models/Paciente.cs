using System.ComponentModel.DataAnnotations;

namespace AgendamientoCitasMedicas.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public TipoGenero Genre { get; set; }

        [Required]
        public string? Address{ get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]

        public string? Phone { get; set; }


        public List<CitaMedica>? CitaMedicaList { get; set; }

        public List<Tratamiento>? Tratamientos { get; set; }

        public HistorialMedico? HistorialMedico { get; set;}
    }


    public enum TipoGenero{
        Masculino, 
        Femenino
    }
}

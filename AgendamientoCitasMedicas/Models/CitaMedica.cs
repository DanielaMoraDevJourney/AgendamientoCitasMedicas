using System.ComponentModel.DataAnnotations;

namespace AgendamientoCitasMedicas.Models
{
    public class CitaMedica
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Reason { get; set; }

        [Required]
        public bool Availability { get; set; }

        [Required]
        public DateTime Schedule { get; set; }


        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        public int MedicoId { get; set; }
        public Medico? Medico { get; set; }


    }
}

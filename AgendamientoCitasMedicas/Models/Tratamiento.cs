using System.ComponentModel.DataAnnotations;

namespace AgendamientoCitasMedicas.Models
{
    public class Tratamiento
    {
        [Key]

        public int Id { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Dosage { get; set; }

        [Required]
        public string? Contraindication { get; set; }

        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        public int MedicoId { get; set; }
        public Medico? Medico { get; set; }
    }
}

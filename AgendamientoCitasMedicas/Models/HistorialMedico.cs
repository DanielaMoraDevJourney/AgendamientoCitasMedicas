using System.ComponentModel.DataAnnotations;

namespace AgendamientoCitasMedicas.Models
{
    public class HistorialMedico
    {
        [Key]
        public int Id { get; set; }

        [Required]  
        public string? Allergy { get; set; }

        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace AgendamientoCitasMedicas.Models
{
    public class Medico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public TipoEspecialidad Speciality { get; set; }

        [Required]
        public TimeOnly Schedule {  get; set; }

        public List<CitaMedica>? CitaMedicaList { get; set; }

        public List<Tratamiento>? Tratamientos { get; set; }
    }

    public enum TipoEspecialidad
    {
        Pediatría,
        Oncología,
        Traumatología,
        Cardiología,
        General
    }
}

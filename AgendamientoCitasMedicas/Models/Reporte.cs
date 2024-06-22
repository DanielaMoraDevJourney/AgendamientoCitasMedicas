using System.ComponentModel.DataAnnotations;

namespace AgendamientoCitasMedicas.Models
{
    public class Reporte
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public string? Descripcion { get; set; }
        public string? DatosEstadisticos { get; set; }

        public int TratamientoId { get; set; }
        public Tratamiento? Tratamiento { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgendamientoCitasMedicas.Models;

namespace AgendamientoCitasMedicas.Data
{
    public class AgendamientoCitasMedicasContext : DbContext
    {
        public AgendamientoCitasMedicasContext (DbContextOptions<AgendamientoCitasMedicasContext> options)
            : base(options)
        {
        }

        public DbSet<AgendamientoCitasMedicas.Models.CitaMedica> CitaMedica { get; set; } = default!;
        public DbSet<AgendamientoCitasMedicas.Models.HistorialMedico> HistorialMedico { get; set; } = default!;
        public DbSet<AgendamientoCitasMedicas.Models.Medico> Medico { get; set; } = default!;
        public DbSet<AgendamientoCitasMedicas.Models.Paciente> Paciente { get; set; } = default!;
        public DbSet<AgendamientoCitasMedicas.Models.Reporte> Reporte { get; set; } = default!;
        public DbSet<AgendamientoCitasMedicas.Models.Tratamiento> Tratamiento { get; set; } = default!;
    }
}

using CitasIPS.Domain;

namespace CitasIPS.Services;

public class CitaService : ICitaService
{
    private readonly IRepositorio<Cita> _repoCitas;

    public CitaService(IRepositorio<Cita> repoCitas)
    {
        _repoCitas = repoCitas;
    }

    public void AgendarCita(Cita cita)
    {
        // Validación: evitar duplicados por médico y por paciente en misma fecha exacta
        if (_repoCitas.Listar().Any(c => c.Medico.Id == cita.Medico.Id && c.Fecha == cita.Fecha && c.Activa))
            throw new InvalidOperationException("El médico ya tiene una cita en esa fecha y hora.");

        if (_repoCitas.Listar().Any(c => c.Paciente.Id == cita.Paciente.Id && c.Fecha == cita.Fecha && c.Activa))
            throw new InvalidOperationException("El paciente ya tiene una cita en esa fecha y hora.");

        _repoCitas.Agregar(cita);
    }

    public void CancelarCita(string id)
    {
        var cita = _repoCitas.ObtenerPorId(id) ?? throw new Exception("Cita no encontrada");
        cita.Cancelar();
    }

    public IEnumerable<Cita> ConsultarPorFecha(DateTime fecha) =>
        _repoCitas.Listar().Where(c => c.Fecha.Date == fecha.Date && c.Activa);

    public IEnumerable<Cita> ConsultarPorPaciente(string pacienteId) =>
        _repoCitas.Listar().Where(c => c.Paciente.Id == pacienteId && c.Activa);

    public IEnumerable<Cita> ListarCitas() => _repoCitas.Listar().Where(c => c.Activa);
}

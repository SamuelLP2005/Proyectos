namespace CitasIPS.Domain;

public interface ICitaService
{
    void AgendarCita(Cita cita);
    void CancelarCita(string id);
    IEnumerable<Cita> ConsultarPorFecha(DateTime fecha);
    IEnumerable<Cita> ConsultarPorPaciente(string pacienteId);
    IEnumerable<Cita> ListarCitas();
}

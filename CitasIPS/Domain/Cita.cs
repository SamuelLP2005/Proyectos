namespace CitasIPS.Domain;

public abstract class Cita
{
    public string Id { get; }
    public DateTime Fecha { get; }
    public Paciente Paciente { get; }
    public Medico Medico { get; }
    public bool Activa { get; private set; } = true;

    protected Cita(string id, DateTime fecha, Paciente paciente, Medico medico)
    {
        if (fecha < DateTime.Now) throw new ArgumentException("La fecha debe ser futura");
        Id = id;
        Fecha = fecha;
        Paciente = paciente;
        Medico = medico;
    }

    public void Cancelar() => Activa = false;

    public abstract decimal CalcularCosto();
}

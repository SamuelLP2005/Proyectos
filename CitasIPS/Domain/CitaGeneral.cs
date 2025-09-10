namespace CitasIPS.Domain;

public class CitaGeneral : Cita
{
    public CitaGeneral(string id, DateTime fecha, Paciente paciente, Medico medico)
        : base(id, fecha, paciente, medico) { }

    public override decimal CalcularCosto() => 50000m;
}

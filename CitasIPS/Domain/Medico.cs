namespace CitasIPS.Domain;

public class Medico : Persona
{
    public string Especialidad { get; private set; }

    public Medico(string id, string nombre, string especialidad)
        : base(id, nombre)
    {
        if (string.IsNullOrWhiteSpace(especialidad)) throw new ArgumentException("La especialidad es obligatoria.");
        Especialidad = especialidad;
    }
}

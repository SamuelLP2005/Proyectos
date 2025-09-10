namespace CitasIPS.Domain;

public class Paciente : Persona
{
    public string Telefono { get; private set; }

    public Paciente(string id, string nombre, string telefono)
        : base(id, nombre)
    {
        if (string.IsNullOrWhiteSpace(telefono)) throw new ArgumentException("El teléfono es obligatorio.");
        Telefono = telefono;
    }
}

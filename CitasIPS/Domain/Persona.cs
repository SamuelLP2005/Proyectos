namespace CitasIPS.Domain;

public abstract class Persona
{
    public string Id { get; }
    public string Nombre { get; private set; }

    protected Persona(string id, string nombre)
    {
        if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("El Id es obligatorio.");
        if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre es obligatorio.");
        Id = id;
        Nombre = nombre;
    }
}

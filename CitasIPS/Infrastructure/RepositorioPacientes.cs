using CitasIPS.Domain;

namespace CitasIPS.Infrastructure;

public class RepositorioPacientes : IRepositorio<Paciente>
{
    private readonly Dictionary<string, Paciente> _db = new();

    public void Agregar(Paciente entidad) => _db[entidad.Id] = entidad;

    public Paciente? ObtenerPorId(string id) => _db.TryGetValue(id, out var paciente) ? paciente : null;

    public IEnumerable<Paciente> Listar() => _db.Values;

    public void Eliminar(string id) => _db.Remove(id);
}

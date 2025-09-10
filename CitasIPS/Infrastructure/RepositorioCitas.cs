using CitasIPS.Domain;

namespace CitasIPS.Infrastructure;

public class RepositorioCitas : IRepositorio<Cita>
{
    private readonly Dictionary<string, Cita> _db = new();

    public void Agregar(Cita entidad) => _db[entidad.Id] = entidad;

    public Cita? ObtenerPorId(string id) => _db.TryGetValue(id, out var cita) ? cita : null;

    public IEnumerable<Cita> Listar() => _db.Values;

    public void Eliminar(string id) => _db.Remove(id);
}

using CitasIPS.Domain;

namespace CitasIPS.Infrastructure;

public class RepositorioMedicos : IRepositorio<Medico>
{
    private readonly Dictionary<string, Medico> _db = new();

    public void Agregar(Medico entidad) => _db[entidad.Id] = entidad;

    public Medico? ObtenerPorId(string id) => _db.TryGetValue(id, out var medico) ? medico : null;

    public IEnumerable<Medico> Listar() => _db.Values;

    public void Eliminar(string id) => _db.Remove(id);
}

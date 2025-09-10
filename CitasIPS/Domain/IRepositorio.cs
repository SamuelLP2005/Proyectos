namespace CitasIPS.Domain;

public interface IRepositorio<T>
{
    void Agregar(T entidad);
    T? ObtenerPorId(string id);
    IEnumerable<T> Listar();
    void Eliminar(string id);
}

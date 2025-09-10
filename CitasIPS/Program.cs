using CitasIPS.Domain;
using CitasIPS.Services;
using CitasIPS.Infrastructure;
using System.Globalization;

var repoPacientes = new RepositorioPacientes();
var repoMedicos = new RepositorioMedicos();
var repoCitas = new RepositorioCitas();
var citaService = new CitasIPS.Services.CitaService(repoCitas);

Console.WriteLine("CitasIPS - Aplicación de Consola\n");

while (true)
{
    Console.WriteLine("--- Menú ---");
    Console.WriteLine("1) Registrar paciente");
    Console.WriteLine("2) Registrar médico");
    Console.WriteLine("3) Agendar cita");
    Console.WriteLine("4) Cancelar cita");
    Console.WriteLine("5) Consultar citas por fecha");
    Console.WriteLine("6) Consultar citas por paciente");
    Console.WriteLine("7) Listar todas las citas");
    Console.WriteLine("0) Salir");
    Console.Write("Opción: ");
    var op = Console.ReadLine();

    try
    {
        switch (op)
        {
            case "1":
                Console.Write("Id paciente: "); var idP = Console.ReadLine()!;
                Console.Write("Nombre: "); var nombreP = Console.ReadLine()!;
                Console.Write("Teléfono: "); var telP = Console.ReadLine()!;
                repoPacientes.Agregar(new Paciente(idP, nombreP, telP));
                Console.WriteLine("Paciente registrado.\n");
                break;

            case "2":
                Console.Write("Id médico: "); var idM = Console.ReadLine()!;
                Console.Write("Nombre: "); var nombreM = Console.ReadLine()!;
                Console.Write("Especialidad: "); var esp = Console.ReadLine()!;
                repoMedicos.Agregar(new Medico(idM, nombreM, esp));
                Console.WriteLine("Médico registrado.\n");
                break;

            case "3":
                Console.Write("Id cita (código): "); var idC = Console.ReadLine()!;
                Console.Write("Id paciente: "); var pid = Console.ReadLine()!;
                var paciente = repoPacientes.ObtenerPorId(pid) ?? throw new Exception("Paciente no encontrado");
                Console.Write("Id médico: "); var mid = Console.ReadLine()!;
                var medico = repoMedicos.ObtenerPorId(mid) ?? throw new Exception("Médico no encontrado");
                Console.Write("Fecha y hora (yyyy-MM-dd HH:mm): ");
                var fechaStr = Console.ReadLine()!;
                var fecha = DateTime.ParseExact(fechaStr, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
                var cita = new CitaGeneral(idC, fecha, paciente, medico);
                citaService.AgendarCita(cita);
                Console.WriteLine("Cita agendada correctamente.\n");
                break;

            case "4":
                Console.Write("Id cita a cancelar: "); var idCancel = Console.ReadLine()!;
                citaService.CancelarCita(idCancel);
                Console.WriteLine("Cita cancelada.\n");
                break;

            case "5":
                Console.Write("Fecha (yyyy-MM-dd): "); var fstr = Console.ReadLine()!;
                var f = DateTime.ParseExact(fstr, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var porFecha = citaService.ConsultarPorFecha(f);
                foreach (var c in porFecha)
                {
                    Console.WriteLine($"{c.Id} | {c.Fecha:yyyy-MM-dd HH:mm} | Paciente: {c.Paciente.Nombre} | Médico: {c.Medico.Nombre}");
                }
                Console.WriteLine();
                break;

            case "6":
                Console.Write("Id paciente: "); var pquery = Console.ReadLine()!;
                var porPac = citaService.ConsultarPorPaciente(pquery);
                foreach (var c in porPac)
                {
                    Console.WriteLine($"{c.Id} | {c.Fecha:yyyy-MM-dd HH:mm} | Médico: {c.Medico.Nombre}");
                }
                Console.WriteLine();
                break;

            case "7":
                foreach (var c in citaService.ListarCitas())
                {
                    Console.WriteLine($"{c.Id} | {c.Fecha:yyyy-MM-dd HH:mm} | Paciente: {c.Paciente.Nombre} | Médico: {c.Medico.Nombre} | Costo: {c.CalcularCosto()}");
                }
                Console.WriteLine();
                break;

            case "0":
                return;

            default:
                Console.WriteLine("Opción inválida.\n");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}\n");
    }
}

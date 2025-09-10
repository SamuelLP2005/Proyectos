# CitasIPS - Sistema de Agendamiento (Consola .NET 8)

## Requisitos
- .NET 8 SDK

## Cómo ejecutar
Desde la carpeta `CitasIPS` ejecutar:

```bash
dotnet run
```

## Estructura
- Domain/: Entidades e interfaces (Persona, Paciente, Medico, Cita, IRepositorio).
- Services/: Lógica de negocio (ICitaService, CitaService).
- Infrastructure/: Repositorios en memoria.
- Program.cs: Menú de consola.

## Notas
- Este proyecto incluye persistencia en memoria.

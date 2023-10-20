using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Linq;

class Empleado
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public double Salario { get; set; }
}

class Program
{
    static Empleado[] empleados = new Empleado[100];
    static int cantidadEmpleados = 0;

    static void Main(string[] args)
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("Sistema de Gestión de Empleados");
            Console.WriteLine("1. Agregar Empleados");
            Console.WriteLine("2. Consultar Empleados");
            Console.WriteLine("3. Modificar Empleados");
            Console.WriteLine("4. Borrar Empleados");
            Console.WriteLine("5. Inicializar Arreglos");
            Console.WriteLine("6. Reportes");
            Console.WriteLine("7. Salir");
            Console.Write("Elija una opción: ");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        AgregarEmpleado();
                        break;
                    case 2:
                        ConsultarEmpleados();
                        break;
                    case 3:
                        ModificarEmpleado();
                        break;
                    case 4:
                        BorrarEmpleado();
                        break;
                    case 5:
                        InicializarArreglos();
                        break;
                    case 6:
                        MostrarMenuReportes();
                        break;
                    case 7:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente nuevamente.");
            }
        }
    }

    static void AgregarEmpleado()
    {
        Console.WriteLine("Agregar Empleado");
        Console.Write("Cédula: ");
        string cedula = Console.ReadLine();
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Salario: ");
        double salario;
        if (double.TryParse(Console.ReadLine(), out salario))
        {
            Empleado empleado = new Empleado
            {
                Cedula = cedula,
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono,
                Salario = salario
            };
            empleados[cantidadEmpleados] = empleado;
            cantidadEmpleados++;
            Console.WriteLine("Empleado agregado exitosamente.");
        }
        else
        {
            Console.WriteLine("Salario no válido. El empleado no ha sido agregado.");
        }
    }

    static void ConsultarEmpleados()
    {
        Console.WriteLine("Consultar Empleados");
        Console.Write("Ingrese la cédula del empleado: ");
        string cedula = Console.ReadLine();

        Empleado empleado = BuscarEmpleadoPorCedula(cedula);

        if (empleado != null)
        {
            Console.WriteLine("Información del Empleado:");
            Console.WriteLine($"Cédula: {empleado.Cedula}");
            Console.WriteLine($"Nombre: {empleado.Nombre}");
            Console.WriteLine($"Dirección: {empleado.Direccion}");
            Console.WriteLine($"Teléfono: {empleado.Telefono}");
            Console.WriteLine($"Salario: {empleado.Salario}");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    static void ModificarEmpleado()
    {
        Console.WriteLine("Modificar Empleado");
        Console.Write("Ingrese la cédula del empleado a modificar: ");
        string cedula = Console.ReadLine();

        Empleado empleado = BuscarEmpleadoPorCedula(cedula);

        if (empleado != null)
        {
            Console.WriteLine("Información actual del Empleado:");
            Console.WriteLine($"Cédula: {empleado.Cedula}");
            Console.WriteLine($"Nombre: {empleado.Nombre}");
            Console.WriteLine($"Dirección: {empleado.Direccion}");
            Console.WriteLine($"Teléfono: {empleado.Telefono}");
            Console.WriteLine($"Salario: {empleado.Salario}");

            Console.Write("Nuevo nombre: ");
            empleado.Nombre = Console.ReadLine();
            Console.Write("Nueva dirección: ");
            empleado.Direccion = Console.ReadLine();
            Console.Write("Nuevo teléfono: ");
            empleado.Telefono = Console.ReadLine();
            Console.Write("Nuevo salario: ");
            if (double.TryParse(Console.ReadLine(), out double nuevoSalario))
            {
                empleado.Salario = nuevoSalario;
                Console.WriteLine("Empleado modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("Salario no válido. No se pudo modificar el empleado.");
            }
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    static void BorrarEmpleado()
    {
        Console.WriteLine("Borrar Empleado");
        Console.Write("Ingrese la cédula del empleado a borrar: ");
        string cedula = Console.ReadLine();

        Empleado empleado = BuscarEmpleadoPorCedula(cedula);

        if (empleado != null)
        {
            for (int i = 0; i < cantidadEmpleados; i++)
            {
                if (empleados[i] == empleado)
                {
                    for (int j = i; j < cantidadEmpleados - 1; j++)
                    {
                        empleados[j] = empleados[j + 1];
                    }
                    cantidadEmpleados--;
                    Console.WriteLine("Empleado borrado exitosamente.");
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    static void InicializarArreglos()
    {
        empleados = new Empleado[100];
        cantidadEmpleados = 0;
        Console.WriteLine("Arreglos inicializados.");
    }

    static void MostrarMenuReportes()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("Reportes");
            Console.WriteLine("1. Consultar empleados con número de cédula");
            Console.WriteLine("2. Listar todos los empleados ordenados por nombre");
            Console.WriteLine("3. Calcular y mostrar el promedio de los salarios");
            Console.WriteLine("4. Calcular y mostrar el salario más alto y el más bajo de todos los empleados");
            Console.WriteLine("5. Volver al menú principal");
            Console.Write("Elija una opción: ");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese la cédula del empleado: ");
                        string cedula = Console.ReadLine();
                        Empleado empleado = BuscarEmpleadoPorCedula(cedula);
                        if (empleado != null)
                        {
                            Console.WriteLine("Información del Empleado:");
                            Console.WriteLine($"Cédula: {empleado.Cedula}");
                            Console.WriteLine($"Nombre: {empleado.Nombre}");
                            Console.WriteLine($"Dirección: {empleado.Direccion}");
                            Console.WriteLine($"Teléfono: {empleado.Telefono}");
                            Console.WriteLine($"Salario: {empleado.Salario}");
                        }
                        else
                        {
                            Console.WriteLine("Empleado no encontrado.");
                        }
                        break;
                    case 2:
                        ListarEmpleadosOrdenadosPorNombre();
                        break;
                    case 3:
                        CalcularPromedioSalarios();
                        break;
                    case 4:
                        CalcularSalarioMasAltoYMasBajo();
                        break;
                    case 5:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente nuevamente.");
            }
        }
    }

    static Empleado BuscarEmpleadoPorCedula(string cedula)
    {
        return empleados.FirstOrDefault(e => e != null && e.Cedula == cedula);
    }

    static void ListarEmpleadosOrdenadosPorNombre()
    {
        var empleadosOrdenados = empleados
            .Where(e => e != null)
            .OrderBy(e => e.Nombre);

        Console.WriteLine("Listado de Empleados Ordenados por Nombre:");
        foreach (var empleado in empleadosOrdenados)
        {
            Console.WriteLine($"Cédula: {empleado.Cedula}, Nombre: {empleado.Nombre}");
        }
    }

    static void CalcularPromedioSalarios()
    {
        double totalSalarios = empleados
            .Where(e => e != null)
            .Sum(e => e.Salario);

        double promedioSalarios = totalSalarios / cantidadEmpleados;
        Console.WriteLine($"Promedio de Salarios: {promedioSalarios}");
    }

    static void CalcularSalarioMasAltoYMasBajo()
    {
        double salarioMasAlto = empleados
            .Where(e => e != null)
            .Max(e => e.Salario);

        double salarioMasBajo = empleados
            .Where(e => e != null)
            .Min(e => e.Salario);

        Console.WriteLine($"Salario más alto: {salarioMasAlto}");
        Console.WriteLine($"Salario más bajo: {salarioMasBajo}");
    }
}

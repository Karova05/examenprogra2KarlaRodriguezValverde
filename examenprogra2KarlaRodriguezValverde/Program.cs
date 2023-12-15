using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenprogra2KarlaRodriguezValverde
{
    class Empleado
{
    public int Cedula { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }

    public double Salario { get; set; }
}

class Menu
{
    private List<Empleado> empleados = new List<Empleado>();

    public void MostrarMenu()
    {
        int opcion = 0;

        while (opcion != 6)
        {
            Console.WriteLine("Programa de Planilla de Recursos Humanos");
            Console.WriteLine("1. Agregar Empleado");
            Console.WriteLine("2. Modificar Empleados");
            Console.WriteLine("3. Consultar Empleado por Cedula");
            Console.WriteLine("4. Borrar Empleados");
            Console.WriteLine("5. Generar Reporte de Salarios");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    AgregarEmpleado();
                    break;
                case 2:
                    ModificarEmpleados();
                    break;
                case 3:
                    ConsultarEmpleadoporCedula();
                    break;
                case 4:
                    BorrarEmpleados();
                    break;
                case 5:
                    GenerarReporteSalarios();
                    break;
                case 6:
                    Console.WriteLine("Cierre del programa");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;

            }
        }
    }

        private double SalarioMasAlto(List<Empleado> empleados)
        {
            if (empleados.Count == 0)
            {
                return 0; // Si no hay empleados, se devuelve 0 como indicador.
            }

            double salarioMaximo = empleados.Max(emp => emp.Salario);
            return salarioMaximo;
        }

        private double SalarioMasBajo(List<Empleado> empleados)
        {
            if (empleados.Count == 0)
            {
                return 0; // Si no hay empleados, se devuelve 0 como indicador.
            }

            double salarioMinimo = empleados.Min(emp => emp.Salario);
            return salarioMinimo;
        }

        private void AgregarEmpleado()
    {
        Empleado nuevoEmpleado = new Empleado();

        Console.Write("Ingrese el nombre del empleado: ");
        nuevoEmpleado.Nombre = Console.ReadLine();

        Console.Write("Ingrese la cedula del empleado: ");
        if (!int.TryParse(Console.ReadLine(), out int cedula))

        {
             Console.WriteLine("La cédula debe ser un número entero.");
             return;
        }
         nuevoEmpleado.Cedula = cedula;


        Console.Write("Ingrese la direccion del empleado: ");
        nuevoEmpleado.Direccion = Console.ReadLine();

        Console.Write("Ingrese el telefono del empleado: ");
        nuevoEmpleado.Telefono = Console.ReadLine();

        Console.Write("Ingrese el salario del empleado: ");
         if (!double.TryParse(Console.ReadLine(), out double salario))
          {
              Console.WriteLine("El salario debe ser un número válido.");
              return;
          }
          nuevoEmpleado.Salario = salario;

            empleados.Add(nuevoEmpleado);
        Console.WriteLine("Empleado agregado con éxito.");
    }

    private void modificarempleados()
    {
        if (empleados.Count == 0)
        {
            Console.WriteLine("No hay empleados registrados.");
            return;
        }

        Console.WriteLine("Listado de Empleados:");
        foreach (Empleado emp in empleados)
        {
            Console.WriteLine($"cedula: {emp.Cedula}, Nombre: {emp.Nombre}, Direccion: {emp.Direccion}, telefono: {emp.Telefono}, Salario: {emp.Salario}");
        }
    }

    private void ConsultarEmpleadoPorcedula()
    {
        Console.Write("Ingrese la cedula del empleado a buscar: ");
        int cedulaBuscado = int.Parse(Console.ReadLine());

        Empleado empleadoEncontrado = empleados.Find(e => e.Cedula == cedulaBuscado);

        if (empleadoEncontrado != null)
        {
            Console.WriteLine($"Empleado encontrado - cedula: {empleadoEncontrado.Cedula}, Nombre: {empleadoEncontrado.Nombre}, direccion: {empleadoEncontrado.direccion}, telefono: {empleadoEncontrado.telefono}, Salario: {empleadoEncontrado.Salario}");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

        private void BorrarEmpleados()
        {
            Console.Write("Ingrese la cedula del empleado a buscar: ");
            int cedulaBorrado = int.Parse(Console.ReadLine());

            Empleado empleadoBorrado = empleados.Remove(e => e.Empleado == empleadoBorrado);

            if (empleadoBorrado != null)
            {
                Console.WriteLine($"Empleado borrado - Cedula: {empleadoBorrado.Cedula}, Nombre: {empleadoBorrado.Nombre}, Direccion: {empleadoBorrado.Direccion}, Telefono: {empleadoBorrado.Telefono}, Salario: {empleadoBorrado.Salario}");
            }
            else
            {
                Console.WriteLine("Empleado borrado.");
            }
        }

        private void GenerarReporteSalarios()
    {
        if (empleados.Count == 0)
        {
            Console.WriteLine("No hay empleados registrados para generar un reporte.");
            return;
        }

        double totalSalarios = 0;
        foreach (Empleado emp in empleados)
        {
            totalSalarios += emp.Salario;
        }

        double promedioSalarios = totalSalarios / empleados.Count;

        Console.WriteLine($"Total de salarios: {totalSalarios}");
        Console.WriteLine($"Promedio de salarios: {promedioSalarios}");

            private void GenerarReporteSalarios()
            {
                if (empleados.Count == 0)
                {
                    Console.WriteLine("No hay empleados registrados para generar un reporte.");
                    return;
                }

                double totalSalarios = 0;
                foreach (Empleado emp in empleados)
                {
                    totalSalarios += emp.Salario;
                }

                double promedioSalarios = totalSalarios / empleados.Count;

                Console.WriteLine($"Total de salarios: {totalSalarios}");
                Console.WriteLine($"Promedio de salarios: {promedioSalarios}");

                // Calcular y mostrar el salario más alto y más bajo
                double salarioMasAlto = SalarioMasAlto(empleados);
                double salarioMasBajo = SalarioMasBajo(empleados);

                Console.WriteLine($"Salario más alto: {salarioMasAlto}");
                Console.WriteLine($"Salario más bajo: {salarioMasBajo}");
            }


        }
}

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.MostrarMenu();
    }
}
}

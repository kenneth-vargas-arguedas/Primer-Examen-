using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exa
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.MostrarMenu();
        }
    }

    // Clase Empleado
    public class Empleado
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public decimal Salario { get; set; }

        public Empleado(string cedula, string nombre, string direccion, string telefono, decimal salario)
        {
            Cedula = cedula;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Salario = salario;
        }
    }

    // Clase Menu
    public class Menu
    {
        private Empleado[] empleados = new Empleado[10]; // 10 empleados
        private int contador = 0; 

        // Mostrar el menú principal
        public void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n--- Menú Principal ---");
                Console.WriteLine("1. Agregar Empleados");
                Console.WriteLine("2. Consultar Empleados");
                Console.WriteLine("3. Modificar Empleados");
                Console.WriteLine("4. Borrar Empleados");
                Console.WriteLine("5. Inicializar Arreglos");
                Console.WriteLine("6. Reportes");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarEmpleado();
                        break;
                    case 2:
                        ConsultarEmpleado();
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
                        MostrarReportes();
                        break;
                }
            } while (opcion != 7);
        }

        // Método para agregar empleados
        public void AgregarEmpleado()
        {
            if (contador >= 10)
            {
                Console.WriteLine("No se pueden agregar más empleados.");
                return;
            }

            Console.Write("Ingrese la cédula: ");
            string cedula = Console.ReadLine();
            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la dirección: ");
            string direccion = Console.ReadLine();
            Console.Write("Ingrese el teléfono: ");
            string telefono = Console.ReadLine();
            Console.Write("Ingrese el salario: ");
            decimal salario = Convert.ToDecimal(Console.ReadLine());

            empleados[contador] = new Empleado(cedula, nombre, direccion, telefono, salario);
            contador++;
            Console.WriteLine("Empleado agregado exitosamente.");
        }

        // Método para consultar empleados
        public void ConsultarEmpleado()
        {
            Console.Write("Ingrese la cédula del empleado: ");
            string cedula = Console.ReadLine();
            var empleado = empleados.FirstOrDefault(e => e != null && e.Cedula == cedula);
            if (empleado != null)
            {
                Console.WriteLine($"Cédula: {empleado.Cedula}, Nombre: {empleado.Nombre}, Dirección: {empleado.Direccion}, Teléfono: {empleado.Telefono}, Salario: {empleado.Salario}");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        // Método para modificar empleados
        public void ModificarEmpleado()
        {
            Console.Write("Ingrese la cédula del empleado a modificar: ");
            string cedula = Console.ReadLine();
            var empleado = empleados.FirstOrDefault(e => e != null && e.Cedula == cedula);

            if (empleado != null)
            {
                Console.Write("Ingrese el nuevo nombre: ");
                empleado.Nombre = Console.ReadLine();
                Console.Write("Ingrese la nueva dirección: ");
                empleado.Direccion = Console.ReadLine();
                Console.Write("Ingrese el nuevo teléfono: ");
                empleado.Telefono = Console.ReadLine();
                Console.Write("Ingrese el nuevo salario: ");
                empleado.Salario = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Empleado modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        // Método para borrar empleados
        public void BorrarEmpleado()
        {
            Console.Write("Ingrese la cédula del empleado a borrar: ");
            string cedula = Console.ReadLine();
            for (int i = 0; i < empleados.Length; i++)
            {
                if (empleados[i] != null && empleados[i].Cedula == cedula)
                {
                    empleados[i] = null;
                    Console.WriteLine("Empleado borrado exitosamente.");
                    return;
                }
            }
            Console.WriteLine("Empleado no encontrado.");
        }

        // Método para inicializar arreglos
        public void InicializarArreglos()
        {
            for (int i = 0; i < empleados.Length; i++)
            {
                empleados[i] = null;
            }
            contador = 0;
            Console.WriteLine("Arreglos inicializados.");
        }

        // Mostrar el menú de reportes
        public void MostrarReportes()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n--- Reportes ---");
                Console.WriteLine("1. Listar empleados ordenados por nombre");
                Console.WriteLine("2. Calcular promedio de salarios");
                Console.WriteLine("3. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ListarEmpleadosPorNombre();
                        break;
                    case 2:
                        CalcularPromedioSalarios();
                        break;
                }
            } while (opcion != 3);
        }

        // Listar empleados ordenados por nombre
        public void ListarEmpleadosPorNombre()
        {
            var empleadosOrdenados = empleados.Where(e => e != null).OrderBy(e => e.Nombre).ToArray();
            foreach (var empleado in empleadosOrdenados)
            {
                Console.WriteLine($"Nombre: {empleado.Nombre}, Cédula: {empleado.Cedula}, Dirección: {empleado.Direccion}, Teléfono: {empleado.Telefono}, Salario: {empleado.Salario}");
            }
        }

        // Calcular el promedio de los salarios
        public void CalcularPromedioSalarios()
        {
            var empleadosConSalario = empleados.Where(e => e != null);
            if (empleadosConSalario.Any())
            {
                decimal promedio = empleadosConSalario.Average(e => e.Salario);
                Console.WriteLine($"El promedio de los salarios es: {promedio}");
            }
            else
            {
                Console.WriteLine("No hay empleados para calcular el promedio.");
            }
        }
    }
}

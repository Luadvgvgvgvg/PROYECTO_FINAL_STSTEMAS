using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaAlertas;
using BibliotecaMonitoreo;

namespace Proyecto_Final_Sistemas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PanelPrincipal();
        }
        static void PanelPrincipal()
        {
            SistemaMonitoreo monitoreo = new SistemaMonitoreo();
            int opcion = 0;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("====================================================");
                Console.WriteLine("     SISTEMA DE MONITOREO CONTRA INCENDIOS");
                Console.WriteLine("====================================================");
                Console.ResetColor();

                Console.WriteLine("Seleccione la zona a monitorear:");
                Console.WriteLine("1. Bloque A");
                Console.WriteLine("2. Bloque B");
                Console.WriteLine("3. Bloque C");
                Console.WriteLine("4. Activar alarma manualmente");
                Console.WriteLine("5. Salir");
                Console.Write("Opción: ");

                int.TryParse(Console.ReadLine(), out opcion);
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        monitoreo.MostrarDatos("Bloque A");
                        break;

                    case 2:
                        monitoreo.MostrarDatos("Bloque B");
                        break;

                    case 3:
                        monitoreo.MostrarDatos("Bloque C");
                        break;

                    case 4:
                        ActivarAlarmaManual(monitoreo);
                        break;

                    case 5:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Saliendo del sistema...");
                        Console.ResetColor();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        Console.ResetColor();
                        break;
                }

                if (opcion != 5)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Presione una tecla para volver al menú...");
                    Console.ResetColor();
                    Console.ReadKey();
                }

            } while (opcion != 5);
        }

        static void ActivarAlarmaManual(SistemaMonitoreo monitoreo)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ALARMA MANUAL ACTIVADA.");
            Console.ResetColor();

            monitoreo.AlertaSonoraCritica();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("¡ALARMA GENERAL ACTIVADA!");
            Console.ResetColor();
        }
    }
}

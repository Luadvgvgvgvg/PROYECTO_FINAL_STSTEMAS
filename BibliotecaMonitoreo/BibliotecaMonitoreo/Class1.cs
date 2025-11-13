using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BibliotecaMonitoreo
{
    public class SistemaMonitoreo
    {
        Random rnd = new Random();

        public int ObtenerTemperatura()
        {
            int temperatura = rnd.Next(15, 81);
            return temperatura;
        }

        public double ObtenerHumo(int temperatura)
        {
            double humo = (temperatura * 1.2) + rnd.Next(-10, 11);

            if (humo < 0)
            {
                humo = 0;
            }

            if (humo > 100)
            {
                humo = 100;
            }

            return Math.Round(humo, 1);
        }

        public string Diagnosticar(int temperatura, double humo)
        {
            if (temperatura < 40 && humo < 30)
            {
                return "Condiciones normales.";
            }
            else if ((temperatura >= 40 && temperatura < 60) || (humo >= 30 && humo < 60))
            {
                return "Advertencia: temperatura o humo elevados.";
            }
            else
            {
                return "PELIGRO: Riesgo de incendio detectado.";
            }
        }

        public void MostrarDatos(string zona)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("MONITOREANDO " + zona + "...");
            Console.ResetColor();
            Console.WriteLine("----------------------------------------------");

            int temperatura = ObtenerTemperatura();
            double humo = ObtenerHumo(temperatura);
            string diagnostico = Diagnosticar(temperatura, humo);

            Console.Write("Temperatura: ");
            if (temperatura >= 60)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (temperatura >= 40)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine(temperatura + " °C");
            Console.ResetColor();

            Console.Write("Nivel de humo: ");
            if (humo >= 60)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (humo >= 30)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine(humo + "%");
            Console.ResetColor();

            Console.WriteLine("----------------------------------------------");

            if (diagnostico.Contains("PELIGRO"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(diagnostico);
                Console.ResetColor();
                AlertaSonoraCritica();
            }
            else if (diagnostico.Contains("Advertencia"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(diagnostico);
                Console.ResetColor();
                AlertaSonoraAdvertencia();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(diagnostico);
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.WriteLine("Presione una tecla para volver al menú...");
            Console.ReadKey();
        }

        public void AlertaSonoraAdvertencia()
        {
            for (int i = 0; i < 2; i++)
            {
                Console.Beep(700, 250);
                Thread.Sleep(120);
            }
        }

        public void AlertaSonoraCritica()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Beep(1000, 300);
                Thread.Sleep(150);
                Console.Beep(800, 300);
                Thread.Sleep(150);
            }
        }
    }
}
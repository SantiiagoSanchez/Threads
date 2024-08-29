using System;
using System.ComponentModel;
using System.Threading;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            CuentaBancaria CuentaFamiliar = new CuentaBancaria(10000);

            Thread[] Personas = new Thread[6];

            for (int i = 0; i < 6; i++) 
            {
                Thread T = new Thread(CuentaFamiliar.RetirarDineroThread);

                T.Name = i.ToString();

                Personas[i] = T;
            }
            for (int i = 0; i < 6; i++)
            {
                Personas[i].Start(); Personas[i].Join();
            }    
        }
    }

    class CuentaBancaria 
    {
        double Sueldo {  get; set; }

        public CuentaBancaria (double Sueldo) 
        {
            this.Sueldo = Sueldo;
        }

        public double RetirarDinero(double DineroRetirado) 
        {
            if (Sueldo - DineroRetirado < 0) 
            {
                Console.WriteLine("Disculpe, no puede retirar {0} pesos porque en la cuenta del banco hay {1} pesos", DineroRetirado, Sueldo);
                return Sueldo;
            }
            if (Sueldo > DineroRetirado) 
            {
                Console.WriteLine("Se ha retirado {0} pesos, quedan {1} pesos en la cuenta", DineroRetirado, (Sueldo - DineroRetirado));
                Sueldo = Sueldo - DineroRetirado;
            }

            return Sueldo;
        }

        public void RetirarDineroThread() 
        {
            Console.WriteLine("Esta sacando dinero el THREAD : {0}", Thread.CurrentThread.Name);
            for (int i = 0; i < 3; i++) 
            {
                RetirarDinero(900);
            }

        }
    }

}


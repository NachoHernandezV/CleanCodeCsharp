using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> ListaDeTareas { get; set; }
        const int add=1;
        const int delete=2;
        const int pending=3;

        static void Main(string[] args)
        {
            ListaDeTareas = new List<string>();
            int OpcionSeleccionada = 0;
            do
            {
                OpcionSeleccionada = ShowMainMenu();
                if (OpcionSeleccionada == add)
                {
                    ShowMenuAdd();
                }
                else if (OpcionSeleccionada == delete)
                {
                    ShowMenuDelete();
                }
                else if (OpcionSeleccionada == pending)
                {
                    ShowMenuPending();
                }
            } while (OpcionSeleccionada != 4);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string line = Console.ReadLine();
            return Convert.ToInt32(line);
        }

        public static void ShowMenuDelete()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
               ShowTasks(); 

                string line = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(line) - 1;
                if (indexToRemove > -1)
                {
                    if (ListaDeTareas.Count > 0)
                    {
                        string task = ListaDeTareas[indexToRemove];
                        ListaDeTareas.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + task + " eliminada");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                ListaDeTareas.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuPending()
        {
            if (ListaDeTareas == null || ListaDeTareas.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
               ShowTasks(); 
            }
        }
         public static void ShowTasks() 
            {
                 Console.WriteLine("----------------------------------------");
                for (int i = 0; i < ListaDeTareas.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + ListaDeTareas[i]);
                }
                Console.WriteLine("----------------------------------------");
            }
    }
}

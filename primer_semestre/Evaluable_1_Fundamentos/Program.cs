using System;
using System.Threading;

/*
-------------------------------------------------------------
AUTOR: Adrian Thoenig
ASIGNATURA: Fundamentos de Programación
ACTIVIDAD: Actividad Evaluable - Primer Trimestre
FECHA DE ENTREGA: 30 de noviembre
PROFESOR: Borja Martin Herrera
-------------------------------------------------------------
*/

namespace Evaluable
{
    class Calculadora
    {
        // Método Main
        static void Main(string[] args)
        {
            // Limpiar consola inicial
            Console.Clear();

            // Mensaje de Bienvenida
            ImprimirTitulo("Bienvenido a la calculadora");

            /********* INICIO DEL PROGRAMA *********/
            // Pedir y almacenar operandos
            int primerNum = ValidarOperando("Primer"); // Pide y almacena el primer número
            int segundoNum = ValidarOperando("Segundo"); // Pide y almacena el segundo número

            /*********** MENU ******************/
            // Mostrar menu de opciones
            bool salirMenu = false;

            // Menu Iterativo
            while (!salirMenu)
            {
                // Validar opción
                bool opcionValidada = false;

                // Almacenar opción
                int opcion;

                do
                {
                    // Mostrar opciones
                    SaltoLinea();
                    Console.WriteLine("Por favor, selecciona una opción:");
                    Console.WriteLine("1 - Sumar [ + ]");
                    Console.WriteLine("2 - Resta [ - ]");
                    Console.WriteLine("3 - Multiplicación [ * ]");
                    Console.WriteLine("4 - División [ / ]");
                    Console.WriteLine("5 - Salir");

                    // Registrar opción
                    Console.Write("Introduce tu opción: ");
                    string entrada = Console.ReadLine();
                    opcionValidada = int.TryParse(entrada, out opcion);

                    // Mensaje de error si no existe la opción
                    if (!opcionValidada || opcion < 1 || opcion > 5)
                    {
                        MensajeError("La opción que has elegido no existe, por favor introduce una del menú");
                        opcionValidada = false; // Forzar la repetición del bucle
                    }

                } while (!opcionValidada);

                // Todo OK! A realizar operaciones
                int resultado = 0;
                string operacionTexto = "";
                string simbolo = "";

                switch (opcion)
                {
                    case 1:
                        // [ + ] SUMA
                        resultado = primerNum + segundoNum;
                        operacionTexto = "suma";
                        simbolo = "+";
                        break;
                    case 2:
                        // [ - ] RESTA
                        resultado = primerNum - segundoNum;
                        operacionTexto = "resta";
                        simbolo = "-";
                        break;
                    case 3:
                        // [ * ] MULTIPLICACIÓN
                        resultado = primerNum * segundoNum;
                        operacionTexto = "multiplicación";
                        simbolo = "*";
                        break;
                    case 4:
                        // [ / ] DIVISIÓN
                        if(segundoNum != 0)
                        {
                            // Evitar error de división por 0 (no existe)
                            resultado = primerNum / segundoNum;
                        } else
                        {
                            // ERROR! No se puede dividir por 0
                            MensajeError("No se puede dividir por 0");
                            continue; // volver al menú sin mostrar el resultado
                        }
                        operacionTexto = "división";
                        simbolo = "/";
                        break;
                    case 5:
                        // SALIR DEL MENU
                        salirMenu = true; // esto rompera el bucle
                        Console.WriteLine("Cerrando calculadora..."); // Mensaje de cierre
                        Console.WriteLine("[ X ] Pulsa cualquier tecla para salir"); // Avisar de pulsar tecla
                        break;
                    default:
                        // Esto no debería pasar
                        MensajeError("Debes seleccionar una opción del menú");
                        break;
                }

                // Mostrar resultado de la operación (si la opción no es salir)
                if(!salirMenu)
                {
                    Separador(30);
                    Console.WriteLine($"La {operacionTexto} de {primerNum} {simbolo} {segundoNum} es {resultado}");

                    // Dormir programa 3 segundos antes de volver a imprimir el menu
                    Thread.Sleep(3000);
                }

            }

            // Leer tecla para finalizar programa
            Console.ReadKey();

            // Mensaje de despedida
            Console.WriteLine("[ - ] Adios! Espero que vuelvas pronto!");
        }


        /*** MÉTODOS ADICIONALES ****/
        // SaltoLinea() -> realiza un salto de línea (más legible)
        static void SaltoLinea()
        {
            Console.WriteLine();
        }

        // ImprimirTitulo(string titulo) -> imprime un título
        static void ImprimirTitulo(string titulo)
        {
            Console.WriteLine($"|| {titulo} ||");
        }

        // MensajeError(string mensaje) -> mostrar un mensaje de error
        static void MensajeError(string mensaje)
        {
            SaltoLinea();
            Console.WriteLine($"¡Error! {mensaje}");
            SaltoLinea();
        }

        // Separador(int numLineas) -> muestra un separador clásico con un número de líneas
        static void Separador(int numLineas)
        {
            for (int i = 0; i < numLineas; i++)
            {
                Console.Write("-");
            }

            // Hacer un salto de línea
            SaltoLinea();
        }

        // Pedir y validar operando
        static int ValidarOperando(string numeroTexto)
        {
            // Variable booleana para validar el número
            bool tipoValidado = false;
            bool positivo = false;

            // Variable a devolver
            int variableSalida;

            // Bucle de validación
            do
            {
                // Pedir al usuario el operando
                Console.Write($"Introduce el {numeroTexto.ToLower()} número (entero positivo): ");
                string entrada = Console.ReadLine();
                tipoValidado = int.TryParse(entrada, out variableSalida);
                SaltoLinea();

                // Mensaje de error: si no ha introducido un tipo int
                if (!tipoValidado)
                {
                    MensajeError("Debes introducir un número entero");
                }

                // Validar que sea de 0 en adelante
                positivo = variableSalida >= 0; // Almacenar true/false

                // Mensaje de error si no es positivo
                if(!positivo)
                {
                    MensajeError("Debes introducir un número POSITIVO (0 en adelante)");
                }

                // Si se ha tipoValidado
                if (tipoValidado && positivo)
                {
                    Console.WriteLine("[ O ] Has elegido el número: " + variableSalida);
                }
            } while (!tipoValidado || !positivo); // Se repite si cualquiera es true

            // Devolver la variable
            return variableSalida;
        }
    }
}
namespace EvaluableFundamentos2
{

        /*
        -------------------------------------------------------------
        AUTOR: Adrian Thoenig
        ASIGNATURA: Fundamentos de Programación
        ACTIVIDAD: Actividad Evaluable - Segundo Trimestre
        FECHA DE ENTREGA: 30 de Enero
        PROFESOR: Borja Martin Herrera
        -------------------------------------------------------------
        */
    internal class Programa
    {
        public static void Main(string[] args)
        {
            // Limpiar consola
            Console.Clear();

            // Diccionario para usuarios (key: email, value: contraseña)
            Dictionary<string, string> usuarios = new Dictionary<string, string>();

            // [ DEBUG ] dummy data
            usuarios.Add("adrian@gmail.com", "123");

            // Variables globales
            bool autenticado = false;
            int op; // donde se guardaran las opciones elegidas por el usuario

            // Bucle de acceso -> hasta que el usuario se logee o cree una cuenta
            while(!autenticado)
            {
                // Mostrar menú de acceso
                acceso();

                // Validar el input del usuario
                while(!int.TryParse(Console.ReadLine(), out op) || (op < 1 || op > 2))
                {
                    // El usuario no ha introducido un número
                    mensajeError("No has introducido un número");
                    Console.Write("Introduce un número correcto: ");
                }

                // Gestionar la opción
                switch(op)
                {
                    // INICIAR SESIÓN
                    case 1:
                        autenticado = login(usuarios);

                        // Acceder a las opciones (una vez iniciado sesión)
                        if(autenticado)
                        {
                            mostrarMenuLogeado();
                        }
                        teclaContinuar();
                        break;
                    
                    // REGISTRARSE
                    case 2:
                        signup(usuarios);
                        teclaContinuar();
                        break;
                    
                    // OPCIÓN INVALIDA
                    default:
                        mensajeError("Esta opción no existe, intentalo de nuevo...");
                        teclaContinuar();
                        break;
                }
            }

        }

        /*** MÉTODOS PARA EL MENÚ ***/
        
        // acceso -> pregunta al usuario si se quiere logear o registrar
        public static void acceso()
        {
            Console.Clear();
            Console.WriteLine("|| Bienvenido a la app de GYM ||");
            Console.WriteLine("1. Iniciar sesión (ya tengo cuenta)");
            Console.WriteLine("2. Registrarse (crear una nueva cuenta)");

            // Pedir al usuario que introduzca una opción
            saltoLinea();
            Console.Write("Introduce una opción: ");
        }

        // login -> realiza un inicio de sesión
        public static bool login(Dictionary<string, string> dict)
        {
            // Variable de intentos de inicio de sesión
            int intentos = 3;

            Console.Clear();
            imprimirTitulo("Iniciar sesión");

            // Pedir correo
            Console.Write("Introduce tu correo: ");
                
            // Validar correo
            string correo = Console.ReadLine().ToLower(); // el correo lo guardamos en minúsculas para hacer el match siempre
            while((correo == null || correo.Equals("")) || !dict.ContainsKey(correo))
            {

                if(correo == null || correo.Equals(""))
                {
                    mensajeError("El correo no puede estar vacío!");
                }

                if(!dict.ContainsKey(correo))
                {
                    mensajeError("Ese correo no esta registrado!");
                }

                Console.Write("Introduce un correo valido: ");
                correo = Console.ReadLine().ToLower();
            }


            // Pedir datos del usuario
            while(intentos > 0)
            {
                Console.Clear();
                imprimirTitulo("Iniciar sesión");
                Console.WriteLine("Te quedan: " + intentos + " intentos");

                // Pedir contraseña
                Console.Write("Introduce tu contraseña: ");

                // Validar contraseña
                string pass = Console.ReadLine();
                while(pass == null || pass.Equals(""))
                {
                    mensajeError("La contraseña no puede estar vacía!");
                    Console.Write("Introduce una contraseña valida: ");
                    pass = Console.ReadLine();
                }

                // Comprobar que la cuenta exista
                if(dict.ContainsKey(correo))
                {
                    if(dict[correo] == pass)
                    {
                        saltoLinea();
                        Console.WriteLine("[ + ] Se ha iniciado sesión correctamente");
                        return true;
                    } else
                    {
                        intentos--; // restar un intento
                        mensajeError("Contraseña invalida, intentalo de nuevo!");
                        teclaContinuar();
                    }
                }
            }

            // Mensaje de final de método
            saltoLinea();
            Console.WriteLine("[ ! ] Has excedido el número de inicio de sesiones posibles...");
            Console.WriteLine("Intentalo de nuevo más tarde");

            return false; // termina el método
        }

        // signup -> registra nuevos usuarios
        public static void signup(Dictionary<string, string> dict)
        {
            // Vaciar consola e imprimir titulo
            Console.Clear();
            imprimirTitulo("Registro");

            // Pedir correo
            Console.Write("Introduce tu correo: ");
            string correo = Console.ReadLine().ToLower();

            // Verificar que no este vacío
            while(correo == null || correo.Equals(""))
            {
                mensajeError("El correo no puede estar vacío!");
                Console.Write("Introduce un correo valido: ");
                correo = Console.ReadLine().ToLower();
            }

            // Comprobar que el correo no este en la lista
            while(dict.ContainsKey(correo))
            {
                mensajeError("Este correo ya está registrado");
                Console.Write("Introduce un nuevo correo: ");
                correo = Console.ReadLine().ToLower();

                // Volver a validar el correo
                while(correo == null || correo.Equals(""))
                {
                    saltoLinea();
                    mensajeError("El correo no puede estar vacío");
                    Console.Write("Introduce un correo valido: ");
                    correo = Console.ReadLine().ToLower();
                }
            }

            // Pedir al usuario la contraseña
            Console.Clear();
            imprimirTitulo("Registro");
            Console.WriteLine("Estas a solo un paso " + correo);
            saltoLinea();
            
            Console.Write("Introduce tu contraseña: ");
            string pass = Console.ReadLine();

            // Validar contraseña
            while(pass == null || pass.Equals("") || pass.Count() <= 6)
            {
                bool skip = false;

                if(pass == null || pass.Equals(""))
                {
                    mensajeError("La contraseña no puede estar vacía!");
                    skip = true;
                }

                if(pass.Count() <= 6 && !skip)
                {
                    mensajeError("La contraseña debe de tener por lo menos 6 caracteres");
                }

                Console.Write("Introduce tu contraseña de nuevo: ");
                pass = Console.ReadLine();

            }

            // Todo OK! Registrar usuario
            if(dict.TryAdd(correo, pass))
            {
                // Usuario registrado correctamente
                Console.WriteLine("[ + ] Te has registrado correctamente!");
            } else
            {
                // Ha habido un error
                mensajeError("Ha habido un error... intentalo de nuevo más tarde");
            }
        }

        // mostrarMenuLogeado -> muestra el menú principal una vez el usuario se ha logeado (para tener el código más limpio)
        public static void mostrarMenuLogeado()
        {
            // Variables
            int logOp;

            // Lista de entrenos (se emparejan/sincronizan por indices)
            List<string> nombreEntreno = new List<string>();
            List<double> distanciaRecorrida = new List<double>();
            List<double> tiempoEmpleado = new List<double>();

            do
            {
                Console.Clear();
                Console.WriteLine("|| MENÚ PRINCIPAL ||");
                Console.WriteLine("1. Registrar un entrenamiento");
                Console.WriteLine("2. Listar entrenamiento");
                Console.WriteLine("3. Vaciar entrenamientos");
                Console.WriteLine("4. Cerrar sesión");

                // Pedir al usuario que introduzca una opción
                saltoLinea();
                Console.Write("Introduce una opción: ");

                // Validar que sea un número
                while(!int.TryParse(Console.ReadLine(), out logOp))
                {
                    saltoLinea();
                    mensajeError("Eso no es un número!");
                    Console.Write("Introduce un número correcto: ");
                }

                // Gestionar operación
                switch(logOp)
                {
                    // REGISTRAR ENTRENAMIENTO
                    case 1:
                        registrarEntreno(nombreEntreno, distanciaRecorrida, tiempoEmpleado);
                        teclaContinuar();
                        break;
                    
                    // LISTAR ENTRENAMIENTOS
                    case 2:
                        listarEntrenos(nombreEntreno, distanciaRecorrida, tiempoEmpleado);
                        teclaContinuar();
                        break;
                    
                    // VACIAR ENTRENAMIENTOS
                    case 3:
                        vaciarEntrenamientos(nombreEntreno, distanciaRecorrida, tiempoEmpleado);
                        teclaContinuar();
                        break;
                    
                    // CERRAR SESIÓN
                    case 4:
                        Console.WriteLine("[ - ] Sesión cerrada, hasta pronto!");
                        break;
                    
                    // OPCIÓN INVALIDA
                    default:
                        mensajeError("Opción no valida! Intentalo de nuevo");
                        break;
                }
            } while(logOp != 4);
        }

        /*** MÉTODOS DE UTILIDADES ***/

        // registrarEntreno -> registra un nuevo entreno
        public static void registrarEntreno(List<string> nombreList, List<double> distanciaList, List<double> tiempoList)
        {
            // Vaciar consola e imprimir titulo
            Console.Clear();
            imprimirTitulo("Registrar un entreno");
            saltoLinea();

            // Pedir el nombre del entreno
            Console.Write("Introduce el nombre del entreno: ");
            string nombreEntreno = Console.ReadLine();

            // Validar nombre de entreno
            while(nombreEntreno == null || nombreEntreno.Equals("") || nombreEntreno.Count() > 40)
            {
                if(nombreEntreno == null || nombreEntreno.Equals(""))
                {
                    mensajeError("El nombre del entreno no puede estar vacío!");
                }

                if(nombreEntreno.Count() > 40)
                {
                    mensajeError("Elige un nombre de entreno más corto!");
                }

                Console.Write("Introduce el nombre del entreno: ");
                nombreEntreno = Console.ReadLine();
            }

            // Vaciar consola e imprimir titulo
            Console.Clear();
            imprimirTitulo("Registrar un entreno");
            saltoLinea();

            // Pedir la distancia recorrida
            Console.Write("Introduce la distancia recorrida (en metros): ");

            // Validar que sea un número
            double distanciaRecorrida;
            while(!double.TryParse(Console.ReadLine(), out distanciaRecorrida) || distanciaRecorrida < 0)
            {
                // Distancia no valida
                saltoLinea();
                mensajeError("Distancia no valida");
                Console.Write("Introduce un número correcto (en metros): ");
            }

            // Pedir el tiempo (en minutos)
            Console.Clear();
            imprimirTitulo("Registrar un entreno");
            Console.WriteLine("Distancia recorrida: " + distanciaRecorrida + " metros");
            saltoLinea();
            
            Console.Write("Introduce el tiempo empleado (en minutos): ");

            // Validar que sea un número
            double tiempoEmpleado;
            while(!double.TryParse(Console.ReadLine(), out tiempoEmpleado) || tiempoEmpleado < 0)
            {
                // Tiempo NO valido
                saltoLinea();
                mensajeError("Tiempo no valido");
                Console.Write("Introduce un tiempo correcto (en minutos): ");
            }

            // Confirmar todo
            Console.Clear();
            imprimirTitulo("Registrar un entreno");
            Console.WriteLine("Nombre del entreno: " + nombreEntreno);
            Console.WriteLine("Distancia recorrida: " + distanciaRecorrida + " metros");
            Console.WriteLine("Tiempo empleado: " + tiempoEmpleado + " minutos");
            saltoLinea();

            // Confirmar acción
            Console.Write("¿Deseas guardar este entreno? (SI): ");
            string decision = Console.ReadLine().ToUpper();

            if(decision.Equals("SI"))
            {
                // Registrar entreno
                nombreList.Add(nombreEntreno);
                distanciaList.Add(distanciaRecorrida);
                tiempoList.Add(tiempoEmpleado);

                // Mensaje de success
                Console.WriteLine("[ + ] Se ha registrado el entreno correctamente");

                saltoLinea();
            } else
            {
                Console.WriteLine("[ - ] Cancelando operación...");
            }

        }

        // listarEntrenos -> lista todos los entrenos
        public static void listarEntrenos(List<string> nombreList, List<double> distanciaList, List<double> tiempoList)
        {
            // Vaciar consola e imprimir titulo
            Console.Clear();
            imprimirTitulo("Lista de entrenos");
            saltoLinea();

            // Comprobar que la lista NO este vacía
            if(nombreList.Count() != 0)
            {
                // Listar todos los entrenos
                int counter = 1;
                Console.WriteLine("------------------------------");
                for(int i = 0; i < nombreList.Count(); i++)
                {
                    Console.WriteLine($"{counter}. {nombreList[i]}");
                    Console.WriteLine("--> Distancia recorrida: " + distanciaList[i] + " metros");
                    Console.WriteLine("--> Tiempo empleado: " + tiempoList[i] + " minutos");
                    Console.WriteLine("------------------------------");

                    // Incrementar contador de indices
                    counter++;
                }
            }  else
            {
                // La lista esta vacía
                Console.WriteLine("Tu lista de entrenos esta vacía!");
                Console.Write("¿Deseas añadir uno? (SI): ");
                string decision = Console.ReadLine().ToUpper();

                // Gestionar decision
                if(decision.Equals("SI"))
                {
                    // Registrar entreno
                    registrarEntreno(nombreList, distanciaList, tiempoList);
                } else
                {
                    // Cancelar operación
                    Console.WriteLine("[ - ] Cancelando operación...");
                }
            }
        }

        // vaciarEntrenamientos --> vacia las listas de entrenamientos sincronizadas
        public static void vaciarEntrenamientos(List<string> nombreList, List<double> distanciaList, List<double> tiempoList)
        {
            // Vaciar consola e imprimir titulo de opción
            Console.Clear();
            imprimirTitulo("Vaciar lista de entrenamientos");
            saltoLinea();

            // Confirmación del usuario
            Console.WriteLine("[ ! ] ATENCIÓN: Una vez vacíada la lista, no podras recuperrar tus entrenos");
            Console.WriteLine("Actualmente cuentas con " + nombreList.Count() + " entrenos guardados");
            Console.Write("¿Estas seguro de que quieres vaciar todo? (SI): ");

            string decision = Console.ReadLine().ToUpper();
            if(decision.Equals("SI"))
            {
                // Vaciar la lista
                nombreList.Clear();
                distanciaList.Clear();
                tiempoList.Clear();

                Console.WriteLine("[ 0 ] Se ha vacíado tu lista de entrenos!");
            } else
            {
                // Cancelar operación
                Console.WriteLine("[ - ] Cancelando operación...");
            }
        }

        // imprimirTitulo -> imprime el titulo de la opción elegida
        public static void imprimirTitulo(string titulo)
        {
            Console.WriteLine("|| " + titulo.ToUpper());
        }

        // saltoLinea -> realiza un salto de linea
        public static void saltoLinea()
        {
            Console.WriteLine();
        }

        // teclaContinuar -> pide al usuario que introduzca una tecla para continuar
        public static void teclaContinuar()
        {
            saltoLinea();
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // mensajeError -> muestra un mensaje de error
        public static void mensajeError(string mensaje)
        {
            Console.WriteLine("ERROR!: " + mensaje);
        }
    }
}
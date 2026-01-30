package evaluable;

import java.util.Scanner;

public class AmigoInvisible {
	
	/*
	 * Autor: Adrian Thoenig
	 * Curso: 1º DAW
	 * Profesor: Borja Martin Herrera
	 * Módulo: Programación
	 * Fecha: 3/11/2025
	 * Actividad: Amigo Invisible
	 */

	
	public static void main(String[] args) {
		// Crear Scanner
		Scanner entrada = new Scanner(System.in);
		
		// Almacenar número de amigos que juegan
		System.out.println("¿Cuántos amigos entran en el juego?");
		int numAmigos = entrada.nextInt();
		
		// Verificar que mínimo se hayan puesto 2 amigos
		while(numAmigos < 2) {
			if(numAmigos < 2) {
				System.out.println("[ ! ] Mínimo tienen que haber 2 amigos: ");
			}
			
			// Registrar otra vez el número de amigos
			numAmigos = entrada.nextInt();
		}
		
		// Limpiar buffer
		entrada.nextLine();
		
		// Crear Array de amigos (Almacenar nombres)
		String[] amigos = almacenarAmigos(numAmigos, entrada);
		
		// Creando parejas aleatorias
		String[] parejas;
		
		// Verificar + Mezclar parejas (en caso de no aleatoriedad)
		do {
			parejas = mezclar(amigos);
		} while(!verificarParejas(amigos, parejas));
		
		// Imprimir amigo -> pareja
		imprimirParejas(amigos, parejas);
		
		// Cerrando Scanner (buena práctica)
		entrada.close();
		
		// Mensaje final
		System.out.println(("-").repeat(30));
		System.out.println("Gracias por jugar al Amigo Invisible.");
	}
	
	// Método adicional: Almacenar amigos
	public static String[] almacenarAmigos(int numAmigos, Scanner scannerGlobal) {
		// Creando un array
		String[] amigos = new String[numAmigos];
		
		// Evitar amigos repetidos
		boolean repetido;
		
		// Recorrer Array
		for(int i = 0; i < amigos.length; i++) {
			// Bucle interno: Para validar nombres
			do {
				repetido = false; // Para que no se repitan nombres
				
				// Pedir nombre del amigo N
				System.out.println("Introduce el nombre del amigo " + (i + 1) + ":");
				amigos[i] = scannerGlobal.nextLine();
				
				// Si el amigo del indice actual esta vacío
				if(amigos[i].isEmpty()) {
					System.out.println("[ ! ] El nombre no puede estar vacío");
				} else {
					// Comprobar nombre duplicado
					for(int j = 0; j < i; j++) {
						if(amigos[i].equalsIgnoreCase(amigos[j])) {
							System.out.println("[ ! ] Este nombre ya está en la lista!");
							repetido = true; // Marcar repetido como true (esta repetido)
							break; // Romper el bucle
						}
					}
				}
			} while(amigos[i].isEmpty() || repetido);
		}
		
		// Devolver array de amigos
		return amigos;
	}
	
	// Método adicional: Para ordenar parejas de forma aleatoria
	public static String[] mezclar(String[] arrOriginal) {
	
		// Creando una copia (para no tocar el original)
		String[] copia = arrOriginal.clone();
		
		// Recorrer copia de forma reversiva
		for(int i = copia.length - 1; i > 0; i--) {
			// Crear un indice aleatorio dentro del rango
			int indexRandom = (int) (Math.floor(Math.random() * (i + 1)));
			
			// Almacenando en una variable temporal el amigo actual de la iteración
			String temporal = copia[i];	
			
			// Asignando al array copia un amigo con indice aleatorio
			copia[i] = copia[indexRandom];
			
			// Asignando al indice copia en el indice aleatorio el valor original de la iteración
			copia[indexRandom] = temporal;
		}
		
		// Devolver el array copia
		return copia;
	}
	
	// Método adicional: Verificar Parejas
	public static boolean verificarParejas(String[] amigos, String[] parejas) {
		
		// Recorrer ambos arrays
		for(int i = 0; i < amigos.length; i++) {
			// Si coinciden en ambos indices -> devolver false
			if(amigos[i].equals(parejas[i])) return false;
		}
		
		// Todo bien
		return true;
	}
	
	// Método adicional: Imprimir parejas
	public static void imprimirParejas(String[] amigos, String[] parejas) {
		// Imprimir mensaje de parejas obtenidas
		System.out.println("\nLas parejas obtenidas son:");
		
		// Bucle para ir imprimiendo las parejas
		for(int i = 0; i < amigos.length; i++) {
			// Imprimir pareja
			System.out.println(amigos[i] + " -> " + parejas[i]);
		}
	}

}

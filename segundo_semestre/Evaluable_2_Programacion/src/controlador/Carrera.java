package controlador;

import modelo.Coche;
import java.util.Scanner;

public class Carrera {
	
	/*** ATRIBUTOS ***/
	private Coche cocheUno;
	private Coche cocheDos;
	private Coche ganador;
	private double kmTotales;
	private int vueltasCircuito;
	
	/*** CONSTRUCTORES ***/
	// constructor vacio
	public Carrera() {
		
	}
	
	// constructor full-args
	public Carrera(Coche cocheUno, Coche cocheDos, double kmTotales, int vueltasCircuito) {
		this.cocheUno = cocheUno;
		this.cocheDos = cocheDos;
		this.ganador = null;
		this.kmTotales = kmTotales;
		this.vueltasCircuito = vueltasCircuito;
	}
	
	/*** MÉTODOS ***/
	
	// iniciar carrera
	public void iniciarCarrera() {
		
		// Imprimir datos del coche uno
		System.out.println("|| DATOS COCHE UNO ||");
		cocheUno.mostrarDatos();
		System.out.println(); // salto de linea
		
		// Imprimir datos del coche dos
		System.out.println("|| DATOS COCHE DOS ||");
		cocheDos.mostrarDatos();
		System.out.println();
		
		// Realizar las vueltas sobre el circuito
		Scanner scan = new Scanner(System.in);
		boolean vueltasCompletadas = false;
		int vueltaActual = 1;
		int numCocheGanador = 0;
		while(!vueltasCompletadas) {
			for(int i = 0; i < vueltasCircuito; i++) {
				// Imprimir la vuelta actual
				System.out.println(); // salto de linea
				System.out.println("||-- Vuelta número: " + vueltaActual);
				
				// Acelerar coches
				System.out.println("|| Acelerar coche uno:");
				cocheUno.acelerar(scan);
				System.out.println();
				
				System.out.println("|| Acelerar coche dos:");
				cocheDos.acelerar(scan);
				
				// Comprobar si el coche uno ha ganado
				if(cocheUno.getKmRecorridos() >= kmTotales) {
					ganador = cocheUno;
					vueltasCompletadas = true;
					numCocheGanador = 1;
					break;
				}
				
				// Comprobar si el coche dos ha ganado
				if(cocheDos.getKmRecorridos() >= kmTotales) {
					ganador = cocheDos;
					vueltasCompletadas = true;
					numCocheGanador = 2;
					break; // finalizar carrera
				}
				
				// Incrementar vuelta actual
				vueltaActual++;
			}			
		}
		
		// Cerrar scanner
		scan.close(); // buena práctica
		
		// Imprimir ganador
		System.out.println();
		System.out.println(("-").repeat(70));
		System.out.println();
		if(ganador != null) {
			System.out.println("[ X ] El ganador es el coche con la matricula: " + ganador.getMatricula() + " ( coche " + numCocheGanador + " )");
		} else {
			System.out.println("[ O ] La carrera ha finalizado sin ganador!");
		}
		System.out.println();
		System.out.println(("-").repeat(70));
		System.out.println();
	}

}

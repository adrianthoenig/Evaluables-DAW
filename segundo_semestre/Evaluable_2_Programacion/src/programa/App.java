package programa;

import modelo.Coche;
import controlador.Carrera;
import java.util.Scanner;

public class App {
	
    /*
    -------------------------------------------------------------
    AUTOR: Adrian Thoenig
    ASIGNATURA: Programación
    ACTIVIDAD: Actividad Evaluable - Segundo Trimestre
    FECHA DE ENTREGA: 31 de Enero
    PROFESOR: Borja Martin Herrera
    -------------------------------------------------------------
    */
	
	public static void main(String[] args) {
		// Creando coches
		Coche cocheUno = new Coche(
			"Toyota", // marca
			"Corolla", // modelo
			95, // cv
			1600, // cc
			"1234-ABC" // matricula
		);
		
		Coche cocheDos = new Coche(
			"Ford", // marca
			"Mustang", // modelo
			150, // cv
			5000, // cc
			"5678-XYZ" // matricula,
		);
		
		// Creando la carrera
		Carrera grandPrix = new Carrera(cocheDos, cocheDos, 100, 5);
		
		// Iniciar la carrera
		grandPrix.iniciarCarrera();
	}

}

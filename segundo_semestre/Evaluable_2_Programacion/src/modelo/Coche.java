package modelo;

import java.util.Scanner;
import programa.Utilidades;

public class Coche {
	
	/**** ATRIBUTOS ***/
	private String marca; // marca del coche
	private String modelo; // modelo del coche
	private int cv; // caballos de vapor
	private int cc; // centimetros cubicos del motor
	private String matricula; // matricula del coche
	private double velocidad; // velocidad a la que va
	private double kmRecorridos; // km que ha recorrido el coche
	
	/*** CONSTRUCTORES ***/
	
	// constructor vacío
	public Coche() {
		
	}
	
	// constructor solo con marca y modelo
	public Coche(String marca, String modelo) {
		this.marca = marca;
		this.modelo = modelo;
	}
	
	// constructor parra carrera
	public Coche(String marca, String modelo, int cv, int cc, String matricula) {
		this(marca, modelo);
		this.cv = cv;
		this.cc = cc;
		this.matricula = matricula;
		this.velocidad = 0;
		this.kmRecorridos = 0;
	}
	
	// constructor full-args
	public Coche(String marca, String modelo, int cv, int cc, String matricula, double velocidad, double kmRecorridos) {
		this(marca, modelo, cv, cc, matricula);
		this.velocidad = velocidad;
		this.kmRecorridos = kmRecorridos;
	}
	
	/*** MÉTODOS ***/
	
	// acelerar
	public void acelerar(Scanner scan) {
		System.out.print("¿Cuanto quieres acelerar? (en km/h): ");
		
		// Validar input
		while(!scan.hasNextDouble()) {
			System.out.println("Error! La velocidad debe ser un número");
			System.out.print("Introduce la velocidad a acelerar (en km/h): ");
			scan.next();
		}
		
		// Almacenar velocidad a acelerar
		double velocidadAcelerar = scan.nextDouble();
		scan.nextLine(); // limpiar buffer
		
		double velocidadAleatoria = 0;
		double incremento = 0;
		
		// Elegir incremento de velocidad para el coche
		if(cv < 100) {
			// Acelera una velocidad aleatoria entre 0 y la velocidad indicada
			incremento = Math.random() * velocidadAcelerar;
		} else {
			// Acelera una velocidad entre 10 y la velocidad indicada
			incremento = Math.random() * (velocidadAcelerar - 10) + 10;
			
		}
		
		// Forzar mínimo de 10km/h si es menor
		if(incremento < 10) {
			incremento = 10;
		}
		
		velocidad += incremento;
		kmRecorridos += incremento * 0.5;
		
		System.out.println("[ ++ ] Se ha acelerado el coche en " + String.format("%.2f", incremento) + "km/h");
		System.out.println("Velocidad actual: " + String.format("%.2f", velocidad) + "km/h");
		System.out.println("Km recorridos actuales: " + String.format("%.2f", kmRecorridos));
		
		
	}
	
	// mostrarDatos
	public void mostrarDatos() {
		System.out.println("Marca: " + ((marca != null) ? marca : "ninguna"));
		System.out.println("Modelo: " + ((modelo != null) ? modelo : "ninguno"));
		System.out.println("CV: " + cv);
		System.out.println("CC: " + cc);
		System.out.println("Matricula: " + ((matricula != null) ? matricula : "ninguna"));
		System.out.println("Velocidad: " + velocidad + "km/h");
		System.out.println("Km recorridos: " + kmRecorridos + "km");
	}
		
		
	
	/*** GETTERS Y SETTERS ***/
	
	// marca : getter
	public String getMarca() {
		return marca;
	}
	
	// marca : setter
	public void setMarca(String marca) {
		if(marca != null && !marca.trim().equals("")) {
			this.marca = marca;
		}
	}
	
	// modelo : getter
	public String getModelo() {
		return modelo;
	}
	
	// modelo : setter
	public void setModelo(String modelo) {
		if(modelo != null && !modelo.trim().equals("")) {
			this.modelo = modelo;
		}
	}
	
	// cv : getter
	public int getCv() {
		return cv;
	}
	
	// cv : setter
	public void setCv(int cv) {
		if(cv > 0) {
			this.cv = cv;
		}
	}
	
	// cc : getter
	public int getCc() {
		return cc;
	}
	
	// cc : setter
	public void setCc(int cc) {
		if(cc > 0) {
			this.cc = cc;
		}
	}
	
	// matricula : getter
	public String getMatricula() {
		return matricula;
	}
	
	// matricula : setter
	public void setMatricula(String matricula) {
		if(matricula != null && !matricula.equals("")) {
			this.matricula = matricula;
		}
	}
	
	// velociad : getter
	public double getVelocidad() {
		return velocidad;
	}
	
	// velocidad : setter
	public void setVelocidad(double velocidad) {
		if(velocidad > 0.1) {
			this.velocidad = velocidad;
		}
	}
	
	// kmRecorridos : getter
	public double getKmRecorridos() {
		return kmRecorridos;
	}
	
	// kmRecorridos : setter
	public void setKmRecorridos(double kmRecorridos) {
		if(kmRecorridos > 0.1) {
			this.kmRecorridos = kmRecorridos;
		}
	}

}

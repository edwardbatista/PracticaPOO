using System;

class Motor
{
    private int litros_de_aceite;
    private int potencia;

    public Motor(int potencia)
    {
        this.potencia = potencia;
        this.litros_de_aceite = 0;
    }

    public int GetLitrosDeAceite()
    {
        return this.litros_de_aceite;
    }

    public void SetLitrosDeAceite(int litros)
    {
        this.litros_de_aceite = litros;
    }

    public int GetPotencia()
    {
        return this.potencia;
    }

    public void SetPotencia(int potencia)
    {
        this.potencia = potencia;
    }
}

class Coche
{
    private Motor motor;
    private string marca;
    private string modelo;
    private double precio_acumulado_de_averias;

    public Coche(string marca, string modelo)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.precio_acumulado_de_averias = 0;
        this.motor = new Motor(100);
    }

    public string GetMarca()
    {
        return this.marca;
    }

    public string GetModelo()
    {
        return this.modelo;
    }

    public double GetPrecioAcumuladoDeAverias()
    {
        return this.precio_acumulado_de_averias;
    }

    public Motor GetMotor()
    {
        return this.motor;
    }


    public void AcumularAveria(double precio)
    {
        this.precio_acumulado_de_averias += precio;
    }

    public void AumentarLitrosAceite(int litros)
    {
        int litros_actuales = this.motor.GetLitrosDeAceite();
        this.motor.SetLitrosDeAceite(litros_actuales + litros);
    }
}

class Garaje
{
    public Coche coche_actual;
    public string averia_actual;
    public int num_coches_atendidos;

    public Garaje()
    {
        this.coche_actual = null;
        this.averia_actual = "";
        this.num_coches_atendidos = 0;
    }

    public bool AceptarCoche(Coche coche, string averia)
    {
        if (this.coche_actual != null)
        {
            return false;
        }

        this.coche_actual = coche;
        this.averia_actual = averia;
        this.num_coches_atendidos++;
        return true;
    }

    public Coche DevolverCoche()
    {
        Coche coche = this.coche_actual;
        this.coche_actual = null;
        this.averia_actual = "";
        return coche;
    }
}

class PracticaPOO
{
    static void Main(string[] args)
    {
        // Creamos el garaje
        Garaje miGaraje = new Garaje();

        // Creamos los coches
        Coche coche1 = new Coche("Ford", "Mustang");
        Motor motorcoche1 = coche1.GetMotor();
        Coche coche2 = new Coche("Audi", "R8");
        Motor motorcoche2 = coche2.GetMotor();

        // Iteramos 2 veces el bucle de entrada al garaje
        for (int i = 0; i < 2; i++)
        {
            // Introducimos el coche 1 en el garaje con avería en aceite
            if (miGaraje.AceptarCoche(coche1, "aceite"))
            {
                Console.WriteLine("El coche {0} {1} ha entrado en el garaje con averia en {2}", coche1.GetMarca(), coche1.GetModelo(), miGaraje.averia_actual);
                Random rnd = new Random();
                double importeAveria = rnd.NextDouble() * 100;
                coche1.AcumularAveria(importeAveria);
                if (miGaraje.averia_actual == "Aceite")
                {
                    coche1.AumentarLitrosAceite(10);
                }
                miGaraje.DevolverCoche();
            }
            else
            {
                Console.WriteLine("El garaje está ocupado. El coche {0} {1} tendrá que esperar.", coche1.GetMarca(), coche1.GetModelo());
            }

            // Introducimos el coche 2 en el garaje con avería en frenos
            if (miGaraje.AceptarCoche(coche2, "frenos"))
            {
                Console.WriteLine("El coche {0} {1} ha entrado en el garaje con averia en {2}", coche2.GetMarca(), coche2.GetModelo(),miGaraje.averia_actual);
                Random rnd = new Random();
                double importeAveria = rnd.NextDouble() * 100;
                coche2.AcumularAveria(importeAveria);
                if (miGaraje.averia_actual == "Aceite")
                {
                    coche2.AumentarLitrosAceite(10);
                }
                miGaraje.DevolverCoche();
            }
            else
            {
                Console.WriteLine("El garaje está ocupado. El coche {0} {1} tendrá que esperar.", coche2.GetMarca(), coche2.GetModelo());
            }
        }

        // Mostramos la información de los coches
        Console.WriteLine("Informacion del coche 1:");
        Console.WriteLine("Marca: {0}", coche1.GetMarca());
        Console.WriteLine("Modelo: {0}", coche1.GetModelo());
        Console.WriteLine("Precio acumulado de averias: {0}", coche1.GetPrecioAcumuladoDeAverias());
        Console.WriteLine("Litros de aceite: {0}", motorcoche1.GetLitrosDeAceite());
        Console.WriteLine("Potencia: {0}", motorcoche1.GetPotencia());

        Console.WriteLine("\nInformacion del coche 2:");
        Console.WriteLine("Marca: {0}", coche2.GetMarca());
        Console.WriteLine("Modelo: {0}", coche2.GetModelo());
        Console.WriteLine("Precio acumulado de averias: {0}", coche2.GetPrecioAcumuladoDeAverias());
        Console.WriteLine("Litros de aceite: {0}", motorcoche2.GetLitrosDeAceite());
        Console.WriteLine("Potencia: {0}", motorcoche2.GetPotencia());
        Console.ReadKey();
    }
}
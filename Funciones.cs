public static class Funciones
{
    public static string IngresarTexto(string msj)
    {
        string texto = "";
        while (texto == "")
        {
            Console.Write(msj);
            texto = Console.ReadLine();
        }
        return texto;
    }
    public static int IngresarDni(string msj)
    {
        int entero=-1;
        while (entero < 9999999)
        {   
            Console.Write(msj);
            int.TryParse(Console.ReadLine(), out entero);
        }
        return entero;
    }

    public static int IngresarEnteroEnRango(string msj, int minimo, int maximo)
    {
        int entero;
        entero = IngresarEntero(msj);
        while (entero < minimo || entero > maximo)
        {
            entero = IngresarEntero("ERROR! " + msj);
        }
        return entero;
    }

    public static DateTime IngresarFecha(string msj)
    {
        DateTime fechaDate;
        string fechaCadena = IngresarTexto(msj);
        while (!DateTime.TryParse(fechaCadena, out fechaDate))
        {
            fechaCadena = IngresarTexto("ERROR! " + msj);
        }
        return fechaDate;
    }
    public static int IngresarEntero(string msj){
        int entero;
        Console.WriteLine(msj);
        entero = int.Parse(Console.ReadLine());
        return entero;
    }
    public static int GenerarEnteroRandom(int desde, int hasta)
    {
        int num;
        Random r = new Random();
        num = r.Next(desde, hasta + 1);
        return num;
    }
}
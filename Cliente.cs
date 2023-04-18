public class Cliente{
    public int DNI{get;private set;}
    public string Apellido{get;private set;}
    public string Nombre{get;private set;}
    public DateTime FechaInscripcion{get;set;}
    public int TipoDeEntrada{get;set;}
    public int TotalAbonado{get;set;}

    public Cliente(){

    }
    public Cliente(int dni, string a, string n, DateTime fi, int tde, int ta){
        DNI=dni;Apellido = a;Nombre = n;FechaInscripcion = fi;TipoDeEntrada = tde;TotalAbonado = ta;
    }

}
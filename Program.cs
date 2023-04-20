using System.Collections.Generic;
using System;

int[] dia = {0, 15000, 30000, 10000, 40000};
int opcion;
int id;
List<string> estadisticas = new List<string>();
do{
    Console.Clear();
    Console.WriteLine("1. Nueva Inscripción");
    Console.WriteLine("2. Obtener Estadísticas del Evento");
    Console.WriteLine("3. Buscar Cliente");
    Console.WriteLine("4. Cambiar entrada de un Cliente");
    Console.WriteLine("5. Salir");
    opcion = Funciones.IngresarEnteroEnRango("Ingrese la opcion deseada",1,5);
    switch (opcion)
        {
            case 1:
                id = Ticketera.AgregarCliente(IngresarCliente());
                Console.WriteLine($"Su id de entrada es {id}");
                Console.ReadLine();
                break;
            case 2:
                ImprimirEstadisticas();
                break;
            case 3:
                MostrarCliente(Funciones.IngresarEntero("Ingrese el id de entrada a buscar"));
                Console.ReadLine();
                break;
            case 4:
                PudoCambiarEntrada();
                Console.ReadLine();
                break;
            case 5:
                break;
            default:
                break;
        }
}while(opcion !=5); 

Cliente IngresarCliente(){
    int dni = Funciones.IngresarDni("Ingrese el dni del cliente ");
    string apellido = Funciones.IngresarTexto("Ingrese el apellido del cliente ");
    string nom = Funciones.IngresarTexto("Ingrese el nombre del cliente ");
    int TipoDeEntrada = Funciones.IngresarEnteroEnRango("Ingrese el tipo de entrada",1 , 4);
    
    return new Cliente(dni, apellido, nom, DateTime.Today, TipoDeEntrada, dia[TipoDeEntrada]);
}
void ImprimirEstadisticas(){
    estadisticas = Ticketera.EstadisticasTicketera();
    if(estadisticas[0] != null){
        foreach(string t in estadisticas){
            Console.WriteLine(t);
        }
    }else Console.WriteLine("Todavia no se ingresaron clientes");
    Console.ReadLine();
}
void MostrarCliente(int id){
    Cliente cliente = Ticketera.BuscarCliente(id);
    if (cliente != null){
        Console.WriteLine($"DNI: {cliente.DNI}" + $"Nombre: {cliente.Nombre}" + $"Apellido: {cliente.Nombre}");
    }
    else Console.WriteLine("El cliente no existe");
}
void PudoCambiarEntrada(){
    int idEntrada = Funciones.IngresarEntero("Ingrese su id de entrada");
    int tipoEntradaNueva = Funciones.IngresarEnteroEnRango("Ingrese el tipo de entrada que quiere obtener", 1, 4);
    bool puedeCambiar = Ticketera.CambiarEntrada(idEntrada, tipoEntradaNueva, dia[tipoEntradaNueva]);
    if(puedeCambiar) Console.WriteLine("Su entrada fue cambiada exitosamente");
    else Console.WriteLine("Su entrada no pudo ser modificada");
}

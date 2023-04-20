public static class Ticketera{
    private static Dictionary<int, Cliente> DicClientes = new Dictionary<int, Cliente>();
    private static int UltimoID {get;set;} = 0;

    public static int DevolverID(){
        return UltimoID;
    }
    public static int AgregarCliente(Cliente cliente){
        if (cliente != null){
            UltimoID = UltimoID + 1;
            DicClientes.Add(UltimoID, cliente);

            return UltimoID;
        }
        else{
            Console.WriteLine("No se ha agregado el cliente");
            return -1;
        } 
        
    }
    public static Cliente BuscarCliente(int id){
        if(DicClientes.Count > 0 && DicClientes.ContainsKey(id)){
            return DicClientes[id];
        }
        else{
            Console.WriteLine("El cliente no existe");
             return null;
        }
    }

    public static bool CambiarEntrada(int id, int tipo, int total){
        if (DicClientes.Count > 0 && DicClientes.ContainsKey(id)){
            if(DicClientes[id].TotalAbonado < total){
                DicClientes[id].TotalAbonado = total;
                DicClientes[id].TipoDeEntrada = tipo;
                return true;
            }
            else return false;
        }
        else return false;
    }
    public static List<string> EstadisticasTicketera(){
        List<string> estadisticas = new List<string>();
        int recaudacionTotal = 0;
        int[] recaudacionCadaDia = {0,0,0,0};
        int[] entrasdasDeCadaTipo = {0,0,0,0};
        double[] porcentajes = new double[4];
        int cantClientes = 0;
        foreach (int clave in DicClientes.Keys){
            recaudacionTotal += DicClientes[clave].TotalAbonado;
            cantClientes++;
            recaudacionCadaDia[DicClientes[clave].TipoDeEntrada-1] = DicClientes[clave].TotalAbonado;
            entrasdasDeCadaTipo[DicClientes[clave].TipoDeEntrada-1]++;
        }
        for (int i = 0; i < porcentajes.Length; i++){
            porcentajes[i] = entrasdasDeCadaTipo[i] * 100 / cantClientes;
        }
        estadisticas.Add("La cantidad de clientes es: " + Convert.ToString(cantClientes));
        estadisticas.Add($"El porcentaje de entradas tipo 1 es: {porcentajes[0]} \n" +
        $"El porcentaje de entradas tipo 2 es: {porcentajes[1]} \n"+
        $"El porcentaje de entradas tipo 3 es: {porcentajes[2]} \n"+ 
        $"El porcentaje de entradas tipo 4 es: {porcentajes[3]}");
        estadisticas.Add($"La recaudacion del dia 1 es de: {recaudacionCadaDia[0]} \n" + 
        $"La recaudacion del dia 2 es de: {recaudacionCadaDia[1]} \n" + 
        $"La recaudacion del dia 3 es de: {recaudacionCadaDia[2]} \n" + 
        $"La recaudacion del full access es de: {recaudacionCadaDia[3]} \n");
        estadisticas.Add($"La recaudacion total fue de: {recaudacionTotal}");
        return estadisticas;
    }
}

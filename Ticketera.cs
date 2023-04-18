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
}
using ProyectoUnidad2.Models;
using ProyectoUnidad2.Services;
using Spectre.Console;

class  Program {
    public static bool running = true;
    public static string[] choices = [
        "1.Mostrar Ropa",
        "2.Eliminar una Ropa",
        "3. Agregar una Ropa",
        "4.Salir"
    ];

    public static ClothesService clothesService = new();
    public static void Main() {
//BUCLE
while (running) {
   
    //INSTRUCCIONES
var selections = new SelectionPrompt<string>()
    .Title("[green]Indica la accion a realizar:[/]")
    .HighlightStyle("DarkGoldenrod")
    .AddChoices(choices);

    var option = AnsiConsole.Prompt(selections);

    List<Clothes> clothes = clothesService.FindAll();

    //Estructura para evaluar la opcion seleccionada
switch (option) {
 case "1.Mostrar Ropa":
    AnsiConsole.Clear();

    var table = new Table();
    table.AddColumn("Id");
    table.AddColumn("Color");
    table.AddColumn("Guy");
    table.AddColumn("Zises");

    //Inyecto vales a las filas de la tabla
    foreach (Clothes item in clothes){
        table.AddRow(
            item.Id.ToString(),
            item.Colors, 
            item.Guy, 
            item.Zises
        );
        
    }

    //Muestro la tabla
    AnsiConsole.Write(table);
    break;
    
 case "2.Eliminar una Ropa":
   AnsiConsole.Clear();
   int id = AnsiConsole.Ask<int>("Indica la ropa que quieres eliminar: ");

   AnsiConsole.WriteLine("");
   var confirmed = AnsiConsole.Confirm("¿Estas seguro?");

   if (confirmed)
 {
  bool deleted = clothesService.Delete(id);

    if (deleted)
 {
      AnsiConsole.MarkupLine("\n[green]Ropa eliminada![/]\n");
 }
 else 
 {
        AnsiConsole.MarkupLine("\n[red]Ropa no encontrada![/]\n");
 }
}
 else 
{
       AnsiConsole.MarkupLine("\n[yellow]Operación cancelada![/]\n");
}
 break;

 case "3. Agregar una Ropa":
    AnsiConsole.Clear();
    string color = AnsiConsole.Ask<string>("Indica el color de Ropa");
    string guy = AnsiConsole.Ask<string>("Indica el tipo de Ropa");
    string zises = AnsiConsole.Ask<string>("Indica el zises de la Ropa");

    var maxId = clothes.Count > 0 ? clothes.Max(b => b.Id) : 0;

    Clothes newClothes = new() {
        Id = maxId + 1,
        Colors = color,
        Guy = guy,
        Zises = zises
        };
        clothesService.Create(newClothes);
        AnsiConsole.MarkupLine("\n[DarkOliveGreen1_1]!Ropa agregada![/]\n");

    break;
case "4.Salir":
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[DarkOliveGreen2_1]Fin del programa![/]");
    running = false;
    break;

}
    }

    }
}
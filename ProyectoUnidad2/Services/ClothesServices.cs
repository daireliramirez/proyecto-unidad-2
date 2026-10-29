using ProyectoUnidad2.Models;

namespace ProyectoUnidad2.Services;

public class ClothesService() {
     //Lista
   private readonly List <Clothes> _clothes = [
    new Clothes {
        Id = 1,
        Colors = "yellow",
        Guy = "jeans",
        Zises = "Small"

    },

new Clothes {
    Id = 2,
    Colors = "Black",
    Guy = "shirt",
    Zises = "Medium"

}
   ];
   //Obtiene la Lista de Ropa almacenada
public List<Clothes> FindAll() {
    return _clothes;

 }
// Eliminar 
 public bool Delete (int id) {
    var clothes = _clothes.FirstOrDefault((b) => b.Id == id);
//Si no se encuentra, retorna falso
    if (clothes is null) { 
        return false;
 }
    _clothes.Remove(clothes);
    return true;
}

public Clothes Create(Clothes clothes){
    _clothes.Add(clothes);
    return clothes;
  }
  }
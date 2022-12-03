using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
  // consiste en 6 espacios donde se guardan items, consumible o no consumible
  // al precionar el numero de la casilla se activa la habilidad de item.activa

    public static Inventario instance;
    public List<Item> inventarioEspacios = new List<Item>();
    private void Awake()
    {
        if (instance is null)
            instance = this;
        
        else Destroy(gameObject);
    }
    private void AgragarAlInventario(Item itemAAgregar)
    {
        if (inventarioEspacios.Count > 5) return;
        inventarioEspacios.Add(itemAAgregar);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Tienda : MonoBehaviour
{
    public List<Item> items;
    public static Tienda instance;
    private void Awake()
    {
        if (instance is null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }
    public void ComprarItem(string nombreItem)
    {
        var item = items.Select(x => x.nombreItem == nombreItem);
        //añdir  al inventario
        //Descontar dinero

    }
}

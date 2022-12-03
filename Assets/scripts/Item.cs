using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string nombreItem;
    public int precio, precioVenta;
    public float tiempoConsumir;
    public bool estaSiendoDestruido=false;
    public virtual void ActivaItem()
    {
    }
    public  virtual void Pasiva()
    {
    }
}

public class Pocion : Item
{
    public override async void ActivaItem()
    {
         base.ActivaItem();
        await Task.Delay(TimeSpan.FromSeconds(tiempoConsumir));
        // quitar de la barra de items;
        Destroy(gameObject);
        estaSiendoDestruido= true;
    }
}
public class SombreroDelExplorador : Item
{
    public override void Pasiva()
    {
        base.Pasiva();
        while (!estaSiendoDestruido)
        {
            Task.Delay(5000);
            // GetComponent<personaje>().velocidadDeMovimiento +=10;
            Task.Delay(1000);
            // GetComponent<personaje>().velocidadDeMovimiento -=10;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionDePersonaje : MonoBehaviour
{
    public LobbyRelay referencia;
    public string seleccionado;
    private void Awake()=> referencia = GameObject.FindObjectOfType<LobbyRelay>();  
    public void ConfirmarPersonaje()
    {
        if (seleccionado is null || seleccionado is "") return;
        GameManager.instance.personajeSeleccionado = seleccionado;
        referencia.FindMatch();
    }
    public void SeleccionarPersonaje(string nombre)
    {
        if (nombre is null || nombre is "") return;
        seleccionado = nombre;
    }
}

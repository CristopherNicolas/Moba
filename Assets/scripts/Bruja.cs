using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class Bruja : Character
{
    protected override void Q()
    {
        base.Q();
        // lanzar hechizo que aturde.
    }
    protected override void W()
    {
        base.W();
        //lanzar hechizo en area
    }
    protected override void E()
    {
        base.E();
        // + 15 de vida
    }
    protected override void R()
    {
        base.R();   
        // aumenta el efecto de tus habilidades en 10 segundos
    }
}

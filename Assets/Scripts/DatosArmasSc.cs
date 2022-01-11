using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevos Datos Arma", menuName = "Datos Armas")]
public class DatosArmasSc : ScriptableObject
{
    [SerializeField] private string descripcionArma;
    [SerializeField] private float fuerza;
    [SerializeField] private float area;

    public string DescripcionArma{
        get{
            return descripcionArma;
        }
    }

    public float Fuerza{
        get{
            return fuerza;
        }
    }

    public float Area{
        get{
            return area;
        }
    }
}

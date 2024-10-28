using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGrow : MonoBehaviour
{
    void OnMouseDown()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f); // Küreyi büyüt
    }
}
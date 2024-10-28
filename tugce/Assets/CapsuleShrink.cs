using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleShrink : MonoBehaviour
{
    void OnMouseDown()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f); // Kapsülü küçült
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderColorChange : MonoBehaviour
{

    private Renderer cubeRenderer;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
    }

    void OnMouseDown()
    {
        cubeRenderer.material.color = new Color(Random.value, Random.value, Random.value); // Rastgele renk değişimi
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCubeController : MonoBehaviour
{
    public float moveSpeed = 0.1f; // Küpün hareket hızı

    public void MoveUp()
    {
        transform.position += Vector3.up * moveSpeed; // Yukarı hareket
    }

    public void MoveDown()
    {
        transform.position += Vector3.down * moveSpeed; // Aşağı hareket
    }

    public void MoveLeft()
    {
        transform.position += Vector3.left * moveSpeed; // Sola hareket
    }

    public void MoveRight()
    {
        transform.position += Vector3.right * moveSpeed; // Sağa hareket
    }
}
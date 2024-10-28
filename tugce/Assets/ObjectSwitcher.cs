using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Button bileşenine erişmek için gerekli

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject humanPrefab;
    public GameObject iguanaPrefab;
    public GameObject bushPrefab;

    private GameObject currentObject;
    private int currentIndex = 0;
    private GameObject[] objects;

    void Start()
    {
        // Nesneleri bir diziye al
        objects = new GameObject[] { humanPrefab, iguanaPrefab, bushPrefab };

        // Eğer sahnede bir humanPrefab varsa, onu yok et
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

    }

    public void SwitchToNextObject()
    {
        // Geçerli nesneyi yok et
        if (currentObject != null)
        {
            Destroy(currentObject);
        }

        // İndeksi güncelle ve döngüsel geçiş yap
        currentIndex = (currentIndex + 1) % objects.Length; // Son nesneden sonra başa dön
        currentObject = Instantiate(objects[currentIndex], transform.position, transform.rotation);
    }

    public void SwitchToPreviousObject()
    {
        // Geçerli nesneyi yok et
        if (currentObject != null)
        {
            Destroy(currentObject);
        }

        // İndeksi güncelle ve döngüsel geçiş yap
        currentIndex = (currentIndex - 1 + objects.Length) % objects.Length; // İlk nesneden önce son nesneye dön
        currentObject = Instantiate(objects[currentIndex], transform.position, transform.rotation);
    }
}
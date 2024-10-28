using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ObjectPlacer : MonoBehaviour
{
    public GameObject bushPrefab;   // Çalı prefab'ı
    public GameObject iguanaPrefab;  // Iguana prefab'ı
    public PlaneFinderBehaviour planeFinder; // Plane Finder referansı
    private GameObject selectedPrefab; // Seçilen nesne (çalı veya iguana)

    private Vector3 placementPosition; // Nesne yerleştirileceği pozisyon

    void Start()
    {
        selectedPrefab = null; // Başlangıçta hiçbir nesne seçilmemiş
        planeFinder.OnInteractiveHitTest.AddListener(OnInteractiveHitTest); // HitTest olayına dinleyici ekle
    }

    // Çalı butonuna tıklanınca çalışacak fonksiyon
    public void SelectBush()
    {
        selectedPrefab = bushPrefab;
        Debug.Log("Bush selected");
        UpdatePlacementPosition(); // Yerleştirme pozisyonunu güncelle
        PlaceObject(); // Nesneyi yerleştir
    }

    // İnsan butonuna tıklanınca çalışacak fonksiyon
    public void SelectIguana()
    {
        selectedPrefab = iguanaPrefab;
        Debug.Log("Human selected");
        UpdatePlacementPosition(); // Yerleştirme pozisyonunu güncelle
        PlaceObject(); // Nesneyi yerleştir
    }

    // Plane Finder yüzey bulduğunda tetiklenir
    public void OnInteractiveHitTest(HitTestResult result)
    {
        if (selectedPrefab != null)
        {
            // Yerleştirileceği pozisyonu belirle
            placementPosition = result.Position;
            Debug.Log("Hit test result: " + placementPosition);
        }
    }

    // Yerleştirme pozisyonunu güncelleyen fonksiyon
    private void UpdatePlacementPosition()
    {
        // Kullanıcı tıklama pozisyonunu güncelleme
        // İsterken Hit Test kullanın
        if (selectedPrefab != null)
        {
            // Ekran tıklama pozisyonunu kullanın
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            planeFinder.PerformHitTest(screenPosition); // Ekran pozisyonunu geçirin
        }
    }

    // Butona tıklandığında nesneyi yerleştirme
    public void PlaceObject()
    {
        if (selectedPrefab != null && placementPosition != Vector3.zero) // Pozisyonun geçerli olduğundan emin olun
        {
            // Aynı yerde başka bir nesne olup olmadığını kontrol et
            Collider[] hitColliders = Physics.OverlapSphere(placementPosition, 0.5f); // 0.5f yarıçapında kontrol et
            bool isOccupied = false;

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("Placeable")) // Nesne yerleştirilebilir olarak işaretlenmişse
                {
                    isOccupied = true;
                    break;
                }
            }

            if (!isOccupied) // Eğer yer boşsa
            {
                Instantiate(selectedPrefab, placementPosition, Quaternion.identity);
                Debug.Log("Object placed at: " + placementPosition);
            }
            else
            {
                Debug.Log("Position already occupied.");
            }
        }
    }
}
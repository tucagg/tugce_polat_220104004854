using UnityEngine;
using System.Collections;

public class IguanaUserController : MonoBehaviour {
    IguanaCharacter iguanaCharacter;

    void Start() {
        iguanaCharacter = GetComponent<IguanaCharacter>();
    }

    void Update() {
        // Dokunma girişlerini kontrol et
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0); // İlk dokunmayı al

            // Dokunma başladığında eylemleri kontrol et
            if (touch.phase == TouchPhase.Began) {
                float touchX = touch.position.x;
                float touchY = touch.position.y;

                // Ekranı dört bölgeye ayır
                if (touchX < Screen.width / 2 && touchY > Screen.height / 2) { // Sol Üst
                    iguanaCharacter.Hit();
                } else if (touchX > Screen.width / 2 && touchY > Screen.height / 2) { // Sağ Üst
                    iguanaCharacter.Rebirth();
                } else if (touchX < Screen.width / 2 && touchY < Screen.height / 2) { // Sol Alt
                    iguanaCharacter.Eat();
                } else if (touchX > Screen.width / 2 && touchY < Screen.height / 2) { // Sağ Alt
                    iguanaCharacter.Death();
                }
            }
        }
    }

    private void FixedUpdate() {
        // Hareket için dokunma veya kaydırma kontrolleri
        float h = 0;
        float v = 0;

        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved) {
                h = touch.deltaPosition.x / Screen.width; // Ekran genişliğine normalize et
                v = touch.deltaPosition.y / Screen.height; // Ekran yüksekliğine normalize et
                iguanaCharacter.Move(v, h);
            }
        }
    }
}
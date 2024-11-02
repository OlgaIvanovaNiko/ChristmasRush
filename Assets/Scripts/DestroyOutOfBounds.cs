// T‰m‰ skripti tuhoaa objekteja, jos ne ovat vasemman reunan takana. Tarvitsemme t‰t‰, jotta v‰lt‰mme ylim‰‰r‰isi‰ objekteja kohtauksessa ja s‰‰st‰mme muistia

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float leftBound = -15; // Asetetaan vasen reunan
    void Update() // Jokaisessa freimiss‰
    {
        if (transform.position.x < leftBound) // Jos objektin sijainti on pienempi kuin -15 (vasen reuna)...
        {
            Destroy(gameObject); // Tuhotaan objekti
        }
    }
}

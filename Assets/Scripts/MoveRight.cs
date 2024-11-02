// Tämä skripti liikuttaa objekteja oikealle

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    private float rightBound = 15; // Asetetaan oikea reuna
    private float leftBound = -20; // Asetetaan vasen reuna
    private float speed = 20; // Asetetaan nopeus
    private PlayerController playerControllerScript; // Linkki PlayerController-skriptiin. Tarvitsemme tätä, jotta voimme tarkistaa muuttujan gameOver sieltä.

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed); // Liikutetaan objekti oikealle käyttäen sen sijaintia, aikaa ja nopeutta
        if (transform.position.x > rightBound && (gameObject.CompareTag("Projectile"))) // Jos objekti on oiken reunan takana ja objektin tagi on "Projectile"...
        {
            Destroy(gameObject); // Tuhotaan objekti
        }
        if (transform.position.x < leftBound) // Jos objekti on oiken vasen reunan takana...
        {
            Destroy(gameObject); // Tuhotaan objekti
        }
    }
}
// Käytin tässä sekä vasenta että oikeaa reunaa, koska käytän tätä skriptiä myös lasten liikuttamiseen. Niiden pivot-piste on 180-astetta käännetty, siksi lisäsin koodia, joka tuhoaa myös objekteja vasemman reunan takana

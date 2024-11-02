// T�m� skripti liikuttaa objekteja oikealle

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    private float rightBound = 15; // Asetetaan oikea reuna
    private float leftBound = -20; // Asetetaan vasen reuna
    private float speed = 20; // Asetetaan nopeus
    private PlayerController playerControllerScript; // Linkki PlayerController-skriptiin. Tarvitsemme t�t�, jotta voimme tarkistaa muuttujan gameOver sielt�.

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed); // Liikutetaan objekti oikealle k�ytt�en sen sijaintia, aikaa ja nopeutta
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
// K�ytin t�ss� sek� vasenta ett� oikeaa reunaa, koska k�yt�n t�t� skripti� my�s lasten liikuttamiseen. Niiden pivot-piste on 180-astetta k��nnetty, siksi lis�sin koodia, joka tuhoaa my�s objekteja vasemman reunan takana

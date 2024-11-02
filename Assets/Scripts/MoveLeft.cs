// T‰m‰ skripti liikkuttaa objekteja vasemmalle

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 10; // Asetetaan nopeus
    private PlayerController playerControllerScript; // Linkki PlayerController-skriptiin. Tarvitsemme t‰t‰, jotta voimme tarkistaa muuttujan gameOver sielt‰.

    void Start() // Pelin alussa
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); // Etsit‰‰n objekteja, joilla on tagi "Player", ja saadaan niist‰ komponentti PlayerController
    }
    void Update() // Jokaisessa freimissa
    {
        if (playerControllerScript.gameOver == false) // Jos muuttuja gameOver PlayerController-skriptiss‰ on false, eli peli ei ole loppunut...
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed); // Liikutetaan objekti vasemmalle
        }
    }
}

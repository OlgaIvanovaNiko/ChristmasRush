// Tämä skripti toistaa taustakuvaa

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    private Vector3 startPos; // Muuttuja alkusijainnin säilyttämiseen
    private float repeatWidth; // Muuttuja taustakuvan pituuden säilylyttämiseen
    void Start()
    {
        startPos = transform.position; // Asetetaan alkusijainti
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // Saadaan BoxCollider-komponentin puolileveys
    }
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth) // Jos taustakuvan sijainti on enemmän kuin alkusijainti miinus puoli
        {
            transform.position = startPos; // Siirretään se alkusijaintiin
        }
    }
}

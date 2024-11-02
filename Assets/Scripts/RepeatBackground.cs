// T�m� skripti toistaa taustakuvaa

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    private Vector3 startPos; // Muuttuja alkusijainnin s�ilytt�miseen
    private float repeatWidth; // Muuttuja taustakuvan pituuden s�ilylytt�miseen
    void Start()
    {
        startPos = transform.position; // Asetetaan alkusijainti
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // Saadaan BoxCollider-komponentin puolileveys
    }
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth) // Jos taustakuvan sijainti on enemm�n kuin alkusijainti miinus puoli
        {
            transform.position = startPos; // Siirret��n se alkusijaintiin
        }
    }
}

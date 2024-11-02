// Tämä skripti tarkistaa törmäyksiä lumipallojen ja muiden objektien välillä tasolla 1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private AudioSource AudioSource; // Muuttuja äänen säilyttämiseen

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>(); // Saadaan AudioSource-komponentti
    }
    void OnTriggerEnter(Collider other) // Metodi, joka tarkistaa törmäyksiä lumipallojen ja muiden objektien välillä
    {
        if (!other.CompareTag("Player") && !other.CompareTag("Ground")) // Jos objektilla, johon törmäämme, ei ole tagia "Player" eikä "Ground"...
        {
            Debug.Log("Snowbal got to: " + other.gameObject.name + ", tag: " + other.tag); // Tämä tulostaa Unityn konsolliin tekstiä, joka näyttää, mihin lumipallo osui
            Destroy(gameObject); // Tuhoamme objektin, jossa on skripti
            Destroy(other.gameObject); // Tuhoamme objektin, johon osuimme
            AudioSource.Play(); // Soitetaan ääni
        }
        if (other.CompareTag("Ground")) // Ja jos osuimme objektiin, jossa on tagi "Ground"...
        {
            Destroy(gameObject); // Tuhoamme objektin, jossa on skripti. Tätä tarvitsemme, jotta pallot, jotka lentävät maan alle, eivät kokoontuisi
        }
    }
}

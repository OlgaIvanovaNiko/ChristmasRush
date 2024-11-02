// Tämä skripti tarkistaa törmäyksiä lahjojen ja lasten välillä tasolla 2

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CheckGiftsGiving : MonoBehaviour
{
    private PlayerController playerControllerScript; // Linkki toiseen skriptiin
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); // Saadaan komponentti, jossa on PlayerController-skripti
    }
    void OnTriggerEnter(Collider other) // Metodi, joka tunnistaa törmäyksiä muiden objektien kanssa
    {
        if (!other.CompareTag("Player") && !other.CompareTag("Ground")) // Jos objektilla, johon törmäämme, ei ole tagia "Player" eikä "Ground"...
        {
            if (other.CompareTag("Kid")) // Jos objektilla, johon törmäämme on tagi "Kid"...
            {
                playerControllerScript.kidScore++; // ...lisätään 1 piste PlayerController-skriptissä olevalle kidScore-muuttujalle
                Debug.Log("Kid: " + playerControllerScript.kidScore); // Tämä koodi näyttää pisteet Unityn konsolissa
            }
            else if (other.CompareTag("Kid_Dark")) // Tai jos objektilla, johon törmäämme on tagi "Kid_Dark"...
            {
                playerControllerScript.mistakeScore++; // ...lisätään 1 piste PlayerController-skriptissä olevalle mistakeScore-muuttujalle
                Debug.Log("Kid_Dark: " + playerControllerScript.mistakeScore); // Tämä koodi näyttää virheiden määrän Unityn konsolissa
            }
            Destroy(gameObject); // Tuhoamme objektin, jossa on skripti
            Destroy(other.gameObject); // Tuhoamme objektin, johon osuimme
        }
    }
}

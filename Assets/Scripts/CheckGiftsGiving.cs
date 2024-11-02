// T�m� skripti tarkistaa t�rm�yksi� lahjojen ja lasten v�lill� tasolla 2

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
    void OnTriggerEnter(Collider other) // Metodi, joka tunnistaa t�rm�yksi� muiden objektien kanssa
    {
        if (!other.CompareTag("Player") && !other.CompareTag("Ground")) // Jos objektilla, johon t�rm��mme, ei ole tagia "Player" eik� "Ground"...
        {
            if (other.CompareTag("Kid")) // Jos objektilla, johon t�rm��mme on tagi "Kid"...
            {
                playerControllerScript.kidScore++; // ...lis�t��n 1 piste PlayerController-skriptiss� olevalle kidScore-muuttujalle
                Debug.Log("Kid: " + playerControllerScript.kidScore); // T�m� koodi n�ytt�� pisteet Unityn konsolissa
            }
            else if (other.CompareTag("Kid_Dark")) // Tai jos objektilla, johon t�rm��mme on tagi "Kid_Dark"...
            {
                playerControllerScript.mistakeScore++; // ...lis�t��n 1 piste PlayerController-skriptiss� olevalle mistakeScore-muuttujalle
                Debug.Log("Kid_Dark: " + playerControllerScript.mistakeScore); // T�m� koodi n�ytt�� virheiden m��r�n Unityn konsolissa
            }
            Destroy(gameObject); // Tuhoamme objektin, jossa on skripti
            Destroy(other.gameObject); // Tuhoamme objektin, johon osuimme
        }
    }
}

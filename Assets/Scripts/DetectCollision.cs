// T�m� skripti tarkistaa t�rm�yksi� lumipallojen ja muiden objektien v�lill� tasolla 1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private AudioSource AudioSource; // Muuttuja ��nen s�ilytt�miseen

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>(); // Saadaan AudioSource-komponentti
    }
    void OnTriggerEnter(Collider other) // Metodi, joka tarkistaa t�rm�yksi� lumipallojen ja muiden objektien v�lill�
    {
        if (!other.CompareTag("Player") && !other.CompareTag("Ground")) // Jos objektilla, johon t�rm��mme, ei ole tagia "Player" eik� "Ground"...
        {
            Debug.Log("Snowbal got to: " + other.gameObject.name + ", tag: " + other.tag); // T�m� tulostaa Unityn konsolliin teksti�, joka n�ytt��, mihin lumipallo osui
            Destroy(gameObject); // Tuhoamme objektin, jossa on skripti
            Destroy(other.gameObject); // Tuhoamme objektin, johon osuimme
            AudioSource.Play(); // Soitetaan ��ni
        }
        if (other.CompareTag("Ground")) // Ja jos osuimme objektiin, jossa on tagi "Ground"...
        {
            Destroy(gameObject); // Tuhoamme objektin, jossa on skripti. T�t� tarvitsemme, jotta pallot, jotka lent�v�t maan alle, eiv�t kokoontuisi
        }
    }
}

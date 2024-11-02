// T‰m‰ skripti generoi lasten prefabit kohtauksessa

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKids : MonoBehaviour
{
    public GameObject[] objectPrefabs; // T‰m‰ on prefabijen taulukko. Se sis‰lt‰‰ lapsien prefabit

    private float startDelay = 2; // Kuten SpawnManagerissa asetetaan viiv‰stys, joka m‰‰ritt‰‰ ajan ennen ensimm‰ist‰ objektin generointia
    private float repeatRate = 2; // M‰‰ritet‰‰n toistuva aikav‰li, joka m‰‰ritt‰‰ ajan objektin uudelleen generoinnin v‰lill‰
    private PlayerController playerControllerScript; // Linkki PlayerController-skriptiin
    private Vector3 spawnLocation = new Vector3(30, 0, 0); // Asetetaan sijainti generoituvalle lapsille

    void Start()
    {
        InvokeRepeating("SpawnKid", startDelay, repeatRate); // Kutsumme SpawnObject-metodia generoimaan prefabit aikaisemmin m‰‰ritellyill‰ viiveill‰
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); // Etsit‰‰n objekteja PlayerController-skriptissa, joilla on tagi "Player", ja saadaan niist‰ komponentti PlayerController
    }

    void SpawnKid() // Metodi joka generoi lapsia
    {
        int index = Random.Range(0, objectPrefabs.Length); // Sattunnaiset luvut nollasta prefabien taulukon pituuteen

        if (playerControllerScript.gameOver == false) // Jos muuttuja gameOver PlayerController-scriptissa ei one false eli peli on viel‰ k‰yniss‰
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation); // Generoidaan lapsien prefabeja
        }
    }
}
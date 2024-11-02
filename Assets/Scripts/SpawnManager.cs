// T‰m‰ skripti generoi porojen, lahjojen, dynamiittien ja lumikasojen prefabeja

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Random = UnityEngine.Random; // T‰m‰ mahdollistaa sattunnaisten lukujen k‰ytˆn

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectPrefabs; // T‰m‰ on prefabien taulukko. Se sis‰lt‰‰ kaikki objektit, joita haluamme generoida

    private float startDelay = 2; // Asetetaan viiv‰stys, joka m‰‰ritt‰‰ ajan ennen ensimm‰ist‰ objektin generointia
    private float repeatRate = 2; // M‰‰ritet‰‰n toistuva aikav‰li, joka m‰‰ritt‰‰ ajan objektin uudelleen generoinnin v‰lill‰
    private PlayerController playerControllerScript; // Linkki PlayerController-skriptiin
    private Vector3 spawnLocation = new Vector3(30, 0, 0); // Asetetaan sijainti generoituvalle objektille
    private Vector3 spawnLocationFixed = new Vector3(30, 1, 0); // Asetetaan uusi sijainti generoituvalle objektille, jonka pivot-piste on liian alhaalla (esim. lahja)

    void Start()
    {
        InvokeRepeating("SpawnObject", startDelay, repeatRate); // Kutsumme SpawnObject-metodia generoimaan prefabit aikaisemmin m‰‰ritellyill‰ viiveill‰
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); // Etsit‰‰n objekteja PlayerController-skriptissa, joilla on tagi "Player", ja saadaan niist‰ komponentti PlayerController
    }
    void SpawnObject() // Metodi, joka generoi prefabeja kohtauksessa
    {
        int index = Random.Range(0, objectPrefabs.Length); // Saadaan satunnainen luku, joka on nollan ja objektijen taulukon pituuden v‰lill‰

        if (playerControllerScript.gameOver == false) // Jos peli on viel‰ k‰yniss‰
        {
            Vector3 spawnLocationUp = new Vector3(30, Random.Range(2, 6), 0); // Myˆs saadaan luku, joka m‰‰rittelee generoituja objektien korkeuden

            if (index == 0) // Jos generoidun objektin indeksi on nolla eli se on lumikasa...
            {
                int randomAppear = Random.Range(0, 3); // Generoidaan uusi indeksi ja...
                Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation); // ...generoimme sen kohtauksessa 

                if (randomAppear == 1 || randomAppear == 2 || randomAppear == 3) // Mutta jos indeksi ei ole nolla eli objekti on lahja, poro tai dynamiitti
                {
                    Instantiate(objectPrefabs[randomAppear], spawnLocationUp, objectPrefabs[randomAppear].transform.rotation); // Generoidaan se kohtauksessa uudella korkeudella lumikasan p‰‰lle
                }
            }
            else // Tai (jos objekti ei ole lumikasa)
            {
                Instantiate(objectPrefabs[index], spawnLocationFixed, objectPrefabs[index].transform.rotation); // Generoidaan objektin. Se mahdollistaa objektien generoimisen maalla
            }
        }
    }
}

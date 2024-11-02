// T‰m‰ skripti hallitsee musiikkia

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Sprite audioOn; // Muuttuja n‰pp‰imen spriten s‰ilytt‰miseen (musiikki on p‰‰ll‰ -sprite)
    public Sprite audioOff; // Muuttuja n‰pp‰imen spriten s‰ilytt‰miseen (musiikki on pois p‰‰lt‰ -sprite)
    public GameObject buttonAudio; // Painikke objekti
    public AudioClip clip; // Muuttuja musiikin s‰ilytt‰miseen

    public void OnOffAudio() // Metodi, joka ottaa pois p‰‰lt‰ tai laittaa p‰‰lle musiikkia
    {
        if(AudioListener.volume == 1) // Jos musiikki on p‰‰ll‰...
        {
            AudioListener.volume = 0; // ...sammutetaan se
            buttonAudio.GetComponent<Image>().sprite = audioOff; // Ja vaihdetaan painikkeen sprite
        }
        else // tai jos se musiikki on pois p‰‰lt‰...
        {
            AudioListener.volume = 1; // ...laitetaan sn p‰‰lle
            buttonAudio.GetComponent<Image>().sprite = audioOn; // Ja vaihdetaan painikkeen sprite
        }
    }
}

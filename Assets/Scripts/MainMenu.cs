// T�m� skripti hallitsee kaikki n�pp�imet (ja siirtymisen kohtauksien v�lill�).

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // T�m� mahdollistaa siirtymisen kohtauksien v�lill�

public class MainMenu : MonoBehaviour
{
    public GameObject SettingsCanvas; // Canvas-objekti (asetukset-n�ytt�), jonka haluamme sitten laittaa p��lle tai ottaa pois p��lt�
    public GameObject AboutCanvas; // Sama mutta n�yt�lle, jossa on tekij�n ja materiaalien tiedot
    public GameObject InstructionBG; // Objekti, joka on ohje-n�yt�n taustakuva
    public void ShowIntro() // T�m� metodi siirt�� pelaajan kohtaukseen, jossa on kuva, josta lukee pelin tarina
    {
        SceneManager.LoadScene("Intro"); // Vaihdetaan kohtaus
    }
    public void QuiteGame() // T�m� metodi sammuttaa pelin
    {
        Debug.Log("Game has been closed"); // Tulostetaan Unityn konsoliin viestin, ett� peli on sammutettu. T�m� auttaa tarkistamaan t�t� toimintaa
        Application.Quit(); // Sammutetaan peli
    }
    public void OpenSettings() // T�m� metodi laittaa p��lle asetukset n�yt�n
    {
        SettingsCanvas.SetActive(true); // Laitetaan n�yt�n p��lle
    }
    public void HideSettings() // T�m� metodi ottaa pois p��lt� asetukset n�yt�n
    {
        SettingsCanvas.SetActive(false); // Otetaan n�yt�n pois p��lt�
    }
    public void StartLevel1() // T�m� metodi siirt�� pelaajan tasolle 1
    {
        SceneManager.LoadScene("Level1"); // Siirret��n pelaaja tasolle 1
    }
    public void StartLevel2() // T�m� metodi siirt�� pelaajan tasolle 2
    {
        SceneManager.LoadScene("Level2"); // Siirret��n pelaaja tasolle 2
    }
    public void ShowInstructions() // T�m� metodi laittaa p��lle ohje-n�yt�n
    {
        InstructionBG.SetActive(true); // Laitetaan n�yt�n p��lle
    }
    public void ShowLevelMenu() // T�m� metodi siirt�� pelaajan LevelMenu kohtaukseen, josta h�n voi valita tasoa
    {
        SceneManager.LoadScene("LevelMenu"); // Siirret��n pelaaja LevelMenu-kohtaukseen
    }
    public void ShowMainMenu() // T�m� metodi siirt�� pelaajan MainlMenu kohtaukseen
    {
        SceneManager.LoadScene("MainMenu"); // Siirret��n pelaaja MainMenu-kohtaukseen
    }
    public void ShowAbout() // T�m� metodi laittaa p��lle kehitt�j�n tiedot -n�yt�n
    {
        AboutCanvas.SetActive(true); // Laitetaan n�yt�n p��lle
    }
    public void HideAbout() // T�m� metodi ottaa pois p��lt� kehitt�j�n tiedot -n�yt�n
    {
        AboutCanvas.SetActive(false); // Otetaan n�yt�n pois p��lt�
    }
}

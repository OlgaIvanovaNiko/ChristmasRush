// Tämä skripti hallitsee kaikki näppäimet (ja siirtymisen kohtauksien välillä).

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Tämä mahdollistaa siirtymisen kohtauksien välillä

public class MainMenu : MonoBehaviour
{
    public GameObject SettingsCanvas; // Canvas-objekti (asetukset-näyttö), jonka haluamme sitten laittaa päälle tai ottaa pois päältä
    public GameObject AboutCanvas; // Sama mutta näytölle, jossa on tekijän ja materiaalien tiedot
    public GameObject InstructionBG; // Objekti, joka on ohje-näytön taustakuva
    public void ShowIntro() // Tämä metodi siirtää pelaajan kohtaukseen, jossa on kuva, josta lukee pelin tarina
    {
        SceneManager.LoadScene("Intro"); // Vaihdetaan kohtaus
    }
    public void QuiteGame() // Tämä metodi sammuttaa pelin
    {
        Debug.Log("Game has been closed"); // Tulostetaan Unityn konsoliin viestin, että peli on sammutettu. Tämä auttaa tarkistamaan tätä toimintaa
        Application.Quit(); // Sammutetaan peli
    }
    public void OpenSettings() // Tämä metodi laittaa päälle asetukset näytön
    {
        SettingsCanvas.SetActive(true); // Laitetaan näytön päälle
    }
    public void HideSettings() // Tämä metodi ottaa pois päältä asetukset näytön
    {
        SettingsCanvas.SetActive(false); // Otetaan näytön pois päältä
    }
    public void StartLevel1() // Tämä metodi siirtää pelaajan tasolle 1
    {
        SceneManager.LoadScene("Level1"); // Siirretään pelaaja tasolle 1
    }
    public void StartLevel2() // Tämä metodi siirtää pelaajan tasolle 2
    {
        SceneManager.LoadScene("Level2"); // Siirretään pelaaja tasolle 2
    }
    public void ShowInstructions() // Tämä metodi laittaa päälle ohje-näytön
    {
        InstructionBG.SetActive(true); // Laitetaan näytön päälle
    }
    public void ShowLevelMenu() // Tämä metodi siirtää pelaajan LevelMenu kohtaukseen, josta hän voi valita tasoa
    {
        SceneManager.LoadScene("LevelMenu"); // Siirretään pelaaja LevelMenu-kohtaukseen
    }
    public void ShowMainMenu() // Tämä metodi siirtää pelaajan MainlMenu kohtaukseen
    {
        SceneManager.LoadScene("MainMenu"); // Siirretään pelaaja MainMenu-kohtaukseen
    }
    public void ShowAbout() // Tämä metodi laittaa päälle kehittäjän tiedot -näytön
    {
        AboutCanvas.SetActive(true); // Laitetaan näytön päälle
    }
    public void HideAbout() // Tämä metodi ottaa pois päältä kehittäjän tiedot -näytön
    {
        AboutCanvas.SetActive(false); // Otetaan näytön pois päältä
    }
}

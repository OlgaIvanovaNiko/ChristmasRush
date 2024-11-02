// T‰m‰ skripti hallitsee monia asioita: pelaajan liikkumista, musiikkia, ‰‰nt‰, partikkelieffektej‰, animatioita jne

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // T‰t‰ tarvitsen, jotta laittaa tekstia n‰ytˆlle
using UnityEngine.SceneManagement; // T‰m‰ mahdollistaa kohtauksien vaihtamisen
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb; // Muuttuja pelaajan Rigidbody-komponentin s‰ilytt‰miseen
    private Animator playerAnim; // Muuttuja, joka hallitsee animaatioita
    private AudioSource AudioSource; // Muuttuja, joka hallitsee ‰‰ni‰ ja musiikkia

    public Text giftCount; // Tekstimuuttuja, joka n‰ytt‰‰ lahjojen m‰‰r‰n
    public Text deerCount; // Sama asia, mutta poroille
    public bool gameOver = false; // Muuttuja, joka hallitsee pelin loppua
    public bool isOnGround; // Muuttuja, joka n‰ytt‰‰ onko pelaaja maalla vai ei
    public float gravityModifier; // Muuttuja painovoiman vaihtamiseen
    public float jumpForce; // Muuttuja, joka hallitsee, kuinka korkealle pelaaja voi hyp‰t‰
    public int score; // Muuttuja lahjojen m‰‰r‰n s‰ilytt‰miseen
    public int kidScore; // Muuttuja annettujen lahjojen m‰‰r‰n s‰ilytt‰miseen tason 2 aikana
    public int mistakeScore; // Muuttuja virheellisesti annettujen lahjojen m‰‰r‰n s‰ilytt‰miseen
    public int deerAmount; // Muuttuja porojen m‰‰r‰n s‰ilytt‰miseen
    public int deerAmountSet = 6; // Maksimi porojen m‰‰r‰
    public ParticleSystem droppingGifts; // Menetettyjen lahjojen efekti
    public ParticleSystem snowDrops; // Lumiefekti
    public GameObject projectilePrefab; // Objekti, jota pelaaja voi heitt‰‰
    void Start() // Pelin alussa
    {
        playerRb = GetComponent<Rigidbody>(); // Lis‰t‰‰n pelaajan Rigidbody komponentti muuttujaan
        Physics.gravity = new Vector3(0, -9.81f * gravityModifier, 0); // Lis‰t‰‰n painovoimaa

        playerAnim = GetComponent<Animator>(); // Saatetaan animaatori-komponentti
        score = 0; // Lahjojen m‰‰r‰ pelin alussa
        deerAmount = 0; // Porojen m‰‰r‰ pelin alussa
        giftCount.text = "Gifts: " + score.ToString(); // ToString tekee intista string. Teen t‰t‰ varmuuden vuoksi, jotta v‰ltt‰‰ mahdollisia virheita
        deerCount.text = "Deers: " + deerAmount.ToString();
        
        AudioSource = GetComponent<AudioSource>(); // Saadetaan AudioSource komponentti
    }
    void Update() // Jokaisessa freimissa
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) // Jos pelaaja painaa "Space" ja pelaaja on maalla ja peli ei ole loppunut...
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Lis‰‰n voimaa ylˆs, jotta se hyppaisi
            isOnGround = false; // Nyt pelaaja ei ole maalla
            playerAnim.SetTrigger("Jump 0"); // Trigger-muuttuja laitetaan p‰‰lle, jotta hyppy-animaatio soisi
            snowDrops.Stop(); // Otetaan lumi-partikkelieffekti pois p‰‰lt‰, koska pelaaja hypp‰‰
        }
        if (Input.GetKeyDown(KeyCode.F) && !gameOver) // Jos pelaaja painaa "F"-n‰pp‰in ja peli ei ole loppunut
        {
            Vector3 positionCorrectionY = transform.position + new Vector3(0, 2, 0); // Asetetaan uusi sijainti lumipallolle, jotta se tulee Joulupukin keskelt‰, eik‰ jaloista
            Instantiate(projectilePrefab, transform.position + positionCorrectionY, projectilePrefab.transform.rotation); // Generoidaan lumipallon prefabista
        }
        CountMistakesAndKids(); // Kutsutaan metodia, joka laskea pisteet tasolla 2 varmuuden vuoksi
    }
    private void CountMistakesAndKids() // Metodi, joka laskee virheiden ja pisteiden m‰‰r‰n tasolla 2
    {
        if (mistakeScore >= 3) // Jos virheit‰ on 3 tai enemm‰n...
        {
            gameOver = true; // Peli loppuu
            Debug.Log("Game over"); // Tulostetaan viesti t‰st‰ Unityn konsoliin
            SceneManager.LoadScene("BadEnd"); // Siirret‰‰n pelaaja huonoon loppuun
        }
        if (kidScore >= 10 && !gameOver) // Jos pisteet tasolla 2 ovat 10 tai enemm‰n...
        {
            SceneManager.LoadScene("GoodEnd"); // Siirret‰‰n pelaaja hyv‰‰n loppuun
        }
    }
    private void OnCollisionEnter(Collision collision) // Metodi, joka tarkistaa tˆrm‰yksi‰ Joulupukin ja muiden objektien v‰lill‰
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle")) // Jos se tˆrm‰‰ maan tai lumikasan
        {
            isOnGround = true; // Ohjelma tiet‰‰ nyt, ett‰ pelaaja on maalla
            playerAnim.ResetTrigger("Jump 0"); // Otetaan hyppy-animaatio pois p‰‰lt‰
            snowDrops.Play(); // Laitetaan lumi-partikkeliefektit p‰‰lle
        }

        if (collision.gameObject.CompareTag("Gift")) // Jos Joulupukki tˆrm‰‰ lahjaan
        {
            Destroy(collision.gameObject); // Tuhotaan lahja
            score++; // Lisataan 1 piste
            giftCount.text = "Gifts: " + score.ToString(); // P‰ivitet‰‰n teksti lahjojen m‰‰r‰st‰ n‰ytˆll‰. ToStringia k‰ytet‰‰n virheiden v‰ltt‰miseksi
            Debug.Log("Collected gift: " + score); // Tulostetaan myˆs Unityn konsoliin lahjojen m‰‰r‰n
            AudioSource.Play(); // Soitetaan ker‰ttyjen objektien ‰‰nt‰
        }
        else if (collision.gameObject.CompareTag("Deer")) // Jos Joulupukki tˆrm‰‰ poroon
        {
            Destroy(collision.gameObject); // Tuhotaan poro
            deerAmount++; // Lisataan 1 piste porojen m‰‰r‰‰n
            deerCount.text = "Deers: " + deerAmount.ToString(); // P‰ivitet‰‰n teksti porojen m‰‰r‰st‰ n‰ytˆll‰
            Debug.Log(deerAmount); // Tulostetaan myˆs Unityn konsoliin porojen m‰‰r‰n
            AudioSource.Play(); // Soitetaan ker‰ttyjen objektien ‰‰nt‰

            if (deerAmount == deerAmountSet) // Jos pelaaja sai tarpeeksi poroja
            {
                gameOver = true; // Peli loppuu
                snowDrops.Stop(); // Otetaan lumi-partikkelieffekti pois p‰‰lt‰, koska peli loppuu
                SceneManager.LoadScene("Lvl1CompleteScreen"); // Siirret‰‰n pelaaja seuraavalle kohtaukselle
                Debug.Log("All deers have been found"); // Tulostetaan Unityn konsoliin viesti, ett‰ kaikki porot ovat lˆyt‰neet
            }
        }
        else if (collision.gameObject.CompareTag("Dynamite")) // tai jos Joulupukki tˆrm‰‰ dynamiittiin
        {
            Destroy(collision.gameObject); // Tuhotaan dynamiitti
            if (score == 0) // Jos pelaajalla ei ollut yht‰ lahjaa...
            { // emme tee mit‰‰n
            }
            else // Mutta jos pelaajalla on lahjoja
            {
                droppingGifts.Play(); // Soitetaan partikkeliefekti, joka n‰ytt‰‰, miten lahjat putosivat Joulupukista
            }
            score = score / 2; // Puolitaan pistem‰‰r‰
            giftCount.text = "Gifts: " + score.ToString(); // P‰ivitet‰‰n teksti lahjojen m‰‰r‰st‰ n‰ytˆll‰
            Debug.Log(score); // P‰ivitet‰‰n lahjojen m‰‰r‰‰ myˆs konsolissa
            AudioSource.Play(); // Soitetaan ker‰ttyjen objektien ‰‰nt‰
        }
        if (collision.gameObject.CompareTag("Kid_Dark")) // Jos Joulupukki tˆrm‰‰ tuhmaan lapsiin (tasolla 2)
        {
            mistakeScore++; // Lis‰t‰‰n 1 virheiden m‰‰r‰‰n
            Debug.Log("Mistakes: " + mistakeScore); // Tulostetaan virheiden m‰‰r‰ konsolissa
        }
    }
}


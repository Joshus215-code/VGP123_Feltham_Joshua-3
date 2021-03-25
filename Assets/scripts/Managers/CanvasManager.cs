using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanvasManager : MonoBehaviour
{
    


    [Header("Buttons")]
    public Button startButton;
    public Button quitButton;
    public Button settingsButton;
    public Button backButton;
    public Button returnToMenuButton;
    public Button returnToGameButton;


    [Header("Menus")]
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject settingsMenu;

    [Header("Text")]
    public Text livesText;
    public Text volText;
    public Text muteText;

    [Header("Slider")]
    public Slider volSlider;

    AudioSource pauseAudio;
    public AudioClip pauseSound;

    [Header("Toggle")]
    public Toggle muteToggle;
    
    void Start()
    {

        if (pauseMenu)
        {
           pauseAudio = gameObject.AddComponent<AudioSource>();
            pauseAudio.clip = pauseSound;
            pauseAudio.loop = false;
           
        }

        if (startButton)
        {
            startButton.onClick.AddListener(() => GameManager.instance.StartGame());
        }

        if (quitButton)
        {
            quitButton.onClick.AddListener(() => GameManager.instance.QuitGame());
        }

        if (returnToGameButton)
        {
            returnToGameButton.onClick.AddListener(() => ReturnToGame());
        }

        if (returnToMenuButton)
        {
            returnToMenuButton.onClick.AddListener(() => GameManager.instance.ReturnToMenu());
        }

        if (backButton)
        {
            backButton.onClick.AddListener(() => ShowMainMenu());
        }

        if (settingsButton)
        {
            settingsButton.onClick.AddListener(() => ShowSettingsMenu());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu)
        {
           
            if (Input.GetKeyDown(KeyCode.P))
            {

                pauseMenu.SetActive(!pauseMenu.activeSelf);

                if(pauseMenu.activeSelf)
                {
                    pauseAudio.Play();
                }
                GameManager.instance.playerInstance.GetComponent<playermovement>().enabled = false;
                GameManager.instance.playerInstance.GetComponent<playerFire>().enabled = false;
                Time.timeScale = 0f;           
            }
            if (Input.GetKeyDown(KeyCode.P) && !pauseMenu.activeSelf)
            {
                ReturnToGame();
            }
        }
        if (livesText)
        {
            livesText.text = GameManager.instance.lives.ToString();
        }

        if (settingsMenu)
        {
            if (settingsMenu.activeSelf)
            {
                volText.text = volSlider.value.ToString();
            }
        }
    }

    public void ReturnToGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameManager.instance.playerInstance.GetComponent<playermovement>().enabled = true;
        GameManager.instance.playerInstance.GetComponent<playerFire>().enabled = true;
    }

    void ShowMainMenu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    void ShowSettingsMenu()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
}

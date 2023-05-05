using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Transactions;

public class LogicScript : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject StartScreen;
    public bool missileTutorial = false;
    public int score = 0;
    public Text scoreDisplay;
    public int lives = 3;
    public Text livesDisplay;
    public int ammo = 2;
    public Text ammoDisplay;
    public Text missileTutorialText;
    public AudioSource startMusic;
    public AudioSource endMusic;
    public AudioSource track1;
    public AudioSource track2;
    public AudioSource track3;
    public static LogicScript instance;

    private void Awake()
    {
        //singleton code, only allow one instance of logic
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        //pause game
        Time.timeScale = 0;
        //display start text and play start music
        StartScreen.SetActive(true);
        startMusic.Play();
    }

    private void Update()
    {
        //if paused, start when space key is pressed
        if (Input.GetKeyDown(KeyCode.Space) == true && Time.timeScale == 0)
        {
            //hide start text
            StartScreen.SetActive(false);
            //resume game
            Time.timeScale = 1;
            //stop menu music and begin random game music
            startMusic.Pause();
            System.Random randomiser = new();
            switch(randomiser.Next(1,4))
            {
                case 1:
                    Debug.Log("1");
                    track1.Play();
                    break;
                case 2:
                    Debug.Log("2");
                    track2.Play();
                    break;
                case 3:
                    Debug.Log("3");
                    track3.Play();
                    break;
            }
        }
        //remove missile tutorial when missile is shot
        if (Input.GetKeyDown(KeyCode.LeftShift) == true)
        {
            missileTutorialText.text = "";
        }
    }

    public void missileTutorialOn()
    {
        //display tutorial text
        missileTutorialText.text = "Break marked walls by pressing LSHIFT to shoot!";
        missileTutorial = true;
    }

    [ContextMenu("Increase Score")]
    public void increaseScore()
    {
        score ++;
        //update display
        scoreDisplay.text = score.ToString();
    }

    [ContextMenu("Decrease Lives")]
    public void decreaseLives()
    {
        lives--;
        //prevent negatives
        if(lives < 0)
        {
            lives = 0;
        }
        //update display
        livesDisplay.text = lives.ToString();
        //when lives = 0, end the game
        if (lives == 0)
        {
            endGame();
        }
    }

    [ContextMenu("Increase Lives")]
    public void increaseLives()
    {
        lives++;
        //update display
        livesDisplay.text = lives.ToString();
    }

    [ContextMenu("Decrease Ammo")]
    public void decreaseAmmo()
    {
        ammo--;
        //update display
        ammoDisplay.text = ammo.ToString();
    }

    [ContextMenu("Increase Ammo")]
    public void increaseAmmo()
    {
        ammo++;
        //update display
        ammoDisplay.text = ammo.ToString();
    }

    [ContextMenu("Reset Game")]
    public void resetGame()
    {
        //reset scene to start again
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    [ContextMenu("End Game")]
    public void endGame()
    {
        //show game over text and play only ending music
        gameOver.SetActive(true);
        track1.Pause();
        track2.Pause();
        track3.Pause();
        endMusic.Play();
    }
}

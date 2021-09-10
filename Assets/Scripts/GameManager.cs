using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gamePause = false;
    bool gameOver = false;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject canvas2;
    [SerializeField] Spaceship player;
    [SerializeField] int numEnemies;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        canvas2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && gameOver == false)
        PauseGame();
    }

    public void StarGame()
    {
        SceneManager.LoadScene(1);
    }

    public void NextLevel1()
    {
        SceneManager.LoadScene(2);
    }

    public void NextLevel2()
    {
        SceneManager.LoadScene(3);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    void PauseGame()
    {
        gamePause = gamePause ? false : true;

        player.gamePaused = gamePause;

        canvas.SetActive(gamePause);
        Time.timeScale = gamePause ? 0 : 1;

    }

    public void ReducirNumEnemigo()
    {
        numEnemies = numEnemies - 1;
        if(numEnemies < 1)
        {

            Ganar();

        }
    }

    void Ganar()
    {

        gameOver = true;
        Time.timeScale = 0;
        player.gamePaused = true;
        Debug.Log("Ganaste!");
        Time.timeScale = gamePause ? 0 : 1;
        canvas2.SetActive(gameOver);
    }
}

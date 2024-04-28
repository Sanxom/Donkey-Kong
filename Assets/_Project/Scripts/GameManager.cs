using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    private int _level;
    private int _lives;
    private int _score;

    private void Start()
    {
        NewGame();
    }

    public void LevelComplete()
    {
        _score += 1000;

        int nextLevel = _level + 1;

        if(nextLevel < SceneManager.sceneCountInBuildSettings)
        {
            LoadLevel(nextLevel);
        }
        else
        {
            LoadLevel(1);
        }
    }

    public void LevelFailed()
    {
        _lives--;

        if(_lives <= 0)
        {
            NewGame();
        }
        else
        {
            LoadLevel(_level);
        }
    }

    private void NewGame()
    {
        _lives = 3;
        _score = 0;

        LoadLevel(1);
    }

    private void LoadLevel(int index)
    {
        _level = index;

        Camera camera = Camera.main;

        if(camera != null)
        {
            camera.cullingMask = 0;
        }

        Invoke(nameof(LoadScene), 1);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_level);
    }
}
using System;
using UnityEngine;
using Sirenix.OdinInspector;using Sirenix.Serialization;
using UnityEngine.SceneManagement;

public enum gameDifficulty { Easy, Hard }; 


public class GameSetup : MonoBehaviour
{
    public static GameSetup Instance; 
    
    [ShowInInspector] public static string CurrentPlayer;
    [ShowInInspector] public static string BestPlayer;
    [ShowInInspector] public static int BestScore;
    [ShowInInspector] public gameDifficulty difficulty; 

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (ES3.KeyExists("bestPlayer"))
        {
            BestPlayer = ES3.Load<string>("bestPlayer"); 
        }
        
        if (ES3.KeyExists("bestScore"))
        {
            BestScore = ES3.Load<int>("bestScore"); 
        }

        difficulty = gameDifficulty.Easy; 
    }
    
    public void SetCurrentPlayer(string playerName)
    {
        CurrentPlayer = playerName; 
        Debug.Log("player Name = " + playerName);
    }

    public void LoadNewGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName); 
    }

    private void OnDisable()
    {
        ES3.Save("bestPlayer", BestPlayer);
        ES3.Save("bestScore", BestScore);
    }

    public void SetDifficulty(string diff)
    {
        Enum.TryParse(diff, out difficulty); 
    }
}

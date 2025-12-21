using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    GameObject Spawnedball;
    public float Ballforce;
    int score = 0;
    public UIManager UIManager;
    public DifficultyManager difficultyManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        QualitySettings.vSyncCount = 0; // disable VSync
        Application.targetFrameRate = 100;

    }

    void Start()
    {

        difficultyManager.LevelOne();
    }

    public GameObject SpawnBall()
    {
        Spawnedball = Instantiate(ballPrefab, new Vector2(Random.Range(-1.3f, 1.3f), Random.Range(0f, 3f)), Quaternion.identity);
        return Spawnedball;
        
    }

    public void ScoreSystem()
    {
        score++;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
        UIManager.AddScore(score);

    }
}

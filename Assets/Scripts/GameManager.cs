using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    GameObject Spawnedball;
    public float Ballforce;
    public int score = 0;
    public UIManager UIManager;
    public DifficultyManager difficultyManager;
    int Health = 5;
    int BonusScore = 0;
    public int ScoreMultiplyerDelay;
    [HideInInspector]
    public bool isBonusScoreActive = false;
    public GameObject CoinPreFab;
    public Vector3 CoinCollectPos;
    public AudioSource CoinCollectSFX;

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

    #region Score Syytem
    public void ScoreSystem()
    {
        score += 1 + BonusScore;

        UIManager.AddScore(score);

    }

    public void DoubleScore() 
    {
        StartCoroutine(DoubpleScoreManager(ScoreMultiplyerDelay));
    }

    IEnumerator DoubpleScoreManager(int ScoreMultiplyerDelay)
    {
        isBonusScoreActive = true;
        BonusScore = 1;
        yield return new WaitForSeconds(ScoreMultiplyerDelay);
        BonusScore = 0;
        isBonusScoreActive = false;

    }

    #endregion

    #region Health Sysstem

    public void HealthSystem()
    {
        if (Health <= 0) return;
        Health--;
        UIManager.RemoveLife(Health);


    }

    #endregion

    #region Coin Reward System

    public void CoinReward()
    {
        Ball ball = FindAnyObjectByType<Ball>();

        GameObject coin = Instantiate(CoinPreFab, ball.BallLastPos, Quaternion.identity);

        StartCoroutine(MoveCoin(coin));
    }

    IEnumerator MoveCoin(GameObject coin)
    {
        float speed = 10f;
        float popDuration = 0.25f;
        float maxPopScale = 4f; // overshoot scale

        // ----- POP-IN ANIMATION -----
        Vector3 originalScale = Vector3.zero;
        Vector3 overshootScale = Vector3.one * maxPopScale;
        Vector3 finalScale = Vector3.one;

        float t = 0f;

        // scale from 0 -> overshoot
        while (t < popDuration / 2)
        {
            t += Time.deltaTime;
            float factor = t / (popDuration / 2);
            coin.transform.localScale = Vector3.Lerp(originalScale, overshootScale, factor);
            yield return null;
        }

        t = 0f;
        // scale from overshoot -> final
        while (t < popDuration / 2)
        {
            t += Time.deltaTime;
            float factor = t / (popDuration / 2);
            coin.transform.localScale = Vector3.Lerp(overshootScale, finalScale, factor);
            yield return null;
        }

        // ----- FLY TO COLLECTOR -----
        Vector3 startPos = coin.transform.position;
        while (Vector3.Distance(coin.transform.position, CoinCollectPos) > 0.05f)
        {
            // ease-out movement
            coin.transform.position = Vector3.MoveTowards(
                coin.transform.position,
                CoinCollectPos,
                speed * Time.deltaTime
            );
            yield return null;
        }

        // Coin reached collector
        coin.transform.position = CoinCollectPos;
        CoinCollectSFX.Play();
        Destroy(coin);
        ScoreSystem();
    }

    #endregion



}

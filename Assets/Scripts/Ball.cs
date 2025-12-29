using UnityEngine;

public class Ball : MonoBehaviour
{

    GameManager gameManager;
    DifficultyManager difficultyManager;
    private int Score;
    AudioSource BallTapSFX;
    [HideInInspector]
    public Vector2 BallLastPos;
    int TwoXBallSpawnDelay = 70;


    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        difficultyManager = FindAnyObjectByType<DifficultyManager>();
        BallTapSFX = GameObject.Find("Ball Tap SFX").GetComponent<AudioSource>();
        Score = gameManager.score;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (BallTapSFX != null)
        {
            BallTapSFX.Play();
        }

    }

    private void OnMouseDown()
    {
        BallLastPos = gameObject.transform.position;

        Destroytheball();
    }

    public void Destroytheball() // Destroy ball 
    {

        
        LevelSelect();
        TwoXBallSpqwn();
        gameManager.CoinReward();
        Destroy(gameObject);

    }

    private void LevelSelect()
    {
        int BallSpawnChance = Random.Range(10, 100);

        
        if (Score <= 10)
        {

            difficultyManager.LevelOne();
        }

        if (Score > 10 && Score <= 20)
        {
            difficultyManager.LevelTwo();

        }

        if (Score > 20 && Score <= 100)
        {
            if (BallSpawnChance < 50 && Score>=50 && !difficultyManager.isBombSpawned)
            {
                difficultyManager.BombBallSpawn();
            }

            else
            {
                difficultyManager.LevelThree();
            }
            

        }
        if(Score == 101)
        {
            difficultyManager.LevelFour();
            difficultyManager.LevelFour();
            difficultyManager.HeartBall();
        }

        if (Score > 101 && Score <= 200)
        {
            if (BallSpawnChance < 35 && Score >= 50 && !difficultyManager.isBombSpawned)
            {
                difficultyManager.BombBallSpawn();
            }

            else
            {
                difficultyManager.LevelFour();
            }


        }





    }

    private void TwoXBallSpqwn()
    {
        if (Score.Equals(TwoXBallSpawnDelay))
        {
            difficultyManager.TwoXBall();
            TwoXBallSpawnDelay += 80;
        }
    }







}



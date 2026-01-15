using UnityEngine;

public class Ball : MonoBehaviour
{

    GameManager gameManager;
    DifficultyManager difficultyManager;
    private int Score;
    AudioSource BallTapSFX;
    [HideInInspector]
    public Vector2 BallLastPos;
    int TwoXBallSpawnDelay = 50;


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
        gameManager.CoinReward();
        Destroy(gameObject);

    }

    private void LevelSelect()
    {
        if (Score <= 10)
        {
            difficultyManager.LevelOne();  //spawn ball
        }

        else if (Score > 10 && Score <= 20)
        {
            difficultyManager.LevelTwo(); // adding swing
        }

        else if (Score > 20 && Score <= 100)
        {
            difficultyManager.LevelThree(); //Ball Speed incrase
        }
        else if (Score > 100 && !difficultyManager.is2BallSpawned) //spawn 2 ball
        {
            difficultyManager.LevelFour();
            difficultyManager.LevelFour();
            difficultyManager.HeartBall();
            difficultyManager.is2BallSpawned = true;
        }

        else if (Score > 100 && Score <= 300 && difficultyManager.is2BallSpawned)
        {
            difficultyManager.LevelFour(); //continuing 2 ball
        }

        else if (Score > 300 && !difficultyManager.is3BallSpawned) // spawn 3 ball
        {
            difficultyManager.LevelFive();
            difficultyManager.LevelFive();
            difficultyManager.HeartBall();
            difficultyManager.HeartBall();
            difficultyManager.is3BallSpawned = true;
        }


        else if (Score > 300 && Score < 450 && difficultyManager.is3BallSpawned)
        {
            difficultyManager.LevelFive();// continuing 3 ball
        }

        else if (Score >= 450 && Score <= 550) // Ball speed increase
        {
            difficultyManager.LevelSix();
        }

        else if (Score > 550 && !difficultyManager.is4BallSpawned) // 4 ball spawn
        {
            difficultyManager.LevelSeven();
            difficultyManager.LevelSeven();
            difficultyManager.LevelSeven();
            difficultyManager.HeartBall();
            difficultyManager.HeartBall();
            difficultyManager.is4BallSpawned = true;
        }

        else if (Score > 550 && Score < 700 && difficultyManager.is4BallSpawned)
        {
            difficultyManager.LevelSeven(); // continuing 4 ball
        }

        else if (Score > 700 && Score < 1000)
        {
            difficultyManager.LevelEight(); // Ball speed increase
        }











    }

    private void TwoXBallSpawn()
    {
        if (Score.Equals(TwoXBallSpawnDelay))
        {
            difficultyManager.TwoXBall();
            TwoXBallSpawnDelay += 80;
        }
    }

}



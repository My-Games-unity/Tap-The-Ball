using System.Collections;
using UnityEngine;


public class Bomb : MonoBehaviour
{
    GameManager gameManager;
    DifficultyManager difficultyManager;
    private int Score;

    private void Awake()
    {
        difficultyManager = FindAnyObjectByType<DifficultyManager>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Start()
    {
        StartCoroutine(BombDisappearRoutine());
    }

    IEnumerator BombDisappearRoutine()
    {
        if (gameObject != null && gameObject.activeSelf)
        {
            yield return new WaitForSeconds(3f);
            LevelSelect();
            Destroy(gameObject);
        }
    }

    private void LevelSelect()
    {

        int BallSpawnChance = Random.Range(10, 100);

        Score = gameManager.score;
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


            difficultyManager.LevelThree();


        }

        if (Score > 100 && Score <= 200)
        {
            difficultyManager.LevelFour();


        }


    }

    private void OnMouseDown()
    {
        gameManager.HealthSystem();
        LevelSelect();
        Destroy(gameObject);

    }

}

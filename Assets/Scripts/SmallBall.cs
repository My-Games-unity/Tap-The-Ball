using UnityEngine;

public class SmallBall : MonoBehaviour
{

    AudioSource BallTapSFX;
    DifficultyManager difficultyManager;

    private void Start()
    {
        BallTapSFX = GameObject.FindGameObjectWithTag("Ball Tap SFX").GetComponent<AudioSource>();
        difficultyManager = FindAnyObjectByType<DifficultyManager>();

    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallTapSFX.Play();
    }

    private void OnDestroy()
    {
        difficultyManager.SpawnLevelFive();
    }
}

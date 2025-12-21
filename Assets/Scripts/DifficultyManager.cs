using Unity.Mathematics;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
   
    public  GameManager gameManager;
    private GameObject SpawnedBall;
    Rigidbody2D Ballrb;
    float BallForce = 10f;
    float CurrectScaleOfBall = 1.3f;
    public GameObject[] SmallBalls;
    public int aliveSmallBalls = 0;

    public void LevelOne()
    {
        gameManager.SpawnBall();
    }

    public void LevelTwo() 
    {
          
        SpawnedBall = gameManager.SpawnBall();
        
        Ballrb = SpawnedBall.GetComponent<Rigidbody2D>();
        int randomnumber = UnityEngine.Random.Range(-2, 1);

        //Debug.Log(randomnumber);
        if (randomnumber <= 0)
        {
            Ballrb.AddForce(new Vector2(-BallForce, 0), ForceMode2D.Impulse);
        }
        else if (randomnumber > 0)
        {
            Ballrb.AddForce(new Vector2(BallForce, 0), ForceMode2D.Impulse);

        }
    }
    
    public void LevelThree()
    {
        CurrectScaleOfBall = CurrectScaleOfBall - 0.03f;
        float BallNewSize = Mathf.Max(CurrectScaleOfBall, 1f);
        BallForce = BallForce + 1.5f;
        float BallForceL3 = Mathf.Clamp(BallForce, 10f, 13f);
        SpawnedBall = gameManager.SpawnBall();
        SpawnedBall.transform.localScale = Vector2.one * BallNewSize;
        Ballrb = SpawnedBall.GetComponent<Rigidbody2D>();
        int randomnumber = UnityEngine.Random.Range(-2, 1);
        //Debug.Log(randomnumber);
        if (randomnumber <= 0)
        {
            Ballrb.AddForce(new Vector2(-BallForceL3, 0), ForceMode2D.Impulse);
        }
        else if (randomnumber > 0)
        {
            Ballrb.AddForce(new Vector2(BallForceL3, 0), ForceMode2D.Impulse);

        }

    }

    public void LevelFour()
    {

        GameObject NewBall = gameManager.ballPrefab;

        SpawnedBall = Instantiate(NewBall, new Vector2(UnityEngine.Random.Range(-1.3f, 1.3f), UnityEngine.Random.Range(-3f, 3f)), quaternion.identity);
        SpawnedBall.transform.localScale = Vector2.one;
        SpawnedBall.transform.localScale = Vector2.one;
        Ballrb = SpawnedBall.GetComponent<Rigidbody2D>();
        Ballrb.bodyType = RigidbodyType2D.Kinematic;

    }
    #region Level 5
    public void LevelFive()
    {

        SpawnedBall = gameManager.SpawnBall();
        SpawnedBall.transform.localScale = Vector2.one;
        Ballrb = SpawnedBall.GetComponent<Rigidbody2D>();
        int randomnumber = UnityEngine.Random.Range(-2, 1);

        //Debug.Log(randomnumber);
        if (randomnumber <= 0)
        {
            Ballrb.AddForce(new Vector2(-13f, 0), ForceMode2D.Impulse);
        }
        else if (randomnumber > 0)
        {
            Ballrb.AddForce(new Vector2(13f, 0), ForceMode2D.Impulse);

        }

    }

    public void TwoSmallBallSpawn(float SmallBallFource, Vector2 SpawnPos)
    {
        
        GameObject SpawnedSmallBall1 = Instantiate(SmallBalls[0], SpawnPos, Quaternion.identity);
        GameObject SpawnedSmallBall2 = Instantiate(SmallBalls[1], SpawnPos, Quaternion.identity);

        aliveSmallBalls = 2;

        Rigidbody2D SmallBall1RB = SpawnedSmallBall1.GetComponent<Rigidbody2D>();
        Rigidbody2D SmallBall2RB = SpawnedSmallBall2.GetComponent<Rigidbody2D>();

        SmallBall1RB.AddForce(new Vector2 (SmallBallFource, SmallBallFource), ForceMode2D.Impulse);
        SmallBall2RB.AddForce(new Vector2 (-SmallBallFource, SmallBallFource), ForceMode2D.Impulse);

    }
    public void SpawnLevelFive()
    {
        aliveSmallBalls--;

        if (aliveSmallBalls <= 0)
        {
            LevelFive(); // invoke again after both destroyed
        }

    }
    #endregion


}

using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
   
    public  GameManager gameManager;
    private GameObject SpawnedBall;
    Rigidbody2D Ballrb;
    public float BallForce = 10f;
    float CurrectScaleOfBall = 1.3f;
    public GameObject _BombPreFab;
    public GameObject _2XBallPrefab;
    [HideInInspector]
    public bool isBombSpawned = false;
    public int BombDelayTime;


    public void BombBallSpawn()
    {
        isBombSpawned=true;
        GameObject Bomb = Instantiate(_BombPreFab, new Vector2(UnityEngine.Random.Range(-1.3f, 1.3f), UnityEngine.Random.Range(0f, 3f)), Quaternion.identity);
        Rigidbody2D BombRB = Bomb.GetComponent<Rigidbody2D>();
        int randomnumber = UnityEngine.Random.Range(-2, 1);

        //Debug.Log(randomnumber);
        if (randomnumber <= 0)
        {
            BombRB.AddForce(new Vector2(-10f, 0), ForceMode2D.Impulse);
        }
        else if (randomnumber > 0)
        {
            BombRB.AddForce(new Vector2(10f, 0), ForceMode2D.Impulse);

        }

        StartCoroutine(Bombelay(BombDelayTime));

    }

    IEnumerator Bombelay(int Delay)
    {
        yield return new WaitForSeconds(Delay);
        isBombSpawned = false;

    }

  

    public void TwoXBall()
    {
        GameObject TwoXBall = Instantiate(_2XBallPrefab, new Vector2(UnityEngine.Random.Range(-1.3f, 1.3f), UnityEngine.Random.Range(0f, 3f)), Quaternion.identity);
        Rigidbody2D BombRB = TwoXBall.GetComponent<Rigidbody2D>();
        int randomnumber = UnityEngine.Random.Range(-2, 1);

        //Debug.Log(randomnumber);
        if (randomnumber <= 0)
        {
            BombRB.AddForce(new Vector2(-10, 0), ForceMode2D.Impulse);
        }
        else if (randomnumber > 0)
        {
            BombRB.AddForce(new Vector2(10, 0), ForceMode2D.Impulse);

        }

    }

    #region Levels

    public void LevelOne()
    {
        gameManager.SpawnBall();
    }

    public void LevelTwo() 
    {
          
        SpawnedBall = gameManager.SpawnBall();
        
        Ballrb = SpawnedBall.GetComponent<Rigidbody2D>();

        if (gameManager.isBonusScoreActive)
        {
            Ballrb.bodyType = RigidbodyType2D.Kinematic;
        }

        else
        {

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
    }
    
    public void LevelThree()
    {
        CurrectScaleOfBall = CurrectScaleOfBall - 0.03f;
        float BallNewSize = Mathf.Max(CurrectScaleOfBall, 1f);
        BallForce += 0.5f;
        BallForce = Mathf.Clamp(BallForce, 10f, 18f);
        SpawnedBall = gameManager.SpawnBall();
        SpawnedBall.transform.localScale = Vector2.one * BallNewSize;
        Ballrb = SpawnedBall.GetComponent<Rigidbody2D>();

        if (gameManager.isBonusScoreActive)
        {
            Ballrb.bodyType = RigidbodyType2D.Kinematic;
        }

        else
        {

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

    }

    public void LevelFour()
    {
        CurrectScaleOfBall = CurrectScaleOfBall - 0.03f;
        float BallNewSize = Mathf.Max(CurrectScaleOfBall, 1f);
        BallForce += 0.5f;
        BallForce = Mathf.Clamp(BallForce, 10f, 25f);

            SpawnedBall = gameManager.SpawnBall();
            SpawnedBall.transform.localScale = Vector2.one * BallNewSize;
            Ballrb = SpawnedBall.GetComponent<Rigidbody2D>();

            if (gameManager.isBonusScoreActive)
            {
                Ballrb.bodyType = RigidbodyType2D.Kinematic;
            }

            else
            {

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

        



    }



    #endregion






}

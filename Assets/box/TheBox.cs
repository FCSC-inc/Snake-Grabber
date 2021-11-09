using UnityEngine;
using System.Collections;
public class TheBox : MonoBehaviour
{
    [SerializeField] GameObject SnekPrefab;
    [SerializeField] Transform[] spawnPositions;
    [SerializeField] Hand hand;
    [SerializeField] UIManager UI;
    [SerializeField] int maxSnakeMisses;
    [SerializeField] Sprite handSnake, snakeBiteHand;
    [SerializeField] float snakeBiteCheckDelay;
    [SerializeField] int snakeBiteOdds, snakeBiteOddsChangePerCatch;
    [SerializeField] float startingSnakeSpeed, snakeSpeedChangePerCatch;
    [SerializeField] bool shouldSnakeBite;
    int snakecatches, snakeMisses;
    float snakeSpeed;
    private void OnEnable()
    {
        shouldSnakeBite = GameSettings.shouldSnakeBite;
        snakeSpeed = startingSnakeSpeed;
        MakeSnake();
        UI.SetNumberOfSnakeMisses(snakeMisses, maxSnakeMisses);
    }
    void MakeSnake()
    {
        GameObject snake = Instantiate(SnekPrefab, spawnPositions[Random.Range(0, 3)]);
        snake.GetComponent<Snake>().Init(this, snakeSpeed);
    }
    public void MissSnake()
    {
        snakeMisses++;
        UI.SetNumberOfSnakeMisses(snakeMisses, maxSnakeMisses);
        if (snakeMisses == maxSnakeMisses)
        {
            hand.locked = true;
            hand.SetHandImage(snakeBiteHand);
            UI.DeathSequence();
        }
        StartCoroutine(newSnakeDelay());
    }
    public void CatchSnake()
    {
        snakeSpeed += snakeSpeedChangePerCatch;
        snakecatches++;
        snakeBiteOdds += snakeBiteOddsChangePerCatch;
        UI.SetNumberOfSnakeCatches(snakecatches);
        hand.locked = true;
        hand.SetHandImage(handSnake);
        StartCoroutine(handGrabDelay());
    }
    void SnakeBiteCheck()
    {
        if (Random.Range(0, snakeBiteOdds) == 0 && shouldSnakeBite)
        {
            hand.SetHandImage(snakeBiteHand);
            AudioManager.S.PlaySound("snakebite");
            UI.DeathSequence();
        }
        else
        {
            hand.locked = false;
            snakeMisses = 0;
            UI.SetNumberOfSnakeMisses(snakeMisses, maxSnakeMisses);
            StartCoroutine(newSnakeDelay());
        }
    }
    IEnumerator handGrabDelay()
    {
        yield return new WaitForSeconds(snakeBiteCheckDelay);
        SnakeBiteCheck();   
    }
    IEnumerator newSnakeDelay()
    {
        yield return new WaitForSeconds(snakeBiteCheckDelay);
        MakeSnake();
    }
}
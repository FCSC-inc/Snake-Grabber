using UnityEngine;
public class TheBox : MonoBehaviour
{
    [SerializeField] GameObject SnekPrefab;
    [SerializeField] Transform[] spawnPositions;
    [SerializeField] Hand hand;
    [SerializeField] 
    private void OnEnable()
    {
        GameObject snake = Instantiate(SnekPrefab, spawnPositions[Random.Range(0, 3)]);
        snake.GetComponent<Snake>().Init(this);
        hand.SetHandImage(null);
    }
}
using UnityEngine;
using UnityEngine.UI;
using SoulShard.Utils;
public class UIManager : MonoBehaviour
{
    [SerializeField] Text snakeMisses, snakeCatches;
    [SerializeField] Animator _deathAnim;
    [SerializeField] string deathSequenceName;
    public void SetNumberOfSnakeMisses(int num, int max)
    {
        snakeMisses.text = $"Snakes Missed: {num}/{max}";
    }
    public void SetNumberOfSnakeCatches(int num)
    {
        snakeCatches.text = $"Snakes Caught: {num}";
    }
    public void DeathSequence()
    {
        _deathAnim.Play(deathSequenceName);
        AudioManager.S.PlaySound("death");
    }
}
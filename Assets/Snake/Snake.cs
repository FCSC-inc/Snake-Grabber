using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Snake : MonoBehaviour
{
    [SerializeField] string beginAnimatonName;
    Animator _anim;
    TheBox _box;
    void OnEnable()
    {
        _anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        _box.CatchSnake();
        Destroy(gameObject);
    }
    void Destroy()
    {
        _box.MissSnake();
        Destroy(gameObject);
    }
    public void Init(TheBox box, float animSpeed)
    {
        _box = box;
        _anim.speed = animSpeed;
    }
}
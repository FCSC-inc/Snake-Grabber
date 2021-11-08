using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Snake : MonoBehaviour
{
    [SerializeField] string beginAnimatonName;
    Animator _anim;
    TheBox _box;
    void OnEnable()
    {
        _anim.speed = 0.1f;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    public void Init(TheBox box)
    {
        _box = box;
    }
}
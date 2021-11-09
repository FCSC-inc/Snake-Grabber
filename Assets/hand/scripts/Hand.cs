using UnityEngine;
public class Hand : MonoBehaviour
{
    [SerializeField] SpriteRenderer _cursorSpriteRenderer;
    [SerializeField] Vector2 Offset;
    [SerializeField] float PPU = 1;
    [SerializeField] Sprite Closed, Open;
    [SerializeField] BoxCollider2D handCollider;
    bool _isClosed;
    const float colliderTime = 0.1f;
    float timeSinceLast;
    [HideInInspector] public bool locked;
    private void OnEnable()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isClosed = true;
            handCollider.enabled = true;
            timeSinceLast = colliderTime;
        }

        if (Input.GetMouseButtonUp(0))
            _isClosed = false;
        if (!locked)
            SetHandImage(_isClosed ? Closed : Open);
        transform.position = (Camera.main.ScreenToWorldPoint(Input.mousePosition) + (Vector3)Offset) / PPU;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);


        timeSinceLast -= Time.deltaTime;
        if (timeSinceLast < 0)
            handCollider.enabled = false;
    }
    public void SetHandImage(Sprite sprite) => _cursorSpriteRenderer.sprite = sprite;
}
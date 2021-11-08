using UnityEngine;
public class Hand : MonoBehaviour
{
    [SerializeField] CursorManager cursor;
    [SerializeField] Sprite Closed, Open;
    bool _isClosed;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isClosed = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isClosed = false;
        }
        cursor.SetCursorImage(_isClosed ? Closed : Open);
    }
}
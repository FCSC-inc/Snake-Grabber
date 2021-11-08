using UnityEngine;
using UnityEngine.UI;
// manages the image and position of the virtual cursor (hides the actual cursor so we can make a cooler looking cursor)
public class CursorManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer _cursorSpriteRenderer;
    [SerializeField] Vector2 Offset;
    [SerializeField] float PPU = 1;
    #region Methods
    public void SetCursorImage(Sprite sprite) => _cursorSpriteRenderer.sprite = sprite;
    private void OnEnable() => Cursor.visible = false;
    private void Update()
    {
        transform.position = (Camera.main.ScreenToWorldPoint(Input.mousePosition) + (Vector3)Offset) / PPU;
        transform.position = new Vector3(transform.position.x,transform.position.y,0);
    }
    #endregion
}

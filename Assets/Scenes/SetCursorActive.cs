using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursorActive : MonoBehaviour
{
    [SerializeField] bool cursorIsVisible;
    private void OnEnable()
    {
        Cursor.visible = cursorIsVisible;
    }
}

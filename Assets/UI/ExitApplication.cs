using UnityEngine;
public class ExitApplication : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("QUITTING");
        Application.Quit();
    }
}
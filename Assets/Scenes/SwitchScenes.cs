using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchScenes : MonoBehaviour
{
    [SerializeField] int index;
    public void SwitchScene(int index) =>
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    public void SwitchScene() =>
        SwitchScene(index);
}
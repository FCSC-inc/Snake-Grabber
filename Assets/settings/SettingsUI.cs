using UnityEngine;
using UnityEngine.UI;
public class SettingsUI : MonoBehaviour
{
    public Text shouldSnakeBiteText;
    public string shouldSnakeBiteName;
    private void OnEnable()
    {
        SetShouldSnakeBite(true);
    }
    public void ToggleShouldSnakeBite()
    {
        GameSettings.shouldSnakeBite = !GameSettings.shouldSnakeBite;
        shouldSnakeBiteText.text = GetBoolPropertyString(shouldSnakeBiteName, GameSettings.shouldSnakeBite);
    }
    public void SetShouldSnakeBite(bool state)
    {
        GameSettings.shouldSnakeBite = state;
        shouldSnakeBiteText.text = GetBoolPropertyString(shouldSnakeBiteName, GameSettings.shouldSnakeBite);
    }
    string GetBoolPropertyString(string name, bool state)
    {
        string stateName = state ? "yes" : "no";
        return $"{name}:{stateName}";
    }
}
using UnityEngine;
[CreateAssetMenu(menuName = "SoulShardUtils/Sounds/SoundByte")]
public class SoundByte: ScriptableObject
{
    [HideInInspector] public AudioSource Source;
    public string Name;
    public bool Loop, PlayOnAwake;
    public Sound[] possibleSounds;
}
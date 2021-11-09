using UnityEngine;
[System.Serializable]
public class Sound
{
    [Range(0f, 1f)] public float Volume;
    [Range(.1f, 3f)] public float Pitch;
    public AudioClip audio;
}

﻿using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixerGroup _mixer;
    public static AudioManager S { get; private set; }
    public SoundByte[] sounds;
    void Awake()
    {
        S = this;
        foreach (SoundByte S in sounds)
            InitializeAudioClip(S);
    }
    void InitializeAudioClip(SoundByte sound)
    {
        if (sound.possibleSounds.Length == 0)
            sound.name = "";
        sound.Source = gameObject.AddComponent<AudioSource>();
        sound.Source.outputAudioMixerGroup = _mixer;
        sound.Source.playOnAwake = sound.PlayOnAwake;
        sound.Source.loop = sound.Loop;
        RandomizeAudioClip(sound);
        if (sound.PlayOnAwake)
            sound.Source.Play();
    }
    void RandomizeAudioClip(SoundByte sound)
    {
        int index = Random.Range(0, sound.possibleSounds.Length);
        sound.Source.clip = sound.possibleSounds[index].audio;
        sound.Source.volume = sound.possibleSounds[index].Volume;
        sound.Source.pitch = sound.possibleSounds[index].Pitch;
    }
    public void PlaySound(SoundByte sound)
    {
        RandomizeAudioClip(sound);
        sound.Source.Play();
        Debug.Log(sound.name);
    }
    public void StopSound(SoundByte sound) => sound.Source.Stop();
    public void StopSound(string SoundName) => StopSound(ConvertSoundNameToSound(SoundName));
    public void PlaySound(string SoundName) => PlaySound(ConvertSoundNameToSound(SoundName));
    public SoundByte ConvertSoundNameToSound(string SoundName)
    {
        foreach (SoundByte S in sounds)
            if (S.Name.ToLower() == SoundName.ToLower() && S.name != "")
                return S;
        return null;
    }
}
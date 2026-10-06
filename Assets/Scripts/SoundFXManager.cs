using UnityEngine;

public class SoundFXManager : MonoBehaviour
{/*This class is what's called a "SINGLETON". This is a very dangerous class
  and you may have to elminate it all together if issues arise.
    
  Basically, it can be accessed gloabally throughout the scene (maybe even the project. Find out ASAP)
    
  This singleton will be used later to make a sound settings menu where you will have sliders that can 
    control the Master volume, Sound FX, and Music.*/
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (instance == null)
        {

            instance = this;
        }
    }

    public void playAudioFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);

        //Figure out a way to use an array to call different sound effects that you have made. WATCH THE VIDEO BY 'Sasquatch B Studios'!!!!
    }
}
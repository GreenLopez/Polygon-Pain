using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if(instance == null) {
        
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

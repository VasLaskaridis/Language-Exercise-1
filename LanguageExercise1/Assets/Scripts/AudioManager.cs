using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [System.NonSerialized]
    public Sound sound = null;

    // Start is called before the first frame update
    void Awake(){
    }

    public void PlayQuestionAudio(string name){
        if(sound==null){
            sound = new Sound();
        }
        sound.source = gameObject.AddComponent<AudioSource>();
        sound.source.PlayOneShot(Resources.Load<AudioClip> ("Audio/Questions/"+name));
    }

    
    public void PlayAnswerAudio(string name){
         if(sound==null){
            sound = new Sound();
        }
        sound.source = gameObject.AddComponent<AudioSource>();
        sound.source.PlayOneShot(Resources.Load<AudioClip> ("Audio/Answers/"+name));
    }

    public void StopALLAudio(){
         if(sound!=null){
            if(sound.source.isPlaying){
                sound.source.Stop();
            }
        }
    }
}

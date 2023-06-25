using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] options;
    public GameObject[] correct_options;
    public GameObject[] answers;
    public GameObject[] markers;
    public GameObject headphone;
    public GameObject reset;
    public GameObject teacher;
    public AudioManager audioManager;

    private int soundArrayPointer;

    private bool allSolved = false;

    void Awake(){
        soundArrayPointer = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        setOptionsEnabled(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(audioManager.sound != null){
            if (audioManager.sound.source.isPlaying && headphone.GetComponent<Headphone_click>().getAnimatorClickTrigger())
            {
                setOptionsEnabled(true);
            } 
        }

        if(!allSolved){
            if(headphone.GetComponent<Headphone_click>().getSoundClickTrigger() == true){
                    string name ="" + getSoundArrayPointer();
                    audioManager.PlayQuestionAudio(name);
                    headphone.GetComponent<Headphone_click>().setSoundClickTrigger(false);
            }
          
            for(int i=0; i<options.Length; i++){
                if(options[i].GetComponent<Option_click>().getOptionChosen()){
                    if(options[i].name == correct_options[getSoundArrayPointer()].name){
                        options[i].GetComponent<Option_click>().setBeginOptionAnimation(true); 
                        teacher.GetComponent<Animator>().Play("teacher_correct_ans");
                        setOptionsEnabled(false);
                        if(getSoundArrayPointer()+1<correct_options.Length){
                            setSoundArrayPointer(getSoundArrayPointer()+1);
                            headphone.GetComponent<Headphone_click>().setAnimatorClickTrigger(false);
                        }else{
                            allSolved=true;
                            teacher.GetComponent<Animator>().Play("teacher_clap");
                        }
                    }else{
                        teacher.GetComponent<Animator>().Play("teacher_wrong_ans");
                    }
                    options[i].GetComponent<Option_click>().setOptionChosen(false);
                }
            }
        }

        for(int i=0; i<correct_options.Length; i++){
                if(correct_options[i].GetComponent<Option_click>().getBeginAnswerAnimation()){
                    answers[i].transform.position = new Vector3(GameObject.Find("marker").transform.position.x,GameObject.Find("marker").transform.position.y,0);
                    answers[i].GetComponent<Answer_click>().setMarker(markers[i]);
                    answers[i].GetComponent<Answer_click>().setBeginAnimation(true);
                    correct_options[i].GetComponent<Option_click>().setBeginAnswerAnimation(false);
                }
                if(answers[i].GetComponent<Answer_click>().getSoundClickTrigger()){
                    audioManager.PlayAnswerAudio(""+i);
                    answers[i].GetComponent<Answer_click>().setSoundClickTrigger(false);
                }
         }

         if(reset.GetComponent<Reset_click>().getResetClicked()){
            initialise();
         }
    }

    public void initialise(){
        audioManager.StopALLAudio();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void setSoundArrayPointer(int i){
        soundArrayPointer=i;
    }

    public int getSoundArrayPointer(){
        return soundArrayPointer;
    }

    public void setOptionsEnabled(bool mode){
         foreach(GameObject obj in options){
            obj.GetComponent<Option_click>().setOptionUnlocked(mode);
         }

    }

    
}

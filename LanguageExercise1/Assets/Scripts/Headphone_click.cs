using UnityEngine;

public class Headphone_click : MonoBehaviour
{
    Animator m_animator = null;

    private bool animatorClickTrigger;

    private bool soundClickTrigger;

    // Start is called before the first frame update
    void Awake()
    {
        m_animator = GetComponent<Animator>();
        setAnimatorClickTrigger(false);
        setSoundClickTrigger(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnMouseDown()
    {
       setAnimatorClickTrigger(true);
       setSoundClickTrigger(true);
    }

    public bool getAnimatorClickTrigger(){
        return animatorClickTrigger;
    }
    public void setAnimatorClickTrigger(bool mode){
        animatorClickTrigger = mode;
        m_animator.SetBool("enabled", animatorClickTrigger);
    }

    public bool getSoundClickTrigger(){
        return soundClickTrigger;
    }
    public void setSoundClickTrigger(bool mode){
        soundClickTrigger = mode;
    }

}

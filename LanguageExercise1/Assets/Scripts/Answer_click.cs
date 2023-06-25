using UnityEngine.EventSystems;
using UnityEngine;

public class Answer_click : MonoBehaviour, IPointerDownHandler
{
    private bool beginAnimation;

    private bool soundClickTrigger;

    private GameObject marker;

    void Start()
    {
        setBeginAnimation(false);
    }

    void Update()
    {   
        if(beginAnimation){
            transform.SetAsLastSibling();
            transform.position -= new Vector3(0,3* Time.deltaTime,0);
            
            if ( transform.position.y <= marker.transform.position.y) {
                setBeginAnimation(false);
            } 
        }
        
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData data){
         setSoundClickTrigger(true);
    }

    public void setBeginAnimation(bool mode){
        beginAnimation = mode;
    }

    public bool getBeginAnimation(){
        return beginAnimation;
    }

    public bool getSoundClickTrigger(){
        return soundClickTrigger;
    }
    public void setSoundClickTrigger(bool mode){
        soundClickTrigger = mode;
    }

    public void setMarker(GameObject m){
        marker = m;
    }


}


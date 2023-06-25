using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Option_click : MonoBehaviour, IPointerDownHandler
{
    private bool beginOptionAnimation;

    private bool beginAnswerAnimation;

    private bool optionChosen;

    private int optionPosition;

    private bool optionUnlocked;

    // Start is called before the first frame update
    void Start()
    {
        setBeginOptionAnimation(false);
        setBeginAnswerAnimation(false);
        setOptionChosen(false);
        setOptionUnlocked(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(beginOptionAnimation){
            transform.SetAsLastSibling();
            transform.position += new Vector3(0,3* Time.deltaTime,0);
        
            Vector3[] v = new Vector3[4];
            GetComponent<RectTransform>().GetWorldCorners (v);

            //float maxY = Mathf.Max (v [0].y, v [1].y, v [2].y, v [3].y);
            float minY = Mathf.Min (v [0].y, v [1].y, v [2].y, v [3].y);

            //No need to check horizontal visibility: there is only a vertical scroll rect
            //float maxX = Mathf.Max (v [0].x, v [1].x, v [2].x, v [3].x);
            //float minX = Mathf.Min (v [0].x, v [1].x, v [2].x, v [3].x);
            
            if ( minY > 10) {
                setBeginOptionAnimation(false);
                setBeginAnswerAnimation(true);
            } 
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData data){
        if(optionUnlocked){
            setOptionChosen(true);
        }
    }

    public bool getOptionChosen(){
        return optionChosen;
    }
    public void setOptionChosen(bool mode){
        optionChosen = mode;
    }

    public bool getOptionUnlocked(){
        return optionUnlocked;
    }
    public void setOptionUnlocked(bool mode){
        optionUnlocked = mode;
    }

    public void setBeginOptionAnimation(bool mode){
         beginOptionAnimation = mode;
    }

    public bool getBeginOptionAnimation(){
        return beginOptionAnimation;
    }

    public void setBeginAnswerAnimation(bool mode){
         beginAnswerAnimation = mode;
    }

    public bool getBeginAnswerAnimation(){
        return beginAnswerAnimation;
    }


}

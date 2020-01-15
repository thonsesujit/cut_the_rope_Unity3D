using UnityEngine;

public class dragging : MonoBehaviour {

    public GameObject menuPanel;
    Touch initTouch;
    bool swiped = false;



	
	// Update is called once per frame
	void Update () {
        foreach(Touch t in Input.touches)
        {

            if(t.phase == TouchPhase.Began)
            {
                initTouch = t;
            }
            else if(t.phase ==TouchPhase.Moved)
            {
                float xMoved = initTouch.position.x - t.position.x;
                float yMoved = initTouch.position.y - t.position.y;
                float distance = Mathf.Sqrt(xMoved * xMoved) + (yMoved * yMoved);             //h2 = p^2 + b^2  calcualte the distance that we drag our finger in screen
                bool swipedLeft = Mathf.Abs(xMoved) > Mathf.Abs(yMoved);

                if(distance > 50f)
                {
                    if(swipedLeft && xMoved > 0)  //swiped left
                    {
                        menuPanel.transform.Translate(-5, 0, 0);
                    }
                    else if(swipedLeft && xMoved < 0) //Swipe right
                    {
                        menuPanel.transform.Translate(5, 0, 0);
                    }
                    else if (swipedLeft == false && yMoved > 0) //Swipe up
                    {
                        menuPanel.transform.Translate(0, -5, 0);
                    }
                    else if (swipedLeft == false && yMoved < 0) //Swipe down
                    {
                        menuPanel.transform.Translate(0, 5, 0);
                    }
                    swiped = true;
                }
            }
            else if(t.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
                swiped = false;
            }
        }
		
	}
}

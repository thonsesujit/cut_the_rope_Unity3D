using UnityEngine;
/// <summary>
///  Make an empty game object and add this code as a compoent in the inspector window in Unity . This script is for cutting the rope . 
/// </summary>


public class RopeCutter : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if (hit.collider != null)
			{
				if (hit.collider.tag == "Link")
				{
					Destroy(hit.collider.gameObject);
                    Destroy(hit.transform.parent.gameObject,2f);  // comment this line if you dont want to destroy parent object.
				}
			}
		}
	}
}

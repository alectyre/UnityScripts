using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ClickedOutsideRectTransform : MonoBehaviour {

	void Update()
	{
		if(Input.GetMouseButtonDown(0) &&
		    !RectTransformUtility.RectangleContainsScreenPoint(
			    GetComponent<RectTransform>(), 
			    Input.mousePosition, 
			    null)) //If NOT using ScreenSpace.Overlay then pass in Canvas's camera
		{
			//Click was outside RectTransform
		}
        else
        {
            //Click was inside RectTransform
        }
	}
}

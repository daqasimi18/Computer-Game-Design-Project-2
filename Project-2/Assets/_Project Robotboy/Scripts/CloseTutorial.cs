using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseTutorial : MonoBehaviour
{
	public GameObject CloseButton;
	PointerEventData ped;
	
    // Start is called before the first frame update
    void Start()
    {
        ped = new PointerEventData(EventSystem.current);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return"))
		{
			ExecuteEvents.Execute(CloseButton, ped, ExecuteEvents.pointerEnterHandler);
			ExecuteEvents.Execute(CloseButton, ped, ExecuteEvents.submitHandler);
		}
    }
}

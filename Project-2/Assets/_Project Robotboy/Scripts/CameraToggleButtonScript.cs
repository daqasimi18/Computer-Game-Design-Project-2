using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraToggleButtonScript : MonoBehaviour
{
	public GameObject CameraToggle;
	//public UnityEngine.UI.Button CameraToggle;
	
	PointerEventData ped;
	
    // Start is called before the first frame update
    void Start()
    {
        ped = new PointerEventData(EventSystem.current);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
		{
			ExecuteEvents.Execute(CameraToggle, ped, ExecuteEvents.pointerEnterHandler);
			ExecuteEvents.Execute(CameraToggle, ped, ExecuteEvents.submitHandler);
			//CameraToggle.onClick.Invoke();
		}
	
    }
}

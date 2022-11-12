using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraToggleButtonScript : MonoBehaviour
{
	public UnityEngine.UI.Button CameraToggle;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
		{
			CameraToggle.onClick.Invoke();
		}
	
    }
}

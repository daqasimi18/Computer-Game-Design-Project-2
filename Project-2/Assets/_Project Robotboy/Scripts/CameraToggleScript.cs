using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraToggleScript : MonoBehaviour
{
	Quaternion sideViewRotation = new Quaternion(0.0958457142f,0f,0f,0.995396256f);
	public float sideViewField;
	Quaternion topViewRotation = new Quaternion(0.382683426f,0f,0f,0.923879564f);
	public float topViewField;
	
	bool sideView;
	CinemachineVirtualCamera camera;
	
    // Start is called before the first frame update
    void Start()
    {
		sideView = false;
		camera = GetComponent<CinemachineVirtualCamera>();
		ChangeView();
        
    }
	
	public void ChangeView()
	{
		if (sideView){
			transform.rotation = topViewRotation;
			camera.m_Lens.FieldOfView = topViewField;
			sideView = false;
		}
		else{
			transform.rotation = sideViewRotation;
			camera.m_Lens.FieldOfView = sideViewField;
			sideView = true;
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

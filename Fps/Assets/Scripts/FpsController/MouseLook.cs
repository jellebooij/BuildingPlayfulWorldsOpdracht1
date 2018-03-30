using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    [SerializeField]
    float m_Sensitivity;

    Vector2 m_Rotation;
	
	void Update () {

        m_Rotation += new Vector2(-Input.GetAxisRaw("Mouse Y"),  Input.GetAxisRaw("Mouse X")) * m_Sensitivity;


        transform.eulerAngles = m_Rotation;

    }
}

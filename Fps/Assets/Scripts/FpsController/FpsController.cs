using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FpsController : MonoBehaviour {

    [SerializeField]
    Camera m_Camera;

    [SerializeField]
    float m_Speed;

    [SerializeField]
    float m_BobAmount;

    [SerializeField]
    float m_BobSpeed;

    float timer;

    public GunBase gun;

    Vector3 m_Input;

    CharacterController m_Controller;
    float bobTimer;
    GunEffectController effect;

	void Start () {
        timer = 10;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        effect = GetComponent<GunEffectController>();
        m_Controller = GetComponent<CharacterController>();

		if(m_Camera == null)
        {
            m_Camera = Camera.main;
        }

      
	}
	
	void Update () {

        timer += Time.deltaTime;
        if(timer > 10)
        {
            gun.bonus = false;
        }

        m_Input.x = Input.GetAxisRaw("Horizontal");
        m_Input.z = Input.GetAxisRaw("Vertical");

        transform.eulerAngles = new Vector3(transform.rotation.x, m_Camera.transform.eulerAngles.y, transform.rotation.z);

        Vector3 direction = ((transform.forward * m_Input.z) + (transform.right * m_Input.x)).normalized;

        m_Controller.Move(direction * m_Speed * Time.deltaTime);

        HeadBob(direction.magnitude);

        if (Input.GetMouseButton(0))
        {
            if(gun.Shoot())
            effect.Play();
        }

	}

    void HeadBob(float speed)
    {
        bobTimer += speed / m_Speed;

        if (bobTimer > Mathf.PI * 2)
        {
            bobTimer = bobTimer - (Mathf.PI * 2);
        }

        float cameraHeight = transform.position.y + (m_Controller.height / 2) + Mathf.Sin(bobTimer * m_BobSpeed) * m_BobAmount;

        m_Camera.transform.position = new Vector3(transform.position.x, cameraHeight ,transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bonus")
        {
            gun.bonus = true;
            timer = 0;
            Destroy(other.gameObject);

        }
    }
}

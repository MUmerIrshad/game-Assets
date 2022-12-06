using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject dummyBall;
    public Transform Bulletspawnposition;
    public Vector3 Rotate;
    public float speed;
    public float mouseSensitivity = 100f;
    public GameObject instanceBall;

    // Start is called before the first frame update
    void Start()
    {
        CreateBall();
        // in play mode Lock Cursor
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
    
        // adding in the rotation with Quaternion in X-Axis
        Rotate.x += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0f, -Rotate.x, 0f);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Umer");
            instanceBall.GetComponent<Rigidbody>().AddForce(instanceBall.transform.forward * speed);
            CreateBall();

        }
    }
    private void CreateBall()
    {
        instanceBall = Instantiate(dummyBall, Bulletspawnposition.position, Quaternion.identity);
        //instanceBall.SetActive(true);

        instanceBall.tag = "NewBall";
        instanceBall.gameObject.layer = LayerMask.NameToLayer("Default");

        SetBallColor(instanceBall);
    }
    private void SetBallColor(GameObject go)
    {
        BallColor randColor = MoveBalls.GetRandomBallColor();

        switch (randColor)
        {
            case BallColor.red:
                go.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                break;

            case BallColor.green:
                go.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                break;

            case BallColor.blue:
                go.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                break;

            case BallColor.yellow:
                go.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                break;
        }
    }
}

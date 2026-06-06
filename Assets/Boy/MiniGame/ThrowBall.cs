using StarterAssets;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ThrowBall : MonoBehaviour
{
    public float maxYRotation = 30;
    public float xRotation,yRotation;
    public float senitivity = 1f;
    public float gravityScale;
    public float MaxThrowForce;
    public float ThrowForce;
    public bool ischarge;
    public GameObject BallPrefab;
    public GameObject Ball;
    public float ChargeSpeed;
    float a;
    public Slider ForceBar;
    void Start()
    {
        a = ChargeSpeed;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ForceBar.maxValue = MaxThrowForce;
        ForceBar.value = 0;
        Reball();
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * senitivity;
        float mouseY = Input.GetAxis("Mouse Y") * senitivity;

        xRotation -= mouseY;
        yRotation -= mouseX;
        xRotation = Mathf.Clamp(xRotation, -maxYRotation, maxYRotation);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation*-1, 0f);
        //Vector3 dir = transform.eulerAngles;
        //transform.Rotate(0,mouseX*senitivity,0);
        if (Ball != null)
        {
            if (!Ball.GetComponent<Rigidbody>().useGravity)
            {
                GetComponentInChildren<LineRenderer>().enabled = true;
                ThrowingBall();
            }
            else
            {
                GetComponentInChildren<LineRenderer>().enabled = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindFirstObjectByType<EventTrigger>().Player.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    public void Reball()
    {
        GameObject ball = Instantiate(BallPrefab);
        ball.transform.parent = transform;
        ball.transform.localPosition = new Vector3(0, -1, 1.25f);
        ball.transform.localEulerAngles = Vector3.zero;
        ball.GetComponent<Ball>().tb = this;
        Ball = ball;
    }
    public void ThrowingBall()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowForce = 0;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (ThrowForce > MaxThrowForce)
            {
                a = ChargeSpeed*-1;
            }
            else if(ThrowForce < 0)
            {
                a = ChargeSpeed;
            }
            ThrowForce += (a * Time.deltaTime);
            ischarge = true;
        }
        GetComponentInChildren<DrawParabola>().launchVelocity = ThrowForce;
        Ball.GetComponent<Ball>().launchVelocity = ThrowForce;
        if (ischarge && Input.GetKeyUp(KeyCode.Space))
        {
            Rigidbody rb = Ball.GetComponent<Rigidbody>();
            rb.useGravity = true;
            Ball.transform.parent = null;
            Ball.GetComponent<Ball>().Shoot();
        }
        ForceBar.value = ThrowForce;
    }
}
using StarterAssets;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class Navigation : MonoBehaviour
{
    private NavMeshAgent nav;
    private LineRenderer line;
    public Transform[] Targets;
    public Button[] Buttons;
    public Transform Target;
    public float DistancefromTarget;
    public TextMeshProUGUI DistText;
    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        line = GetComponent<LineRenderer>();
    }

    void Start()
    {
        nav.isStopped = true;
        SetButtons();
        DistText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Target != null)
        {
            DrawPath();
            DistancefromTarget = Dist();
        }
        else
        {
            return;
        }
        if (nav.isOnNavMesh && transform.position != transform.parent.position)
        {
            transform.position = transform.parent.position;
        }
        else
        {
            return;
        }
    }
    public float Dist()
    {
        float dist = 0;
        Vector3[] point = nav.path.corners;
        for (int i = 1; i < nav.path.corners.Length; i++)
        {
            dist += Vector3.Distance(point[i - 1], point[i]);
        }
        return dist;
    }
    public void SetButtons()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            int I = i;
            Buttons[I].onClick.AddListener(() => tp(I));
        }
        DistText.gameObject.SetActive(true);
    }
    public void setpart(int I)
    {
        Target = Targets[I];
        print(I);
        nav.SetDestination(Target.position);
        line.enabled = true;
        DistText.gameObject.SetActive(true);
    }
    public void tp(int i)
    {
        transform.parent.GetComponent<ThirdPersonController>().enabled = false;
        transform.parent.position = Targets[i].position;
        transform.parent.GetComponent<ThirdPersonController>().enabled = true;
    }
    public void DrawPath()
    {
        SetDistText();
        Vector3[] Corner = nav.path.corners;
        line.positionCount = Corner.Length;
        for (int i = 0; i < Corner.Length; i++)
        {
            Vector3 tarpos = Corner[i];
            tarpos.y += 1;

            line.SetPosition(i, tarpos);
        }

        if (Vector3.Distance(transform.position, Target.position) < 1)
        {
            DistText.gameObject.SetActive(false);
            line.enabled = false;
            Target = null;
        }
        else
        {
            return;
        }
    }
    public void SetDistText()
    {
        DistText.gameObject.transform.LookAt(Camera.main.transform.position);
        DistText.text = "Disance Remaining: "+Dist().ToString("0.00");
    }
}

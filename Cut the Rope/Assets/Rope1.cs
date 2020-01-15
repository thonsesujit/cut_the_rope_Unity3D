using System.Collections.Generic;
using UnityEngine;

public class Rope1 : MonoBehaviour {

	public Rigidbody2D hook1;
    public Weight hook2;
    public GameObject linkPrefab;

    private int links = 7;

    private float distance;
    public float linkFactor = 1;

    private Vector3 hook1Pos;
    private Vector3 hook2Pos;


    private List<GameObject> joints = new List<GameObject>();

    void Start () {
       GenerateRopeV3();
	}

    void Update()
    {
        UpdateRopeV2();

    }

   

    private void GenerateRopeV3()
    {
        Rigidbody2D previousRB = hook1;

        CalculateNumberOFLinks();

        for (int i = 0; i < links; i++)
        {
            GameObject link = Instantiate(linkPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;
            joints.Add(link);

            if (i < links - 1)

            {
                previousRB = link.GetComponent<Rigidbody2D>();
            }
            else
            {
                hook2.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
            }
        }
    }

    private void UpdateRopeV2()
    {
        int oldLink = links;
        CalculateNumberOFLinks();

        if (links < oldLink)
        {
            if (joints.Count != 0)
            {
                Destroy(joints[0]);
                joints.RemoveAt(0);
                joints[0].GetComponent<HingeJoint2D>().connectedBody = hook1;
            }

            if (joints.Count == 0)
            {
                GenerateRopeV3();
            }

        }

        else if (links > oldLink)
        {
            Rigidbody2D previousRB = hook1;

            if (joints.Count != 0)
            {
                joints[0].GetComponent<HingeJoint2D>().connectedBody = null;
                GameObject link = Instantiate(linkPrefab, transform);
                HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
                joint.connectedBody = previousRB;
                joints.Insert(0, link);
                joints[1].GetComponent<HingeJoint2D>().connectedBody = joints[0].GetComponent<Rigidbody2D>();
                                       
            }
        }
    }
    void CalculateNumberOFLinks()
    {
        hook1Pos = hook1.transform.position;
        hook2Pos = hook2.transform.position;
        distance = Vector3.Distance(hook1Pos, hook2Pos);
        links = (int)(distance * linkFactor);
    }


}

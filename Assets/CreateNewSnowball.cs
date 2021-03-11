using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System.Linq;

public class CreateNewSnowball : MonoBehaviour
{
    public XRDirectInteractor Hand;
    public XRNode GetXRNode;
    private Vector3 handPosition;
    private List<XRNodeState> nodeStates = new List<XRNodeState>();
    public GameObject snowballPrefab;
    private GameObject spawnedSnowball;
    private bool leftholding;
    private bool rightholding;

    // Start is called before the first frame update
    void Start()
    {
        leftholding = false;
        rightholding = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log('1');
        InputTracking.GetNodeStates(nodeStates);
        //Debug.Log('2');
        XRNodeState handPos = nodeStates.Find(node => node.nodeType == GetXRNode);
        //Debug.Log('3');
        handPos.TryGetPosition(out handPosition);
        //Debug.Log('4');
       
            //Debug.Log(handPosition);
            //Debug.Log('5');
            //Debug.Log(Hand.isSelectActive);
            if (Hand.name == "Right Hand") {
                Debug.Log(rightholding + " 1");
                if (handPosition.y <= 0.05f && !rightholding)
                {
                    Debug.Log(rightholding + " 2");
                    spawnedSnowball = Instantiate(snowballPrefab, transform.position, Quaternion.identity);
                }
                Debug.Log(rightholding + " 3");
            }
            else
            {
                Debug.Log(leftholding + " 1");
                if (handPosition.y <= 0.05f && !leftholding)
                {
                    Debug.Log(leftholding + " 2");
                    spawnedSnowball = Instantiate(snowballPrefab, transform.position, Quaternion.identity);
                }
                Debug.Log(leftholding + " 3");
            }
    }

    public void updaterightHolding()
    {
        if (rightholding == true)
        {
            rightholding = false;
        }
        else
        {
            rightholding = true;
        }
    }
    public void updateleftHolding()
    {
        if (leftholding == true)
        {
            leftholding = false;
        }
        else
        {
            leftholding = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System.Linq;

public class CreateNewSnowball : MonoBehaviour
{
    public XRNode GetXRNode;
    private Vector3 handPosition;
    private XRNodeState handPos;
    private List<XRNodeState> nodeStates = new List<XRNodeState>();
    public GameObject snowballPrefab;
    private GameObject spawnedSnowball;

    // Start is called before the first frame update
    void Start()
    {
        InputTracking.GetNodeStates(nodeStates);

        nodeStates.Find(node => node.nodeType == GetXRNode);
    }

    // Update is called once per frame
    void Update()
    {
        handPos.TryGetPosition(out handPosition);

        if (handPosition.y <= 0.1f)
        {
            spawnedSnowball = Instantiate(snowballPrefab, transform);
        }

    }
 
}

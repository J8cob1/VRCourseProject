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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log('1');
        InputTracking.GetNodeStates(nodeStates);
        Debug.Log('2');
        XRNodeState handPos = nodeStates.Find(node => node.nodeType == GetXRNode);
        Debug.Log('3');
        handPos.TryGetPosition(out handPosition);
        Debug.Log('4');
        if (handPosition.y != null)
        {
            Debug.Log(handPosition);
            Debug.Log('5');
            if (handPosition.y <= 0.5f && Hand.isSelectActive)
            {
                Debug.Log("Snowball");
                spawnedSnowball = Instantiate(snowballPrefab, new Vector3(handPosition.x, .3f, handPosition.z), Quaternion.identity);
            }
        }

    }
 
}

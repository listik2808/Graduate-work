using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracerPlayer : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _xOffSet;

    private void Update()
    {
        transform.position = new Vector3(_target.transform.position.x - _xOffSet, transform.position.y,transform.position.z); 
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class PatrolBehaviour : MonoBehaviour
{

    [SerializeField] 
    private Transform[] _targets ;
    [SerializeField] 
    private float _speed = 5;
    [SerializeField]
    private float _waitingTime;
    
    private float _startWaitingTime;
    private int _target;

    private void Start()
    {
        _startWaitingTime = _waitingTime;
    }

    private void Update()
    {

        var travelDistanse = _speed * Time.deltaTime;
        var newPosition = Vector3.MoveTowards(transform.position, _targets[_target].position, travelDistanse);
            transform.LookAt(_targets[_target]);
            transform.position = newPosition;
            if (Vector3.Distance(transform.position,_targets[_target].position)<0.2f)
            {
                if (_waitingTime<=0)
                {
                    _target++;
                    if (_target == _targets.Length)
                    {
                        _target = 0;
                    }

                    _waitingTime = _startWaitingTime;
                }
                else
                {
                    _waitingTime -= Time.deltaTime;
                }
            }
            
    }
}

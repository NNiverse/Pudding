﻿using UnityEngine;
using Pudding.StateMachine;
using Pudding.StateMachine.ScriptableObjects;
using UnityEngine.UIElements;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "PullPointAction", menuName = "State Machines/Actions/Pull Point Action")]

public class PullPointActionSO : StateActionSO<PullPointAction>
{
    public LayerMask PointLayerMask;
}

public class PullPointAction : StateAction
{
	protected new PullPointActionSO _originSO => (PullPointActionSO)base.OriginSO;


    private Transform _transform;
	private InteractionManager _interactionManager;

	public override void Awake(StateMachine stateMachine)
	{
        _transform = stateMachine.GetComponent<Transform>();
        _interactionManager = stateMachine.GetComponent<InteractionManager>();
	}

    public override void OnUpdate()
    {
        _transform.rotation = _interactionManager.currentInteractiveObject.transform.rotation * Quaternion.Euler(new Vector3(180f,-90.0f,0f));
		_transform.position = _interactionManager.currentInteractiveObject.transform.position + _transform.up * 1.0f + _transform.right * 0.5f;
    }
}
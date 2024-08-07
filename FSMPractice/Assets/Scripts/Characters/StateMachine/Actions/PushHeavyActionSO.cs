﻿using UnityEngine;
using Pudding.StateMachine;
using Pudding.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "PushHeavyAction", menuName = "State Machines/Actions/Push Heavy Action")]
public class PushHeavyActionSO : StateActionSO
{
	protected override StateAction CreateAction() => new PushHeavyAction();
}

public class PushHeavyAction : StateAction
{
    //protected new PushHeavyActionSO _originSO => (PushHeavyActionSO)base.OriginSO;

    private InteractionManager _interactionManager;

    public override void Awake(StateMachine stateMachine)
    {
        _interactionManager = stateMachine.GetComponent<InteractionManager>();
    }

    public override void OnStateExit()
    {
        _interactionManager.currentInteractionType = InteractionType.None;
        _interactionManager.currentInteractiveObject = null;
    }

    public override void OnUpdate() { }
}

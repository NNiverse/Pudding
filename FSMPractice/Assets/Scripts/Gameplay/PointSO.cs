using UnityEngine;

[CreateAssetMenu(fileName = "RespawnPoint", menuName = "Scene Data/Point")]
public class PointSO : SerializableScriptableObject 
{
    public Vector3 position;
}
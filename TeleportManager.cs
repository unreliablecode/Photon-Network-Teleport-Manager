using UnityEngine;
using Photon.Pun;

public class TeleportManager : MonoBehaviourPunCallbacks
{
    [Header("GameObject Settings")]
    public GameObject targetObject;

    [Header("Position")]
    public Vector3 newPosition = Vector3.zero;

    [Header("Rotation (Euler Angles)")]
    public Vector3 newRotationEuler = Vector3.zero;

    [Header("Rotation (Quaternion)")]
    public Quaternion newRotationQuaternion = Quaternion.identity;

    [Header("Scale")]
    public Vector3 newScale = Vector3.one;

    [Header("Gravity")]
    public float newGravityScale = -9.81f;

    [Header("Time Scale")]
    public float newTimeScale = 1.0f;

    [Header("Rigidbody")]
    public bool addRigidbody = false;

    private void OnGUI()
    {
        GUILayout.Label("Teleport Manager Controls");

        // Check if the target object is assigned
        if (targetObject == null)
        {
            GUILayout.Label("Please assign a target GameObject.");
            return;
        }

        // Teleport Position
        GUILayout.Label("Teleport Position:");
        newPosition.x = float.Parse(GUILayout.TextField(newPosition.x.ToString()));
        newPosition.y = float.Parse(GUILayout.TextField(newPosition.y.ToString()));
        newPosition.z = float.Parse(GUILayout.TextField(newPosition.z.ToString()));
        if (GUILayout.Button("Teleport Position"))
        {
            photonView.RPC("RPC_TeleportPosition", RpcTarget.All, newPosition);
        }

        // Teleport Rotation (Euler Angles)
        GUILayout.Label("Teleport Rotation (Euler):");
        newRotationEuler.x = float.Parse(GUILayout.TextField(newRotationEuler.x.ToString()));
        newRotationEuler.y = float.Parse(GUILayout.TextField(newRotationEuler.y.ToString()));
        newRotationEuler.z = float.Parse(GUILayout.TextField(newRotationEuler.z.ToString()));
        if (GUILayout.Button("Teleport Rotation"))
        {
            photonView.RPC("RPC_TeleportRotation", RpcTarget.All, newRotationEuler);
        }

        // Teleport Quaternion Rotation
        GUILayout.Label("Teleport Rotation (Quaternion):");
        newRotationQuaternion.x = float.Parse(GUILayout.TextField(newRotationQuaternion.x.ToString()));
        newRotationQuaternion.y = float.Parse(GUILayout.TextField(newRotationQuaternion.y.ToString()));
        newRotationQuaternion.z = float.Parse(GUILayout.TextField(newRotationQuaternion.z.ToString()));
        newRotationQuaternion.w = float.Parse(GUILayout.TextField(newRotationQuaternion.w.ToString()));
        if (GUILayout.Button("Teleport Quaternion"))
        {
            photonView.RPC("RPC_TeleportQuaternion", RpcTarget.All, newRotationQuaternion);
        }

        // Change Scale
        GUILayout.Label("Change Scale:");
        newScale.x = float.Parse(GUILayout.TextField(newScale.x.ToString()));
        newScale.y = float.Parse(GUILayout.TextField(newScale.y.ToString()));
        newScale.z = float.Parse(GUILayout.TextField(newScale.z.ToString()));
        if (GUILayout.Button("Change Scale"))
        {
            photonView.RPC("RPC_ChangeScale", RpcTarget.All, newScale);
        }

        // Change Gravity
        GUILayout.Label("Change Gravity:");
        newGravityScale = float.Parse(GUILayout.TextField(newGravityScale.ToString()));
        if (GUILayout.Button("Change Gravity"))
        {
            photonView.RPC("RPC_ChangeGravity", RpcTarget.All, newGravityScale);
        }

        // Change Time Scale
        GUILayout.Label("Change Time Scale:");
        newTimeScale = float.Parse(GUILayout.TextField(newTimeScale.ToString()));
        if (GUILayout.Button("Change Time Scale"))
        {
            photonView.RPC("RPC_ChangeTimeScale", RpcTarget.All, newTimeScale);
        }

        // Add/Remove Rigidbody
        GUILayout.Label("Toggle Rigidbody:");
        addRigidbody = GUILayout.Toggle(addRigidbody, "Add Rigidbody");
        if (GUILayout.Button(addRigidbody ? "Add Rigidbody" : "Remove Rigidbody"))
        {
            photonView.RPC("RPC_ToggleRigidbody", RpcTarget.All, addRigidbody);
        }
    }

    // RPC Methods
    [PunRPC]
    private void RPC_TeleportPosition(Vector3 position)
    {
        if (targetObject != null)
        {
            targetObject.transform.position = position;
        }
    }

    [PunRPC]
    private void RPC_TeleportRotation(Vector3 eulerAngles)
    {
        if (targetObject != null)
        {
            targetObject.transform.rotation = Quaternion.Euler(eulerAngles);
        }
    }

    [PunRPC]
    private void RPC_TeleportQuaternion(Quaternion rotation)
    {
        if (targetObject != null)
        {
            targetObject.transform.rotation = rotation;
        }
    }

    [PunRPC]
    private void RPC_ChangeScale(Vector3 scale)
    {
        if (targetObject != null)
        {
            targetObject.transform.localScale = scale;
        }
    }

    [PunRPC]
    private void RPC_ChangeGravity(float gravityScale)
    {
        if (targetObject != null)
        {
            Rigidbody rb = targetObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = true;
                Physics.gravity = new Vector3(0, gravityScale, 0);
            }
        }
    }

    [PunRPC]
    private void RPC_ChangeTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    [PunRPC]
    private void RPC_ToggleRigidbody(bool addRigidbody)
    {
        if (targetObject != null)
        {
            Rigidbody rb = targetObject.GetComponent<Rigidbody>();

            if (addRigidbody && rb == null)
            {
                rb = targetObject.AddComponent<Rigidbody>();
            }
            else if (!addRigidbody && rb != null)
            {
                Destroy(rb);
            }
        }
    }
}

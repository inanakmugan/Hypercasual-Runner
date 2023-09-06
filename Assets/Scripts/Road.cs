using UnityEngine;

public class Road : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 size;
    // Start is called before the first frame update

    public float returnZ()
    {
        return size.z;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(transform.position, new Vector3(size.x, size.y, size.z));
    }
}

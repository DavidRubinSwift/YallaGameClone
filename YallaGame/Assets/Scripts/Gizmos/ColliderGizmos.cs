using UnityEngine;

[ExecuteAlways] // Чтобы работал в редакторе без запуска сцены
public class ColliderGizmos : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        BoxCollider box = GetComponent<BoxCollider>();
        if (box == null) return;

        Gizmos.color = Color.red; 

        // Позиция и размер с учётом трансформаций объекта
        Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        Gizmos.matrix = rotationMatrix;

        Gizmos.DrawWireCube(box.center, box.size);
    }
}
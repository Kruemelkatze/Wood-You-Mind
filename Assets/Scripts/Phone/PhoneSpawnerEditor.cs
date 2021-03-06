using UnityEditor;
using UnityEngine;

#if (UNITY_EDITOR)

[CustomEditor(typeof(PhoneSpawner))]
public class PhoneSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        if (!Application.isPlaying)
            return;

        PhoneSpawner myScript = (PhoneSpawner) target;
        if (GUILayout.Button("Spawn Phone"))
        {
            myScript.SpawnPhone();
        }
        
        if (GUILayout.Button("Clear Phones"))
        {
            myScript.RemoveAllPhones();
        }
    }
}

#endif
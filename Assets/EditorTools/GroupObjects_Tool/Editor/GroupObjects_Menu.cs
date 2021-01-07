using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



namespace EditorTools.Tools
{

    public class GroupObjects_Menu : MonoBehaviour
    {
        [MenuItem("Editor Tool/Tools/ GroupObjects %g")]
        public static void LaunchGroupObjects()
        {
            GroupObjects_Editor.LaunchGroupObjectsWindow();
        }
    }
}

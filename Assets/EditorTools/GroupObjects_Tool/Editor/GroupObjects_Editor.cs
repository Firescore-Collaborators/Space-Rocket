using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



namespace EditorTools.Tools
{
    public class GroupObjects_Editor : EditorWindow
    {
        #region Variables

        private string wantedName = "Enter Name";
        private int currentSelectionCount;
        private GameObject[] selected = new GameObject[0];

        #endregion

        #region BuiltIn Methods
        public static void LaunchGroupObjectsWindow()
        {
            var win = GetWindow<GroupObjects_Editor>();
            win.Show();
        }
        private void OnGUI()
        {

            selected = Selection.gameObjects;
            currentSelectionCount = selected.Length;

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical();
            EditorGUILayout.Space();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Selection Count: " + currentSelectionCount.ToString(), EditorStyles.boldLabel);

            GUILayout.Space(5);

            EditorGUILayout.LabelField("Group Name", EditorStyles.boldLabel);
            
            GUILayout.Space(5);

            wantedName = EditorGUILayout.TextField(wantedName);

            GUILayout.Space(2);

            if (GUILayout.Button("Group Selected", GUILayout.ExpandWidth(true), GUILayout.Height(45)))
            {
                GroupSelectedObjects();
            }

            EditorGUILayout.Space();
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();
            EditorGUILayout.EndHorizontal();

            Repaint();
        }
        #endregion

        #region Custom Methods
        void GroupSelectedObjects()
        {
            if (selected.Length > 0)
            {
                if(wantedName != "Enter Name")
                {
                    GameObject groupGO = new GameObject(wantedName + "_GRP");

                    foreach (GameObject curgo in selected)
                    {
                        curgo.transform.SetParent(groupGO.transform);
                    }
                }

                else
                {
                    EditorUtility.DisplayDialog("Grouper Message", "You must provide a name for your Group!", "OK");
                }
                
            }
        }
        #endregion
    }
}

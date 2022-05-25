using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using UnityEditor;
using UnityEngine;
using FMODUnity;
using Sirenix.Utilities;

namespace FMODUnity 
{
    #if UNITY_EDITOR
    public static class FMODEventCompiler
    {
        [MenuItem("Tools/Compile FMOD Events")]
        public static void CompileFMODEvents()
        {
            var eventRoot = new Node("event:");
            FMODUnity.EventManager.Events.Where(e => e.Path.StartsWith("event")).ForEach(e =>
            {
                var p = Itemize("event", e.Path);
                eventRoot.AddNode(p);
            });

            var snapshotRoot = new Node("snapshot:");
            FMODUnity.EventManager.Events.Where(e => e.Path.StartsWith("snapshot")).ForEach(e =>
            {
                var p = Itemize("snapshot", e.Path);
                snapshotRoot.AddNode(p);
            });

            var output = "";
            ProcessNode(eventRoot, "", ref output);
            StreamWriter writer = new StreamWriter(Application.dataPath + "/Scripts/Audio/FMODEvents.cs");
            writer.Write(output);

            var snapOutput = "";
            ProcessNode(snapshotRoot, "", ref snapOutput);
            writer.Write(snapOutput);
            writer.Dispose();
            AssetDatabase.Refresh();
        }

        private static void ProcessNode(Node node, string parentPath, ref string output)
        {
            var isLast = node.Branches.Count == 0;
            var pre = string.IsNullOrEmpty(parentPath) ? "" : parentPath + "/";
            var fullPath = pre + node.Value;
            if (isLast)
            {
                output += $"\n\t public const string {node.Value.FirstCharToUpper()} = \"{fullPath}\";";
            }
            else
            {
                var className = "";
                if (node.Value == "event:")
                {
                    className = "FMODEvents";
                }
                else if(node.Value == "snapshot:")
                {
                    className = "FMODSnapshots";
                }
                else
                {
                    className = node.Value;
                }
                  // ?  : node.Value;
                output += $"\n\t public class {className.FirstCharToUpper()} {{ ";

                foreach (var branch in node.Branches)
                {
                    ProcessNode(branch, fullPath, ref output);
                }

                output += "}";
            }
        }

        public static string[] Itemize(string root, string path)
        {
            var sub = path.Substring(root.Length + 1);
            var result = sub.Split('/');
            return result;
        }
    }

    public class Node
    {
        public string Value;
        public List<Node> Branches = new List<Node>();

        public Node(string value)
        {
            Value = value;
        }

        public void AddNode(string[] path)
        {
            path = path.SkipWhile(string.IsNullOrEmpty).ToArray();
            if (path.Length <= 0) return;
            var first = path[0];
            var existing = Branches.FirstOrDefault(b => b.Value == first);
            if (existing == null)
            {
                var branch = new Node(first);
                Branches.Add(branch);
                branch.AddNode(path.Skip(1).ToArray());
            }
            else
            {
                existing.AddNode(path.Skip(1).ToArray());
            }
        }
    }
    #endif
}

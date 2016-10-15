using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class MoveableObject : MonoBehaviour, IGvrGazeResponder
    {
        public static event Action<Vector3> IssueMoveAction;

        public void OnGazeEnter()
        {
            if (IssueMoveAction != null) IssueMoveAction(transform.position);
        }

        public void OnGazeExit()
        {
        }

        public void OnGazeTrigger()
        {
        }
    }
}

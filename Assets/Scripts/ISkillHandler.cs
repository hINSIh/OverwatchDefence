using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISkillHandler : MonoBehaviour {

	public interface Player
    {
        void OnKeyShift();
        void OnKeyE();
        void OnUltimate();
    }
}

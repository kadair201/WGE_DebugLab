using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpCubeScript : MonoBehaviour {

    public GameObject _cube;
    public Vector3 _leftPosition;
    public Vector3 _rightPosition;

    public void StartLerp()
    {
        _cube.transform.position = _leftPosition;
        StartCoroutine(LerpCube());
    }

    IEnumerator LerpCube()
    {
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime;
            Debug.Log(t);
            _cube.transform.position = SmoothStopLerp(_leftPosition, _rightPosition, t);
            if(t >=1)
            {
                _cube.transform.position = _rightPosition;
            }
            yield return null;
        }
    }

    //insert code here:

    Vector3 SmoothStartLerp(Vector3 a, Vector3 b, float t)
    {
        float x = a.x + (b.x - a.x) * t * t;
        float y = a.y + (b.y - a.y) * t * t;
        float z = a.z + (b.z - a.z) * t * t;

        return new Vector3(x, y, z);
    }

    Vector3 SmoothStopLerp(Vector3 a, Vector3 b, float t)
    {
        float x = a.x + (b.x - a.x) * (1 - (1 - t) * (1 - t));
        float y = a.y + (b.y - a.y) * (1 - (1 - t) * (1 - t));
        float z = a.z + (b.z - a.z) * (1 - (1 - t) * (1 - t));

        return new Vector3(x, y, z);
    }

    public void PrintDebugScript()
    {
        Debug.Log(this.ToString());
    }

    public override string ToString()
    {
        string s;
        s = (_cube ? "Cube positon = " + _cube.transform.position
       : "Cube not instantiated ") + "\n"
        + "Left Position = " + _leftPosition + "\n"
        + "Right Position = " + _rightPosition;
        return s;
    }

}

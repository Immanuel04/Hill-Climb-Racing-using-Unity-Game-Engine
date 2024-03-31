using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class EnvironmentGenerator : MonoBehaviour
{
    public SpriteShapeController _spriteShapeController;
    [Range(3f, 100f)] public int _levelLength = 50;
    [Range(1f, 50f)] public float _xMultiplier = 2f;
    [Range(1f, 50f)] public float _yMultiplier = 2f;
    [Range(0f, 1f)] public float _curveSmoothness = 0.5f;
    public float _noisestop = 0.5f;
    public float _bottom = 10f;
    public Vector3 _lastPos;
    // Update is called once per frame
    public void OnValidate()
    {
        _spriteShapeController.spline.Clear();
        for (int i = 0; i < _levelLength; i++)
        {
            _lastPos = transform.position + new Vector3(i + _xMultiplier, Mathf.PerlinNoise(0, i * _noisestop) * _yMultiplier);
            _spriteShapeController.spline.InsertPointAt(i, _lastPos);
            if(i !=0 && i != _levelLength -1)
            {
                _spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                _spriteShapeController.spline.SetLeftTangent(i, Vector3.left * _xMultiplier * _curveSmoothness);
                _spriteShapeController.spline.SetRightTangent(i, Vector3.right * _xMultiplier * _curveSmoothness);
            }
        }
        _spriteShapeController.spline.InsertPointAt(_levelLength, new Vector3(_lastPos.x, transform.position.y - _bottom));
        _spriteShapeController.spline.InsertPointAt(_levelLength + 1, new Vector3(transform.position.x, transform.position.y - _bottom));
    }
}

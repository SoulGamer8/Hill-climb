using UnityEngine;
using UnityEngine.U2D;

namespace HillClimb.Ground
{
    public class GroundGenerator : MonoBehaviour
    {
        [SerializeField] private SpriteShapeController _groundShape;

        [SerializeField] private int _levelLength;
        [SerializeField] private float _xMultiplier;
        [SerializeField] private float _yMultiplier;
        [SerializeField] private float _curveSmoothess;

        [SerializeField] private float _noiseStep = 0.5f;
        [SerializeField] private float _bottom = 10f;

        private Vector3 _lastPosition;

        private void OnValidate() {
            _groundShape.spline.Clear();

            for (int i = 0; i < _levelLength; i++){
                _lastPosition = transform.position + new Vector3(i * _xMultiplier, Mathf.PerlinNoise(0,i * _noiseStep) * _yMultiplier);
                _groundShape.spline.InsertPointAt(i, _lastPosition);

                if(i != 0 && i != _levelLength - 1){
                    _groundShape.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                    _groundShape.spline.SetLeftTangent(i, Vector3.left *_xMultiplier * _curveSmoothess);    
                    _groundShape.spline.SetRightTangent(i, Vector3.right *_xMultiplier * _curveSmoothess);
            
                }
             
            }

            _groundShape.spline.InsertPointAt(_levelLength,new Vector3(_lastPosition.x,transform.position.y - _bottom));
            _groundShape.spline.InsertPointAt(_levelLength + 1, new Vector3(transform.position.x, transform.position.y - _bottom));
        }
    }
}

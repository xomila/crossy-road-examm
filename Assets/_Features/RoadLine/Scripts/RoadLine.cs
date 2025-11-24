using UnityEngine;

public class RoadLine : LevelLine
{
	[SerializeField]
	private float _spawnInterval = 4f;

	[SerializeField]
	private Transform _leftSpawnPoint = null;
	[SerializeField]
	private Transform _rightSpawnPoint = null;

	[SerializeField]
	private CarObstacle _carObstaclePrefab = null;

	private Transform _selectedSpawnPoint = null;
	private Vector3 _selectedDirection = Vector3.right;

	private float _spawnIntervalDelta = 0f;

	public override void Initialize()
	{
		bool chooseRight = Random.Range(0, 2) == 0;

		if(chooseRight)
		{
			_selectedSpawnPoint = _rightSpawnPoint;
			_selectedDirection = Vector3.left;
		}
		else
		{
			_selectedSpawnPoint = _leftSpawnPoint;
			_selectedDirection = Vector3.right;
		}

		_spawnIntervalDelta = Random.Range(0f, _spawnInterval);
	}

	private void Update()
	{
		_spawnIntervalDelta += Time.deltaTime;

		if (_spawnIntervalDelta < _spawnInterval)
			return;

		_spawnIntervalDelta = 0f;

		CarObstacle car = Instantiate(_carObstaclePrefab, _selectedSpawnPoint);
		car.Initialize(_selectedDirection);
	}
}

using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	[SerializeField]
	private int _baseOffset = 5;

	[SerializeField]
	private int _playerOffsetAhead = 8;

	[SerializeField]
	private float _offsetSize = 2f;

	[SerializeField]
	private List<LevelLine> linesPrefabs = new();

	[SerializeField]
	private Transform _playerTransform = null;

	int _currentOffset = 0;

	private void Start()
	{
		_currentOffset = _baseOffset;
	}

	private void Update()
	{
		HandleGeneration();
	}

	private void HandleGeneration()
	{
		if (_playerTransform.position.z >= _currentOffset - _playerOffsetAhead)
			SpawnNewLine();
	}

	private void SpawnNewLine()
	{
		_currentOffset++;

		int lineIndex = Random.Range(0, linesPrefabs.Count);

		LevelLine line = Instantiate(linesPrefabs[lineIndex], new Vector3(0f, 0f, _currentOffset * _offsetSize), Quaternion.identity, transform);
		line.Initialize();
	}
}

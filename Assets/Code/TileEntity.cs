using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEntity
	:
	MonoBehaviour
{
	void Awake()
	{
		TileGrid.InitPos( tag,this );
	}

	public virtual void Move( Vector3 dir )
	{
		transform.position += dir;
	}
}

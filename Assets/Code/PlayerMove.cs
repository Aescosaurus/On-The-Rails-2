using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMove
	:
	TileEntity
{
	void Update()
	{
		move = Vector3.zero;
		if( Input.GetKeyDown( KeyCode.W ) ) ++move.z;
		else if( Input.GetKeyDown( KeyCode.S ) ) --move.z;
		else if( Input.GetKeyDown( KeyCode.A ) ) --move.x;
		else if( Input.GetKeyDown( KeyCode.D ) ) ++move.x;

		if( move != Vector3.zero )
		{
			// todo more robust system to allow for mobile/immobile tiles
			// movable check in tileentity serializefield
			bool canMove = true;
			var entity = TileGrid.CheckTile( transform.position + move );
			if( entity?.tag == "Track" )
			{
				canMove = TileGrid.CheckTile( transform.position + move * 2.0f ) == null;
				if( canMove ) entity.Move( move );
			}
			
			if( canMove ) transform.position += move;
		}
	}

	Vector3 move = Vector3.zero;
}

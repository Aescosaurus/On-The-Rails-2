using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track
	:
	TileEntity
{
	void Start()
	{
		filter = GetComponentInChildren<MeshFilter>();

		straight = Resources.Load<Mesh>( "Models/Track" );
		corner = Resources.Load<Mesh>( "Models/TrackCorner" );
	}

	public override void Move( Vector3 dir )
	{
		base.Move( dir );

		foreach( var track in TileGrid.GetEntityList( "Track" ) )
		{
			track.gameObject.GetComponent<Track>()?.UpdateDir();
		}
	}

	public void UpdateDir()
	{
		Vector3[] checkSpots = { Vector3.forward,Vector3.back,Vector3.left,Vector3.right };
		bool[] found = { false,false,false,false };
		TileEntity[] neighbors = { null,null,null,null };

		foreach( var e in TileGrid.GetEntityList( "Track" ) )
		{
			for( int i = 0; i < checkSpots.Length; ++i )
			{
				if( e.transform.position == transform.position + checkSpots[i] )
				{
					found[i] = true;
					neighbors[i] = e;
				}
			}
		}

		if( found[0] && found[3] ) SetDir( 4 );
		else if( found[3] && found[1] ) SetDir( 5 );
		else if( found[1] && found[2] ) SetDir( 6 );
		else if( found[2] && found[0] ) SetDir( 7 );
		else if( found[0] || found[1] ) SetDir( 0 );
		else if( found[2] || found[3] ) SetDir( 2 );
	}

	void SetDir( int dir )
	{
		this.dir = dir;

		switch( dir )
		{
			case 0:
			case 1:
				filter.mesh = straight;
				SetRot( 0.0f );
				break;
			case 2:
			case 3:
				filter.mesh = straight;
				SetRot( 90.0f );
				break;
			case 4:
				filter.mesh = corner;
				SetRot( 180.0f );
				break;
			case 5:
				filter.mesh = corner;
				SetRot( 270.0f );
				break;
			case 6:
				filter.mesh = corner;
				SetRot( 0.0f );
				break;
			case 7:
				filter.mesh = corner;
				SetRot( 90.0f );
				break;
		}
	}

	void SetRot( float deg )
	{
		transform.rotation = Quaternion.identity;
		transform.Rotate( Vector3.up,deg );
	}

	int dir = 0;
	MeshFilter filter;
	Mesh straight;
	Mesh corner;
}

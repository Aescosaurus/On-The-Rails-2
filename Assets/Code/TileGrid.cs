using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrid
	:
	MonoBehaviour
{
	public static void InitPos( string category,TileEntity obj )
	{
		if( !entities.ContainsKey( category ) )
		{
			entities[category] = new List<TileEntity>();
		}
		entities[category].Add( obj );
	}

	public static TileEntity CheckTile( Vector3 pos )
	{
		foreach( var list in entities )
		{
			foreach( var entity in list.Value )
			{
				if( entity.transform.position == pos ) return( entity );
			}
		}

		return( null );
	}

	public static List<TileEntity> GetEntityList( string category )
	{
		return( entities[category] );
	}

	public static Dictionary<string,List<TileEntity>> GetEntityDict()
	{
		return( entities );
	}

	static Dictionary<string,List<TileEntity>> entities = new Dictionary<string,List<TileEntity>>();
}

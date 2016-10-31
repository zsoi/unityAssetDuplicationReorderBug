using UnityEditor;
using UnityEngine;

public class NestedAssetCreator : Editor
{
	[MenuItem( "Assets/Create/>> NESTED ASSET" )]
	private static void CreateNewAsset()
	{
		MainAssetType mainAsset = ScriptableObject.CreateInstance<MainAssetType>();

		AssetDatabase.CreateAsset( mainAsset, AssetDatabase.GenerateUniqueAssetPath( "assets/NestedAsset.asset" ) );
		AssetDatabase.SaveAssets();

		for( int n = 0; n < 5; n++ ) {
			SubAssetType subAsset = ScriptableObject.CreateInstance<SubAssetType>();
			subAsset.AssetIndex = n;

			mainAsset.SubAssets.Add( subAsset );

			AssetDatabase.AddObjectToAsset( subAsset, mainAsset );
		}

		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
	}
}

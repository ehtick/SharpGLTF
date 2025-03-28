// <auto-generated/>

//------------------------------------------------------------------------------------------------
//      This file has been programatically generated; DON´T EDIT!
//------------------------------------------------------------------------------------------------

#pragma warning disable SA1001
#pragma warning disable SA1027
#pragma warning disable SA1028
#pragma warning disable SA1121
#pragma warning disable SA1205
#pragma warning disable SA1309
#pragma warning disable SA1402
#pragma warning disable SA1505
#pragma warning disable SA1507
#pragma warning disable SA1508
#pragma warning disable SA1652

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Text.Json;

namespace SharpGLTF.Schema2
{
	using Collections;

	/// <summary>
	/// glTF extension defines instance attributes for a node with a mesh.
	/// </summary>
	#if NET6_0_OR_GREATER
	[System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembers(System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.NonPublicConstructors | System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicConstructors)]
	#endif
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("SharpGLTF.CodeGen", "1.0.0.0")]
	partial class MeshGpuInstancing : ExtraProperties
	{
	
		private Dictionary<String,Int32> _attributes;
		
	
		protected override void SerializeProperties(Utf8JsonWriter writer)
		{
			base.SerializeProperties(writer);
			SerializeProperty(writer, "attributes", _attributes);
		}
	
		protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
		{
			switch (jsonPropertyName)
			{
				case "attributes": DeserializePropertyDictionary<MeshGpuInstancing, Int32>(ref reader, this, _attributes); break;
				default: base.DeserializeProperty(jsonPropertyName,ref reader); break;
			}
		}
	
	}

}

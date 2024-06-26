﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

using SharpGLTF.Geometry.VertexTypes;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;

namespace SharpGLTF
{
    [System.Diagnostics.DebuggerDisplay("𝐂:{Color} 𝐔𝐕:{TexCoord}")]
    public struct VertexPointcloud : IVertexCustom
    {
        public VertexPointcloud(Vector4 color, float intensity, float classification)
        {
            Color = color;
            Intensity = intensity;
            Classification = classification;
        }

        public const string INTENSITYATTRIBUTENAME = "_INTENSITY";
        public const string CLASSIFICATIONATTRIBUTENAME = "_CLASSIFICATION";

        
        public Vector4 Color;
        public float Intensity;
        public float Classification;

        IEnumerable<KeyValuePair<string, AttributeFormat>> IVertexReflection.GetEncodingAttributes()
        {
            yield return new KeyValuePair<string, AttributeFormat>("COLOR_0", new AttributeFormat(DimensionType.VEC4, EncodingType.UNSIGNED_BYTE, true));
            yield return new KeyValuePair<string, AttributeFormat>(INTENSITYATTRIBUTENAME, new AttributeFormat(DimensionType.SCALAR));
            yield return new KeyValuePair<string, AttributeFormat>(CLASSIFICATIONATTRIBUTENAME, new AttributeFormat(DimensionType.SCALAR));
        }

        public int MaxColors => 1;

        public int MaxTextCoords => 0;

        public IEnumerable<string> CustomAttributes => throw new NotImplementedException();

        void IVertexMaterial.SetColor(int setIndex, Vector4 color) {
            if (setIndex == 0) Color = color;
        }

        public void SetTexCoord(int setIndex, Vector2 coord) { }

        public Vector4 GetColor(int index) {
            return Color;
        }

        public Vector2 GetTexCoord(int index) { throw new ArgumentOutOfRangeException(nameof(index)); }

        public void Validate() { }

        public object GetCustomAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public bool TryGetCustomAttribute(string attributeName, out object value)
        {
            if (attributeName == INTENSITYATTRIBUTENAME) {
                value = Intensity; return true;
            }
            else if(attributeName == CLASSIFICATIONATTRIBUTENAME)
            {
                value = Classification; return true;
            }
            else
            {
                value = null; return false;
            }
        }

        public void SetCustomAttribute(string attributeName, object value)
        {
            throw new NotImplementedException();
        }

        public VertexMaterialDelta Subtract(IVertexMaterial baseValue)
        {
            throw new NotImplementedException();
        }

        public void Add(in VertexMaterialDelta delta)
        {
            throw new NotImplementedException();
        }
    }
}

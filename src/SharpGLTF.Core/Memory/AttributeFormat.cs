﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SharpGLTF.Memory
{
    using DIMENSIONS = SharpGLTF.Schema2.DimensionType;
    using ENCODING = SharpGLTF.Schema2.EncodingType;

    /// <summary>
    /// Defines the formatting in which a byte sequence can be encoded/decoded to attribute elements.
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
    public readonly struct AttributeFormat : IEquatable<AttributeFormat>
    {
        #region debug

        internal string _GetDebuggerDisplay()
        {
            var txt = $"{Encoding}";

            switch (Dimensions)
            {
                case DIMENSIONS.SCALAR: break;
                case DIMENSIONS.VEC2: txt += "2"; break;
                case DIMENSIONS.VEC3: txt += "3"; break;
                case DIMENSIONS.VEC4: txt += "4"; break;
                case DIMENSIONS.MAT2: txt += "2x2"; break;
                case DIMENSIONS.MAT3: txt += "3x3"; break;
                case DIMENSIONS.MAT4: txt += "4x4"; break;
                default: txt += "?"; break;
            }

            if (Normalized) txt += " Normalized";
            return txt;
        }

        #endregion

        #region predefined values

        public static readonly AttributeFormat Float1 = new AttributeFormat(ENCODING.FLOAT);
        public static readonly AttributeFormat Float2 = new AttributeFormat(DIMENSIONS.VEC2 ,ENCODING.FLOAT);
        public static readonly AttributeFormat Float3 = new AttributeFormat(DIMENSIONS.VEC3, ENCODING.FLOAT);
        public static readonly AttributeFormat Float4 = new AttributeFormat(DIMENSIONS.VEC4, ENCODING.FLOAT);
        public static readonly AttributeFormat Float2x2 = new AttributeFormat(DIMENSIONS.MAT2, ENCODING.FLOAT);
        public static readonly AttributeFormat Float3x3 = new AttributeFormat(DIMENSIONS.MAT3, ENCODING.FLOAT);
        public static readonly AttributeFormat Float4x4 = new AttributeFormat(DIMENSIONS.MAT4, ENCODING.FLOAT);

        #endregion

        #region constructors

        public static implicit operator AttributeFormat(Schema2.IndexEncodingType indexer) { return new AttributeFormat(indexer); }        

        public static implicit operator AttributeFormat(ENCODING enc) { return new AttributeFormat(enc); }

        public static implicit operator AttributeFormat(DIMENSIONS dim) { return new AttributeFormat(dim); }

        public static implicit operator AttributeFormat((DIMENSIONS dim, ENCODING enc) fmt) { return new AttributeFormat(fmt.dim, fmt.enc); }

        public static implicit operator AttributeFormat((DIMENSIONS dim, ENCODING enc, Boolean nrm) fmt) { return new AttributeFormat(fmt.dim, fmt.enc, fmt.nrm); }

        public AttributeFormat(Schema2.IndexEncodingType enc)
        {
            Dimensions = DIMENSIONS.SCALAR;
            Encoding = enc.ToComponent();
            Normalized = false;
            ByteSize = Dimensions.DimCount() * Encoding.ByteLength();
        }

        public AttributeFormat(ENCODING enc)
        {
            Dimensions = DIMENSIONS.SCALAR;
            Encoding = enc;
            Normalized = false;
            ByteSize = Dimensions.DimCount() * Encoding.ByteLength();
        }

        public AttributeFormat(DIMENSIONS dim)
        {
            Dimensions = dim;
            Encoding = ENCODING.FLOAT;
            Normalized = false;
            ByteSize = Dimensions.DimCount() * Encoding.ByteLength();
        }

        public AttributeFormat(DIMENSIONS dim, ENCODING enc)
        {
            Dimensions = dim;
            Encoding = enc;
            Normalized = false;
            ByteSize = Dimensions.DimCount() * Encoding.ByteLength();
        }

        public AttributeFormat(DIMENSIONS dim, ENCODING enc, Boolean nrm)
        {
            if (nrm)
            {
                Guard.IsFalse(enc == ENCODING.FLOAT, nameof(nrm), "Float encoding must not be normalized");
            }

            Dimensions = dim;
            Encoding = enc;
            Normalized = nrm;
            ByteSize = Dimensions.DimCount() * Encoding.ByteLength();
        }

        #endregion

        #region data

        public readonly ENCODING Encoding;
        public readonly DIMENSIONS Dimensions;
        public readonly Boolean Normalized;
        public readonly Int32 ByteSize;

        public override int GetHashCode()
        {
            return Dimensions.GetHashCode()
                ^ Encoding.GetHashCode()
                ^ Normalized.GetHashCode();
        }

        public static bool AreEqual(AttributeFormat a, AttributeFormat b)
        {
            if (a.Encoding != b.Encoding) return false;
            if (a.Dimensions != b.Dimensions) return false;
            if (a.Normalized != b.Normalized) return false;
            return true;
        }

        public Int32 ByteSizePadded => ByteSize.WordPadded();

        #endregion

        #region API

        public override bool Equals(object obj) { return obj is AttributeFormat other ? AreEqual(this, other) : false; }

        public bool Equals(AttributeFormat other) { return AreEqual(this, other); }

        public static bool operator ==(AttributeFormat a, AttributeFormat b) { return AreEqual(a, b); }
        public static bool operator !=(AttributeFormat a, AttributeFormat b) { return !AreEqual(a, b); }

        #endregion
    }
}

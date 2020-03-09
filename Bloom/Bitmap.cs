using System;

namespace Bloom
{
    public class Bitmap
    {
        private readonly Boolean[] array;

        public Bitmap(Int32 lengthArray)
        {
            array = new Boolean[lengthArray + 1];
        }

        public void InsertHash(Int32 hash)
        {
            array[ConvertHashToArrayRange(hash)] = true;
        }

        public Boolean IsHashInBitmap(Int32 hash)
        {
            return array[ConvertHashToArrayRange(hash)];
        }

        private Int32 ConvertHashToArrayRange(Int32 hash)
        {
            return Math.Abs(hash) % array.Length;
        }
    }
}

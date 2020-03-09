using System;

namespace Bloom
{
    public class WordChecker
    {
        private readonly Bitmap bitmap;

        public WordChecker(Bitmap bitmap)
        {
            this.bitmap = bitmap;
        }

        public Boolean IsWordInBitmap(String word)
        {
            CalculationHash hash = new CalculationHash();

            return IsHashInBitmap(hash.MD5CalculationValue(word)) &&
            IsHashInBitmap(hash.SHA1CalculationValue(word)) &&
            IsHashInBitmap(hash.StandartHashCalculationValue(word));
        }

        private Boolean IsHashInBitmap(Int32 hashValue)
        {
            return bitmap.IsHashInBitmap(hashValue);
        }
    }
}

using Bloom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloomTests
{
    [TestClass]
    public class BloomTests
    {
        [TestMethod]
        public void MD5ComputationHash()
        {
            String testString = "Andrey";
            CalculationHash calcHash = new CalculationHash();

            Int32 md5HashCode = calcHash.MD5CalculationValue(testString);
            Assert.AreNotEqual(testString.GetHashCode(), md5HashCode);
        }

        [TestMethod]
        public void SHA1ComputationHash()
        {
            String testString = "Andrey";
            CalculationHash calcHash = new CalculationHash();

            Int32 md5HashCode = calcHash.SHA1CalculationValue(testString);
            Assert.AreNotEqual(testString.GetHashCode(), md5HashCode);
        }

        [TestMethod]
        public void StandartComputationHash()
        {
            String testString = "Andrey";
            CalculationHash calcHash = new CalculationHash();

            Int32 standartHashCode = calcHash.StandartHashCalculationValue(testString);
            Assert.AreEqual(testString.GetHashCode(), standartHashCode);
        }

        [TestMethod]
        public void ReflectionHashValueOnBitmapIndex()
        {
            String testString = "Andrey";

            CalculationHash calculationHash = new CalculationHash();
            Bitmap bitmap = new Bitmap(32);

            Int32 md5Hash = calculationHash.MD5CalculationValue(testString);

            bitmap.InsertHash(md5Hash);

            Assert.AreEqual(true, bitmap.IsHashInBitmap(md5Hash));
        }

        [TestMethod]
        public void ElementIsInBitmap()
        {
            String testString = "Andrey";

            CalculationHash calculationHash = new CalculationHash();
            Bitmap bitmap = new Bitmap(32);
            
            Int32 md5Hash = calculationHash.MD5CalculationValue(testString);
            Int32 sha1Hash = calculationHash.SHA1CalculationValue(testString);
            Int32 standartHash = calculationHash.StandartHashCalculationValue(testString);

            bitmap.InsertHash(md5Hash);
            bitmap.InsertHash(sha1Hash);
            bitmap.InsertHash(standartHash);

            WordChecker wordChecker = new WordChecker(bitmap);
            Boolean returnedValue = wordChecker.IsWordInBitmap("Andrey");
            Assert.AreEqual(true, returnedValue);
        }

        [TestMethod]
        public void ReadWordsListTests()
        {
            ReadFile file = new ReadFile();
            List<String> list = file.ReadWordsList("word list.txt");

            Assert.AreEqual(true, list.Contains("kyles"));
        }


        [TestMethod]
        public void CheckOnExistAllWordsInBitmap()
        {
            ReadFile file = new ReadFile();
            List<String> words = file.ReadWordsList("word list.txt");

            Bitmap bitmap = InsertWordsListInBitmap(words);
            WordChecker checker = new WordChecker(bitmap);

            foreach (String word in words)
            {
                Assert.AreEqual(true, checker.IsWordInBitmap(word));
            }
        }

        private Bitmap InsertWordsListInBitmap(List<String> words)
        {
            CalculationHash calculationHash = new CalculationHash();
            Bitmap bitmap = new Bitmap(500000);

            foreach (String word in words) 
            {
                Int32 md5Hash = calculationHash.MD5CalculationValue(word);
                Int32 sha1Hash = calculationHash.SHA1CalculationValue(word);
                Int32 standartHash = calculationHash.StandartHashCalculationValue(word);

                bitmap.InsertHash(md5Hash);
                bitmap.InsertHash(sha1Hash);
                bitmap.InsertHash(standartHash);
            }
            return bitmap;
        }

        [TestMethod]
        public void ChanceFalseSearch()
        {
            ReadFile file = new ReadFile();
            List<String> words = file.ReadWordsList("word list.txt");

            Bitmap bitmap = InsertWordsListInBitmap(words);
            WordChecker checker = new WordChecker(bitmap);

            StringBuilder word = new StringBuilder();
            Int32 searchWordsCount = 0;

            for (Int32 count = 0; count < 1000000; count++)
            {
                for (Int32 numberChar = 0; numberChar < 4; numberChar++)
                {
                    Random random = new Random();
                    Char randomValue = (Char)random.Next(65, 122);
                    word.Append(randomValue);
                }

                if (checker.IsWordInBitmap(word.ToString()) == true)
                {
                    searchWordsCount++;
                }

                word.Clear();
            }

            Console.WriteLine(searchWordsCount);
        }
    }
}

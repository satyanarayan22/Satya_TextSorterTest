namespace SimpleTest
{
    /// <summary>
    /// custom comparer to compare the alphabets
    /// </summary>
    public class CustomStringComparer : IComparer<string>
    {
        private readonly IComparer<string> _baseComparer;

        public CustomStringComparer(IComparer<string> baseComparer)
        {
            _baseComparer = baseComparer;
        }


        /// <summary>
        /// Custom method to do the string comparision
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(string x, string y)
        {
            var xChars = x.ToCharArray();
            var yChars = y.ToCharArray();

            if (_baseComparer.Compare(x, y) == 0)
            {
                for (var i = 0; i < xChars.Length; i++)
                {
                    if (string.Compare(xChars[i].ToString(), yChars[i].ToString(), false) == 0)
                    {
                        continue;
                    }
                    var result = string.Compare(xChars[i].ToString(), yChars[i].ToString(), false) * (-1);

                    return result;
                }
            }            

            return _baseComparer.Compare(x, y);
        }
    }
}
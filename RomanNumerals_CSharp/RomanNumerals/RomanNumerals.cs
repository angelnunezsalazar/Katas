namespace RomanNumeralsExample
{
    public class RomanNumerals
    {
        private static int[] ARABIC = { 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private static string[] ROMAN = { "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        public static string Convert(int arabic)
        {
            var result = "";
            for (int i = 0; i < ARABIC.Length; i++)
            {
                while (arabic >= ARABIC[i])
                {
                    result += ROMAN[i];
                    arabic -= ARABIC[i];
                }
            }

            return result;
        }
    }
}
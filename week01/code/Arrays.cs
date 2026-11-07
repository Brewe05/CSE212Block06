using System.Security.Cryptography;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        //first we must increase the index we are currently posisioned at using a for loop
        //we then need to esure index 0 starts with 7 because it is our first multiplication if we choose 7
        //we then need to increment by using i as the multiplyer and index 1 which is our number to multiply
        //then we need to store each number of our multiple into the array
        double[] answer = new double[length];
        for (int i = 0; i < length; i++)
        {
            answer[i] = (i + 1) * number;
        }

        return answer; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {   // first we need to declare i = 0
        // We then need to make a while loop that checks if i < amount
        // we then need to insert the data into variable to hold it then remove it from the array and insert it using the variable into the array
        // we need to increase i
        int i = 0;
        while(i < amount)
        {
            int last = data[data.Count -1]; //this takes the last value in the array
            data.RemoveAt(data.Count -1); //remove that read value
            data.Insert(0, last); //insert the read value into the beginning of the array
            i++;//increase i
        }
    }
}

public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {   
        //this will help keep track of where we last took the value from which index
        int taker1 = 0;
        int taker2 = 0;
        //create the result array
        var result = new List<int>();
        //start at index 0 of select and then increase after each iteration
        for (int i = 1; i < select.Length; i++)
        {
            //if i is 1 then take from li1
            if (select[i] == 1)
            {
                result.Add(list1[taker1]);
                ++taker1;
            }
            //if i = 2 then thake from li2
            else
            {
                result.Add(list2[taker2]);
                ++taker2;
            }
        }
        //repeats the process
        return result.ToArray();
    }
}
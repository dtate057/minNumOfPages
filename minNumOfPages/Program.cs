using System;
using System.Collections.Generic;

public class Solution
{
	public static int MinimumNumberOfPages(List<int> pages, int days)
	{
        //find the maximum pages to be read in a day
        int maxPageDay = int.MinValue;
        foreach(int page in pages)
        {
            if(maxPageDay < page)
            {
                maxPageDay = page;
            }
        }
        //initialize variables for binary search
        int low = 1;
        int high = maxPageDay;
        int actualDays = int.MaxValue;
        //perform binary serach
        while(low <= high)
        {
        //initialize mid value
        int mid = low + (high-low) / 2;
        //call getDays to test the mid value and track the current days it takes with that value
        int currDays = GetDays(pages,mid);
        //if currDays needed are less than alotted days reduce pages to read 
        if(currDays <= days)
        {
            actualDays = Math.Min(actualDays,mid);
            high = mid - 1;
        }
        //if curr days needed are more than alotted days read more each day
        else
        {
            low = mid + 1;
        }

        }
        return actualDays == int.MaxValue ? -1 : actualDays;

	}
	public static int GetDays(List<int> pages, int capacity)
{
    //initalize i pointer finger to read
    int i = 0;
    //initialize totaldays to return how many days it takes to read at the given capacity
    int totaldays = 0;
    //simulate reading pages
    while(i < pages.Count)
    {
        int currPage = pages[i];
        while(currPage > 0)
        {
        currPage -= capacity;
        totaldays++;
        }
        i++;
    }

return totaldays;

}

	// Main method for testing
	public static void Main(string[] args)
	{
		// Example input
		List<int> pages = new List<int> { 2, 3, 4, 5 };
		int days = 4;

		// Find and print the minimum number of pages that can be read per day
		int result = MinimumNumberOfPages(pages, days);
		Console.WriteLine("Minimum number of pages per day: " + result);  // Expected output: 5
	}
}

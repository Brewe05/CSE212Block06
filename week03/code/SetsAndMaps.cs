using System.ComponentModel;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var pairs = new List<string>();
        var processed = new HashSet<string>();

        foreach (var word in words){
            string reverse = $"{word[1]}{word[0]}";

            if (word[0] != word[1] &&
                wordSet.Contains(reverse) &&
                !processed.Contains(word) &&
                !processed.Contains(reverse))
            {
                pairs.Add($"{word} & {reverse}");
                processed.Add(word);
                processed.Add(reverse);
            }
        }

    return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            string degree = fields[3].Trim();
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees.Add(degree, 1);
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower(); //Remove the spaces and make everything lowercase
        word2 = word2.Replace(" ", "").ToLower();
        if (word1.Length != word2.Length)
        {
            return false; //if there are more letters in one word than the other then not anagram
        }
        var letters = new Dictionary<char, int>(); //create dictionary to store letters and how many times they appear
        foreach (char letter in word1) // begin letter counting in first word
        {
            if (letters.ContainsKey(letter)) //if letter is already in dictionary then add one to letter
            {
                letters[letter]++;
            }
            else
            {
                letters.Add(letter, 1); //if letter not in dictionary then add letter
            }
        }
        foreach (char letter in word2) //check word 2 if it contains stored letters from word1 in dictionary
        {
            if (!letters.ContainsKey(letter))
            {
                return false; //cannot be anagram if letter doesnt exist
            }
            letters[letter]--;
            if(letters[letter] < 0)
            {
                return false; //cannot be anagram if letter appears more in word1 compared to word2
            }
        }
        return true; //if passes all tests above then is anagram
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        
        var earthquakes = new List<string>();// store data as string in a list
        if (featureCollection == null) //check json convert to object success
        {
            return earthquakes.ToArray();
        }
        foreach (var feature in featureCollection.Features) //loops through data
        {
            //get location + magnitude from json
            string place = feature.Properties.Place;
            double? magnitude = feature.Properties.Mag;
            earthquakes.Add($"{place} - Mag {magnitude}");//combine data into one string to display
        }
        //make list an array and return data
        return earthquakes.ToArray();
    }
}
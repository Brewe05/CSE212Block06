public class FeatureCollection
{
    //stores all the earthquake data returned by the website.
    public List<Feature> Features { get; set; } = new List<Feature>();
}
//represents single earthquake.
public class Feature
{
    //details= magnitude and location.
    public EarthquakeProperties Properties { get; set; } = new EarthquakeProperties();
}
//stores detals metioned above
public class EarthquakeProperties
{
    public double Mag { get; set; }
    public string Place { get; set; }
}
namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            
            var cells = line.Split(',');

            // If your array's Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log error message and return null
                return null; 
            }

            
            double lat = double.Parse(cells[0]);
            double lon = double.Parse(cells[1]);
            string name = cells[2];

            var point = new Point();
            point.Latitude = lat;
            point.Longitude = lon;

            var tacoBell = new TacoBell();
            tacoBell.Name = name;
            tacoBell.Location = point;

            return tacoBell;
        }
    }
}

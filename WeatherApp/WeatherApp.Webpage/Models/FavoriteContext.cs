using System.Collections.Generic;

namespace WeatherApp.Webpage.Models
{
    public class FavoriteContext
    {
        public ISet<string> FavoriteSet;
        public FavoriteContext()
        {
            FavoriteSet = new HashSet<string>();
        }
    }
}
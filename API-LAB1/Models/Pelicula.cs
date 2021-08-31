using System;
using System.Collections.Generic;
using System.Text;

namespace API_LAB1.Models
{
    public class Pelicula : IComparable
    {
        //public string id { get; set; }
        public string director { get; set; }
        public double imdbRating { get; set; }
        public string genre { get; set; }
        public string releaseDate { get; set; }
        public int rottenTomatoesRating { get; set; }
        public string title { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            else
            {
                var pelicula2 = (Pelicula)obj;

                if (title.CompareTo(pelicula2.title) == 0) // los títulos son iguales
                {
                    if ((director != null && pelicula2.director != null && director.CompareTo(pelicula2.director) == 0)
                        || (director == null && pelicula2.director == null)) // los directores son iguales
                    {
                        if ((genre != null && pelicula2.genre != null && genre.CompareTo(pelicula2.genre) == 0)
                            || (genre == null && pelicula2.genre == null)) // los géneros son iguales
                        {
                            if ((releaseDate != null && pelicula2.releaseDate != null && releaseDate.CompareTo(pelicula2.releaseDate) == 0)
                                || (releaseDate == null && pelicula2.releaseDate == null)) // las fechas de estreno son iguales
                            {
                                return 0; // ambas son la misma película
                            }
                            else if (releaseDate == null && pelicula2.releaseDate != null) return -1;
                            else if (releaseDate != null && pelicula2.releaseDate == null) return 1;
                            else if (releaseDate.CompareTo(pelicula2.genre) < 0) return -1;
                            else return 1;
                        }
                        else if (genre == null && pelicula2.genre != null) return -1;
                        else if (genre != null && pelicula2.genre == null) return 1;
                        else if (genre.CompareTo(pelicula2.genre) < 0) return -1;
                        else return 1;
                    }
                    else if (director == null && pelicula2.director != null) return -1;
                    else if (director != null && pelicula2.director == null) return 1;
                    else if (director.CompareTo(pelicula2.director) < 0) return -1;
                    else return 1;
                }
                else if (title.CompareTo(pelicula2.title) < 0) return -1;
                else return 1;
            }           
        }

        public override string ToString(){
            return title + " - " + director;
        }
    }
}

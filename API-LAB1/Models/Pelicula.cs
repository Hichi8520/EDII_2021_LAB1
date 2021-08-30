using System;
using System.Collections.Generic;
using System.Text;

namespace API_LAB1.Models
{
    public class Pelicula : IComparable
    {
        public string id { get; set; }
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
                    if (director.CompareTo(pelicula2.director) == 0) // los directores son iguales
                    {
                        if (genre.CompareTo(pelicula2.genre) == 0) // los géneros son iguales
                        {
                            if (releaseDate.CompareTo(pelicula2.releaseDate) < 0) return -1;
                            else return 1;
                        }
                        else if (genre.CompareTo(pelicula2.genre) < 0) return -1;
                        else return 1;
                    }
                    else if (director.CompareTo(pelicula2.director) < 0) return -1;
                    else return 1;
                }
                else if (title.CompareTo(pelicula2.title) < 0) return -1;
                else return 1;
            }           
        }

        public override string ToString(){
            return "test";
        }
    }
}

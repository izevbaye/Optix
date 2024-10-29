using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optix.Database.DbContext.Tables
{
    public class Tbl_Movies
    {
        [Key]
        public int MovieID { get; set; }
        [Required]
        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string? Overview { get; set; }

        public decimal? Popularity { get; set; }

        public int? Vote_Count { get; set; }

        public int? Vote_Average { get; set; }

        public string? Original_Language { get; set; }

        [ForeignKey("GenreID")]
        public string? Genre { get; set; }// This value could either be set as a FK or simply a C# enum. In this exmaple, I am using a FK Constraint

        public string? Poster_Url { get; set; }

       
    }

    public class Tbl_MoviesActors
    {
        [Key]
        public int ActorID { get; set; }
        public string ActorName { get; set; }

        [ForeignKey(nameof(MovieID))]
        public string MovieID { get; set; }

        [ForeignKey("MovieID")]

        public List<Tbl_Movies>? Tbl_Movies { get; set; }

    }
    public class Tbl_MoviesGenre
    {
        [Key]
        public int GenreID { get; set; }

        public string Genre { get; set; }// FK Constraint added in the database

    }

    }

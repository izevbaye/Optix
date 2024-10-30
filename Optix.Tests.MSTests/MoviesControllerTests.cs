using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Optix.Database.DbContext.Tables;
using Optix.Service.ServiceAPI.Controllers;
using Optix.Service.ServiceAPI.Data;
using System;
using System.Collections.Generic;

namespace Optix.Tests.MSTests
{
   
    [TestClass]
    public class MoviesControllerTests
    {
        private Mock<DbSet<Tbl_Movies>> _mockMoviesDbSet;
        private MoviesController _controller;
        private OptixServiceServiceAPIContext _context;

        [TestInitialize]
        public void TestInitialize()
        {
            // Set up the in-memory database
            var options = new DbContextOptionsBuilder<OptixServiceServiceAPIContext>()
                .UseInMemoryDatabase(databaseName: "OptixTestDb")
                .Options;

            _context = new OptixServiceServiceAPIContext(options);
            _controller = new MoviesController(_context);

            
            // Seed data for tests
            _context.Tbl_Movies.AddRange(
                new Tbl_Movies { MovieID = 1, Title = "Movie A" },
                new Tbl_Movies { MovieID = 2, Title = "Movie B" },
                new Tbl_Movies { MovieID = 3, Title = "Movie C" },
                new Tbl_Movies { MovieID = 4, Title = "Movie D" }
            );
            _context.SaveChanges();

        }
        [TestCleanup]
        public void TestCleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [TestMethod]
        public async Task GetTheMovie_ReturnsBadRequest_WhenIdIsNull()
        {
            var result = await _controller.GetTheMovie(null);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
            var badRequestResult = result.Result as BadRequestObjectResult;
            Assert.AreEqual("Movie ID is required.", badRequestResult.Value);
        }

        [TestMethod]
        public async Task GetTheMovie_ReturnsNotFound_WhenMovieDoesNotExist()
        {
            var result = await _controller.GetTheMovie(99);

            Assert.IsInstanceOfType(result.Result, typeof(NotFoundObjectResult));
            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.AreEqual("No movie found with ID 99", notFoundResult.Value);
        }

        [TestMethod]
        public async Task GetTheMovie_ReturnsOk_WithMovieData_WhenMovieExists()
        {
            var result = await _controller.GetTheMovie(1);

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = result.Result as OkObjectResult;
            var movie = okResult.Value as Tbl_Movies;
            Assert.IsNotNull(movie);
            Assert.AreEqual(1, movie.MovieID);
            Assert.AreEqual("Movie A", movie.Title);
        }


        [TestMethod]
        public async Task SearchMovies_ReturnsLimitedResults_WhenLimitIsSpecified()
        {
            // Act: Call the controller's SearchMovies with a limit of 2
            var result = await _controller.SearchMovies("", pageLimit: 2, pageNumber: 1);
            var okResult = result.Result as OkObjectResult;
            var movies = okResult.Value as List<Tbl_Movies>;

            // Assert: Only 2 movies should be returned
            Assert.AreEqual(2, movies.Count);
        }

        [TestMethod]
        public async Task SearchMovies_ReturnsCorrectResults_ForSpecifiedPage()
        {
            // Act: Retrieve the second page with a limit of 2 per page
            var result = await _controller.SearchMovies("", pageLimit: 2, pageNumber: 2);
            var okResult = result.Result as OkObjectResult;
            var movies = okResult.Value as List<Tbl_Movies>;

            // Assert: The returned movies should be "Movie C" and "Movie D"
            Assert.AreEqual(2, movies.Count);
            Assert.AreEqual("Movie C", movies[0].Title);
            Assert.AreEqual("Movie D", movies[1].Title);
        }

        [TestMethod]
        public async Task SearchMovies_ReturnsAllResults_WhenLimitExceedsAvailableMovies()
        {
            // Act: Request more movies than exist
            var result = await _controller.SearchMovies("", pageLimit: 10, pageNumber: 1);
            var okResult = result.Result as OkObjectResult;
            var movies = okResult.Value as List<Tbl_Movies>;

            // Assert: All 4 movies should be returned
            Assert.AreEqual(4, movies.Count);
        }

        [TestMethod]
        public async Task SearchMovies_ReturnsEmptyList_WhenNoMoviesMatchQuery()
        {
            // Act: Search with a query that matches no movies
            var result = await _controller.SearchMovies("NonExistentMovie", pageLimit: 5, pageNumber: 1);
            var okResult = result.Result as OkObjectResult;
            var movies = okResult.Value as List<Tbl_Movies>;

            // Assert: Result list should be empty
            Assert.AreEqual(0, movies.Count);
        }
    }
}
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json;
using RestSharp;

namespace MusicShopApiTests;

public class MusicShopTests
{
    private const string GENRES_ROUTE = "Genres";
    private const string ALBUMS_ROUTE = "Albums";
    private static RestClient _client;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _client = new RestClient("http://localhost:60715/api/");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _client.Dispose();
    }

    [Test]
    public async Task TestGetAllRequest()
    {
        var getRequest = new RestRequest(GENRES_ROUTE, Method.Get);

        var allGenres = await _client.GetAsync<List<Genres>>(getRequest);
        
        Assert.IsTrue(allGenres.Any());
    }

    [Test]
    public async Task TestGetById()
    {
        var getRequest = new RestRequest("Genres/5", Method.Get);

        var actualGenre = await _client.GetAsync<Genres>(getRequest);

        Assert.AreEqual("Rock And Roll", actualGenre.Name);
        Assert.AreEqual(5, actualGenre.GenreId);
    }

    [Test]
    public async Task TestPostRequest()
    {
        var getAllRequest = new RestRequest(GENRES_ROUTE, Method.Get);
        var allGenres = await _client.GetAsync<List<Genres>>(getAllRequest);
        long largestId = allGenres.Select(s => s.GenreId).Max();

        var newGenere = new Genres()
        {
            Name = Guid.NewGuid().ToString(),
            GenreId = largestId + 1
        };

        try
        {
            var postRequest = new RestRequest("Genres", Method.Post);
            postRequest.AddJsonBody(newGenere);

            var actualGenre = await _client.ExecuteAsync<Genres>(postRequest);

            Assert.IsTrue(actualGenre.IsSuccessful);

            // check if it is created successfully
            var getRequest = new RestRequest($"Genres/{newGenere.GenreId}", Method.Get);
            var createdGenre = await _client.GetAsync<Genres>(getRequest);

            Assert.AreEqual(newGenere.Name, createdGenre.Name);
            Assert.AreEqual(newGenere.GenreId, createdGenre.GenreId);
        }
        finally
        {
            // delete test data
            var deleteRequest = new RestRequest($"Genres/{newGenere.GenreId}", Method.Delete);
            await _client.DeleteAsync(deleteRequest);
        }
    }

    [Test]
    public async Task TestPutRequest()
    {
        var getAllRequest = new RestRequest(GENRES_ROUTE, Method.Get);
        var allGenres = await _client.GetAsync<List<Genres>>(getAllRequest);
        long largestId = allGenres.Select(s => s.GenreId).Max();

        var newGenere = new Genres()
        {
            Name = Guid.NewGuid().ToString(),
            GenreId = largestId + 1
        };

        try
        {
            var postRequest = new RestRequest("Genres", Method.Post);
            postRequest.AddJsonBody(newGenere);

            var actualGenre = await _client.ExecuteAsync<Genres>(postRequest);

            newGenere.Name = DateTime.Now.ToString();

            // Update
            var putRequest = new RestRequest($"Genres/{newGenere.GenreId}", Method.Put);
            putRequest.AddJsonBody(newGenere);
            var updatedGenre = await _client.ExecuteAsync<Genres>(putRequest);

            // check if it is created successfully
            var getRequest = new RestRequest($"Genres/{newGenere.GenreId}", Method.Get);
            var actualUpdatedGenre = await _client.GetAsync<Genres>(getRequest);

            Assert.AreEqual(newGenere.Name, actualUpdatedGenre.Name);
        }
        finally
        {
            // delete test data
            var deleteRequest = new RestRequest($"Genres/{newGenere.GenreId}", Method.Delete);
            await _client.DeleteAsync(deleteRequest);
        }
    }

    [Test]
    public async Task TestDeleteRequest()
    {
        var getAllRequest = new RestRequest(GENRES_ROUTE, Method.Get);
        var allGenres = await _client.GetAsync<List<Genres>>(getAllRequest);
        long largestId = allGenres.Select(s => s.GenreId).Max();

        var newGenere = new Genres()
        {
            Name = Guid.NewGuid().ToString(),
            GenreId = largestId + 1
        };

        var postRequest = new RestRequest("Genres", Method.Post);
        postRequest.AddJsonBody(newGenere);

        var actualGenre = await _client.ExecuteAsync<Genres>(postRequest);

        // delete test data
        var deleteRequest = new RestRequest($"Genres/{newGenere.GenreId}", Method.Delete);
        await _client.DeleteAsync(deleteRequest);

        // check if it is created successfully
        allGenres = await _client.GetAsync<List<Genres>>(getAllRequest);

        CollectionAssert.DoesNotContain(allGenres, newGenere);
    }
}
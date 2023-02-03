using NoteTakingAPI.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace NoteTakingApi.Tests
{
    public class NoteControllerTests
    {
        private readonly HttpClient _client;

        public NoteControllerTests()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7111/swagger/index.html");
        }

        [Fact]
        public async Task GetAllNotes_ReturnsOkResponse()
        {
            // Act
            var response = await _client.GetAsync("api/note");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetNoteById_ReturnsOkResponse()
        {
            // Arrange
            int id = 1;

            // Act
            var response = await _client.GetAsync($"api/note/{id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CreateNote_ReturnsOkResponse()
        {
            // Arrange
            var note = new Note { Id = 3, Title = "Test Note", Description = "Test Description", CreationDate = DateTime.Now };

            // Act
            var response = await _client.PostAsJsonAsync("api/note", note);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UpdateNote_ReturnsOkResponse()
        {
            // Arrange
            int id = 1;
            var updatedNote = new Note { Id = id, Title = "Updated Test Note", Description = "Updated Test Description", CreationDate = DateTime.Now };

            // Act
            var response = await _client.PutAsJsonAsync($"api/note/{id}", updatedNote);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task DeleteNote_ReturnsOkResponse()
        {
            // Arrange
            int id = 3;

            // Act
            var response = await _client.DeleteAsync($"api/note/{id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
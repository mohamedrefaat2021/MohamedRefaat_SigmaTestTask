using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MohamedRefaat_SigmaTestTask.API.Controllers;
using MohamedRefaat_SigmaTestTask.Domain.IRepository;
using MohamedRefaat_SigmaTestTask.Infra.Data.Models.Candidate;
using Moq;

namespace CandidateAPI.Tests
{
    public class CandidatesControllerTests
    {
        private readonly Mock<ICandidateRepository> _mockRepository;
        private readonly Mock<IMemoryCache> _mockCache;
        private readonly CandidatesController _controller;

        public CandidatesControllerTests()
        {
            _mockRepository = new Mock<ICandidateRepository>();
            _mockCache = new Mock<IMemoryCache>();
            _controller = new CandidatesController(_mockRepository.Object, _mockCache.Object);
        }

        [Fact]
        public async Task UpsertCandidate_ShouldAddNewCandidate_WhenCandidateDoesNotExist()
        {
            // Arrange
            var candidate = new Candidate
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com"
            };

            _mockRepository.Setup(m => m.GetCandidateByEmailAsync(candidate.Email)).ReturnsAsync((Candidate)null);
            _mockRepository.Setup(m => m.AddCandidateAsync(candidate)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpsertCandidate(candidate);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnCandidate = Assert.IsType<Candidate>(okResult.Value);
            returnCandidate.FirstName.Should().Be(candidate.FirstName);

            _mockRepository.Verify(m => m.AddCandidateAsync(It.IsAny<Candidate>()), Times.Once);
        }

        [Fact]
        public async Task UpsertCandidate_ShouldUpdateExistingCandidate_WhenCandidateExists()
        {
            // Arrange
            var existingCandidate = new Candidate
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com"
            };

            var updatedCandidate = new Candidate
            {
                FirstName = "Jane",
                LastName = "Doe",
                Email = "john.doe@example.com"
            };

            _mockRepository.Setup(m => m.GetCandidateByEmailAsync(existingCandidate.Email)).ReturnsAsync(existingCandidate);
            _mockRepository.Setup(m => m.UpdateCandidateAsync(existingCandidate)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpsertCandidate(updatedCandidate);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnCandidate = Assert.IsType<Candidate>(okResult.Value);
            returnCandidate.FirstName.Should().Be(updatedCandidate.FirstName);

            _mockRepository.Verify(m => m.UpdateCandidateAsync(It.IsAny<Candidate>()), Times.Once);
        }
    }
}

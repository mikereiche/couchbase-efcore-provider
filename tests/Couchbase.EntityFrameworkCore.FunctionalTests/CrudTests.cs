using ContosoUniversity.Models;
using Couchbase.Core.IO.Operations;
using Couchbase.Core.IO.Transcoders;
using Couchbase.EntityFrameworkCore.Extensions;
using Couchbase.EntityFrameworkCore.FunctionalTests.Fixtures;
using Couchbase.EntityFrameworkCore.FunctionalTests.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace Couchbase.EntityFrameworkCore.FunctionalTests;

[Collection(CouchbaseTestingCollection.Name)]
public class CrudTests
{
    private readonly CouchbaseFixture _couchbaseFixture;
    private readonly ITestOutputHelper _outputHelper;

    public CrudTests(CouchbaseFixture couchbaseFixture, ITestOutputHelper outputHelper)
    {
        _couchbaseFixture = couchbaseFixture;
        _outputHelper = outputHelper;
    }

    [Fact]
    public async Task Test_ExecuteUpdate()
    {
        await using var context = _couchbaseFixture.TravelSampleContext;
        var airline1 = new Airline
        {
            Type = "airline",
            Id = 666,
            Callsign = "MILE-AIR",
            Country = "United States",
            Icao = "MLA",
            Iata = "Q5",
            Name = "40-Mile Air"
        };

        var airline2 = new Airline
        {
            Type = "airline",
            Id = 667,
            Callsign = "MILE-AIR",
            Country = "United States",
            Icao = "MLA",
            Iata = "Q5",
            Name = "40-Mile Air"
        };

        try
        {
            context.Update(airline1);
            context.Update(airline2);

            var inserted = await context.SaveChangesAsync();
            Assert.Equal(2, inserted);

            //RYOW is currently not supported, so we need a brief delay for indexing etc.
            await Task.Delay(100);

            var count = await context.Airlines.CountAsync(a => a.Id > 665 && a.Id < 668);
            Assert.Equal(2, count);

            await context.Airlines
                .Where(a => a.Id > 665 && a.Id < 668)
                .ExecuteUpdateAsync(setters =>
                    setters.SetProperty(a => a.Country, "Banana Republic"));

            var count2 = await context.Airlines.CountAsync(a => a.Country == "Banana Republic");
            Assert.Equal(2, count2);
        }
        finally
        {
            context.Remove(airline1);
            context.Remove(airline2);
            await context.SaveChangesAsync();
        }
    }

    [Fact]
    public async Task Test_ExecuteDelete()
    {
        var context = _couchbaseFixture.TravelSampleContext;
        var airline1 = new Airline
        {
            Type = "airline",
            Id = 777,
            Callsign = "MILE-AIR",
            Country = "United States",
            Icao = "MLA",
            Iata = "Q5",
            Name = "40-Mile Air"
        };

        var airline2 = new Airline
        {
            Type = "airline",
            Id = 778,
            Callsign = "MILE-AIR",
            Country = "United States",
            Icao = "MLA",
            Iata = "Q5",
            Name = "40-Mile Air"
        };

        try
        {
            context.Update(airline1);
            context.Update(airline2);

            await context.SaveChangesAsync();
            var count = await context.Airlines.CountAsync(a => a.Id > 776 && a.Id < 779);
            Assert.Equal(2, count);

            await context.Airlines
                .Where(a => a.Id > 776 && a.Id < 779)
                .ExecuteDeleteAsync();

            var count2 = await context.Airlines.CountAsync(a => a.Id > 776 && a.Id < 779);
            Assert.Equal(0, count2);
        }
        finally
        {
            if (context.Remove(airline1).State != EntityState.Deleted)
            {
                await context.SaveChangesAsync();
            }

            if (context.Remove(airline2).State != EntityState.Deleted)
            {
                await context.SaveChangesAsync();
            }
        }
    }

    [Fact]
    public async Task Test_ComplexObject()
    {
        var context = _couchbaseFixture.TravelSampleContext;

        var user = new User
        {
            Name = "Jeff Morris",
            DrivingLicence = "A^&*GUIOO",
            PreferredEmail = "jefry@job.com",
            Addresses =
            [
                new Address
                {
                    City = "Huntington Beach", Country = "USA", HomeAddress = "10032 Stonybrook Drive", ID = "1",
                    Type = "Home"
                },
                new Address
                {
                    City = "Newport", ID = "2", HomeAddress = "123 Balboa Ave", Country = "USA", Type = "Work"
                }
            ]
        };
        context.Update(user);
        await context.SaveChangesAsync();
    }

    [Fact]
    public async Task Test_AddAsync()
    {
        var context = _couchbaseFixture.TravelSampleContext;
        var airline = new Airline
        {
            Type = "airline",
            Id = 11,
            Callsign = "MILE-AIR",
            Country = "United States",
            Icao = "MLA",
            Iata = "Q5",
            Name = "40-Mile Air"
        };
        try
        {
            var saved = context.Update(airline);
            await context.SaveChangesAsync();

            var airline1 = await context.Airlines.FindAsync("airline", 11);
            Assert.Equal(airline, airline1);
        }
        finally
        {
            var entity = context.Remove(airline);
            await context.SaveChangesAsync();
        }
    }

    [Fact]
    public async Task Test_RemoveAsync()
    {
        var context = _couchbaseFixture.TravelSampleContext;
        var airline = new Airline
        {
            Type = "airline",
            Id = 11,
            Callsign = "MILE-AIR",
            Country = "United States",
            Icao = "MLA",
            Iata = "Q5",
            Name = "40-Mile Air"
        };

        context.Add(airline);
        await context.SaveChangesAsync();

        context.Remove(airline);
        await context.SaveChangesAsync();

        var airline1 = await context.Airlines.FindAsync("airline", 11);
        Assert.Null(airline1);
    }

    [Fact]
    public async Task Test_UpdateAsync()
    {
        var context = _couchbaseFixture.TravelSampleContext;
        var airline = new Airline
        {
            Type = "airline",
            Id = 11,
            Callsign = "MILE-AIR",
            Country = "United States",
            Icao = "MLA",
            Iata = "Q5",
            Name = "40-Mile Air"
        };
        try
        {
            context.Add(airline);
            await context.SaveChangesAsync();

            var airline1 = await context.Airlines.FindAsync("airline", 11);
            airline1.Name = "bob";
            context.Update(airline1);

            await context.SaveChangesAsync();
            var airlineChanged = await context.Airlines.FindAsync("airline", 11);
            Assert.Equal("bob", airlineChanged.Name);
        }
        finally
        {
            context.Remove(airline);
            await context.SaveChangesAsync();
        }
    }

    [Fact]
    public async Task Test_AddAsyncAsync()
    {
        await using var context = _couchbaseFixture.TravelSampleContext;
        var airline = new Airline
        {
            Type = "airline",
            Id = 11,
            Callsign = "MILE-AIR",
            Country = "United States",
            Icao = "MLA",
            Iata = "Q5",
            Name = "40-Mile Air"
        };
        try
        {
            context.Update(airline);
            await context.SaveChangesAsync();

            var airline1 = await context.Airlines.FindAsync("airline", 11);
            Assert.Equal(airline, airline1);
        }
        finally
        {
            context.Remove(airline);
            await context.SaveChangesAsync();
        }
    }

    [Fact]
    public async Task Test_SaveChanges()
    {
        using (var context = new BloggingContext())
        {
            context.Blogs.Add(new Blog
            {
                BlogId = Guid.NewGuid().GetHashCode(), Url = "http://example.com"
            });
            await context.SaveChangesAsync();
            var blog = await context.Blogs.FirstAsync(b => b.Url == "http://example.com");
            blog.Url = "http://example.com/blog";
            await context.SaveChangesAsync();
            context.Remove(blog);
            await context.SaveChangesAsync();
        }
    }

    [Fact]
    public async Task Test_Saving_Related_Data()
    {
        using (var context = new BloggingContext())
        {
            var blog = new Blog
            {
                BlogId = Guid.NewGuid().GetHashCode(),
                Url = "http://blogs.msdn.com/dotnet",
                Posts =
                [
                    new() { Title = "Intro to C#", PostId = Guid.NewGuid().GetHashCode() },
                    new() { Title = "Intro to VB.NET", PostId = Guid.NewGuid().GetHashCode() },
                    new() { Title = "Intro to F#", PostId = Guid.NewGuid().GetHashCode() }
                ]
            };

            try
            {
                await context.Blogs.AddAsync(blog);
                var count = await context.SaveChangesAsync();
                Assert.Equal(4, count);
            }
            finally
            {
                context.Remove(blog);
                await context.SaveChangesAsync();
            }
        }
    }

    [Fact]
    public async Task Test_Adding_Related_Entity()
    {
        await using (var context = new BloggingContext())
        {
            context.Update(new Blog{ BlogId = 10, Url = "http://example.com" });
            context.Update(new Post { BlogId = 10, PostId = 10 });
            await context.SaveChangesAsync();

            var blog = await context.Blogs.FirstAsync();
            blog.Posts = await context.Posts.Where(x => x.BlogId == blog.BlogId).ToListAsync();

            var post = new Post { Title = "Intro to EF Core", PostId = 11};
            blog.Posts.Add(post);
            await context.SaveChangesAsync();

            blog.Posts.Remove(post);
            await context.SaveChangesAsync();
        }
    }

    [Fact]
    public async Task Test_Changing_Relationships()
    {
        using (var context = new BloggingContext())
        {
            context.Update(new Post { Title = "Intro to EF Core", PostId = 4, BlogId = 2 });
            await context.SaveChangesAsync();
            var blog1 = await context.Blogs.FirstAsync();

            var blog = new Blog { Url = "http://blogs.msdn.com/visualstudio", BlogId = 2};
            var post = await context.Posts.FirstAsync();

            post.Blog = blog;
            await context.SaveChangesAsync();
        }
    }

    [Fact]
    public async Task Removing_Relationships_Async()
    {
        using (var context = new BloggingContext())
        {
            var blog = new Blog { Url = "http://blogs.msdn.com/visualstudio", BlogId = 2 };
            var post = new Post { Title = "Intro to EF Core", PostId = 4, BlogId = 2 };
            try
            {
                context.Update(blog);
                await context.SaveChangesAsync();

                context.Update(post);
                await context.SaveChangesAsync();

                blog = await context.Blogs.FirstAsync();
                var posts = await context.Posts.ToListAsync();
                blog.Posts = await context.Posts.Where(x => x.BlogId == blog.BlogId).ToListAsync();
                post = blog.Posts.First();
            }
            catch (Exception ex)
            {
                _outputHelper.WriteLine(ex.Message);
            }
            finally
            {

                blog.Posts.Remove(post);
                await context.SaveChangesAsync();
            }
        }
    }
}
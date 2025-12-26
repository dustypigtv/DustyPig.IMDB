using DustyPig.IMDB;

namespace APITests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public async Task SearchTitle()
    {
        var client = new Client() { AutoThrowIfError = true };
        var ret = await client.SearchTitleAsync("The Avengers", "movie", 2012, false);
        Assert.IsTrue(ret.Data!.Any(_ => _.Basic.TConst.Equals("tt0848228")));
    }

    [TestMethod]
    public async Task GetTitle()
    {
        var client = new Client() { AutoThrowIfError = true };
        var ret = await client.GetTitleAsync("tt0848228");
    }

    [TestMethod]
    public async Task SearchPerson()
    {
        var client = new Client() { AutoThrowIfError = true };
        var ret = await client.SearchPersonAsync("Chris Evans", "actor");
        Assert.IsTrue(ret.Data!.Any(_ => _.NConst.Equals("nm0262635")));
    }

    [TestMethod]
    public async Task GetPerson()
    {
        var client = new Client() { AutoThrowIfError = true };
        var ret = await client.GetPersonAsync("nm0262635");
    }
}

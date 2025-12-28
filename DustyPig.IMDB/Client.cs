using DustyPig.IMDB.Models;
using DustyPig.REST;
using Microsoft.Extensions.Logging;

namespace DustyPig.IMDB;

public class Client
{
    public const string API_VERSION = "1.0";
    public const string API_AS_OF_DATE = "12/26/2025";

    private const string API_BASE_ADDRESS = "https://imdb-api.dustypig.tv/";

    private static readonly HttpClient _httpClient = new();
    private readonly REST.Client _restClient;


    public Client() : this(null, null) { }

    public Client(HttpClient httpClient) : this(httpClient, null) { }

    public Client(ILogger<Client> logger) : this(null, logger) { }

    public Client(HttpClient? httpClient, ILogger<Client>? logger)
    {
        _restClient = new(httpClient ?? _httpClient, logger) { BaseAddress = new(API_BASE_ADDRESS) };
    }

    public bool IncludeRawContentInResponse
    {
        get => _restClient.IncludeRawContentInResponse;
        set => _restClient.IncludeRawContentInResponse = value;
    }

    public bool AutoThrowIfError
    {
        get => _restClient.AutoThrowIfError;
        set => _restClient.AutoThrowIfError = value;
    }

    /// <summary>
    /// When an error occurs, how many times to retry the api call.
    /// <br />
    /// Default = 0
    /// </summary>
    /// <remarks>
    /// <para>
    /// There are 2 events that can trigger a retry:
    /// </para>
    /// <para>
    /// 1. There is an error connecting to the server (such as a network layer error).
    /// </para>
    /// <para>
    /// 2. The connection succeeded, but the server sent HttpStatusCode.TooManyRequests
    ///    (429). In this case, the client will attempt to get the RetryAfter header, and
    ///    if found, the delay will use that value. If not found, exponential backoff with
    ///    jitter will be used.
    /// </para>
    /// </remarks>
    public ushort RetryCount
    {
        get => _restClient.RetryCount;
        set => _restClient.RetryCount = value;
    }



    public Task<Response<Title>> GetTitleAsync(string tconst, CancellationToken cancellationToken = default) =>
        _restClient.GetAsync<Title>($"API/GetTitle/{tconst}", null, cancellationToken);



    public Task<Response<NameBasic>> GetPersonAsync(string nconst, CancellationToken cancellationToken = default) =>
        _restClient.GetAsync<NameBasic>($"API/GetPerson/{nconst}", null, cancellationToken);



    public Task<Response<List<TitleSearchResult>>> SearchTitleAsync(string query, string? titleType, int? year, bool? adult, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> qpd = [];

        qpd.Add("query", Uri.EscapeDataString(query));

        if (titleType.HasValue())
            qpd.Add("titleType", Uri.EscapeDataString(titleType));

        if (year.HasValue)
            qpd.Add("year", year.Value.ToString());

        if (adult.HasValue)
            qpd.Add("adult", adult.Value.ToString());

        var qp = string.Join('&', qpd.Select(_ => $"{_.Key}={_.Value}"));

        return _restClient.GetAsync<List<TitleSearchResult>>($"API/SearchTitle?{qp}", null, cancellationToken);
    }



    public Task<Response<List<TitleSearchResult>>> SearchTitleAsync(string query, TitleTypes? titleType, int? year, bool? adult, CancellationToken cancellationToken = default)
    {
        string? titleTypeStr = null;
        if(titleType.HasValue)
        {
            titleTypeStr = titleType.ToString();
            titleTypeStr = titleTypeStr![0].ToString().ToLower() + titleTypeStr[1..];
        }

        return SearchTitleAsync(query, titleTypeStr, year, adult, cancellationToken);
    }



    public Task<Response<List<NameBasic>>> SearchPersonAsync(string query, string? primaryProfession, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> qpd = [];

        qpd.Add("query", Uri.EscapeDataString(query));

        if (primaryProfession.HasValue())
            qpd.Add("primaryProfession", Uri.EscapeDataString(primaryProfession));

        var qp = string.Join('&', qpd.Select(_ => $"{_.Key}={_.Value}"));

        return _restClient.GetAsync<List<NameBasic>>($"API/SearchPerson?{qp}", null, cancellationToken);
    }



    public Task<Response<List<NameBasic>>> SearchPersonAsync(string query, PrimaryProfessions? primaryProfession, CancellationToken cancellationToken = default)
    {
        string? primaryProfessionStr = null;
        if (primaryProfession.HasValue)
            primaryProfessionStr = primaryProfession.ToString()!.ToLower();
        return SearchPersonAsync(query, primaryProfessionStr, cancellationToken);
    }



    /// <summary>
    /// This endpoint isn't for public use
    /// </summary>
    public Task<Response<List<ExternalData>>> NextExternalToFindAsync(string privilegedApiKey, ushort? count = null, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> qpd = [];
        qpd.Add("privilegedApiKey", privilegedApiKey);
        if (count > 0)
            qpd.Add("count", count.Value.ToString());

        var qp = string.Join('&', qpd.Select(_ => $"{_.Key}={_.Value}"));

        return _restClient.GetAsync<List<ExternalData>>($"API/NextExternalToFind?{qp}", null, cancellationToken);
    }


    /// <summary>
    /// This endpoint isn't for public use
    /// </summary>
    public Task<Response> UpdateExternalDataAsync(string privilegedApiKey, IEnumerable<ExternalData> externalDatas, CancellationToken cancellationToken = default) =>
        _restClient.PostAsync($"API/UpdateExternalData?privilegedApiKey={privilegedApiKey}", externalDatas, null, cancellationToken);
}

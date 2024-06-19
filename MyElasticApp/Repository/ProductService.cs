using System.Collections.Generic;
using System.Threading.Tasks;
using Nest;

public class ProductService : IProductService
{
    private readonly IElasticClient _elasticClient;

    public ProductService(IElasticClient elasticClient)
    {
        _elasticClient = elasticClient;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var searchResponse = await _elasticClient.SearchAsync<Product>(s => s
            .MatchAll()
            .Size(10000)
        );

        if (!searchResponse.IsValid)
        {
            throw new Exception($"Failed to retrieve documents: {searchResponse.ServerError}");
        }

        return searchResponse.Documents;
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        var response = await _elasticClient.GetAsync<Product>(id.ToString());
        return response.Source;
    }

    public async Task<IEnumerable<Product>> SearchAsync(string query)
    {
        var response = await _elasticClient.SearchAsync<Product>(s => s
            .Query(q => q
                .MultiMatch(m => m
                    .Fields(f => f
                        .Field(p => p.Name))
                    .Query(query)
                )
            )
            .Size(10000)
        );

        if (!response.IsValid)
        {
            throw new Exception($"Failed to search documents: {response.ServerError}");
        }

        return response.Documents;
    }
}
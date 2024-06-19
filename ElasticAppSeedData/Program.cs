using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using Nest;

class Program
{
    private static readonly string elasticsearchUrl = "http://localhost:9200";
    private static readonly string indexName = "products";

    static async Task Main(string[] args)
    {
        var settings = new ConnectionSettings(new Uri(elasticsearchUrl))
            .DefaultIndex(indexName);
        var client = new ElasticClient(settings);

        // Indeksin var olup olmadığını kontrol et, varsa sil ve yeniden oluştur
        var existsResponse = await client.Indices.ExistsAsync(indexName);
        if (existsResponse.Exists)
        {
            await client.Indices.DeleteAsync(indexName);
        }

        var createIndexResponse = await client.Indices.CreateAsync(indexName, c => c
            .Map<Product>(m => m
                .Properties(p => p
                    .Number(n => n.Name(nn => nn.Id).Type(NumberType.Integer))
                    .Text(t => t.Name(n => n.Name))
                    .Number(n => n.Name(nn => nn.Price))
                )
            )
        );

        // Faker ile veri oluşturma
        var faker = new Faker<Product>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()));

        var products = new List<Product>();
        for (int i = 0; i < 1000000; i++)
        {
            products.Add(faker.Generate());
        }

        // Toplu veri ekleme
        int batchSize = 1000; // Her bir toplu işlemdeki veri sayısı
        for (int i = 0; i < products.Count; i += batchSize)
        {
            var batch = products.GetRange(i, Math.Min(batchSize, products.Count - i));
            var bulkIndexResponse = await client.BulkAsync(b => b
                .Index(indexName)
                .IndexMany(batch)
            );

            if (bulkIndexResponse.Errors)
            {
                Console.WriteLine("Hata oluştu: ");
                foreach (var itemWithError in bulkIndexResponse.ItemsWithErrors)
                {
                    Console.WriteLine("Hata: " + itemWithError.Error.Reason);
                }
            }
            else
            {
                Console.WriteLine($"{batch.Count} adet veri eklendi. Toplam: {i + batch.Count}");
            }
        }

        Console.WriteLine("Veri ekleme işlemi tamamlandı.");
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

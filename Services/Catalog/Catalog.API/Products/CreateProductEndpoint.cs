namespace Catalog.API.Products;

public record CreateProductRequest(
    string Name,
    string Description,
    decimal Price,
    List<string> Category,
    string ImageFile);

public record CreateProductResponse(Guid Id);

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductRequest request, ISender sender, CancellationToken ct) =>
            {
                var command = request.Adapt<CreateProductCommand>();

                var result = await sender.Send(command, ct);

                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"products/{response.Id}", response);
            })
            .WithName("CreateProduct")
            .WithDescription("Creates a new product")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .ProducesValidationProblem();
    }
}
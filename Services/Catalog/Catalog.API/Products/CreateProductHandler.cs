using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products;

public record CreateProductCommand(string Name, string Description, decimal Price, List<string> Category, string ImageFile)
    : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = command.Name,
            Discription = command.Description,
            Price = command.Price,
            Category = command.Category,
            ImageFile = command.ImageFile
        };

        return new CreateProductResult(Guid.NewGuid());
    }
}


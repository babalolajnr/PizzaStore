using Microsoft.EntityFrameworkCore;

namespace PizzaStore.DB;

/// <summary>
/// Represents a pizza in the database.
/// </summary>
public record Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}

/// <summary>
/// Represents a database of available pizzas.
/// </summary>
public class PizzaDB : DbContext
{
    public PizzaDB(DbContextOptions<PizzaDB> options) : base(options) { }
    public DbSet<Pizza> Pizzas { get; set; } = null!;
}
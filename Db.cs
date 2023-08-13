namespace PizzaStore.DB;

/// <summary>
/// Represents a pizza in the database.
/// </summary>
public record Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

/// <summary>
/// Represents a database of available pizzas.
/// </summary>
public class PizzaDB
{
    private static List<Pizza> _pizzas = new()
    {
        new Pizza { Id = 1, Name = "Cheese" },
        new Pizza { Id = 2, Name = "Pepperoni" },
        new Pizza { Id = 3, Name = "Sausage" },
        new Pizza { Id = 4, Name = "Veggie" },
        new Pizza { Id = 5, Name = "Supreme" },
    };

    /// <summary>
    /// Returns a list of all available pizzas.
    /// </summary>
    public static List<Pizza> GetPizzas() => _pizzas;

    /// <summary>
    /// Retrieves a pizza from the database by its ID.
    /// </summary>
    /// <param name="id">The ID of the pizza to retrieve.</param>
    /// <returns>The pizza with the specified ID, or null if no such pizza exists.</returns>
    public static Pizza? GetPizza(int id) => _pizzas.SingleOrDefault(p => p.Id == id);

    /// <summary>
    /// Adds a new pizza to the database.
    /// </summary>
    /// <param name="pizza">The pizza to add.</param>
    /// <returns>The added pizza.</returns>
    public static Pizza CreatePizza(Pizza pizza)
    {
        // pizza.Id = _pizzas.Max(p => p.Id) + 1;
        _pizzas.Add(pizza);
        return pizza;
    }

    /// <summary>
    /// Updates a pizza in the database with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the pizza to update.</param>
    /// <param name="update">The updated pizza object.</param>
    /// <returns>The updated pizza object.</returns>
    public static Pizza? UpdatePizza(int id, Pizza update)
    {
        _pizzas = _pizzas.Select(pizza =>
        {
            if (pizza.Id == update.Id)
            {
                pizza.Name = update.Name;
            }
            return pizza;
        }).ToList();

        return update;
    }

    /// <summary>
    /// Removes a pizza from the list of available pizzas by its ID.
    /// </summary>
    /// <param name="id">The ID of the pizza to remove.</param>
    public static void RemovePizza(int id) => _pizzas.RemoveAll(p => p.Id == id);
}
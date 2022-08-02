// See https://aka.ms/new-console-template for more information
using TemporalTables;

Console.WriteLine("Hello, World!");
var context = new MyContext();
await context.Database.EnsureCreatedAsync();
var userId = Guid.NewGuid();
await context.Users.AddAsync(new User {
    Id = userId,
    Name = "Henk"
});

await context.SaveChangesAsync();

var user = context.Users.FirstOrDefault(c=> c.Id == userId);
user!.Name = "Karel";

await context.SaveChangesAsync();

var updatedUser = context.Users.FirstOrDefault(c=> c.Id == userId)!;

context.Remove(updatedUser);

await context.SaveChangesAsync();
using Microsoft.EntityFrameworkCore;

namespace AuthService.Application;

public class UsersService
{
    private readonly IApplicationDbContext _db;

    public async Task<User> Create(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync(CancellationToken.None);
        return user;
    }

    public async Task<User?> Get(Guid id)
    {
        var user = await _db.Users.FindAsync(id);
        return user;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        var results = await _db.Users.ToListAsync();
        return results;
    }

    public async Task<IEnumerable<User>> Find(string username, string email)
    {
        var result = await _db.Users.AsQueryable()
            .Where(u => string.IsNullOrEmpty(email) ? true : u.email.Contains(email))
            .Where(u => string.IsNullOrEmpty(username) ? true : u.Username.Contains(username))
            .ToListAsync();
        return result;
    }

    public async Task<User?> Update(User user)
    {
        var result = _db.Users.Update(user);
        if (result == null)
            return null;
        await _db.SaveChangesAsync(CancellationToken.None);
        return user;
    }

    public async Task<User?> Delete(User user)
    {
        var result = _db.Users.Remove(user);
        await _db.SaveChangesAsync(CancellationToken.None);
        return result.Entity;
    }

    public UsersService(IApplicationDbContext db)
    {
        _db = db;
    }
}
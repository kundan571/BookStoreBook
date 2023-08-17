﻿using Microsoft.EntityFrameworkCore;

namespace BookStore.Book.Entity;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {  
    }

    public DbSet<BookEntity> Books { get; set; }
}

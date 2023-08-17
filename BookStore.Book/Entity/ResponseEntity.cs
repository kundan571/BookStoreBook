﻿namespace BookStore.Book.Entity;

public class ResponseEntity
{
    public object Data { get; set; }
    public bool IsSuccess { get; set; } = false;
    public string Message { get; set; } = "Execution successfull";
}

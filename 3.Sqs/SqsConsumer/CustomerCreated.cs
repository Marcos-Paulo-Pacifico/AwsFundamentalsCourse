﻿namespace SqsPublisher;

public class CustomerCreated
{
    public required Guid Id { get; init; }
    public required string FullName { get; init; }
    public required string Email { get; init; }
    public required string GutHubUsername { get; init; }
    public required DateTime DateOfBirth { get; init; }
}
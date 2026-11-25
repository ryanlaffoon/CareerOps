
namespace CareerOps.Modules.ProfessionalProfile.Entities;

public sealed class Employment
{
    // Required by EF Core
    private Employment() { }

    public Guid Id { get; private set; }

    public string CompanyName { get; private set; } = string.Empty;

    public string JobTitle { get; private set; } = string.Empty;

    public DateOnly StartDate { get; private set; }

    public DateOnly? EndDate { get; private set; }

    public string? Description { get; private set; }

    public bool IsCurrent { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }

    public static Employment Create(
        string companyName,
        string jobTitle,
        DateOnly startDate,
        DateOnly? endDate = null,
        string? description = null,
        bool isCurrent = false)
    {
        if (string.IsNullOrWhiteSpace(companyName))
            throw new ArgumentException("Company name is required.", nameof(companyName));

        if (string.IsNullOrWhiteSpace(jobTitle))
            throw new ArgumentException("Job title is required.", nameof(jobTitle));

        if (endDate.HasValue && endDate.Value < startDate)
            throw new ArgumentException("End date cannot precede start date.", nameof(endDate));

        if (isCurrent && endDate.HasValue)
            throw new ArgumentException("Current employment cannot have an end date.", nameof(endDate));

        return new Employment
        {
            Id = Guid.NewGuid(),
            CompanyName = companyName.Trim(),
            JobTitle = jobTitle.Trim(),
            StartDate = startDate,
            EndDate = endDate,
            Description = string.IsNullOrWhiteSpace(description)
                ? null
                : description.Trim(),
            IsCurrent = isCurrent,
            CreatedAtUtc = DateTime.UtcNow
        };
    }
}

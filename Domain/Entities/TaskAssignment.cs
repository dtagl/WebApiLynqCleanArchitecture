namespace Domain.Entities;

public class TaskAssignment
{
    public int Id { get; set; }

    // Foreign Keys
    public int TaskId { get; set; }
    public Task? Task { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    public DateTime AssignedDate { get; set; }
}
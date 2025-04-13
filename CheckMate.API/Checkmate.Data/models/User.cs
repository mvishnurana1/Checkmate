namespace CheckMate.Data.models
{
    public class User
    {
        public required int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public bool IsActive { get; set; }
        public required string Email { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public required DateTimeOffset CreatedDate { get; set; }
        public virtual List<ActionItem> ActionItems { get; set; } = new List<ActionItem>();
    }
}
    
namespace CheckMate.API.models
{
    public class User
    {
        private static readonly TimeZoneInfo WaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("W. Australia Standard Time");

        public required int UserId { get; set; }
        public required string FirstName { get; set; }
        public bool IsActive { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required DateTimeOffset CreatedDate { get; set; } = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, WaTimeZone);
        public DateTimeOffset? ModifiedDate { get; set; }
        public virtual List<ActionItem> ActionItems { get; set; } = new List<ActionItem>();
    }
}

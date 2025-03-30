namespace CheckMate.API.models
{
    public class ActionItem
    {
        private static readonly TimeZoneInfo WaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("W. Australia Standard Time");
        public required int ActionItemID { get; set; }
        public required int UserID { get; set; }
        public required string ActionItemName { get; set; }
        public bool IsActive { get; set; }
        public string? ActionItemDescription { get; set; }
        public required DateTimeOffset CreatedDate { get; set; } = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, WaTimeZone);
        public DateTimeOffset? ModifiedDate { get; set; }
        public virtual required User User { get; set; }
    }
}

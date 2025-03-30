namespace CheckMate.API.models
{

    public class ActionItemStatus
    {
        private static readonly TimeZoneInfo WaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("W. Australia Standard Time");
        public required int ActionItemStatusId { get; set; }
        public bool IsActive { get; set; }
        public required string KnownActionDescription { get; set; }
        public required KnownActionItemStatus KnownActionItemStatus { get; set; }
        public required DateTimeOffset CreatedDate { get; set; } = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, WaTimeZone);
        public DateTimeOffset ModifiedDate { get; set; }
    }
}

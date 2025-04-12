namespace CheckMate.API.models
{
    public class ActionItem
    {
        public required int ActionItemID { get; set; }
        public required int UserID { get; set; }
        public required string ActionItemName { get; set; }
        public string? ActionItemDescription { get; set; }
        public required string Status { get; set; }
        public required DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public virtual required User CreatedBy { get; set; }
    }
}

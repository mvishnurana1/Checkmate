using System.ComponentModel;

namespace CheckMate.Data.models
{
    public enum KnownActionItemStatus
    {
        [Description("Open")]
        Open = 1,

        [Description("InProgress")]
        InProgress = 2,

        [Description("Closed")]
        Closed = 3,

        [Description("Cancelled")]
        Cancelled = 4
    }
}

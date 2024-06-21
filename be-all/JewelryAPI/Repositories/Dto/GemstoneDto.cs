namespace SWP3.Dto
{
    public class GemstoneDto
    {
        public int GemstoneId { get; set; }

        public string GemstoneType { get; set; } = null!;

        public int GemstoneCarat { get; set; }

        public string? Color { get; set; }
    }
}

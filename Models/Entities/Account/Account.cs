namespace LearningAPI.Models.Entities.Account
{
    public class Account
    {
        public Guid AccountId { get; set; }
        public required string AccountName { get; set; }
        public required string AccountPassword { get; set; }
        public string? AccountAddress { get; set; }
        public required bool IsDeleted { get; set; }
    }
}
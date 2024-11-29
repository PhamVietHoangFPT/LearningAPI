namespace LearningAPI.Models.Entities.Account.AccountDTO
{
    public class AddAccountDto
    {
        public required string AccountName { get; set; }

        public required string AccountPassword { get; set; }

        public string? AccountAddress { get; set; }

        public bool IsDeleted { get; set; }
    }
}

namespace LearningAPI.Models.Entities.Account.AccountDTO
{
    public class UpdateAccountDTO
    {
        public required string AccountName { get; set; }
        public required string AccountPassword { get; set; }
        public required string AccountAddress { get; set; }
    }
}

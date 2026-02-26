namespace EmployeeManagementAPI.DTOs
{
    public class AuthorizeResponseDto
    {
        public string Token { get;set; } = string.Empty;
        public DateTime ExpiresAt {  get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}

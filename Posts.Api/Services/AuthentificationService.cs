namespace Posts.Api.Services
{
    public static class AuthentificationService
    {
        public static int GetUserId(string token)
        {
            switch (token)
            {
                case "token1":
                    return 1;
                case "token2":
                    return 2;
                default:
                    throw new Exception("Invalid token");
            }
        }
    }
}

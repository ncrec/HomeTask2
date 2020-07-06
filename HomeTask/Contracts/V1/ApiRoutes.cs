namespace HomeTask.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class TodoItems
        {
            public const string GetAll = Base + "/";

            public const string Update = Base + "/{todoId}";

            public const string Delete = Base + "/{todoId}";

            public const string Get = Base + "/{todoId}";

            public const string Create = Base + "/";
        }
        
        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            
            public const string Register = Base + "/identity/register";
            
            public const string Refresh = Base + "/identity/refresh";
        }
    }
}
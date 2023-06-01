﻿namespace CallAppAssignment.Infrastructure.Auth
{
    public class JWTConfiguration
    {
        public string Secret { get; set; }

        public int ExpirationInMinutes { get; set; }
    }
}

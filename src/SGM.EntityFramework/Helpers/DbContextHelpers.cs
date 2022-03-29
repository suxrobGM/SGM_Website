﻿namespace SGM.EntityFramework.Helpers;

internal static class DbContextHelpers
{
    public static void ConfigureSqlServer(string connectionString, DbContextOptionsBuilder options)
    {
        options.UseSqlServer(connectionString).UseLazyLoadingProxies();
    }
}
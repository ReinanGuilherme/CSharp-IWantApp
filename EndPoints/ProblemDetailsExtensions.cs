﻿using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace IWantApp_API.EndPoints
{
    public static class ProblemDetailsExtensions
    {
        public static Dictionary<string, string[]> ConvertToProblemDetails(this IReadOnlyCollection<Notification> notifications)
        {
            return notifications
                    .GroupBy(g => g.Key)
                    .ToDictionary(g => g.Key, g => g.Select(x => x.Message).ToArray());
        }
        public static Dictionary<string, string[]> ConvertToProblemDetails(this IEnumerable<IdentityError> error)
        {
            return error
                    .GroupBy(g => g.Code)
                    .ToDictionary(g => g.Key, g => g.Select(x => x.Description).ToArray());
        }
    }

}

using System;
using System.Collections.Generic;

namespace RektaRetailApp.Web.ApiModel
{
        public class Response<T> where T : class
    {
        public T Data { get; } = null!;

        public List<object>? Errors { get; } = new List<object>();

        public string CurrentResponseStatus { get; }

        public Response(string currentResponseStatus, dynamic errors)
        {
            CurrentResponseStatus = currentResponseStatus;
            Errors?.Add(errors);
        }

        public Response(T data, string currentResponseStatus, dynamic errors = null!)
        {
            Data = data ?? throw new ArgumentException("the first argument is in an invalid state!");
            CurrentResponseStatus = currentResponseStatus;
            if (errors == null || CurrentResponseStatus == ResponseStatus.Success) return;
            Errors?.Add(errors);
<<<<<<< HEAD
            CurrentResponseStatus = ResponseStatus.NonAction;
=======
            CurrentResponseStatus = ResponseStatus.Failure;
>>>>>>> e3390aa (finished with backend features for suppliers. Working on frontend features for suppliers)
            Errors?.Add(new
            {
                ErrorMessage = "The response is assuming an invalid state and has been defaulted to a state of fault!"
            });
        }
    }

    public class ResponseStatus
    {
        public static string Success { get; } = nameof(Success);

<<<<<<< HEAD
<<<<<<< HEAD
        public static string Error { get; } = nameof(Error);

        public static string Failure { get; } = nameof(Failure);

        public static string NonAction { get; } = nameof(NonAction);
    }


    public class TaskPerformed
    {
        public static string Creation { get; } = nameof(Creation);

        public static string Modification { get; } = nameof(Modification);

        public static string Deletion { get; } = nameof(Deletion);
    }

=======
        public static string Error { get; set; } = nameof(Error);
=======
        public static string Error { get; } = nameof(Error);
>>>>>>> a4e57b3 (enabled soft delete feature. Enabled domain events to carry basic logs within them. Fixing Product persistence features)

        public static string Failure { get; } = nameof(Failure);
    }


    public class TaskPerformed
    {
        public static string Creation { get; } = nameof(Creation);

        public static string Modification { get; } = nameof(Modification);

        public static string Deletion { get; } = nameof(Deletion);
    }
>>>>>>> 5ffa05a (implement soft delete on all DomainEntities.)
}

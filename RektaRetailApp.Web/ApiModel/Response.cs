using System;
using System.Collections.Generic;

namespace RektaRetailApp.Web.ApiModel
{
        public class Response<T> where T : class
    {
        public T Data { get; } = null!;

<<<<<<< HEAD
        public List<object>? Errors { get; } = new List<object>();
=======
        public dynamic? Errors { get; }
>>>>>>> 5ffa05a (implement soft delete on all DomainEntities.)

        public string CurrentResponseStatus { get; }

        public Response(string currentResponseStatus, dynamic errors)
        {
            CurrentResponseStatus = currentResponseStatus;
<<<<<<< HEAD
            Errors?.Add(errors);
=======
            Errors = errors;
>>>>>>> 5ffa05a (implement soft delete on all DomainEntities.)
        }

        public Response(T data, string currentResponseStatus, dynamic errors = null!)
        {
            Data = data ?? throw new ArgumentException("the first argument is in an invalid state!");
            CurrentResponseStatus = currentResponseStatus;
<<<<<<< HEAD
            if (errors == null || CurrentResponseStatus == ResponseStatus.Success) return;
            Errors?.Add(errors);
            CurrentResponseStatus = ResponseStatus.NonAction;
            Errors?.Add(new
            {
                ErrorMessage = "The response is assuming an invalid state and has been defaulted to a state of fault!"
            });
=======
            if (errors != null && CurrentResponseStatus != ResponseStatus.Success)
                Errors = errors;
            CurrentResponseStatus = ResponseStatus.Failure;
            Errors = new
            {
                ErrorMessage = "The response is assuming an invalid state and has been defaulted to a state of fault!"
            };
>>>>>>> 5ffa05a (implement soft delete on all DomainEntities.)
        }
    }

    public class ResponseStatus
    {
        public static string Success { get; } = nameof(Success);

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

        public static string Failure { get; set; } = nameof(Failure);
    }
>>>>>>> 5ffa05a (implement soft delete on all DomainEntities.)
}

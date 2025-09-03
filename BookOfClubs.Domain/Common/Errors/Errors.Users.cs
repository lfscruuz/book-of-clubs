using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfClubs.Domain.Common.Errors
{
    public static class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail",
                                                                 description: "Email has already been registered.");
            public static Error FailedLogin => Error.Validation(code: "User.FailedLogin",
                                                                 description: "Email or Password is incorrect.");
        }
    }
}

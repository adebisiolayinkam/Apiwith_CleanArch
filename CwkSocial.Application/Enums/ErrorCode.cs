using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.Enums
{
   public enum  ErrorCode
    {
        NotFound = 404,
        ServerError = 500,

        //Validation error should be in the range 100-199
        ValidationError = 101,

        //Infrastructure error should be in the range 200-299
        IdentityUserAlreadyExists = 201,
        IdentityCreationFailed = 202,
        IdentityUserDoesNotExist = 203,
        IncrroectPassword = 204,
        InexistenUserProfile = 205,
        UnknowError = 999
    }
}

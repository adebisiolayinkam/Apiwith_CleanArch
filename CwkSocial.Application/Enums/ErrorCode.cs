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
        IdentityCreationFailed = 202,
       

        //Application error should be in the range 300-399
        PostUpdateNotPossible = 300,
        PostDeleteNotPossible = 301,
        InteractionRemovalNotAuthorized = 302,
        IdentityUserAlreadyExists = 303,
        IdentityUserDoesNotExist = 304,
        IncrroectPassword = 305,
        UnauthorizedAccountRemoval = 306,


        UnknowError = 999
    }
}

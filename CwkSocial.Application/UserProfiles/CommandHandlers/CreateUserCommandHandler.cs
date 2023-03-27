using AutoMapper;
using Cwk.Domain.Aggregates.UserProfileAggregate;
using Cwk.Domain.Exceptions;
using CwkSocial.Application.Enums;
using CwkSocial.Application.Models;
using CwkSocial.Application.UserProfiles.Commands;
using CwkSocial.Dal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.UserProfiles.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, OperationResult<UserProfile>>
    {
        private readonly DataContext _ctx;
       
        public CreateUserCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
            
        }
        public async Task<OperationResult<UserProfile>> Handle(CreateUserCommand request,
            CancellationToken cancellationToken)
        {

            var result = new OperationResult<UserProfile>();

            try
            {
                var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName,
                               request.EmailAddress, request.Phone, request.DateofBirth,
                               request.CurrentCity, out BasicInfo basicInfo1);

                var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(),
                    basicInfo);

                _ctx.UserProfiles.Add(userProfile);
                await _ctx.SaveChangesAsync();

                result.Payload = userProfile;

                return result;
            }

            catch (UserProfileNotValidException ex)
            {
                result.IsError = true;
                ex.ValidationErrors.ForEach(e =>
                {
                    var error = new Error
                    {
                        Code = ErrorCode.ValidationError,
                        Message = $"{ex.Message}"
                    };
                    result.Errors.Add(error);
                });
                return result;
            }

           catch(Exception e)
            {
                var error = new Error
                {
                    Code = ErrorCode.UnknowError,
                    Message = $"{e.Message}"
                };
                result.IsError = true;
                result.Errors.Add(error);
                return result;
                
            }
        }
    }
}

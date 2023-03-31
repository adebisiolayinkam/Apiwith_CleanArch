﻿using Cwk.Domain.Aggregates.PostAggregate;
using CwkSocial.Application.Enums;
using CwkSocial.Application.Models;
using CwkSocial.Application.Posts.Commands;
using CwkSocial.Dal;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.Posts.CommandHandlers
{
    public class DeletePostHandler : IRequestHandler<DeletePost, OperationResult<Post>>
    {
        private readonly DataContext _ctx;

        public DeletePostHandler(DataContext ctx)
        {
            _ctx = ctx;

        }
        public async Task<OperationResult<Post>> Handle(DeletePost request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Post>();

            try
            {
                var post = await _ctx.Posts.FirstOrDefaultAsync(p => p.PostId == request.PostId);

                if (post is null)
                {
                    result.IsError = true;
                    var error = new Error
                    {
                        Code = ErrorCode.NotFound,
                        Message = $"No post found with ID {request.PostId}"
                    };
                    result.Errors.Add(error);
                    return result;
                }
                _ctx.Posts.Remove(post);
                await _ctx.SaveChangesAsync();

                result.Payload = post;
            }
            catch (Exception e)
            {
                var error = new Error
                {
                    Code = ErrorCode.UnknowError,
                    Message = $"{e.Message}"};
                result.IsError = true;
                result.Errors.Add(error);
            }

            return result;
        }
    }
}

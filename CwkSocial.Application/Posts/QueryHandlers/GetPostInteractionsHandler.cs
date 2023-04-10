﻿using Cwk.Domain.Aggregates.PostAggregate;
using CwkSocial.Application.Enums;
using CwkSocial.Application.Models;
using CwkSocial.Application.Posts.Queries;
using CwkSocial.Dal;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.Posts.QueryHandlers
{
    public class GetPostInteractionsHandler : IRequestHandler<GetPostInteractions, OperationResult<List<PostInteraction>>>
    {
        private readonly DataContext _ctx;
        public GetPostInteractionsHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<List<PostInteraction>>> Handle(GetPostInteractions request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<PostInteraction>>();

            try
            {
                var post = await _ctx.Posts
                    .Include(p => p.Interaction)
                    .ThenInclude(i => i.UserProfile)
                    .FirstOrDefaultAsync(p => p.PostId == request.PostId, cancellationToken);

                if (post == null)
                {
                    result.AddError(ErrorCode.NotFound, PostsErrorMessages.PostNotFound);
                    return result;
                }

                result.Payload = post.Interaction.ToList();
            }
            catch (Exception e)
            {

                result.AddUnknownError(e.Message);
            }
            return result;
        }
    }
}

using Microsoft.AspNet.Identity;
using SAS.Models;
using SAS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SAS.WebMVC.Controllers.WebAPI
{
    [Authorize]
    [RoutePrefix("api/Scripture")]
    public class ScriptureController : ApiController
    {
        private bool SetStarState(int scriptureId, bool newState)
        {
            // Create the service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ScriptureService(userId);

            // Get the scripture
            var detail = service.GetScriptureById(scriptureId);

            // Create the ScriptureEdit model instance with the new star state
            var updateScripture =
                new ScriptureEdit
                {
                    ScriptureId = detail.ScriptureId,
                    Book = detail.Book,
                    Chapter = detail.Chapter,
                    Verses = detail.Verses,
                    Content = detail.Content,
                    IsStarred = newState
                };

            // Return a value indicating whether the update succedded
            return service.UpdateScripture(updateScripture);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);

    }
}

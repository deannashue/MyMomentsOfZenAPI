using MyMomentsOfZenAPI.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using MyMomentsOfZenAPI.DataControllers;



namespace MyMomentsOfZenAPI.Controllers
{
    
    [RoutePrefix("api/VideoClips")]
    public class VideoClipController : ApiController
    {


        // GET: api/VideoClip
        [HttpGet]
        [Route("")]
        public IEnumerable<VideoClip> GetAllClips()
        {
      
            return DataControllers.VideoClipDataController.ListAllClips(3);

        }

        //GET" api/VideoClip/search for me
        [HttpGet]
        [Route("search/{criteria}")]
        public IEnumerable<VideoClip> GetSearchedClips(string criteria)
        {
            return DataControllers.VideoClipDataController.SearchClips(criteria, 3);
        }

        //GET" api/VideoClips/UserFavorites/1
        [HttpGet]
        [Route("UserFavorites/{id}")]
        public IEnumerable<VideoClip> GetUsersFavoriteClips(int id)
        {
            return DataControllers.VideoClipDataController.UsersFavoriteClips(id);
        }

        // GET: api/VideoClip/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(VideoClip))]
        public IHttpActionResult Get(int id)
        {
            //Call to Get Specific 

            VideoClip result =
                DataControllers.VideoClipDataController.GetVideoClip(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("{id:int}/IncPlayCount/{user:int}")]
        // POST: api/VideoClip/IncPlayCount
        public IHttpActionResult IncPlayCount(int id, int user)
        {
            bool success =
                DataControllers.VideoClipDataController.IncrementPlayCount(id, user);
           
            if (success)
            {
                return Ok(success);
            }

            return InternalServerError();
        }

        // PUT: api/VideoClip/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VideoClip/5
        public void Delete(int id)
        {
        }
    }
}

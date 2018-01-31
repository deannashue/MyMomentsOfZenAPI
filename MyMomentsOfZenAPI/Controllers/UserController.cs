using MyMomentsOfZenAPI.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using MyMomentsOfZenAPI.DataControllers;


namespace MyMomentsOfZenAPI.Controllers
{

    [RoutePrefix("api/Users")]
    public class UserController : ApiController
    {
        // GET: api/Users
        [HttpGet]
        [Route("")]
        public void GetAllUsers()
        {

            //return DataControllers.UserDataController.GetAllUsers();

        }



        
        // GET: api/Users/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(User))]
        public IHttpActionResult Get(int id)
        {
            //Call to Get Specific 

            User result =
                DataControllers.UserDataController.GetUser(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("{id:int}/FavorClip/{clipid:int}")]
        // POST: api/Users/2/FavorClip/3
        public IHttpActionResult FavorClip(int id, int clipid)
        {
            bool success =
                DataControllers.UserDataController.FavorClip(clipid, id);

            if (success)
            {
                return Ok(success);
            }

            return InternalServerError();
        }

        [HttpPost]
        [Route("{id:int}/UnFavorClip/{clipid:int}")]
        // POST: api/Users/2/FavorClip/3
        public IHttpActionResult UnFavorClip(int id, int clipid)
        {
            bool success =
                DataControllers.UserDataController.UnFavorClip(clipid, id);

            if (success)
            {
                return Ok(success);
            }

            return InternalServerError();
        }

    }
}


using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LevelAService.Controllers
{
    //Attributes for APIController and routing
    [ApiController]
    [Route("[controller]")]
    public class PullController : ControllerBase
    {

        //Use HttpGet and return applicatiion/xml
        [HttpGet("")]
        [Produces("application/xml")]
        public async Task<ActionResult> PullPayload()
        {

            GenericPublication genericPublication = new GenericPublication();
            genericPublication.lang = "en";
            genericPublication.genericPublicationName = "Level A Publication";
            genericPublication.publicationTime = DateTime.Now;

            genericPublication.publicationCreator = new InternationalIdentifier();
            genericPublication.publicationCreator.nationalIdentifier = "NATX";
            genericPublication.publicationCreator.country = "SE";

            //Add feedType genericPublication.feedType = "LevelA";

            #region Trick to get right root element correct to payload
            //Trick to return XML with root element payload
            string xmlString = Util.SerializeObject<PayloadPublication>(genericPublication);
            // Same as string xmlString = genericPublication.SerializeObject<PayloadPublication>();

            XmlDocument xmlContent = new XmlDocument();
            xmlContent.LoadXml(xmlString);
            return new OkObjectResult(xmlContent);
            #endregion

            //If return genericPublication like this you will not get the rootElement payload
            //return new OkObjectResult(genericPublication);
        }
     
    }
}

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
            genericPublication.genericPublicationName = "Hello World Publication";
            genericPublication.publicationTime = DateTime.Now;
            genericPublication.publicationCreator = new InternationalIdentifier();
            genericPublication.publicationCreator.nationalIdentifier = "NATX";
            genericPublication.publicationCreator.country = "SE";
           
            genericPublication.feedType = "LevelB";

            //Create the extension
            genericPublication._genericPublicationExtension = new _GenericPublicationExtensionType();
            genericPublication._genericPublicationExtension.genericPublicationExtended = new GenericPublicationExtended();
            genericPublication._genericPublicationExtension.genericPublicationExtended.greeting = "Hello World!";

            string xmlString = Util.SerializeObject<PayloadPublication>(genericPublication);
            XmlDocument xmlContent = new XmlDocument();
            xmlContent.LoadXml(xmlString);
            return new OkObjectResult(xmlContent);
        }
     
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LevelCService.Controllers
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

            //Create the AnotherPublication class
            AnotherClass anotherPublication = new AnotherClass();
            anotherPublication.lang = "en";
            anotherPublication.genericPublicationName = "Another Publication";
            anotherPublication.publicationTime = DateTime.Now;
            anotherPublication.publicationCreator = new InternationalIdentifier();
            anotherPublication.publicationCreator.nationalIdentifier = "NATX";
            anotherPublication.publicationCreator.country = "SE";

            anotherPublication.feedType = "LevelC";

            anotherPublication.anotherString = "Another string";

            anotherPublication._genericPublicationExtension = new _GenericPublicationExtensionType();
            anotherPublication._genericPublicationExtension.genericPublicationExtended = new GenericPublicationExtended();
            anotherPublication._genericPublicationExtension.genericPublicationExtended.greeting = "Hello World!";

            string xmlString = anotherPublication.SerializeObject<PayloadPublication>();
            
            XmlDocument xmlContent = new XmlDocument();
            xmlContent.LoadXml(xmlString);
            return new OkObjectResult(xmlContent);
        }
     
    }
}

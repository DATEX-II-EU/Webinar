using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LevelBProfiledService.Controllers
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
           
            //Not in profiile
            //genericPublication.feedType = "LevelB";

            genericPublication._genericPublicationExtension = new _GenericPublicationExtensionType();
            genericPublication._genericPublicationExtension.genericPublicationExtended = new GenericPublicationExtended();

            //Check the facets on greeting attribute, with xsd.exe facets <xs:pattern value="[A-Za-z ]*"/>) are lost.
            genericPublication._genericPublicationExtension.genericPublicationExtended.greeting = "Hello World";

            //To get nicer namespaces
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("com", "http://datex2.eu/schema/3/common");
            ns.Add("ext", "http://datex2.eu/schema/3/extension");
            ns.Add("d2", "http://datex2.eu/schema/3/d2Payload");
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
      
            string xmlString = genericPublication.SerializeObject<PayloadPublication>(ns);
           
            XmlDocument xmlContent = new XmlDocument();
            xmlContent.LoadXml(xmlString);         
            return new OkObjectResult(xmlContent);
        }
     
    }
}

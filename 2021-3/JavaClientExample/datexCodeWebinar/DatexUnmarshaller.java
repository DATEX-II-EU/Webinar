package datexCodeWebinar;
import java.io.File;
import java.io.InputStream;

import javax.xml.XMLConstants;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBElement;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Unmarshaller;
import javax.xml.transform.Source;
import javax.xml.transform.stream.StreamSource;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;

import org.xml.sax.SAXException;

import eu.datex2.schema._3.common.GenericPublication;
import eu.datex2.schema._3.common.PayloadPublication;

public class DatexUnmarshaller
{
    private Unmarshaller jaxbUnmarshaller;
    
    DatexUnmarshaller() throws JAXBException, SAXException
    {
        JAXBContext jc = JAXBContext.newInstance("eu.datex2.schema._3.d2payload");
        jaxbUnmarshaller = jc.createUnmarshaller();
        prepareValidation();
    }
    
    private void prepareValidation() throws SAXException
    {
        SchemaFactory sf = SchemaFactory.newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI); 
        Schema schema = sf.newSchema(new File("src\\DATEXII_3_D2Payload.xsd"));
        jaxbUnmarshaller.setSchema(schema);
    }
    
    PayloadPublication readDatexPayloadFromXmlStream(InputStream stream) throws JAXBException
    {
        Source source = new StreamSource(stream);
        JAXBElement<PayloadPublication> root = jaxbUnmarshaller.unmarshal(source, PayloadPublication.class);
        return root.getValue();
    }
    
    GenericPublication readGenericPublication(InputStream stream) throws JAXBException
    {
        return (GenericPublication) readDatexPayloadFromXmlStream(stream);
    }
}

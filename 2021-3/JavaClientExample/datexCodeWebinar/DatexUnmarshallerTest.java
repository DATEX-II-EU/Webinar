package datexCodeWebinar;
import static org.junit.jupiter.api.Assertions.*;

import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.List;

import javax.xml.bind.JAXBException;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.xml.sax.SAXException;

import eu.datex2.schema._3.common.GenericPublication;

class DatexUnmarshallerTest
{
    private DatexUnmarshaller datex;
            
    @BeforeEach
    void setUp() throws JAXBException, SAXException
    {
        datex = new DatexUnmarshaller();
    }
    
    @Test
    void testDatexPayloadFromLocalXml() throws IOException, JAXBException
    {
        InputStream datexStream = new FileInputStream("src\\local.xml");
        GenericPublication publication = datex.readGenericPublication(datexStream);
        assertEquals("Hello World Publication", publication.getGenericPublicationName());
    }
    
    @Test
    void testDatexPayloadFromRemoteUrl() throws IOException, JAXBException
    {
        URL url = new URL("https://d2levela.azurewebsites.net/pull");
        HttpURLConnection con = (HttpURLConnection) url.openConnection();
        con.setRequestMethod("GET");
        InputStream inputStream = con.getInputStream();
        GenericPublication publication = datex.readGenericPublication(inputStream);
        assertEquals("Level A Publication", publication.getGenericPublicationName());
    }
    
    void examineExtensionElements(GenericPublication publication)
    {
        if (publication.get_GenericPublicationExtension() != null)
        {
            // unrecognised elements in an 'any' are mapped to DOM 'Elements' by JAXB
            List<Object> extension = publication.get_GenericPublicationExtension().getAny();
            Element e = (Element) extension.get(0);
            Node n = e.getFirstChild();
            String s = n.getTextContent();
            assertEquals("Some arbitrary text inside an XML any", s);
        }
    }
}

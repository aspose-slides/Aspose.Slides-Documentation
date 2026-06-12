---
title: Licenties
type: docs
weight: 50
url: /nl/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides for JasperReports is beschikbaar als een gratis, onbeperkte evaluatie met onbeperkte tijd vanaf de [downloadpagina](https://downloads.aspose.com/slides/nl/jasperreport). De evaluatie- en gelicentieerde versies van het product zijn dezelfde download.

Als u tevreden bent met de evaluatie, [koop een licentie](https://purchase.aspose.com/buy). Zorg ervoor dat u de abonnementsvoorwaarden begrijpt en ermee akkoord gaat.

De licentie is beschikbaar voor download vanaf de bestelpagina nadat de bestelling is betaald. De licentie is een platte tekst, digitaal ondertekend XML-bestand dat informatie bevat zoals de klantnaam, het aangeschafte product en het licentietype. Wijzig de inhoud van het licentiebestand op geen enkele manier: dit maakt de licentie ongeldig.

Download de licentie naar uw computer en kopieer deze naar de juiste map (bijvoorbeeld uw toepassingsmap of **JasperReports\lib**).

## **Beperking van de evaluatieversie**
De evaluatieversie van Aspose.Slides (zonder opgegeven licentie) biedt volledige functionaliteit van het product, maar (bij het opslaan van uw presentaties) plaatst het een evaluatiewatermerk in het midden van elke dia, zoals weergegeven in de onderstaande afbeelding:

![todo:image_alt_text](evaluation_watermark.png) 

## **Een licentie toepassen**
Er zijn verschillende manieren om een licentie toe te passen, afhankelijk van of u werkt met JasperReports of JasperServer.

### **Een licentie toepassen voor JasperReports**
Gebruik een directe setLicense-methode-aanroep vergelijkbaar met Aspose.Slides voor Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Maak een stream-object aan dat het licentiebestand bevat
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
    
    //Instantieer de License-klasse
    License license = new License();
    
    //Stel de licentie in via het stream-object
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Of stel de exporter-parameter in de code in.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Een licentie toepassen op JasperServer**
Stel de exporter-parameter in de applicationContext.xml in.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```
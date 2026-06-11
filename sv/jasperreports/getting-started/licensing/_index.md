---
title: Licensiering
type: docs
weight: 50
url: /sv/jasperreports/licensing/
---
{{% alert color="primary" %}}

Aspose.Slides för JasperReports är tillgängligt som en gratis tidsobestämd utvärdering från [download page](https://downloads.aspose.com/slides/sv/jasperreport). Utvärderings- och licensierade versioner av produkten är samma nedladdning.

När du är nöjd med utvärderingen, [buy a license](https://purchase.aspose.com/buy). Se till att du förstår och godkänner abonnemangsvillkoren.

Licensen kan laddas ner från beställningssidan efter att beställningen har betalats. Licensen är en klartext, digitalt signerad XML-fil som innehåller information såsom kundnamn, den köpta produkten och licenstypen. Ändra inte innehållet i licensfilen på något sätt: detta ogiltigförklarar licensen.

Ladda ner licensen till din dator och kopiera den till lämplig mapp (till exempel din applikationsmapp eller **JasperReports\lib**).

## **Begränsning för utvärderingsversion**
Utvärderingsversionen av Aspose.Slides (utan en licens angiven) ger full produktfunktionalitet, men (när du sparar dina presentationer) infogar den ett utvärderingsvattenmärke i mitten av varje bild som visas i figuren nedan:

![todo:image_alt_text](evaluation_watermark.png) 

## **Applicera en licens**
Det finns flera sätt att applicera en licens, beroende på om du arbetar med JasperReports eller JasperServer.

### **Applicera en licens för JasperReports**
Använd ett direkt setLicense-metodanrop som i Aspose.Slides för Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Skapa ett strömobjekt som innehåller licensfilen
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Instansiera License-klassen
    License license = new License();
	
    //Ställ in licensen via strömobjektet
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Eller, sätt exportörparametern i koden.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Applicera en licens på JasperServer**
Sätt exportörparametern i applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```
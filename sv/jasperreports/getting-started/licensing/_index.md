---
title: Licensiering
type: docs
weight: 50
url: /sv/jasperreports/licensing/
---
{{% alert color="info" %}} 

Aspose.Slides for JasperReports är tillgänglig som en fri tidsobegränsad utvärdering från [nedladdningssida](https://downloads.aspose.com/slides/sv/jasperreport). Utvärderings‑ och licensierade versioner av produkten är samma nedladdning.

När du är nöjd med utvärderingen, [köp en licens](https://purchase.aspose.com/buy). Se till att du förstår och godkänner prenumerationsvillkoren.

Licensen kan hämtas från beställningssidan efter att beställningen har betalats. Licensen är en klartext, digitalt signerad XML‑fil som innehåller information såsom kundnamn, den köpta produkten och licenstypen. Ändra inte innehållet i licensfilen på något sätt: det gör licensen ogiltig.

Ladda ner licensen till din dator och kopiera den till lämplig mapp (till exempel din programmapp eller **JasperReports\lib**).
{{% /alert %}}

## **Begränsning av utvärderingsversion**
Utvärderingsversionen av Aspose.Slides (utan en specificerad licens) ger full funktionalitet, men (när du sparar dina presentationer) infogar den ett utvärderingsvattenstämpel i mitten av varje bild som visas i figuren nedan:

![todo:image_alt_text](evaluation_watermark.png) 

## **Applicera en licens**
Det finns flera sätt att applicera en licens, beroende på om du arbetar med JasperReports eller JasperServer.

### **Applicera en licens för JasperReports**
Använd ett direkt setLicense‑metodanrop liknande Aspose.Slides för Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Skapa ett strömobjekt som innehåller licensfilen
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Instansiera License-klassen
    License license = new License();
	
    //Ange licensen via strömobjektet
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
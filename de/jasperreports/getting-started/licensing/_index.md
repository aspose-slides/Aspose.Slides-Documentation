---
title: Lizenzierung
type: docs
weight: 50
url: /de/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides for JasperReports ist als kostenlose, zeitlich unbegrenzte Evaluierung von der [Download-Seite](https://downloads.aspose.com/slides/de/jasperreport) verfügbar. Die Evaluierungs‑ und Lizenzversionen des Produkts sind derselbe Download.

Wenn Sie mit der Evaluierung zufrieden sind, [kaufen Sie eine Lizenz](https://purchase.aspose.com/buy). Stellen Sie sicher, dass Sie die Abonnementbedingungen verstehen und akzeptieren.

Die Lizenz ist nach Bezahlung der Bestellung auf der Bestellseite zum Download verfügbar. Die Lizenz ist eine Klartext‑, digital signierte XML‑Datei, die Informationen wie den Kundennamen, das gekaufte Produkt und den Lizenztyp enthält. Ändern Sie den Inhalt der Lizenzdatei in keiner Weise: Dadurch wird die Lizenz ungültig.

Laden Sie die Lizenz auf Ihren Computer herunter und kopieren Sie sie in den entsprechenden Ordner (z. B. Ihr Anwendungsordner oder **JasperReports\lib**).
{{% /alert %}}

## **Einschränkung der Evaluierungsversion**
Die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) bietet die volle Produktfunktionalität, fügt jedoch (wenn Sie Ihre Präsentationen speichern) ein Evaluierungs‑Wasserzeichen in der Mitte jeder Folie ein, wie in der nachstehenden Abbildung gezeigt:

![todo:image_alt_text](evaluation_watermark.png) 

## **Lizenz anwenden**
Es gibt mehrere Möglichkeiten, eine Lizenz anzuwenden, abhängig davon, ob Sie mit JasperReports oder JasperServer arbeiten.

### **Lizenz für JasperReports anwenden**
Verwenden Sie einen direkten Aufruf der setLicense‑Methode, ähnlich wie bei Aspose.Slides für Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Erstelle ein Stream-Objekt, das die Lizenzdatei enthält
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Instanziiere die License-Klasse
    License license = new License();
	
    //Setze die Lizenz über das Stream-Objekt
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Oder setzen Sie den Exporter‑Parameter im Code.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Lizenz auf JasperServer anwenden**
Setzen Sie den Exporter‑Parameter in der applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```
---
title: Lizenzierung
type: docs
weight: 50
url: /jasperreports/licensing/
---

{{% alert color="primary" %}} 

Aspose.Slides für JasperReports ist als kostenlose, zeitlich unbegrenzte Evaluierung auf der [Download-Seite](https://downloads.aspose.com/slides/jasperreport) verfügbar. Die Evaluierungs- und lizenzierten Versionen des Produkts sind derselbe Download.

Wenn Sie mit der Evaluierung zufrieden sind, [kaufen Sie eine Lizenz](https://purchase.aspose.com/buy). Stellen Sie sicher, dass Sie die Abonnementbedingungen verstehen und akzeptieren.

Die Lizenz ist nach Zahlung der Bestellung von der Bestellseite herunterladbar. Die Lizenz ist eine im Klartext verfasste, digital signierte XML-Datei, die Informationen wie den Clientnamen, das gekaufte Produkt und den Lizenztyp enthält. Ändern Sie den Inhalt der Lizenzdatei in keiner Weise: Eine solche Änderung führt zur Ungültigkeit der Lizenz.

Laden Sie die Lizenz auf Ihren Computer herunter und kopieren Sie sie in den entsprechenden Ordner (zum Beispiel Ihren Anwendungsordner oder **JasperReports\lib**).

## **Einschränkung der Evaluierungsversion**
Die Evaluierungsversion von Aspose.Slides (ohne angegebene Lizenz) bietet die volle Produktfunktionalität, fügt jedoch (wenn Sie Ihre Präsentationen speichern) ein Evaluierungs-Wasserzeichen in der Mitte jeder Folie hinzu, wie in der Abbildung unten gezeigt:

![todo:image_alt_text](evaluation_watermark.png) 

## **Anwenden einer Lizenz**
Es gibt mehrere Möglichkeiten, eine Lizenz anzuwenden, abhängig davon, ob Sie an JasperReports oder JasperServer arbeiten.

### **Anwenden einer Lizenz für JasperReports**
Verwenden Sie einen direkten Aufruf der Methode setLicense, ähnlich wie bei Aspose.Slides für Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Erstellen Sie ein Stream-Objekt mit der Lizenzdatei
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Instanziieren Sie die License-Klasse
    License license = new License();
	
    //Setzen Sie die Lizenz durch das Stream-Objekt
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Oder setzen Sie den Exporter-Parameter im Code.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Anwenden einer Lizenz auf JasperServer**
Setzen Sie den Exporter-Parameter in der applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```
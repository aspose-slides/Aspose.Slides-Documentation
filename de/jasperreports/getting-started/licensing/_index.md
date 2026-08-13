---
title: Lizenzierung
type: docs
weight: 50
url: /de/jasperreports/licensing/
---
{{% alert color="info" %}} 
Aspose.Slides for JasperReports ist als kostenlose, zeitlich unbegrenzte Evaluation von der [Download-Seite](https://downloads.aspose.com/slides/de/jasperreport) verfügbar. Die Evaluations‑ und lizenzierten Versionen des Produkts werden über denselben Download bereitgestellt.

Wenn Sie mit der Evaluation zufrieden sind, [kaufen Sie eine Lizenz](https://purchase.aspose.com/buy). Stellen Sie sicher, dass Sie die Abonnementbedingungen verstehen und akzeptieren.

Die Lizenz kann nach erfolgter Zahlung auf der Bestellseite heruntergeladen werden. Die Lizenz ist eine Klartext‑XML‑Datei, die digital signiert ist und Informationen wie den Kundennamen, das gekaufte Produkt und den Lizenztyp enthält. Ändern Sie den Inhalt der Lizenzdatei in keiner Weise: Dadurch wird die Lizenz ungültig.

Laden Sie die Lizenz auf Ihren Computer herunter und kopieren Sie sie in den entsprechenden Ordner (z. B. Ihren Anwendungsordner oder **JasperReports\lib**).
{{% /alert %}}

## **Einschränkungen der Evaluierungs‑Version**
Die Evaluierungs‑Version von Aspose.Slides (ohne angegebene Lizenz) bietet die volle Produktfunktionalität, fügt beim Speichern Ihrer Präsentationen jedoch ein Evaluierungs‑Wasserzeichen in der Mitte jeder Folie ein, wie in der Abbildung unten gezeigt:

![todo:image_alt_text](evaluation_watermark.png) 

## **Anwenden einer Lizenz**
Es gibt mehrere Möglichkeiten, eine Lizenz anzuwenden, je nachdem, ob Sie mit JasperReports oder JasperServer arbeiten.

### **Anwenden einer Lizenz für JasperReports**
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

### **Anwenden einer Lizenz auf JasperServer**
Setzen Sie den Exporter‑Parameter in der applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```
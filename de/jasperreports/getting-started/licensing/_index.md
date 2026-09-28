---
title: Lizenzierung
type: docs
weight: 50
url: /de/jasperreports/licensing/
description: "Erfahren Sie, welche Ergänzungen die Evaluierungsversion von Aspose.Slides für JasperReports zu exportierten Dateien hinzufügt und wie Sie eine Lizenz in JasperReports und JasperReports Server anwenden."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides für JasperReports ist als kostenlose, zeitlich unbegrenzte Evaluation von der [Download-Seite](https://releases.aspose.com/slides/jasperreport/) verfügbar. Die Evaluierungs- und Lizenzversionen des Produkts werden über denselben Download bereitgestellt.

Wenn Sie mit der Evaluation zufrieden sind, [kaufen Sie eine Lizenz](https://purchase.aspose.com/pricing/slides/jasperreports/). Stellen Sie sicher, dass Sie die Abonnementbedingungen verstanden haben und diesen zustimmen.

Die Lizenz steht zum Download auf der Bestellseite zur Verfügung, nachdem die Bestellung bezahlt wurde. Die Lizenz ist eine Klartext, digital signierte XML-Datei, die Informationen wie den Kundennamen, das gekaufte Produkt und den Lizenztyp enthält. Ändern Sie den Inhalt der Lizenzdatei in keiner Weise: Dies würde die Lizenz ungültig machen.

Laden Sie die Lizenz auf Ihren Computer herunter und kopieren Sie sie in den entsprechenden Ordner (zum Beispiel in Ihren Anwendungsordner oder **JasperReports\lib**).
{{% /alert %}}

## **Einschränkung der Evaluierungsversion**
Die Evaluierungsversion von Aspose.Slides für JasperReports (ohne angegebene Lizenz) exportiert jede Seite des Berichts, fügt jedoch in allen vier Ausgabeformaten (PPT, PPTX, PDF und HTML) ein Evaluierungs-Wasserzeichen in der Mitte jeder Folie oder Seite ein, wie in der nachstehenden Abbildung gezeigt. Siehe [Evaluieren Sie Aspose.Slides](/slides/de/jasperreports/evaluate-aspose-slides/) für Details.

![Das Evaluierungs-Wasserzeichen in der Mitte einer exportierten Folie](evaluation_watermark.png)

## **Anwenden einer Lizenz**
Es gibt mehrere Möglichkeiten, eine Lizenz anzuwenden, abhängig davon, ob Sie mit JasperReports oder JasperServer arbeiten.

### **Anwenden einer Lizenz für JasperReports**
Rufen Sie die Methode `setLicense` der Klasse `License` mit einem Stream auf, der die Lizenzdatei liest, wie in Aspose.Slides für Java:

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // Erstelle ein Stream-Objekt, das die Lizenzdatei enthält.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // Instanziiere die License-Klasse.
            License license = new License();

            // Setze die Lizenz über das Stream-Objekt.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

Oder übergeben Sie den Pfad der Lizenzdatei an den Exporter im Parameter `ASExporterParameters.PPT_LICENSE`. In diesem Fragment ist `jasperPrint` ein ausgefüllter Bericht, wie in [Ihr erster Export](/slides/de/jasperreports/#your-first-export):

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Anwenden einer Lizenz auf JasperServer**
Setzen Sie die Eigenschaft `licenseFile` des Beans `pptExportParameters` in *applicationContext.xml* auf den Pfad der Lizenzdatei, wie in [Integration mit JasperServer](/slides/de/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license) gezeigt.
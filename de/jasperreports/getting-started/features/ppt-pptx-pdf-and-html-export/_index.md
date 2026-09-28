---
title: PPT, PPTX, PDF und HTML-Export
type: docs
weight: 20
url: /de/jasperreports/ppt-pptx-pdf-and-html-export/
description: "Wählen Sie den Aspose.Slides for JasperReports Exporter für PPT-, PPTX-, PDF- oder HTML-Ausgabe, exportieren Sie damit einen gefüllten Bericht und ordnen Sie die Berichtsschriftarten den Präsentationsschriftarten zu."
---
## **Exportierer**

Aspose.Slides for JasperReports fügt JasperReports vier Exporter hinzu. Jeder nimmt einen gefüllten Bericht (`JasperPrint`) und exportiert jede Berichtseite: als Folie in PPT und PPTX, als Seite in PDF und als SVG‑Bild in einer einzigen HTML‑Datei.

| Ausgabeformat | Exporter‑Klasse |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

Die Klassen befinden sich im Paket `com.aspose.slides.jasperreports` der Bibliotheks‑Jar und verwenden nicht Microsoft PowerPoint. Übergib den Bericht und die Ausgabedatei an einen Exporter mit `setParameter` und `JRExporterParameter`, die JasperReports als veraltet kennzeichnet: Die Exporter akzeptieren nicht die neuere Konfiguration `setExporterInput` und `setExporterOutput`.

## **Exportieren eines Berichts in alle vier Formate**

Das nachfolgende Programm basiert auf dem Projekt aus [Ihr erster Export](/slides/de/jasperreports/#your-first-export). Es kompiliert und füllt *hello.jrxml* einmal und übergibt den gefüllten Bericht anschließend nacheinander an jeden Exporter. Speichere es als *src/main/java/ExportAllFormats.java* in diesem Projekt:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASAbstractExporter;
import com.aspose.slides.jasperreports.ASHtmlExporter;
import com.aspose.slides.jasperreports.ASPdfExporter;
import com.aspose.slides.jasperreports.ASPptExporter;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRException;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class ExportAllFormats {
    public static void main(String[] args) throws Exception {
        // Bericht einmal kompilieren und füllen.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Den gleichen gefüllten Bericht mit jedem Exporter exportieren.
        export(new ASPptExporter(), jasperPrint, "hello.ppt");
        export(new ASPptxExporter(), jasperPrint, "hello.pptx");
        export(new ASPdfExporter(), jasperPrint, "hello.pdf");
        export(new ASHtmlExporter(), jasperPrint, "hello.html");
    }

    private static void export(ASAbstractExporter exporter, JasperPrint jasperPrint, String outputFileName) throws JRException {
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, outputFileName);
        exporter.exportReport();
    }
}
```

Führe es aus dem Projektordner aus:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

Das Programm speichert *hello.ppt*, *hello.pptx*, *hello.pdf* und *hello.html* im Projektordner. Die Hilfsmethode nimmt `ASAbstractExporter`, die Basisklasse aller vier Exporter. Ohne Lizenz enthält jede Ausgabedatei das Evaluations‑Wasserzeichen — siehe [Aspose.Slides bewerten](/slides/de/jasperreports/evaluate-aspose-slides/).

![Ein Bericht ohne Lizenz in eine Präsentation exportiert](ppt-pptx-pdf-and-html-export_1.png)

## **Schriftarten zuordnen**

Die PPT‑ und PPTX‑Exporter schreiben die Schriftartnamen des Berichtdesigns unverändert in die Präsentation. Wenn ein Textelement keine Schriftart angibt, verwendet JasperReports die Standardschrift `SansSerif`, einen logischen Java‑Schriftartnamen, der nicht unbedingt als installierte Schrift vorliegt. Um solche Namen zu ersetzen, übergebe eine Zuordnung von Berichtsschriftarten zu den Schriftarten, die in der Präsentation verwendet werden sollen, im Parameter `ASExporterParameters.PPT_FONT_MAP`. Die Schlüssel müssen exakt mit den Schriftartnamen im Bericht übereinstimmen, einschließlich Groß‑/Kleinschreibung. Jeder Wert muss eine Schriftart sein, die Java auf dem ausführenden Rechner finden kann; die Exporter ignorieren Einträge, deren Schriftart Java nicht findet.

Speichere dieses Programm als *src/main/java/MapFonts.java* im selben Projekt. Es exportiert *hello.jrxml* nach PPTX und ersetzt `SansSerif` durch Arial:

```java
import java.util.HashMap;
import java.util.Map;

import com.aspose.slides.jasperreports.ASExporterParameters;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class MapFonts {
    public static void main(String[] args) throws Exception {
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Ordne den Berichtsschriftartnamen dem Schriftartnamen zu, der in die Präsentation geschrieben wird.
        Map<String, String> fontMap = new HashMap<String, String>();
        fontMap.put("SansSerif", "Arial");

        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello-arial.pptx");
        exporter.setParameter(ASExporterParameters.PPT_FONT_MAP, fontMap);
        exporter.exportReport();
    }
}
```

Führe es aus dem Projektordner aus:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

In der gespeicherten *hello-arial.pptx* verwendet der Berichtstext Arial anstelle von `SansSerif`. Auf einem Rechner, auf dem Java Arial nicht findet – etwa ein Linux‑System ohne diese Schrift – bleibt der Text bei `SansSerif`. Auf JasperReports Server setzt man dieselbe Zuordnung über die `fontMap`‑Eigenschaft des Export‑Parameter‑Beans — siehe [Integration mit JasperServer](/slides/de/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).
---
title: PPT, PPTX, PDF and HTML Export
type: docs
weight: 20
url: /jasperreports/ppt-pptx-pdf-and-html-export/
description: "Choose the Aspose.Slides for JasperReports exporter for PPT, PPTX, PDF or HTML output, export a filled report with it, and map report fonts to presentation fonts."
---

## **Exporters**

Aspose.Slides for JasperReports adds four exporters to JasperReports. Each one takes a filled report (`JasperPrint`) and exports every report page: as a slide in PPT and PPTX, as a page in PDF, and as an SVG image in a single HTML file.

| Output format | Exporter class |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

The classes are in the `com.aspose.slides.jasperreports` package of the library jar, and they do not use Microsoft PowerPoint. Pass the report and the output file to an exporter with `setParameter` and `JRExporterParameter`, which JasperReports marks as deprecated: the exporters do not accept the newer `setExporterInput` and `setExporterOutput` configuration.

## **Export a report to all four formats**

The program below builds on the project from [Your first export](/slides/jasperreports/#your-first-export). It compiles and fills *hello.jrxml* once, then passes the filled report to each exporter in turn. Save it as *src/main/java/ExportAllFormats.java* in that project:

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
        // Compile and fill the report once.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Export the same filled report with each exporter.
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

Run it from the project folder:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

The program saves *hello.ppt*, *hello.pptx*, *hello.pdf* and *hello.html* in the project folder. The helper method takes `ASAbstractExporter`, the base class of all four exporters. Without a license, every output file carries the evaluation watermark — see [Evaluate Aspose.Slides](/slides/jasperreports/evaluate-aspose-slides/).

![A report exported to a presentation without a license](ppt-pptx-pdf-and-html-export_1.png)

## **Map fonts**

The PPT and PPTX exporters write the font names of the report design into the presentation unchanged. When a text element names no font, JasperReports uses its default font, `SansSerif`, which is a Java logical font name rather than an installed font. To replace such names, pass a map from report font names to the font names you want in the presentation in the `ASExporterParameters.PPT_FONT_MAP` parameter. The keys must match the font names in the report exactly, including case. Each value must be a font that Java finds on the machine that runs the export; the exporters ignore an entry whose font Java cannot find.

Save this program as *src/main/java/MapFonts.java* in the same project. It exports *hello.jrxml* to PPTX with `SansSerif` replaced by Arial:

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

        // Map the report font name to the font name to write to the presentation.
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

Run it from the project folder:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

In the saved *hello-arial.pptx*, the report's text uses Arial instead of `SansSerif`. On a machine where Java does not find Arial, such as a Linux system without it, the text keeps `SansSerif`. On JasperReports Server, set the same map through the `fontMap` property of the export parameters bean — see [Integration with JasperServer](/slides/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).

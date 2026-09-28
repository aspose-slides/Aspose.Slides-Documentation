---
title: PPT, PPTX, PDF och HTML-export
type: docs
weight: 20
url: /sv/jasperreports/ppt-pptx-pdf-and-html-export/
description: "Välj exportören Aspose.Slides för JasperReports för PPT-, PPTX-, PDF- eller HTML-utdata, exportera en ifylld rapport med den och mappa rapportens teckensnitt till presentationens teckensnitt."
---
## **Exportörer**

Aspose.Slides för JasperReports lägger till fyra exportörer till JasperReports. Var och en tar en ifylld rapport (`JasperPrint`) och exporterar varje rapportsida: som en bild i PPT och PPTX, som en sida i PDF och som en SVG‑bild i en enda HTML‑fil.

| Utdataformat | Exportörklass |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

Klasserna finns i paketet `com.aspose.slides.jasperreports` i bibliotekets JAR och använder inte Microsoft PowerPoint. Skicka rapporten och utdatafilen till en exportör med `setParameter` och `JRExporterParameter`, som JasperReports markerar som föråldrade: exportörerna accepterar inte den nyare konfigurationen `setExporterInput` och `setExporterOutput`.

## **Exportera en rapport till alla fyra format**

Programmet nedan bygger på projektet från [Your first export](/slides/sv/jasperreports/#your-first-export). Det kompilerar och fyller *hello.jrxml* en gång, och skickar sedan den ifyllda rapporten till varje exportör i tur och ordning. Spara det som *src/main/java/ExportAllFormats.java* i det projektet:

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
        // Kompilera och fyll i rapporten en gång.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Exportera samma ifyllda rapport med varje exportör.
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

Kör det från projektmappen:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

Programmet sparar *hello.ppt*, *hello.pptx*, *hello.pdf* och *hello.html* i projektmappen. Hjälpmetoden tar emot `ASAbstractExporter`, basklassen för alla fyra exportörer. Utan licens innehåller varje utdatafil en utvärderingsvattenstämpel — se [Evaluate Aspose.Slides](/slides/sv/jasperreports/evaluate-aspose-slides/).

![En rapport exporterad till en presentation utan licens](ppt-pptx-pdf-and-html-export_1.png)

## **Mappa teckensnitt**

PPT‑ och PPTX‑exportörerna skriver teckensnittsnamnen från rapportdesignen till presentationen oförändrade. När ett textelement inte anger något teckensnitt använder JasperReports sitt standardteckensnitt, `SansSerif`, vilket är ett Java‑logiskt teckensnittsnamn snarare än ett installerat teckensnitt. För att ersätta sådana namn, skicka en karta från rapportens teckensnittsnamn till de teckensnitt du vill ha i presentationen i parametern `ASExporterParameters.PPT_FONT_MAP`. Nycklarna måste exakt matcha teckensnittsnamnen i rapporten, inklusive versaler/gemener. Varje värde måste vara ett teckensnitt som Java hittar på maskinen som kör exporten; exportörerna ignorerar en post vars teckensnitt Java inte kan hitta.

Spara detta program som *src/main/java/MapFonts.java* i samma projekt. Det exporterar *hello.jrxml* till PPTX med `SansSerif` ersatt av Arial:

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

        // Mappa rapportens teckensnittsnamn till teckensnittsnamnet som ska skrivas till presentationen.
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

Kör det från projektmappen:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

I den sparade *hello-arial.pptx* använder rapportens text Arial istället för `SansSerif`. På en maskin där Java inte hittar Arial, till exempel ett Linux‑system utan det, behåller texten `SansSerif`. På JasperReports Server, ställ in samma karta via `fontMap`‑egenskapen på exportparametrarnas bean — se [Integration with JasperServer](/slides/sv/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).
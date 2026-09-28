---
title: PPT, PPTX, PDF en HTML-export
type: docs
weight: 20
url: /nl/jasperreports/ppt-pptx-pdf-and-html-export/
description: "Kies de Aspose.Slides for JasperReports-exporteur voor PPT-, PPTX-, PDF- of HTML-uitvoer, exporteer er een ingevuld rapport mee, en breng de rapportlettertypen in kaart naar de presentatielettertypen."
---
## **Exporteurs**

Aspose.Slides for JasperReports voegt vier exporteurs toe aan JasperReports. Elke exporteur neemt een ingevuld rapport (`JasperPrint`) en exporteert elke rapportpagina: als een dia in PPT en PPTX, als een pagina in PDF, en als een SVG‑afbeelding in één HTML‑bestand.

| Uitvoerformaat | Exporteur‑klasse |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

De klassen bevinden zich in het `com.aspose.slides.jasperreports`‑pakket van de bibliotheek‑jar, en ze gebruiken geen Microsoft PowerPoint. Geef het rapport en het uitvoerbestand door aan een exporteur met `setParameter` en `JRExporterParameter`, die door JasperReports gemarkeerd zijn als verouderd: de exporteurs accepteren de nieuwere configuratie `setExporterInput` en `setExporterOutput` niet.

## **Exporteer een rapport naar alle vier formaten**

Het onderstaande programma bouwt voort op het project uit [Uw eerste export](/slides/nl/jasperreports/#your-first-export). Het compileert en vult *hello.jrxml* één keer, en geeft vervolgens het gevulde rapport achtereenvolgens door aan elke exporteur. Sla het op als *src/main/java/ExportAllFormats.java* in dat project:

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
        // Compileer en vul het rapport één keer.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Exporteer hetzelfde gevulde rapport met elke exporteur.
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

Voer het uit vanuit de projectmap:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

Het programma slaat *hello.ppt*, *hello.pptx*, *hello.pdf* en *hello.html* op in de projectmap. De hulpmethode neemt `ASAbstractExporter`, de basisklasse van alle vier exporteurs. Zonder licentie bevat elk uitvoerbestand een evaluatiewatermerk — zie [Evalueer Aspose.Slides](/slides/nl/jasperreports/evaluate-aspose-slides/).

![Een rapport geëxporteerd naar een presentatie zonder licentie](ppt-pptx-pdf-and-html-export_1.png)

## **Lettertypen in kaart brengen**

De PPT‑ en PPTX‑exporteurs schrijven de lettertype‑namen van het rapportontwerp ongewijzigd naar de presentatie. Wanneer een textelement geen lettertype opgeeft, gebruikt JasperReports zijn standaardlettertype `SansSerif`, wat een Java‑logische lettertype‑naam is in plaats van een geïnstalleerd lettertype. Om dergelijke namen te vervangen, geef je een map door van rapport‑lettertypen naar de lettertypen die je in de presentatie wilt gebruiken via de `ASExporterParameters.PPT_FONT_MAP`‑parameter. De sleutels moeten exact overeenkomen met de lettertype‑namen in het rapport, inclusief hoofdlettergebruik. Elke waarde moet een lettertype zijn dat Java op de machine vindt waarop de export wordt uitgevoerd; de exporteurs negeren een item waarvan Java het lettertype niet kan vinden.

Save dit programma op als *src/main/java/MapFonts.java* in hetzelfde project. Het exporteert *hello.jrxml* naar PPTX waarbij `SansSerif` wordt vervangen door Arial:

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

        // Koppel de rapportlettertype‑naam aan de lettertype‑naam die in de presentatie moet worden geschreven.
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

Voer het uit vanuit de projectmap:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

In de opgeslagen *hello‑arial.pptx* gebruikt de tekst van het rapport Arial in plaats van `SansSerif`. Op een machine waar Java Arial niet kan vinden, bijvoorbeeld een Linux‑systeem zonder dit lettertype, blijft de tekst `SansSerif`. Op JasperReports Server stel je dezelfde map in via de `fontMap`‑eigenschap van de export‑parameters‑bean — zie [Integratie met JasperServer](/slides/nl/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).
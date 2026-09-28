---
title: "PPT, PPTX, PDF és HTML exportálás"
type: docs
weight: 20
url: /hu/jasperreports/ppt-pptx-pdf-and-html-export/
description: "Válassza ki az Aspose.Slides for JasperReports exportálót PPT, PPTX, PDF vagy HTML kimenethez, exportálja vele a kitöltött jelentést, és térképezze le a jelentés betűkészleteit a prezentáció betűkészleteire."
---
## **Exporterek**

Az Aspose.Slides for JasperReports négy exportálót ad hozzá a JasperReports-hoz. Mindegyik egy kitöltött jelentést (`JasperPrint`) vesz át, és minden jelentésoldalt exportál: PPT és PPTX dia, PDF oldal, valamint egyetlen HTML‑fájlban SVG‑kép formájában.

| Kimeneti formátum | Exportáló osztály |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

Az osztályok a könyvtár‑jar `com.aspose.slides.jasperreports` csomagjában találhatók, és nem a Microsoft PowerPoint‑ot használják. A jelentést és a kimeneti fájlt egy exportálónak a `setParameter` és a `JRExporterParameter` használatával adhatjuk át, amelyeket a JasperReports elavultnak jelöl: az exportálók nem fogadják el az új `setExporterInput` és `setExporterOutput` beállítást.

## **Exportálás egy jelentés négy formátumba**

Az alábbi program a [Az első export](/slides/hu/jasperreports/#your-first-export) projektjére épül. Egyszer fordítja le és tölti ki a *hello.jrxml*-t, majd sorban átadja a kitöltött jelentést minden exportálónak. Mentse el *src/main/java/ExportAllFormats.java* néven ebben a projektben:

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
        // Fordítsa le és töltse ki a jelentést egyszer.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Exportálja ugyanazt a kitöltött jelentést minden exportálóval.
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

Futtassa a projekt mappájából:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

A program elmenti a *hello.ppt*, *hello.pptx*, *hello.pdf* és *hello.html* fájlokat a projekt mappájába. A segédmetódus a `ASAbstractExporter`‑t veszi, amely az összes négy exportáló alaposztálya. Licenc nélkül minden kimeneti fájl értékelési vízjelet tartalmaz — lásd a [Aspose.Slides értékelése](/slides/hu/jasperreports/evaluate-aspose-slides/) oldalt.

![Jelentés exportálva prezentációba licenc nélkül](ppt-pptx-pdf-and-html-export_1.png)

## **Betűkészletek leképezése**

A PPT és PPTX exportálók a jelentésterv betűkészlet-neveit változtatás nélkül írják a prezentációba. Ha egy szövegelem nem ad meg betűkészletet, a JasperReports az alapértelmezett `SansSerif` betűkészletet használja, amely egy Java logikai betűkészlet‑név, nem egy telepített betűkészlet. Az ilyen nevek lecseréléséhez adjon át egy térképet a jelentés betűkészlet-neveiből a prezentációban kívánt betűkészlet‑nevekre az `ASExporterParameters.PPT_FONT_MAP` paraméterben. A kulcsoknak pontosan meg kell egyezniük a jelentésben szereplő betűkészlet‑nevekkel, beleértve a kis‑ és nagybetűket is. Minden értéknek olyan betűkészletnek kell lennie, amelyet a Java megtalál a gépen, ahol az exportálás történik; a exportálók figyelmen kívül hagynak olyan bejegyzést, amelynek betűkészletét a Java nem találja.

Mentse el ezt a programot *src/main/java/MapFonts.java* néven ugyanabban a projektben. A program a *hello.jrxml*-t PPTX‑be exportálja, a `SansSerif`‑et Arial‑ra cserélve:

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

        // Térképezze a jelentés betűkészlet‑nevet a prezentációba írandó betűkészlet‑névre.
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

Futtassa a projekt mappájából:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

A mentett *hello-arial.pptx* fájlban a jelentés szövege Arial‑t használ a `SansSerif` helyett. Egy olyan gépen, ahol a Java nem találja az Arial‑t, például egy Linux rendszerben, a szöveg továbbra is `SansSerif` marad. JasperReports Server esetén ugyanazt a térképet a `fontMap` tulajdonságon keresztül állítsa be az export paraméterek bean‑jében — lásd a [Integráció JasperServer‑rel](/slides/hu/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license) oldalt.
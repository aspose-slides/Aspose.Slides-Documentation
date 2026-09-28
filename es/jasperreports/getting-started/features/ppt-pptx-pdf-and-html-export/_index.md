---
title: Exportación PPT, PPTX, PDF y HTML
type: docs
weight: 20
url: /es/jasperreports/ppt-pptx-pdf-and-html-export/
description: "Elija el exportador Aspose.Slides para JasperReports para salida PPT, PPTX, PDF o HTML, exporte un informe rellenado con él y asocie las fuentes del informe a las fuentes de la presentación."
---
## **Exportadores**

Aspose.Slides for JasperReports añade cuatro exportadores a JasperReports. Cada uno toma un informe rellenado (`JasperPrint`) y exporta cada página del informe: como una diapositiva en PPT y PPTX, como una página en PDF y como una imagen SVG en un único archivo HTML.

| Formato de salida | Clase exportadora |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

Las clases están en el paquete `com.aspose.slides.jasperreports` del archivo JAR de la biblioteca, y no utilizan Microsoft PowerPoint. Pase el informe y el archivo de salida a un exportador con `setParameter` y `JRExporterParameter`, que JasperReports marca como obsoleto: los exportadores no aceptan la configuración más reciente `setExporterInput` y `setExporterOutput`.

## **Exportar un informe a los cuatro formatos**

El programa a continuación se basa en el proyecto de [Your first export](/slides/es/jasperreports/#your-first-export). Compila y rellena *hello.jrxml* una sola vez, y luego pasa el informe rellenado a cada exportador a su vez. Guárdelo como *src/main/java/ExportAllFormats.java* en ese proyecto:

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
        // Compila y rellena el informe una vez.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Exporta el mismo informe rellenado con cada exportador.
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

Ejecútelo desde la carpeta del proyecto:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

El programa guarda *hello.ppt*, *hello.pptx*, *hello.pdf* y *hello.html* en la carpeta del proyecto. El método auxiliar recibe `ASAbstractExporter`, la clase base de los cuatro exportadores. Sin una licencia, cada archivo de salida lleva la marca de agua de evaluación — vea [Evaluate Aspose.Slides](/slides/es/jasperreports/evaluate-aspose-slides/).

![Un informe exportado a una presentación sin licencia](ppt-pptx-pdf-and-html-export_1.png)

## **Mapear fuentes**

Los exportadores PPT y PPTX escriben los nombres de fuente del diseño del informe en la presentación sin cambios. Cuando un elemento de texto no especifica fuente, JasperReports utiliza su fuente predeterminada, `SansSerif`, que es un nombre lógico de fuente de Java y no una fuente instalada. Para sustituir esos nombres, pase un mapa de nombres de fuente del informe a los nombres de fuente que desea en la presentación en el parámetro `ASExporterParameters.PPT_FONT_MAP`. Las claves deben coincidir exactamente con los nombres de fuente del informe, incluidas mayúsculas y minúsculas. Cada valor debe ser una fuente que Java encuentre en la máquina que ejecuta la exportación; los exportadores ignoran una entrada cuya fuente Java no pueda encontrar.

Guarde este programa como *src/main/java/MapFonts.java* en el mismo proyecto. Exporta *hello.jrxml* a PPTX con `SansSerif` sustituido por Arial:

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

        // Mapea el nombre de fuente del informe al nombre de fuente que se escribirá en la presentación.
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

Ejecútelo desde la carpeta del proyecto:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

En el *hello-arial.pptx* guardado, el texto del informe usa Arial en lugar de `SansSerif`. En una máquina donde Java no encuentre Arial, como en un sistema Linux sin ella, el texto conserva `SansSerif`. En JasperReports Server, establezca el mismo mapa mediante la propiedad `fontMap` del bean de parámetros de exportación — vea [Integration with JasperServer](/slides/es/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).
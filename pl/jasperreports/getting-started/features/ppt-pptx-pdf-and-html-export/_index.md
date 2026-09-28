---
title: Eksport PPT, PPTX, PDF i HTML
type: docs
weight: 20
url: /pl/jasperreports/ppt-pptx-pdf-and-html-export/
description: "Wybierz eksporter Aspose.Slides for JasperReports dla wyjścia PPT, PPTX, PDF lub HTML, wyeksportuj wypełniony raport przy jego użyciu oraz zamapuj czcionki raportu na czcionki prezentacji."
---
## **Eksporterzy**

Aspose.Slides for JasperReports dodaje cztery eksportery do JasperReports. Każdy z nich przyjmuje wypełniony raport (`JasperPrint`) i eksportuje każdą stronę raportu: jako slajd w formacie PPT i PPTX, jako stronę w PDF oraz jako obraz SVG w jednym pliku HTML.

| Format wyjściowy | Klasa eksportera |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

Klasy znajdują się w pakiecie `com.aspose.slides.jasperreports` biblioteki jar i nie korzystają z Microsoft PowerPoint. Przekaż raport i plik wyjściowy do eksportera za pomocą `setParameter` i `JRExporterParameter`, które JasperReports oznacza jako przestarzałe: eksportery nie akceptują nowszej konfiguracji `setExporterInput` i `setExporterOutput`.

## **Eksportuj raport do wszystkich czterech formatów**

Program poniżej opiera się na projekcie z [Your first export](/slides/pl/jasperreports/#your-first-export). Kompiluje i wypełnia *hello.jrxml* jednorazowo, a następnie kolejno przekazuje wypełniony raport do każdego eksportera. Zapisz go jako *src/main/java/ExportAllFormats.java* w tym projekcie:

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
        // Kompiluj i wypełnij raport jednorazowo.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Eksportuj ten sam wypełniony raport każdym eksporterem.
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

Uruchom go z folderu projektu:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

Program zapisuje *hello.ppt*, *hello.pptx*, *hello.pdf* oraz *hello.html* w folderze projektu. Metoda pomocnicza przyjmuje `ASAbstractExporter`, klasę bazową wszystkich czterech eksporterów. Bez licencji każdy plik wyjściowy zawiera znak wodny wersji ewaluacyjnej — zobacz [Evaluate Aspose.Slides](/slides/pl/jasperreports/evaluate-aspose-slides/).

![Raport wyeksportowany do prezentacji bez licencji](ppt-pptx-pdf-and-html-export_1.png)

## **Mapowanie czcionek**

Eksportery PPT i PPTX zapisują nazwy czcionek z projektu raportu w prezentacji bez zmian. Gdy element tekstowy nie określa czcionki, JasperReports używa domyślnej czcionki `SansSerif`, która jest logiczną nazwą czcionki Java, a nie zainstalowaną czcionką. Aby zastąpić takie nazwy, przekaż mapę z nazwami czcionek raportu na nazwy czcionek, które chcesz mieć w prezentacji, w parametrze `ASExporterParameters.PPT_FONT_MAP`. Klucze muszą dokładnie odpowiadać nazwom czcionek w raporcie, łącznie z wielkością liter. Każda wartość musi być czcionką, którą Java znajdzie na maszynie uruchamiającej eksport; eksportery ignorują wpis, którego czcionki Java nie może znaleźć.

Zapisz ten program jako *src/main/java/MapFonts.java* w tym samym projekcie. Eksportuje *hello.jrxml* do PPTX, zamieniając `SansSerif` na Arial:

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

        // Mapuj nazwę czcionki raportu na nazwę czcionki, która ma zostać zapisana w prezentacji.
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

Uruchom go z folderu projektu:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

W zapisanym *hello-arial.pptx* tekst raportu używa Arial zamiast `SansSerif`. Na maszynie, na której Java nie znajdzie Arial, np. w systemie Linux bez tej czcionki, tekst pozostaje `SansSerif`. W JasperReports Server ustaw tę samą mapę za pomocą właściwości `fontMap` bean’a parametrów eksportu — zobacz [Integration with JasperServer](/slides/pl/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).
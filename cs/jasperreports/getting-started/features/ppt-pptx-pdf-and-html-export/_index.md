---
title: Export PPT, PPTX, PDF a HTML
type: docs
weight: 20
url: /cs/jasperreports/ppt-pptx-pdf-and-html-export/
description: "Vyberte exportér Aspose.Slides for JasperReports pro výstup PPT, PPTX, PDF nebo HTML, exportujte s ním vyplněnou zprávu a namapujte písma zprávy na písma v prezentaci."
---
## **Exportéři**

Aspose.Slides for JasperReports přidává do JasperReports čtyři exportéry. Každý z nich přijímá vyplněnou zprávu (`JasperPrint`) a exportuje každou stránku zprávy: jako snímek v PPT a PPTX, jako stránku v PDF a jako SVG obrázek v jediném HTML souboru.

| Výstupní formát | Třída exportéru |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

Třídy jsou v balíčku `com.aspose.slides.jasperreports` knihovny jar a nepoužívají Microsoft PowerPoint. Předejte zprávu a výstupní soubor exportéru pomocí `setParameter` a `JRExporterParameter`, které JasperReports označuje jako zastaralé: exportéři nepřijímají novější konfiguraci `setExporterInput` a `setExporterOutput`.

## **Exportovat zprávu do všech čtyř formátů**

Program níže staví na projektu z [Váš první export](/slides/cs/jasperreports/#your-first-export). Zkompiluje a vyplní *hello.jrxml* jednou, poté postupně předá vyplněnou zprávu každému exportéru. Uložte jej jako *src/main/java/ExportAllFormats.java* v tomto projektu:

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
        // Zkompilujte a vyplňte zprávu jednou.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Exportujte stejnou vyplněnou zprávu pomocí každého exportéru.
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

Spusťte jej ze složky projektu:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

Program uloží *hello.ppt*, *hello.pptx*, *hello.pdf* a *hello.html* do složky projektu. Pomocná metoda přijímá `ASAbstractExporter`, základní třídu všech čtyř exportérů. Bez licence obsahuje každý výstupní soubor vodotisk hodnocení — viz [Vyhodnotit Aspose.Slides](/slides/cs/jasperreports/evaluate-aspose-slides/).

![Zpráva exportovaná do prezentace bez licence](ppt-pptx-pdf-and-html-export_1.png)

## **Mapovat písma**

Exportéry PPT a PPTX zapisují názvy písem návrhu zprávy do prezentace beze změny. Když textový prvek neudává žádné písmo, JasperReports použije výchozí písmo `SansSerif`, což je logický název písma v Javě, nikoli nainstalované písmo. Chcete‑li takové názvy nahradit, předávejte mapu z názvů písem zprávy na názvy písem, která chcete v prezentaci použít, v parametru `ASExporterParameters.PPT_FONT_MAP`. Klíče musí přesně odpovídat názvům písem ve zprávě, včetně velikosti písmen. Každá hodnota musí být písmo, které Java na stroji provádějícím export najde; exportéry ignorují položku, jejíž písmo Java nenajde.

Uložte tento program jako *src/main/java/MapFonts.java* ve stejném projektu. Exportuje *hello.jrxml* do PPTX s nahrazením `SansSerif` písmenem Arial:

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

        // Namapujte název písma zprávy na název písma, který se má zapsat do prezentace.
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

Spusťte jej ze složky projektu:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

V uloženém *hello-arial.pptx* text zprávy používá Arial místo `SansSerif`. Na stroji, kde Java nenajde Arial, např. na Linuxu, text si ponechá `SansSerif`. Na JasperReports Server nastavte stejnou mapu prostřednictvím vlastnosti `fontMap` bean parametrů exportu — viz [Integrace s JasperServer](/slides/cs/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).
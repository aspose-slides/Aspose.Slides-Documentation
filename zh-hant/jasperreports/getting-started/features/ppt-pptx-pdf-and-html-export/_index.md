---
title: PPT、PPTX、PDF 與 HTML 匯出
type: docs
weight: 20
url: /zh-hant/jasperreports/ppt-pptx-pdf-and-html-export/
description: "選擇 Aspose.Slides for JasperReports 的 PPT、PPTX、PDF 或 HTML 輸出匯出器，使用它匯出已填寫的報表，並將報表字型對映至簡報字型。"
---
## **匯出器**

Aspose.Slides for JasperReports 為 JasperReports 添加了四個匯出器。每個匯出器都會接收已填寫的報表 (`JasperPrint`) 並將每一頁報表匯出：作為 PPT 或 PPTX 檔案中的投影片、作為 PDF 檔案中的頁面、以及作為單一 HTML 檔案中的 SVG 圖像。

| 輸出格式 | 匯出器類別 |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

這些類別位於程式庫 jar 的 `com.aspose.slides.jasperreports` 套件中，且不使用 Microsoft PowerPoint。使用 `setParameter` 和 `JRExporterParameter`（JasperReports 標示為已淘汰）將報表與輸出檔案傳遞給匯出器：匯出器不接受較新的 `setExporterInput` 和 `setExporterOutput` 設定。

## **將報表匯出為四種格式**

以下程式基於 [Your first export](/slides/zh-hant/jasperreports/#your-first-export) 專案。它會編譯並填寫一次 *hello.jrxml*，然後依序將已填寫的報表傳遞給每個匯出器。將它儲存為該專案中的 *src/main/java/ExportAllFormats.java*：

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
        // 編譯並填寫報表一次。
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // 使用每個匯出器匯出相同的已填寫報表。
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

在專案資料夾中執行：

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

此程式會在專案資料夾中產生 *hello.ppt*、*hello.pptx*、*hello.pdf* 與 *hello.html*。協助方法接受 `ASAbstractExporter`，即四個匯出器的基底類別。若未取得授權，所有輸出檔案都會帶有評估水印——請參閱 [Evaluate Aspose.Slides](/slides/zh-hant/jasperreports/evaluate-aspose-slides/)。

![未授權的報表匯出為簡報](ppt-pptx-pdf-and-html-export_1.png)

## **映射字型**

PPT 與 PPTX 匯出器會將報表設計中的字型名稱原樣寫入簡報。當文字元素未指定字型時，JasperReports 會使用其預設字型 `SansSerif`，這是 Java 的邏輯字型名稱，而非已安裝的字型。若要替換此類名稱，請在 `ASExporterParameters.PPT_FONT_MAP` 參數中傳遞一個從報表字型名稱到簡報中欲使用字型名稱的映射。鍵必須完全匹配報表中的字型名稱（包括大小寫），每個值必須是 Java 在執行匯出時能找到的字型；若 Java 找不到該字型，匯出器會忽略該條目。

將此程式儲存為同一專案中的 *src/main/java/MapFonts.java*。它會將 *hello.jrxml* 匯出為 PPTX，將 `SansSerif` 替換為 Arial：

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

        // 將報表字型名稱映射為寫入簡報的字型名稱。
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

在專案資料夾中執行：

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

在儲存的 *hello-arial.pptx* 中，報表的文字會使用 Arial 取代 `SansSerif`。若在 Java 找不到 Arial（例如在未安裝該字型的 Linux 系統），文字仍會保持 `SansSerif`。在 JasperReports Server 上，請透過匯出參數 bean 的 `fontMap` 屬性設定相同的映射——請參閱 [Integration with JasperServer](/slides/zh-hant/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license)。
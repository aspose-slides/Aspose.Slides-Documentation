---
title: PPT、PPTX、PDF 和 HTML 导出
type: docs
weight: 20
url: /zh/jasperreports/ppt-pptx-pdf-and-html-export/
description: "选择 Aspose.Slides for JasperReports 导出器，以输出 PPT、PPTX、PDF 或 HTML，使用它导出已填充的报告，并将报告字体映射到演示文稿字体。"
---
## **导出器**

Aspose.Slides for JasperReports 为 JasperReports 添加了四个导出器。每个导出器接受一个已填充的报告（`JasperPrint`），并将每页报告导出为：PPT 和 PPTX 中的幻灯片、PDF 中的页面以及单个 HTML 文件中的 SVG 图像。

| 输出格式 | 导出器类 |
| :- | :- |
| PPT（PowerPoint 97–2003） | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

这些类位于库 jar 的 `com.aspose.slides.jasperreports` 包中，且不使用 Microsoft PowerPoint。使用 `setParameter` 和 `JRExporterParameter`（JasperReports 将其标记为已弃用）将报告和输出文件传递给导出器：导出器不接受较新的 `setExporterInput` 和 `setExporterOutput` 配置。

## **将报告导出为四种格式**

下面的程序基于[Your first export](/slides/zh/jasperreports/#your-first-export)项目。它仅编译并填充一次 *hello.jrxml*，随后依次将填充的报告传递给每个导出器。将其保存为该项目中的 *src/main/java/ExportAllFormats.java*：

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
        // 编译并填充报告一次。
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // 使用每个导出器导出相同的已填充报告。
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

在项目文件夹中运行：

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

程序会在项目文件夹中保存 *hello.ppt*、*hello.pptx*、*hello.pdf* 和 *hello.html*。辅助方法接受 `ASAbstractExporter`，即四个导出器的基类。若未提供许可证，所有输出文件都会带有评估水印——参见[Evaluate Aspose.Slides](/slides/zh/jasperreports/evaluate-aspose-slides/)。

![A report exported to a presentation without a license](ppt-pptx-pdf-and-html-export_1.png)

## **映射字体**

PPT 和 PPTX 导出器会将报告设计中的字体名称原样写入演示文稿。当文本元素未指定字体时，JasperReports 使用其默认字体 `SansSerif`，这是一种 Java 逻辑字体名称，而非已安装的字体。要替换此类名称，请在 `ASExporterParameters.PPT_FONT_MAP` 参数中传入报告字体名称到演示文稿中所需字体名称的映射。键必须与报告中的字体名称完全匹配，包括大小写。每个值必须是 Java 在运行导出的机器上能够找到的字体；如果 Java 找不到该字体，导出器会忽略相应条目。

将此程序保存为同一项目中的 *src/main/java/MapFonts.java*。它会将 *hello.jrxml* 导出为 PPTX，并将 `SansSerif` 替换为 Arial：

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

        // 将报告字体名称映射为写入演示文稿的字体名称。
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

在项目文件夹中运行：

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

在保存的 *hello-arial.pptx* 中，报告的文本使用 Arial 而不是 `SansSerif`。如果 Java 在机器上找不到 Arial，例如在没有该字体的 Linux 系统上，文本仍会保持 `SansSerif`。在 JasperReports Server 上，可通过导出参数 bean 的 `fontMap` 属性设置相同的映射——参见[Integration with JasperServer](/slides/zh/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license)。
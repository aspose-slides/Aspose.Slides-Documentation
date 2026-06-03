---
title: 产品概述
type: docs
weight: 10
url: /zh/jasperreports/product-overview/
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **欢迎使用 Aspose.Slides for JasperReports！**

Aspose.Slides for JasperReports 是一个专为需要在 Java 应用程序中轻松将 JasperReports 报表导出为 Microsoft PowerPoint 演示文稿（PPT）和 Microsoft PowerPoint 幻灯片放映（PPS）格式的开发人员设计和开发的库。所有报表功能都以最高精度转换为 Microsoft PowerPoint 演示文稿。Aspose.Slides for JasperReports 包含对 JasperReports 5+ 的支持。

## **产品描述**
JasperReports 和 JasperServer 没有内置将报表导出为 Microsoft PowerPoint 演示文稿的功能，但 Aspose.Slides for JasperReports 为您提供了另外两种导出格式：

- PPT – 通过 Aspose.Slides 的 PowerPoint 演示文稿
- PPS – 通过 Aspose.Slides 的 PowerPoint 幻灯片放映
- PPTX – 通过 Aspose.Slides 的 PowerPoint 演示文稿
- PPSX – 通过 Aspose.Slides 的 PowerPoint 幻灯片放映

Aspose.Slides for JasperReports 在内部使用我们 100% 纯 Java 库 Aspose.Slides for Java 和 Aspose.Metafiles for Java，这些是用于服务器端演示文稿和元文件处理的世界级库。

Aspose.Slides for JasperReports 使得任何报表都可以导出为 PPT 或 PPS 格式。

### **输出示例**
ASPptExporter 类扩展了 ASAbstractExporter 类，因此可以像其他标准导出器一样使用。此简短示例展示了典型代码以及在 MS PowerPoint 中查看的报表截图。详细示例可在提供的演示报表中找到。

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**使用 JasperReports xmldatasource 示例生成的演示文稿** 

![Presentation generated with JasperReports](product-overview_2.png)
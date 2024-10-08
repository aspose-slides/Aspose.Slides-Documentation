---
title: 产品概述
type: docs
weight: 10
url: /zh/jasperreports/product-overview/
---

{{% alert color="primary" %}} 

![todo:image_alt_text](product-overview_1.png)

## **欢迎来到 Aspose.Slides for JasperReports 文档！**
Aspose.Slides for JasperReports 是一个特别为需要轻松将 JasperReports 报告导出到 Microsoft PowerPoint 演示文稿 (PPT) 和 Microsoft PowerPoint 放映 (PPS) 格式的 Java 应用程序开发的库。所有报告特性都以最高的精准度转换为 Microsoft PowerPoint 演示文稿。Aspose.Slides for JasperReports 支持 JasperReports 5 及以上版本。

{{% /alert %}} 

## **产品描述**
JasperReports 和 JasperServer 不具备将报告导出为 Microsoft PowerPoint 演示文稿的内置能力，但 Aspose.Slides for JasperReports 为您提供了两种额外的导出格式：

- PPT – 通过 Aspose.Slides 的 PowerPoint 演示文稿
- PPS - 通过 Aspose.Slides 的 PowerPoint 放映
- PPTX – 通过 Aspose.Slides 的 PowerPoint 演示文稿
- PPSX - 通过 Aspose.Slides 的 PowerPoint 放映

Aspose.Slides for JasperReports 内部使用我们 100% 纯 Java 库 Aspose.Slides for Java 和 Aspose.Metafiles for Java，这些是用于服务器端演示文稿和元文件处理的世界级库。

Aspose.Slides for JasperReports 使得能够将任何报告导出为 PPT 或 PPS 格式。

### **输出示例**
ASPptExporter 类扩展了 ASAbstractExporter 类，因此可以像其他标准导出器一样使用。这个简短的示例展示了在 MS PowerPoint 中查看报告的典型代码和截图。详细示例可以在提供的演示报告中找到。

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**使用 JasperReports xmldatasource 演示生成的演示文稿** 

![todo:image_alt_text](product-overview_2.png)
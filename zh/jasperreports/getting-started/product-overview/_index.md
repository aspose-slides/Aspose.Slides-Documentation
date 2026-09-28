---
title: 产品概述
type: docs
weight: 10
url: /zh/jasperreports/product-overview/
description: "了解 Aspose.Slides for JasperReports 的功能、支持的 JasperReports 版本及输出格式，以及它的两个 jar 的用途。"
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **产品描述**

Aspose.Slides for JasperReports 将 JasperReports 的报告导出为 PowerPoint 演示文稿，可在 Java 应用程序和 JasperReports Server 中使用，而无需 Microsoft PowerPoint。它支持 JasperReports 3.7.2 到 6.16.0，为每个版本范围提供单独的 jar —— 请参阅[安装 Aspose.Slides for JasperReports](/slides/zh/jasperreports/installing-aspose-slides-for-jasperreports/)。

它将已填充的报告导出为四种格式，每个报告页对应一张幻灯片或页面：

- PPT – PowerPoint 97–2003 演示文稿
- PPTX – PowerPoint 演示文稿 (Office Open XML)
- PDF
- HTML

该产品包含两部分：

- 库 jar 将导出器 `ASPptExporter`、`ASPptxExporter`、`ASPdfExporter` 和 `ASHtmlExporter` 添加到 JasperReports Library。
- 服务器 jar 提供相同四种格式的导出操作，您需要在 JasperReports Server 中注册它们 —— 请参阅[与 JasperServer 的集成](/slides/zh/jasperreports/integration-with-jasperserver/)。

### **输出示例**

这些导出器扩展了 JasperReports 自身的导出器类，使用方式相同：将已填充的报告和输出文件传递给它们，然后调用 `exportReport`。有关将报告填充并导出为 PPTX 的完整示例，请参阅[您的首次导出](/slides/zh/jasperreports/#your-first-export)；有关四种格式的全部示例，请参阅[PPT、PPTX、PDF 和 HTML 导出](/slides/zh/jasperreports/ppt-pptx-pdf-and-html-export/)。

![未授权的报告导出为演示文稿，幻灯片中心带有评估水印](/product-overview_2.png)
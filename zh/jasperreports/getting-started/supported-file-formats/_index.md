---
title: 支持的文件格式
type: docs
weight: 20
url: /zh/jasperreports/supported-file-formats/
description: "查看 Aspose.Slides for JasperReports 接受哪些输入以及它将报告导出为哪些文件格式。"
---
## **Input**

Aspose.Slides for JasperReports 导出报告；它不转换现有的演示文稿。其导出器接受已填充的 JasperReports 报告（`JasperPrint`），例如 `JasperFillManager` 的结果或从 *.jrprint* 文件加载的已填充报告。

## **输出格式**

下表列出了 Aspose.Slides for JasperReports 将报告导出为的格式以及对应的导出器类。

|**格式**|**描述**|**导出器**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97–2003 演示文稿；每个报告页面对应一张幻灯片|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 演示文稿（Office Open XML）；每个报告页面对应一张幻灯片|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|可移植文档格式（PDF）；每个报告页面对应一页 PDF|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|单个 HTML 文件，每个报告页面包含一个 SVG 图像|`ASHtmlExporter`|

目前没有针对 PPS 和 PPSX 幻灯片放映格式的导出器。即使将 PPTX 导出为 *.ppsx* 文件名，仍然会生成 PPTX 演示文稿，而不是幻灯片放映。要了解每个导出器的使用方式，请参阅 [PPT, PPTX, PDF and HTML Export](/slides/zh/jasperreports/ppt-pptx-pdf-and-html-export/).
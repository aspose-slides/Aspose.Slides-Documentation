---
title: 将 OpenDocument 演示文稿转换为 Android
linktitle: 转换 OpenDocument
type: docs
weight: 10
url: /zh/androidjava/convert-openoffice-odp/
keywords:
- 转换 ODP
- ODP 转图片
- ODP 转 GIF
- ODP 转 HTML
- ODP 转 JPG
- ODP 转 MD
- ODP 转 PDF
- ODP 转 PNG
- ODP 转 PPT
- ODP 转 PPTX
- ODP 转 TIFF
- ODP 转视频
- ODP 转 Word
- ODP 转 XPS
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android 让您轻松将 ODP 转换为 PDF、HTML 和图像格式。使用快速且准确的演示文稿转换提升您的 Java 应用程序。"
---

[**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/) 允许您将 OpenDocument (ODP) 演示文稿转换为多种格式（HTML、PDF、TIFF、SWF、XPS 等）。用于将 ODP 文件转换为其他文档格式的 API 与用于 PowerPoint（PPT 和 PPTX）转换操作的 API 相同。

例如，如果您需要将 ODP 演示文稿转换为 PDF，可按以下方式操作：
```java
Presentation presentation = null;
try {
    presentation = new Presentation("pres.odp");
    presentation.save("pres.pdf", SaveFormat.Pdf);
    
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**What if the formatting of my ODP file changes after conversion?**

ODP 和 PowerPoint 使用不同的演示模型，某些元素——如表格、自定义字体或填充样式——可能无法完全相同地呈现。建议检查输出结果，并在必要时通过代码调整布局或格式。

**Do I need OpenOffice or LibreOffice installed to use ODP conversion?**

不需要，Aspose.Slides 是独立库，无需在系统上安装 OpenOffice 或 LibreOffice。

**Can I customize the output format during ODP conversion (e.g., set PDF options)?**

是的，Aspose.Slides 提供丰富的选项来自定义输出。例如，在保存为 PDF 时，您可以通过 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) 类控制压缩、图像质量、文本渲染等。

**Is Aspose.Slides suitable for server-side or cloud-based ODP processing?**

完全适合。Aspose.Slides 旨在在桌面和服务器环境中使用，包括 Azure、AWS 和 Docker 容器等云平台，且无需任何 UI 依赖。
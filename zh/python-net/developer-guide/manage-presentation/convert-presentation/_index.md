---
title: 将演示文稿转换为多种格式（Python）
linktitle: 转换演示文稿
type: docs
weight: 70
url: /zh/python-net/developer-guide/manage-presentation/convert-presentation/
keywords:
- convert presentation
- export presentation
- PPT to PPTX
- PPT to PDF
- PPTX to PDF
- PPT to XPS
- PPTX to XPS
- PPT to TIFF
- PPTX to TIFF
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 将 PowerPoint 和 OpenDocument 演示文稿转换为 PPTX、PDF、XPS、TIFF 等格式。简单、高质量的转换。"
---

## **简介**

本页概述了使用 Aspose.Slides for Python via .NET 进行演示文稿转换的情况。它总结了支持的场景，并指向展示导出演示文稿和幻灯片到 PDF、XPS、TIFF 等格式以及在 PPT 与 PPTX 之间转换的具体代码示例的专题指南。相关链接的文章会突出特定格式的选项——例如渲染备注或调节图像质量——以及已知的局限性，如 PPT→PPTX 路径的部分支持。使用本页选择目标格式，然后按链接的步骤进行操作。

## **PPT 到 PPTX 转换**

### **关于 PPT/PPTX**

PPT 是旧的二进制 PowerPoint 格式（97–2003），而 PPTX 是在 PowerPoint 2007 中引入的 ZIP 打包的 Open XML 格式。与 PPT 相比，PPTX 通常生成更小的文件，支持现代特性，能够很好地与文档自动化配合，并且推荐用于长期存储和跨平台工作流。

### **将 PPT 转换为 PPTX**

Aspose.Slides 支持将 PPT 演示文稿转换为 PPTX 格式。使用 Aspose.Slides API 完成此任务的主要优势在于工作流的简单性。实际操作中，只需少量代码即可完成转换，并保持幻灯片、布局和媒体的高度保真。

{{% alert color="primary" %}}
阅读更多： [在 Python 中将 PPT 转换为 PPTX](/slides/zh/python-net/convert-ppt-to-pptx/)。
{{% /alert %}}

## **演示文稿到 PDF 转换**

### **关于 PDF**

[Portable Document Format](https://en.wikipedia.org/wiki/PDF)（PDF）是由 Adobe Systems 创建的文件格式，用于在组织之间交换文档。其目的是确保无论在何种平台上查看文档，内容的视觉外观都保持一致。

### **将演示文稿转换为 PDF**

任何可以在 Aspose.Slides 中加载的演示文稿都可以转换为 PDF 文档。您可以直接使用 Aspose.Slides 组件导出为 PDF，无需第三方库或 Aspose.PDF 组件。

{{% alert color="primary" %}}
阅读更多： [在 Python 中将 PPT 与 PPTX 转换为 PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)。
{{% /alert %}}

## **演示文稿到 XPS 转换**

### **关于 XPS**

[XML Paper Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification)（XPS）是一种页面描述语言和固定文档格式，最初由 Microsoft 开发。与 PDF 类似，XPS 是一种固定布局文档格式，旨在保持文档的保真度并提供设备无关的外观。

### **将演示文稿转换为 XPS**

任何可以在 Aspose.Slides 中加载的演示文稿都可以转换为 XPS 格式。Aspose.Slides 使用高保真的页面布局和渲染引擎生成固定布局的 XPS 输出。值得注意的是，Aspose.Slides 直接生成 XPS，而不依赖 Windows Presentation Foundation（WPF）。

{{% alert color="primary" %}}
阅读更多： [在 Python 中将 PowerPoint 演示文稿转换为 XPS](/slides/zh/python-net/convert-powerpoint-to-xps/)。
{{% /alert %}}

## **演示文稿到 TIFF 转换**

### **关于 TIFF**

[Tagged Image File Format](https://en.wikipedia.org/wiki/TIFF)（TIFF）是一种光栅图像格式，以能够在单个文件中存储多幅图像（页面）而著称。最初由 Aldus 开发，已被扫描、传真及其他图像处理应用广泛支持。

### **将演示文稿转换为 TIFF**

任何可以在 Aspose.Slides 中加载的文档也可以直接转换为 TIFF 文件，无需任何第三方组件。您还可以选择为生成的 TIFF 页面指定图像尺寸。

{{% alert color="primary" %}}
阅读更多： [在 Python 中将 PowerPoint 演示文稿转换为 TIFF](/slides/zh/python-net/convert-powerpoint-to-tiff/)。
{{% /alert %}}

## **常见问题**

**导出为 PDF/XPS 时可以包含隐藏的幻灯片吗？**

可以。导出时可通过相应的选项在 [PDF](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/)/[XPS](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) 设置中包含隐藏幻灯片。

**是否支持保存为 PDF/A 格式（用于归档存储）？**

支持，导出时可使用 PDF/A 合规级别（包括 A-2a/A-2b/A-2u 和 A-3a/A-3b），详见 [PDF/A 合规性](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfcompliance/)。

**转换时字体会如何处理：是嵌入还是替换？**

提供灵活的选项：您可以 [嵌入所有字形或仅使用的子集](/slides/zh/python-net/embedded-font/)，指定 [后备字体](/slides/zh/python-net/fallback-font/)，以及在缺少某些样式时 [控制替换行为](/slides/zh/python-net/font-substitution/)。

**如何控制生成的 PDF 的质量和大小？**

可以设置 [JPEG 质量](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/)、[文本压缩](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/text_compression/)、以及图像的 [足够分辨率阈值](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/)，并可使用一种模式为图片选择 [最佳压缩比例](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/)。

**可以只导出特定范围的幻灯片吗（例如 5–12）？**

可以，导出时支持选择幻灯片子集。

**是否支持同时对多个文件进行多核处理？**

可以在不同进程中并行处理不同的演示文稿。重要提示：同一个 [presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象不能在 [多个线程](/slides/zh/python-net/multithreading/) 中同时加载或保存。

**在不同线程中应用许可证会有风险吗？**

会有风险，设置许可证的调用 [license-setting](/slides/zh/python-net/licensing/) 不是线程安全的，需要进行同步处理。
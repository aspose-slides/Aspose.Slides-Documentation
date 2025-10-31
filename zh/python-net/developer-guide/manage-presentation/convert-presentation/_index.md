---
title: 将演示文稿转换为多种格式（Python）
linktitle: 转换演示文稿
type: docs
weight: 70
url: /zh/python-net/convert-presentation/
keywords:
- 转换演示文稿
- 导出演示文稿
- PPT 转 PPTX
- PPT 转 PDF
- PPTX 转 PDF
- PPT 转 XPS
- PPTX 转 XPS
- PPT 转 TIFF
- PPTX 转 TIFF
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 将 PowerPoint 和 OpenDocument 演示文稿转换为 PPTX、PDF、XPS、TIFF 等格式。简单且高质量的转换。"
---

## **简介**

本页概述了使用 Aspose.Slides for Python via .NET 进行演示文稿转换的情况。它汇总了支持的场景，并指向展示如何将演示文稿和幻灯片导出为 PDF、XPS、TIFF 等格式以及在 PPT 与 PPTX 之间转换的专题指南。相关链接文章会突出特定格式的选项——例如渲染备注或调节图像质量——以及已知的限制，例如在 PPT→PPTX 路径中的部分支持。使用本页可以选择目标格式，然后按照链接中的示例操作。

## **PPT 转 PPTX 转换**

### **关于 PPT/PPTX**

PPT 是较早的二进制 PowerPoint 格式（97–2003），而 PPTX 是自 PowerPoint 2007 起采用的 ZIP 打包的 Open XML 格式。相比 PPT，PPTX 通常文件更小、支持现代功能、便于文档自动化，并且推荐用于长期存储和跨平台工作流。

### **将 PPT 转换为 PPTX**

Aspose.Slides 支持将 PPT 演示文稿转换为 PPTX 格式。使用 Aspose.Slides API 完成此任务的主要优势在于工作流的简洁性。实际上，您只需极少的代码即可完成转换，同时保持幻灯片、布局和媒体的高保真度。

{{% alert color="primary" %}}
了解更多： [Convert PPT to PPTX in Python](/slides/zh/python-net/convert-ppt-to-pptx/).
{{% /alert %}}

## **演示文稿转 PDF 转换**

### **关于 PDF**

[便携式文档格式](https://en.wikipedia.org/wiki/PDF)（PDF）是由 Adobe Systems 创建的文件格式，用于在组织之间交换文档。其目的是确保文档内容在任何平台上查看时均呈现相同的视觉外观。

### **将演示文稿转换为 PDF**

任何可在 Aspose.Slides 中加载的演示文稿均可转换为 PDF 文档。您可以直接使用 Aspose.Slides 组件导出 PDF，无需第三方库或 Aspose.PDF 组件。

{{% alert color="primary" %}}
了解更多： [Convert PPT & PPTX to PDF in Python](/slides/zh/python-net/convert-powerpoint-to-pdf/).
{{% /alert %}}

## **演示文稿转 XPS 转换**

### **关于 XPS**

[XML 纸张规范](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification)（XPS）是一种页面描述语言和固定文档格式，最初由 Microsoft 开发。与 PDF 类似，XPS 是一种固定布局文档格式，旨在保持文档的保真度并提供设备无关的外观。

### **将演示文稿转换为 XPS**

任何可由 Aspose.Slides 加载的演示文稿均可转换为 XPS 格式。Aspose.Slides 使用高保真页面布局和渲染引擎生成固定布局的 XPS 输出。值得注意的是，Aspose.Slides 直接生成 XPS，而不依赖于 Windows Presentation Foundation（WPF）。

{{% alert color="primary" %}}
了解更多： [Convert PowerPoint Presentations to XPS in Python](/slides/zh/python-net/convert-powerpoint-to-xps/).
{{% /alert %}}

## **演示文稿转 TIFF 转换**

### **关于 TIFF**

[标记图像文件格式](https://en.wikipedia.org/wiki/TIFF)（TIFF）是一种光栅图像格式，以能够在单个文件中存储多张图像（页面）而闻名。最初由 Aldus 开发，广泛用于扫描、传真及其他图像处理应用。

### **将演示文稿转换为 TIFF**

任何可在 Aspose.Slides 中加载的文档同样可以直接转换为 TIFF 文件，无需任何第三方组件。您还可以根据需要为生成的 TIFF 中的页面指定图像尺寸。

{{% alert color="primary" %}}
了解更多： [Convert PowerPoint Presentations to TIFF in Python](/slides/zh/python-net/convert-powerpoint-to-tiff/).
{{% /alert %}}

## **FAQ**

**导出为 PDF/XPS 时可以包含隐藏幻灯片吗？**

可以。导出时可通过 [PDF](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) / [XPS](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) 设置中的相应选项包含隐藏幻灯片。

**是否支持保存为 PDF/A（归档存储）格式？**

支持，导出时可使用 [PDF/A 合规性级别](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfcompliance/)（包括 A-2a/A-2b/A-2u 和 A-3a/A-3b）。

**转换过程中字体会如何处理：是嵌入还是替换？**

提供灵活选项：您可以 [嵌入所有字形或仅嵌入使用的子集](/slides/zh/python-net/embedded-font/)、指定 [备用字体](/slides/zh/python-net/fallback-font/)，以及在字体缺少某些样式时 [控制行为](/slides/zh/python-net/font-substitution/)。

**如何控制生成的 PDF 的质量和大小？**

可以设置 [JPEG 质量](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/)、[文本压缩](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/text_compression/)、以及图像的 [足够分辨率阈值](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/)，还有一种模式可选择 [图片的最佳压缩比例](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/)。

**是否可以只导出指定范围的幻灯片（例如 5–12）？**

可以，导出时支持选择幻灯片子集。

**是否支持同时对多个文件进行多核处理？**

可以在独立进程中并行处理不同的演示文稿。重要提示：同一 [presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象不能在 [多个线程](/slides/zh/python-net/multithreading/) 中同时加载或保存。

**在不同线程中应用许可证会有风险吗？**

会的，[设置许可证](/slides/zh/python-net/licensing/) 的调用不是线程安全的，需要进行同步处理。
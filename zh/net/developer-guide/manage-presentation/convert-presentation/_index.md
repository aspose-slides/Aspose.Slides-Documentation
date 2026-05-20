---
title: 在 .NET 中将演示文稿转换为多种格式
linktitle: 转换演示文稿
type: docs
weight: 70
url: /zh/net/convert-presentation/
keywords:
- 转换演示文稿
- 导出演示文稿
- PPT 转 PPTX
- PPTX 转 PPT
- ODP 转 PPTX
- PPT 转 PDF
- PPTX 转 PDF
- ODP 转 PDF
- PPT 转 HTML
- PPTX 转 HTML
- ODP 转 HTML
- PPT 转 PNG
- PPTX 转 PNG
- ODP 转 PNG
- PPTX 转 JPG
- ODP 转 JPG
- PPT 转 XPS
- PPTX 转 XPS
- ODP 转 XPS
- PPT 转 TIFF
- PPTX 转 TIFF
- ODP 转 TIFF
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 将 PowerPoint 和 OpenDocument 演示文稿转换为 PPTX、PDF、HTML、图像、XPS、TIFF 等格式。"
---
## **概述**

Aspose.Slides for .NET 可加载 PowerPoint 和 OpenDocument 演示文稿，并在无需 Microsoft PowerPoint、OpenOffice 或 LibreOffice 的情况下将其保存或渲染为多种其他格式。您可以将旧的 PPT 文件转换为现代 PPTX，将演示文稿导出为 PDF、XPS 等固定布局文档，以 HTML 形式发布幻灯片，或将幻灯片渲染为图像文件以供预览、缩略图和存档使用。

大多数文档转换遵循相同的通用工作流：加载源文件、选择所需的输出格式，并在需要时应用特定格式的选项。对于图像格式，每张幻灯片会单独渲染，然后保存为光栅或矢量图像。下面链接的专门文章提供了每种情况的实现细节。

## **选择转换场景**

使用下面的文章获取完整的 C# 示例和特定格式的选项。

| 场景 | 适用场景 | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP 转 PPTX | 将旧的 PPT 文件现代化，标准化现有 PPTX 文件，或将 OpenDocument 演示文稿转换为 PowerPoint PPTX。 | [Convert PPT to PPTX](/slides/zh/net/convert-ppt-to-pptx/),[Convert ODP to PPTX](/slides/zh/net/convert-odp-to-pptx/),[Save Presentations](/slides/zh/net/save-presentation/) |
| PPTX 转 PPT | 将现代 PowerPoint 演示文稿保存为旧的二进制 PPT 格式，以兼容旧的工作流。 | [Convert PPTX to PPT](/slides/zh/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP 转 PDF | 创建便携、可搜索的固定布局文档，以便共享、打印或归档。 | [Convert PowerPoint to PDF](/slides/zh/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP 转 PDF（含备注） | 将演讲者备注与幻灯片内容一起导出。 | [Convert PowerPoint to PDF with Notes](/slides/zh/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP 转 HTML | 将演示文稿发布为 HTML 页面，并控制图像、字体、备注和响应式布局选项。 | [Convert PowerPoint to HTML](/slides/zh/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP 转 HTML5 | 将幻灯片导出为 HTML5，以在浏览器中保持格式和交互性进行查看。 | [Convert Presentations to HTML5](/slides/zh/net/export-to-html5/) |
| PPT/PPTX/ODP 转 PNG | 将每张幻灯片渲染为 PNG 图像，用于预览、缩略图或网页输出。 | [Convert PowerPoint to PNG](/slides/zh/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP 转 JPG | 将幻灯片渲染为 JPG 图像，并控制图像尺寸和质量。 | [Convert PowerPoint to JPG](/slides/zh/net/convert-powerpoint-to-jpg/) |
| 幻灯片转 SVG | 将单个幻灯片导出为可缩放矢量图形。 | [Render Slide as SVG](/slides/zh/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP 转 XPS | 生成固定布局的 XPS 文档。 | [Convert PowerPoint to XPS](/slides/zh/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP 转 TIFF | 将演示文稿保存为多页 TIFF 文件，适用于打印、扫描、传真或归档工作流。 | [Convert PowerPoint to TIFF](/slides/zh/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP 转 TIFF（含备注） | 将带有演讲者备注的幻灯片保存为 TIFF。 | [Convert PowerPoint to TIFF with Notes](/slides/zh/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX 转 Word | 当需要文档式输出时，将幻灯片转换为 Word 文档。 | [Convert PowerPoint to Word](/slides/zh/net/convert-powerpoint-to-word/) |
| PPT/PPTX 转 Markdown | 将演示文稿内容提取为 Markdown，以便文档编写和基于文本的工作流。 | [Convert PowerPoint to Markdown](/slides/zh/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX 转 动画 GIF | 将幻灯片创建为动画 GIF。 | [Convert PowerPoint to Animated GIF](/slides/zh/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX 转 视频 | 构建从演示文稿幻灯片到视频的导出工作流。 | [Convert PowerPoint to Video](/slides/zh/net/convert-powerpoint-to-video/) |
| 演示文稿转 XAML | 将幻灯片导出为 XAML，用于 .NET UI 场景。 | [Export Presentations to XAML](/slides/zh/net/export-to-xaml/) |

要查看更完整的输入和输出格式列表，请参阅 [Supported File Formats](/slides/zh/net/supported-file-formats/)。

## **PowerPoint 和 OpenDocument 转换**

Aspose.Slides for .NET 支持从常用演示文稿格式（如 PPT、PPTX、PPS、PPSX、POT、POTX 和 ODP）进行转换。PowerPoint 与 OpenDocument 文件使用相同的转换 API，因此将 PPTX 保存为 PDF 的工作流通常只需更换输入文件即可用于 ODP。

转换 ODP 文件时，请记住 PowerPoint 与 OpenDocument 应用程序并未以完全相同的方式支持每一种布局和格式化功能。如果 ODP 文件是使用 LibreOffice 或 OpenOffice Impress 创建的，请检查输出并在需要特定格式指导时参考 [Convert OpenDocument Presentations](/slides/zh/net/convert-openoffice-odp/) 中的选项。

## **PPT 转 PPTX 转换**

PPT 是旧的二进制 PowerPoint 格式，PPTX 是现代的 Office Open XML 格式。Aspose.Slides for .NET 能够高保真地将 PPT 转换为 PPTX，同时保留诸如母版、布局、幻灯片、图表、组合形状、占位符、文本框、纹理和图片填充等复杂结构。

详情请参阅 [Convert PPT to PPTX](/slides/zh/net/convert-ppt-to-pptx/) 和 [PPT vs PPTX](/slides/zh/net/ppt-vs-pptx/)。

## **固定布局导出**

PDF、XPS 和 TIFF 在需要在各设备上保持完全相同外观且不作演示文稿编辑时非常有用。使用 [PdfOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pdfoptions/)、[XpsOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/xpsoptions/) 和 [TiffOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/tiffoptions/) 控制合规性、隐藏幻灯片、备注、图像质量、压缩、像素格式和输出尺寸。

## **HTML 和图像导出**

HTML 与 HTML5 导出适用于浏览器查看、网页发布和轻量共享。图像导出适用于每张幻灯片需要成为单独的预览、缩略图或光栅资源的情况。请参考 PNG、JPG 和 SVG 章节获取特定格式的渲染指导。

## **常见问题**

**是否需要 Microsoft PowerPoint 才能转换演示文稿？**

不需要。Aspose.Slides for .NET 是独立库，无需 Microsoft PowerPoint 或 Office 自动化。

**是否可以批量转换大量演示文稿？**

可以。加载每个演示文稿，保存为所需格式，处理完后释放 `Presentation` 对象。并行处理时，请使用独立的演示文稿实例并遵循 [multithreading](/slides/zh/net/multithreading/) 指南。

**是否可以只导出选定的幻灯片？**

可以。多种导出方法允许传入幻灯片索引或单独渲染幻灯片，具体取决于输出格式。请参阅目标格式的专用文章。

**导出为 PDF 或 XPS 时可以包含隐藏幻灯片吗？**

可以。使用 [PdfOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pdfoptions/) 或 [XpsOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/xpsoptions/) 中的 `ShowHiddenSlides` 属性。

**是否可以创建 PDF/A 输出？**

可以。PDF 合规性设置可通过 [PdfOptions.Compliance](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pdfoptions/compliance/) 和 [PdfCompliance](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pdfcompliance/) 进行配置。

**转换过程中字体如何处理？**

Aspose.Slides 支持嵌入字体、字体回退和字体替换设置。请参考 [Embedded Font](/slides/zh/net/embedded-font/)、[Fallback Font](/slides/zh/net/fallback-font/) 和 [Font Substitution](/slides/zh/net/font-substitution/)。
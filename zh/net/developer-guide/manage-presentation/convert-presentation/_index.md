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

Aspose.Slides for .NET 可以加载 PowerPoint 和 OpenDocument 演示文稿，并在无需 Microsoft PowerPoint、OpenOffice 或 LibreOffice 的情况下将其保存或渲染为多种其他格式。您可以将旧版 PPT 文件转换为现代 PPTX，将演示文稿导出为 PDF、XPS 等固定布局文档，将幻灯片发布为 HTML，或将幻灯片渲染为图像文件以供预览、缩略图和存档使用。

大多数文档转换遵循相同的通用工作流：加载源文件，选择所需的输出格式，并在需要时应用特定格式的选项。对于图像格式，每张幻灯片会单独渲染，然后保存为光栅或矢量图像。下面链接的专用文章提供了每种情况的实现细节。

## **选择转换场景**

使用下面的文章获取完整的 C# 示例和特定格式的选项。

| 场景 | 适用情况 | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP 转 PPTX | 现代化旧版 PPT 文件，规范化现有 PPTX 文件，或将 OpenDocument 演示文稿转换为 PowerPoint PPTX。 | [Convert PPT to PPTX](/slides/zh/net/convert-ppt-to-pptx/),[Convert ODP to PPTX](/slides/zh/net/convert-odp-to-pptx/),[Save Presentations](/slides/zh/net/save-presentation/) |
| PPTX 转 PPT | 将现代 PowerPoint 演示文稿保存为旧的二进制 PPT 格式，以兼容旧的工作流。 | [Convert PPTX to PPT](/slides/zh/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP 转 PDF | 创建可移植、可搜索的固定布局文档，用于共享、打印或归档。 | [Convert PowerPoint to PDF](/slides/zh/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP 转 PDF（含备注） | 将演讲者备注与幻灯片内容一起导出。 | [Convert PowerPoint to PDF with Notes](/slides/zh/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP 转 HTML | 将演示文稿发布为 HTML 页面，并控制图像、字体、备注和响应式布局选项。 | [Convert PowerPoint to HTML](/slides/zh/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP 转 HTML5 | 将幻灯片导出为 HTML5，以便在浏览器中查看并保留格式和交互性。 | [Convert Presentations to HTML5](/slides/zh/net/export-to-html5/) |
| PPT/PPTX/ODP 转 PNG | 将每张幻灯片渲染为 PNG 图像，用于预览、缩略图或网页输出。 | [Convert PowerPoint to PNG](/slides/zh/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP 转 JPG | 将幻灯片渲染为 JPG 图像，并控制图像尺寸和质量。 | [Convert PowerPoint to JPG](/slides/zh/net/convert-powerpoint-to-jpg/) |
| 幻灯片转 SVG | 将单个幻灯片导出为可缩放矢量图形。 | [Render Slide as SVG](/slides/zh/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP 转 XPS | 生成固定布局 XPS 文档。 | [Convert PowerPoint to XPS](/slides/zh/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP 转 TIFF | 将演示文稿保存为多页 TIFF 文件，用于打印、扫描、传真或归档工作流。 | [Convert PowerPoint to TIFF](/slides/zh/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP 转 TIFF（含备注） | 将带有演讲者备注的幻灯片保存为 TIFF。 | [Convert PowerPoint to TIFF with Notes](/slides/zh/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX 转 Word | 当需要文档式输出时，将幻灯片转换为 Word 文档。 | [Convert PowerPoint to Word](/slides/zh/net/convert-powerpoint-to-word/) |
| PPT/PPTX 转 Markdown | 将演示文稿内容提取为 Markdown，便于文档编写和基于文本的工作流。 | [Convert PowerPoint to Markdown](/slides/zh/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX 转 动态 GIF | 从幻灯片创建动画 GIF。 | [Convert PowerPoint to Animated GIF](/slides/zh/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX 转 视频 | 构建从演示幻灯片导出为视频的工作流。 | [Convert PowerPoint to Video](/slides/zh/net/convert-powerpoint-to-video/) |
| 演示文稿转 XAML | 将幻灯片导出为 XAML，以用于 .NET UI 场景。 | [Export Presentations to XAML](/slides/zh/net/export-to-xaml/) |

有关更完整的输入和输出格式列表，请参阅[Supported File Formats](/slides/zh/net/supported-file-formats/)。

## **PowerPoint 和 OpenDocument 转换**

Aspose.Slides for .NET 支持从常用演示文稿格式（如 PPT、PPTX、PPS、PPSX、POT、POTX 和 ODP）进行转换。PowerPoint 和 OpenDocument 文件使用相同的转换 API，因此将 PPTX 文件保存为 PDF 的工作流通常只需更改输入文件即可用于 ODP 文件。

在转换 ODP 文件时，请记住 PowerPoint 和 OpenDocument 应用程序并不以完全相同的方式支持每一种布局和格式化特性。如果 ODP 文件是使用 LibreOffice 或 OpenOffice Impress 创建的，请审查输出并在需要特定格式指导时使用[Convert OpenDocument Presentations](/slides/zh/net/convert-openoffice-odp/)中描述的选项。

## **PPT 转 PPTX 转换**

PPT 是旧的二进制 PowerPoint 格式，而 PPTX 是现代的 Office Open XML 格式。Aspose.Slides for .NET 支持高保真度的 PPT 转 PPTX 转换，并保留复杂的演示结构，如母版、布局、幻灯片、图表、组合形状、占位符、文本框、纹理和图片填充。

详细信息请参阅[Convert PPT to PPTX](/slides/zh/net/convert-ppt-to-pptx/)和[PPT vs PPTX](/slides/zh/net/ppt-vs-pptx/)。

## **固定布局导出**

PDF、XPS 和 TIFF 在需要在不同设备上保持相同外观且不作为演示文稿进行编辑时非常有用。使用[PdfOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pdfoptions/)、[XpsOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/xpsoptions/)和[TiffOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/tiffoptions/)来控制合规性、隐藏幻灯片、备注、图像质量、压缩、像素格式和输出尺寸。

## **HTML 与图像导出**

HTML 和 HTML5 导出适用于浏览器查看、网页发布和轻量级共享。图像导出适用于每张幻灯片需要生成单独的预览、缩略图或光栅资源的情况。请使用 PNG、JPG 和 SVG 相关文章获取特定格式的渲染指南。

## **FAQ**

**是否需要 Microsoft PowerPoint 才能转换演示文稿？**

不需要。Aspose.Slides for .NET 是独立库，不依赖 Microsoft PowerPoint 或 Office 自动化。

**能否批量转换大量演示文稿？**

可以。加载每个演示文稿后保存为所需格式，处理完毕后释放 `Presentation` 对象。对于并行处理，请使用独立的演示实例并遵循[multithreading](/slides/zh/net/multithreading/)指南。

**可以只导出选定的幻灯片吗？**

可以。多种导出方法允许您传递幻灯片索引或单独渲染幻灯片，具体取决于输出格式。请参阅目标格式的专用文章。

**导出为 PDF 或 XPS 时可以包含隐藏幻灯片吗？**

可以。在[PdfOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pdfoptions/)或[XpsOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/xpsoptions/)中使用 `ShowHiddenSlides` 属性。

**可以创建 PDF/A 输出吗？**

可以。PDF 合规性设置可通过[PdfOptions.Compliance](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pdfoptions/compliance/)和[PdfCompliance](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pdfcompliance/)进行配置。

**转换过程中字体如何处理？**

Aspose.Slides 可以使用嵌入字体、字体回退和字体替换设置。请参阅[Embedded Font](/slides/zh/net/embedded-font/)、[Fallback Font](/slides/zh/net/fallback-font/)和[Font Substitution](/slides/zh/net/font-substitution/)。
---
title: 在 PHP 中将演示文稿转换为多种格式
linktitle: 转换演示文稿
type: docs
weight: 70
url: /zh/php-java/convert-presentation/
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
- PHP
- Aspose.Slides
description: 使用 Aspose.Slides for PHP via Java 将 PowerPoint 和 OpenDocument 演示文稿转换为 PPTX、PDF、HTML、图像、XPS、TIFF 等格式。
---
## **概述**

Aspose.Slides for PHP via Java 可以加载 PowerPoint 和 OpenDocument 演示文稿，并在不依赖 Microsoft PowerPoint、OpenOffice 或 LibreOffice 的情况下保存或渲染为多种其他格式。您可以将旧版 PPT 文件转换为现代 PPTX，将演示文稿导出为 PDF、XPS 等固定布局文档，将幻灯片发布为 HTML，或将幻灯片渲染为图像文件用于预览、缩略图和归档。

大多数文档转换使用相同的通用工作流：加载源文件，选择所需的输出格式，并在需要时应用特定格式的选项。对于图像格式，每张幻灯片分别渲染，然后保存为光栅或矢量图像。下面链接的专用文章提供了每种情况的实现细节。

## **选择转换场景**

使用下面的文章获取完整的 PHP 示例和特定格式的选项。

| 场景 | 何时使用 | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | 现代化旧的 PPT 文件，规范现有的 PPTX 文件，或将 OpenDocument 演示文稿转换为 PowerPoint PPTX。 | [转换 PPT 为 PPTX](/slides/zh/php-java/convert-ppt-to-pptx/), [转换 ODP 为 PPTX](/slides/zh/php-java/convert-odp-to-pptx/), [保存演示文稿](/slides/zh/php-java/save-presentation/) |
| PPTX to PPT | 将现代 PowerPoint 演示文稿保存为旧的二进制 PPT 格式，以兼容旧的工作流。 | [转换 PPTX 为 PPT](/slides/zh/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | 创建可便携、可搜索、固定布局的文档，以供共享、打印或归档。 | [将 PowerPoint 转换为 PDF](/slides/zh/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | 导出演讲者备注以及幻灯片内容。 | [将 PowerPoint 转换为带备注的 PDF](/slides/zh/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | 将演示文稿发布为 HTML 页面，并控制图像、字体、备注以及响应式布局选项。 | [将 PowerPoint 转换为 HTML](/slides/zh/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | 将幻灯片导出为 HTML5，以在浏览器中查看，保持格式和交互性。 | [将演示文稿转换为 HTML5](/slides/zh/php-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | 将每张幻灯片渲染为 PNG 图像，以供预览、缩略图或网页输出。 | [将 PowerPoint 转换为 PNG](/slides/zh/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | 将幻灯片渲染为 JPG 图像，并控制图像尺寸和质量。 | [将 PowerPoint 转换为 JPG](/slides/zh/php-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | 将单个幻灯片导出为可缩放矢量图形。 | [将幻灯片渲染为 SVG](/slides/zh/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | 将 PowerPoint 转换为 XPS。 | [将 PowerPoint 转换为 XPS](/slides/zh/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | 将演示文稿保存为多页 TIFF 文件，以用于打印、扫描、传真或归档工作流。 | [将 PowerPoint 转换为 TIFF](/slides/zh/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | 将包含演讲者备注的幻灯片保存为 TIFF。 | [将 PowerPoint 转换为带备注的 TIFF](/slides/zh/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Markdown | 将演示文稿内容提取为 Markdown，以用于文档编写和基于文本的工作流。 | [将 PowerPoint 转换为 Markdown](/slides/zh/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | 从幻灯片创建动画 GIF。 | [将 PowerPoint 转换为动画 GIF](/slides/zh/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | 从演示文稿幻灯片构建视频导出工作流。 | [将 PowerPoint 转换为视频](/slides/zh/php-java/convert-powerpoint-to-video/) |
| Presentation to XAML | 将幻灯片导出为 XAML，以用于 PHP 或 Java UI 场景。 | [导出演示文稿为 XAML](/slides/zh/php-java/export-to-xaml/) |

有关更广泛的输入和输出格式列表，请参阅 [支持的文件格式](/slides/zh/php-java/supported-file-formats/).

## **PowerPoint 和 OpenDocument 转换**

Aspose.Slides for PHP via Java 支持从常用的演示文稿格式（如 PPT、PPTX、PPS、PPSX、POT、POTX 和 ODP）进行转换。PowerPoint 和 OpenDocument 文件使用相同的转换 API，因此将 PPTX 文件保存为 PDF 的工作流通常只需更改输入文件即可应用于 ODP 文件。

在转换 ODP 文件时，请记住 PowerPoint 和 OpenDocument 应用程序并不是在完全相同的方式下支持每一种布局和格式化功能。如果 ODP 文件是使用 LibreOffice 或 OpenOffice Impress 创建的，请检查输出结果，并在需要特定格式指导时使用 [转换 OpenDocument 演示文稿](/slides/zh/php-java/convert-openoffice-odp/) 中描述的选项。

## **PPT 转 PPTX 转换**

PPT 是较旧的二进制 PowerPoint 格式，而 PPTX 是现代的 Office Open XML 格式。Aspose.Slides for PHP via Java 支持高保真度的 PPT 到 PPTX 转换，同时保留复杂的演示结构，如母版、布局、幻灯片、图表、组合形状、占位符、文本框、纹理和图片填充。

有关详细信息，请参阅 [转换 PPT 为 PPTX](/slides/zh/php-java/convert-ppt-to-pptx/) 和 [PPT 与 PPTX 对比](/slides/zh/php-java/ppt-vs-pptx/)。

## **固定布局导出**

当输出需要在不同设备上保持一致且不应作为演示文稿进行编辑时，PDF、XPS 和 TIFF 非常有用。专门的 PDF、XPS 和 TIFF 文章解释了如何控制合规性、隐藏幻灯片、备注、图像质量、压缩、像素格式和输出尺寸。

## **HTML 和图像导出**

HTML 和 HTML5 导出对于在浏览器中查看、网页发布以及轻量级共享非常有用。图像导出在每张幻灯片需要成为单独的预览、缩略图或栅格资源时非常实用。请使用 PNG、JPG 和 SVG 文章获取特定格式的渲染指南。

## **常见问题**

**我需要 Microsoft PowerPoint 来转换演示文稿吗？**

不需要。Aspose.Slides for PHP via Java 是一个独立的库，不需要 Microsoft PowerPoint 或 Office 自动化。

**我可以批量转换大量演示文稿吗？**

可以。加载每个演示文稿，将其保存为所需格式，并在处理后释放演示对象。对于并行处理，请使用单独的演示实例并遵循 [多线程](/slides/zh/php-java/multithreading/) 指南。

**我可以仅导出选定的幻灯片吗？**

可以。多种导出方法允许您传递幻灯片索引或渲染单个幻灯片，具体取决于输出格式。请参阅针对目标格式的专门文章。

**导出为 PDF 或 XPS 时我可以包含隐藏幻灯片吗？**

可以。使用在 [PDF](/slides/zh/php-java/convert-powerpoint-to-pdf/) 与 [XPS](/slides/zh/php-java/convert-powerpoint-to-xps/) 转换文章中描述的隐藏幻灯片导出设置。

**我可以创建 PDF/A 输出吗？**

可以。PDF 导出提供合规性设置。详情请参阅 [将 PowerPoint 转换为 PDF](/slides/zh/php-java/convert-powerpoint-to-pdf/)。

**转换期间如何处理字体？**

Aspose.Slides 可以使用嵌入字体、字体回退和字体替换设置。请参阅 [嵌入字体](/slides/zh/php-java/embedded-font/)、[回退字体](/slides/zh/php-java/fallback-font/) 和 [字体替换](/slides/zh/php-java/font-substitution/)。
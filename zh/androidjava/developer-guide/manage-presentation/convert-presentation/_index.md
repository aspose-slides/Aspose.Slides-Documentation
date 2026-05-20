---
title: 在 Android 上将演示文稿转换为多种格式
linktitle: 转换演示文稿
type: docs
weight: 70
url: /zh/androidjava/convert-presentation/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 将 PowerPoint 和 OpenDocument 演示文稿转换为 PPTX、PDF、HTML、图像、XPS、TIFF 等格式。"
---
## **概述**

Aspose.Slides for Android via Java 可以加载 PowerPoint 和 OpenDocument 演示文稿，并将其保存或渲染为许多其他格式，无需 Microsoft PowerPoint、OpenOffice 或 LibreOffice。您可以将旧版 PPT 文件转换为现代 PPTX，将演示文稿导出为 PDF、XPS 等固定布局文档，发布为 HTML，或将幻灯片渲染为图像文件以用于预览、缩略图和归档。

大多数文档转换使用相同的一般工作流：加载源文件，选择所需的输出格式，并在需要时应用特定格式的选项。对于图像格式，每张幻灯片单独渲染，然后保存为光栅或矢量图像。下面链接的专门文章提供了每种情况的实现细节。

## **选择转换场景**

使用下面的文章获取完整的 Java 示例和特定格式的选项。

| 场景 | 适用于需要 | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP 转 PPTX | 现代化旧版 PPT 文件，规范化现有 PPTX 文件，或将 OpenDocument 演示文稿转换为 PowerPoint PPTX。 | [将 PPT 转换为 PPTX](/slides/zh/androidjava/convert-ppt-to-pptx/), [将 ODP 转换为 PPTX](/slides/zh/androidjava/convert-odp-to-pptx/), [保存演示文稿](/slides/zh/androidjava/save-presentation/) |
| PPTX 转 PPT | 将现代 PowerPoint 演示文稿保存为旧的二进制 PPT 格式，以兼容旧工作流。 | [将 PPTX 转换为 PPT](/slides/zh/androidjava/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP 转 PDF | 创建可移植、可搜索的固定布局文档以用于共享、打印或归档。 | [将 PowerPoint 转换为 PDF](/slides/zh/androidjava/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP 转 PDF（含备注） | 导出包含幻灯片内容的演讲者备注。 | [将 PowerPoint 转换为带备注的 PDF](/slides/zh/androidjava/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP 转 HTML | 将演示文稿发布为 HTML 页面，并控制图像、字体、备注和响应式布局选项。 | [将 PowerPoint 转换为 HTML](/slides/zh/androidjava/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP 转 HTML5 | 将幻灯片导出为 HTML5，以在浏览器中查看并保留格式和交互性。 | [将演示文稿导出为 HTML5](/slides/zh/androidjava/export-to-html5/) |
| PPT/PPTX/ODP 转 PNG | 将每张幻灯片渲染为 PNG 图像，用于预览、缩略图或网页输出。 | [将 PowerPoint 转换为 PNG](/slides/zh/androidjava/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP 转 JPG | 将幻灯片渲染为 JPG 图像，并控制图像尺寸和质量。 | [将 PowerPoint 转换为 JPG](/slides/zh/androidjava/convert-powerpoint-to-jpg/) |
| 幻灯片转 SVG | 将单独的幻灯片导出为可缩放矢量图形。 | [将幻灯片渲染为 SVG](/slides/zh/androidjava/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP 转 XPS | 生成固定布局的 XPS 文档。 | [将 PowerPoint 转换为 XPS](/slides/zh/androidjava/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP 转 TIFF | 将演示文稿保存为多页 TIFF 文件，以用于打印、扫描、传真或归档工作流。 | [将 PowerPoint 转换为 TIFF](/slides/zh/androidjava/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP 转 TIFF（含备注） | 将带有演讲者备注的幻灯片保存为 TIFF。 | [将 PowerPoint 转换为带备注的 TIFF](/slides/zh/androidjava/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX 转 Word | 当需要文档式输出时，将幻灯片转换为 Word 文档。 | [将 PowerPoint 转换为 Word](/slides/zh/androidjava/convert-powerpoint-to-word/) |
| PPT/PPTX 转 Markdown | 将演示文稿内容提取为 Markdown，以用于文档和基于文本的工作流。 | [将 PowerPoint 转换为 Markdown](/slides/zh/androidjava/convert-powerpoint-to-markdown/) |
| PPT/PPTX 转 动画 GIF | 从幻灯片创建动画 GIF。 | [将 PowerPoint 转换为动画 GIF](/slides/zh/androidjava/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX 转 视频 | 构建从演示文稿幻灯片导出为视频的工作流。 | [将 PowerPoint 转换为视频](/slides/zh/androidjava/convert-powerpoint-to-video/) |
| 演示文稿转 XAML | 将幻灯片导出为 XAML，用于 Android 或 Java UI 场景。 | [将演示文稿导出为 XAML](/slides/zh/androidjava/export-to-xaml/) |

有关更全面的输入和输出格式列表，请参阅 [支持的文件格式](/slides/zh/androidjava/supported-file-formats/)。

## **PowerPoint 与 OpenDocument 转换**

Aspose.Slides for Android via Java 支持从常用演示文稿格式（如 PPT、PPTX、PPS、PPSX、POT、POTX 和 ODP）进行转换。PowerPoint 和 OpenDocument 文件使用相同的转换 API，因此将 PPTX 文件保存为 PDF 的工作流通常只需更改输入文件即可用于 ODP 文件。

转换 ODP 文件时，请记住 PowerPoint 和 OpenDocument 应用程序并不以完全相同的方式支持每种布局和格式设置。如果 ODP 文件是在 LibreOffice 或 OpenOffice Impress 中创建的，请检查输出并在需要特定格式指导时使用 [转换 OpenDocument 演示文稿](/slides/zh/androidjava/convert-openoffice-odp/) 中描述的选项。

## **PPT 转 PPTX 转换**

PPT 是旧的二进制 PowerPoint 格式，而 PPTX 是现代的 Office Open XML 格式。Aspose.Slides for Android via Java 支持高保真度的 PPT 到 PPTX 转换，保留复杂的演示结构，如母版、布局、幻灯片、图表、组合形状、占位符、文本框、纹理和图片填充。

详情请参阅 [将 PPT 转换为 PPTX](/slides/zh/androidjava/convert-ppt-to-pptx/) 和 [PPT 与 PPTX](/slides/zh/androidjava/ppt-vs-pptx/)。

## **固定布局导出**

PDF、XPS 和 TIFF 在需要在不同设备上保持相同外观且不作为演示文稿编辑时非常有用。专门的 PDF、XPS 和 TIFF 文章解释了如何控制合规性、隐藏幻灯片、备注、图像质量、压缩、像素格式和输出尺寸。

## **HTML 与图像导出**

HTML 和 HTML5 导出适用于浏览器查看、网页发布和轻量级共享。图像导出用于每张幻灯片需要单独的预览、缩略图或光栅资源的情况。请使用 PNG、JPG 和 SVG 文章获取特定格式的渲染指南。

## **常见问题**

**是否需要 Microsoft PowerPoint 才能转换演示文稿？**

不需要。Aspose.Slides for Android via Java 是一个独立库，不依赖 Microsoft PowerPoint 或 Office 自动化。

**是否可以批量转换大量演示文稿？**

可以。加载每个演示文稿，保存为所需格式，处理完毕后释放演示文稿对象。对于并行处理，请使用独立的演示文稿实例并遵循 [多线程](/slides/zh/androidjava/multithreading/) 指南。

**是否可以仅导出选定的幻灯片？**

可以。多种导出方法允许您传递幻灯片索引或单独渲染幻灯片，具体取决于输出格式。请参阅目标格式的专门文章。

**导出为 PDF 或 XPS 时是否可以包含隐藏幻灯片？**

可以。使用在 [PDF](/slides/zh/androidjava/convert-powerpoint-to-pdf/) 和 [XPS](/slides/zh/androidjava/convert-powerpoint-to-xps/) 转换文章中描述的隐藏幻灯片导出设置。

**是否可以创建 PDF/A 输出？**

可以。PDF 导出提供合规性设置。详情请参阅 [将 PowerPoint 转换为 PDF](/slides/zh/androidjava/convert-powerpoint-to-pdf/)。

**转换过程中字体如何处理？**

Aspose.Slides 可以使用嵌入字体、字体回退和字体替代设置。请参阅 [嵌入字体](/slides/zh/androidjava/embedded-font/)、[回退字体](/slides/zh/androidjava/fallback-font/) 和 [字体替代](/slides/zh/androidjava/font-substitution/)。
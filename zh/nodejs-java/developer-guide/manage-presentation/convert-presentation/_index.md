---
title: 在 JavaScript 中将演示文稿转换为多种格式
linktitle: 转换演示文稿
type: docs
weight: 70
url: /zh/nodejs-java/convert-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 将 PowerPoint 和 OpenDocument 演示文稿转换为 PPTX、PDF、HTML、图像、XPS、TIFF 等格式。"
---
## **概述**

Aspose.Slides for Node.js via Java 可以加载 PowerPoint 和 OpenDocument 演示文稿，并在不依赖 Microsoft PowerPoint、OpenOffice 或 LibreOffice 的情况下将其保存或渲染为多种其他格式。您可以将传统的 PPT 文件转换为现代 PPTX，将演示文稿导出为 PDF、XPS 等固定布局文档，将幻灯片发布为 HTML，或将幻灯片渲染为用于预览、缩略图和归档的图像文件。

大多数文档转换使用相同的一般工作流：加载源文件，选择所需的输出格式，并在需要时应用特定格式的选项。对于图像格式，每张幻灯片会单独渲染，然后保存为光栅或矢量图像。下面链接的专门文章提供了每种情况的实现细节。

## **选择转换场景**

请使用下面的文章获取完整的 JavaScript 示例和特定格式的选项。

| 场景 | 在需要时使用 | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP 转换为 PPTX | 将传统 PPT 文件现代化，规范化现有 PPTX 文件，或将 OpenDocument 演示文稿转换为 PowerPoint PPTX。 | [转换 PPT 为 PPTX](/slides/zh/nodejs-java/convert-ppt-to-pptx/), [转换 ODP 为 PPTX](/slides/zh/nodejs-java/convert-odp-to-pptx/), [保存演示文稿](/slides/zh/nodejs-java/save-presentation/) |
| PPTX 转换为 PPT | 将现代 PowerPoint 演示文稿保存为旧的二进制 PPT 格式，以兼容旧的工作流。 | [转换 PPTX 为 PPT](/slides/zh/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP 转换为 PDF | 创建便携、可搜索、固定布局的文档，以便共享、打印或归档。 | [转换 PowerPoint 为 PDF](/slides/zh/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP 转换为 PDF（带备注） | 将演讲者备注与幻灯片内容一起导出。 | [转换 PowerPoint 为 PDF（带备注）](/slides/zh/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP 转换为 HTML | 将演示文稿发布为 HTML 页面，并控制图像、字体、备注以及响应式布局选项。 | [转换 PowerPoint 为 HTML](/slides/zh/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP 转换为 HTML5 | 将幻灯片导出为 HTML5，以实现基于浏览器的查看，保留格式和交互性。 | [导出演示文稿为 HTML5](/slides/zh/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP 转换为 PNG | 将每张幻灯片渲染为 PNG 图像，用于预览、缩略图或网络输出。 | [转换 PowerPoint 为 PNG](/slides/zh/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP 转换为 JPG | 将幻灯片渲染为 JPG 图像，并控制图像尺寸和质量。 | [转换 PowerPoint 为 JPG](/slides/zh/nodejs-java/convert-powerpoint-to-jpg/) |
| 幻灯片转换为 SVG | 将单个幻灯片导出为可缩放矢量图形。 | [将幻灯片渲染为 SVG](/slides/zh/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP 转换为 XPS | 生成固定布局的 XPS 文档。 | [转换 PowerPoint 为 XPS](/slides/zh/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP 转换为 TIFF | 将演示文稿保存为多页 TIFF 文件，以用于打印、扫描、传真或归档工作流。 | [转换 PowerPoint 为 TIFF](/slides/zh/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP 转换为 TIFF（带备注） | 将包含演讲者备注的幻灯片保存为 TIFF。 | [转换 PowerPoint 为 TIFF（带备注）](/slides/zh/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX 转换为 Markdown | 将演示文稿内容提取为 Markdown，以用于文档编写和基于文本的工作流。 | [转换 PowerPoint 为 Markdown](/slides/zh/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX 转换为 Animated GIF | 从幻灯片创建动画 GIF。 | [转换 PowerPoint 为 Animated GIF](/slides/zh/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX 转换为 Video | 构建从演示文稿幻灯片导出为视频的工作流。 | [转换 PowerPoint 为 Video](/slides/zh/nodejs-java/convert-powerpoint-to-video/) |
| 演示文稿转换为 XAML | 将幻灯片导出为 XAML，以用于 JavaScript 或 Java UI 场景。 | [导出演示文稿为 XAML](/slides/zh/nodejs-java/export-to-xaml/) |

欲了解更全面的输入和输出格式列表，请参阅 [支持的文件格式](/slides/zh/nodejs-java/supported-file-formats/)。

## **PowerPoint 与 OpenDocument 转换**

Aspose.Slides for Node.js via Java 支持从常用的演示文稿格式（如 PPT、PPTX、PPS、PPSX、POT、POTX 和 ODP）进行转换。PowerPoint 与 OpenDocument 文件使用相同的转换 API，因此将 PPTX 文件保存为 PDF 的工作流通常只需更改输入文件即可用于 ODP。

在转换 ODP 文件时，请记住 PowerPoint 与 OpenDocument 应用程序并未以完全相同的方式支持所有布局和格式功能。如果 ODP 文件是在 LibreOffice 或 OpenOffice Impress 中创建的，请检查输出结果，并在需要特定格式指导时使用 [转换 OpenDocument 演示文稿](/slides/zh/nodejs-java/convert-openoffice-odp/) 中描述的选项。

## **PPT 转换为 PPTX**

PPT 是旧的二进制 PowerPoint 格式，而 PPTX 是现代的 Office Open XML 格式。Aspose.Slides for Node.js via Java 支持高保真度的 PPT 转换为 PPTX，保留诸如母版、布局、幻灯片、图表、组合形状、占位符、文本框、纹理和图片填充等复杂的演示结构。

有关详情，请参阅 [转换 PPT 为 PPTX](/slides/zh/nodejs-java/convert-ppt-to-pptx/) 和 [PPT 与 PPTX 对比](/slides/zh/nodejs-java/ppt-vs-pptx/)。

## **固定布局导出**

当输出需在各设备上保持一致且不应作为演示文稿编辑时，PDF、XPS 和 TIFF 非常有用。专门的 PDF、XPS 和 TIFF 文章说明了如何控制合规性、隐藏幻灯片、备注、图像质量、压缩、像素格式和输出尺寸。

## **HTML 与图像导出**

HTML 和 HTML5 导出适用于浏览器查看、网页发布以及轻量级共享。图像导出适用于每张幻灯片需要生成独立的预览、缩略图或光栅资产的情况。请使用 PNG、JPG 和 SVG 文章获取特定格式的渲染指导。

## **常见问题**

**我是否需要 Microsoft PowerPoint 来转换演示文稿？**

不需要。Aspose.Slides for Node.js via Java 是一个独立的库，无需 Microsoft PowerPoint 或 Office 自动化。

**我可以批量转换多个演示文稿吗？**

可以。加载每个演示文稿，保存为所需格式，处理完后释放演示对象。对于并行处理，请使用独立的演示实例并遵循 [多线程](/slides/zh/nodejs-java/multithreading/) 指南。

**我可以只导出选定的幻灯片吗？**

可以。多种导出方法允许您传递幻灯片索引或渲染单个幻灯片，具体取决于输出格式。请参阅对应格式的专门文章。

**导出为 PDF 或 XPS 时可以包含隐藏幻灯片吗？**

可以。使用在 [PDF](/slides/zh/nodejs-java/convert-powerpoint-to-pdf/) 和 [XPS](/slides/zh/nodejs-java/convert-powerpoint-to-xps/) 转换文章中描述的隐藏幻灯片导出设置。

**我可以创建 PDF/A 输出吗？**

可以。PDF 导出提供了符合 PDF/A 的合规设置。详情请参阅 [转换 PowerPoint 为 PDF](/slides/zh/nodejs-java/convert-powerpoint-to-pdf/)。

**转换过程中字体如何处理？**

Aspose.Slides 可使用嵌入字体、字体回退和字体替换设置。请参阅 [嵌入字体](/slides/zh/nodejs-java/embedded-font/)、[回退字体](/slides/zh/nodejs-java/fallback-font/) 和 [字体替换](/slides/zh/nodejs-java/font-substitution/)。
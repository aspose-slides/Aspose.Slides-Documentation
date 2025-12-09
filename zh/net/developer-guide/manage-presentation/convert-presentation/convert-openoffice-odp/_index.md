---
title: 在 .NET 中转换 OpenDocument 演示文稿
linktitle: 转换 OpenDocument
type: docs
weight: 10
url: /zh/net/convert-openoffice-odp/
keywords:
- 转换 ODP
- ODP 转 图像
- ODP 转 GIF
- ODP 转 HTML
- ODP 转 JPG
- ODP 转 MD
- ODP 转 PDF
- ODP 转 PNG
- ODP 转 PPT
- ODP 转 PPTX
- ODP 转 TIFF
- ODP 转 视频
- ODP 转 Word
- ODP 转 XPS
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 让您轻松将 ODP 转换为 PDF、HTML 和图像格式。通过快速且准确的演示文稿转换提升您的 .NET 应用程序。"
---

## **概述**

Aspose.Slides for .NET 提供了一个强大的 API，用于将 OpenDocument (ODP) 演示文稿转换为各种其他格式。采用与 PowerPoint (PPT 和 PPTX) 文件类似的方法，开发人员可以轻松将 ODP 文档导出为 HTML、PDF、TIFF、JPG、XPS 等格式。

以下示例展示了如何将 ODP 文档转换为其他格式（只需将源更改为 ODP 文件）：

- [转换 ODP 为 HTML](/slides/zh/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [转换 ODP 为 PDF](/slides/zh/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [转换 ODP 为 TIFF](/slides/zh/net/convert-powerpoint-to-tiff/)
- [转换 ODP 为 SWF](/slides/zh/net/convert-powerpoint-to-swf-flash/)
- [转换 ODP 为 XPS](/slides/zh/net/convert-powerpoint-to-xps/)
- [转换 ODP 为带批注的 PDF](/slides/zh/net/convert-powerpoint-to-pdf-with-notes/)
- [转换 ODP 为带批注的 TIFF](/slides/zh/net/convert-powerpoint-to-tiff-with-notes/)

例如，将 ODP 演示文稿转换为 PDF 只需几行 C# 代码：
```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```


## **不同应用中的 OpenDocument 演示文稿**

当在 PowerPoint 中打开 OpenDocument 演示文稿 (ODP) 文件时，可能无法保留创建该文件的应用程序中的原始格式。这是因为 OpenDocument 演示文稿应用程序和 PowerPoint 应用程序提供了不同的功能和渲染行为。

以下是一些差异：

- 在 PowerPoint 中，表格通常在最后渲染，可能会覆盖其他形状，无论它们在 ODP 幻灯片上的顺序如何。
- PowerPoint 不支持 ODP 表格的图片填充。
- LibreOffice/OpenOffice Impress 不支持文本垂直旋转（270°，堆叠）和分散对齐。
- LibreOffice/OpenOffice Impress 不支持文本的图片填充、渐变填充和图案填充。

MS PowerPoint 和 LibreOffice/OpenOffice Impress 也会以不同方式处理列表。使用 PowerPoint 创建的 ODP 文件在 LibreOffice/OpenOffice Impress 中可能显示不正确，反之亦然。

下图展示了在 LibreOffice Impress 中创建的列表的外观：

![ODP 列表示例](odp-list-example.png)

Aspose.Slides 以一种确保列表在 LibreOffice/OpenOffice Impress 中正确显示的方式保存 ODP 列表。

[了解有关 OpenDocument 格式和 PowerPoint 的更多信息](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **常见问题**

**如果在转换后我的 ODP 文件的格式发生变化怎么办？**

ODP 和 PowerPoint 使用不同的演示模型，某些元素——例如表格、自定义字体或填充样式——可能无法完全相同地渲染。建议检查输出结果，并在需要时通过代码调整布局或格式。

**我需要安装 OpenOffice 或 LibreOffice 才能使用 ODP 转换吗？**

不需要，Aspose.Slides for .NET 是一个独立的库，无需在系统上安装 OpenOffice 或 LibreOffice。

**我可以在 ODP 转换期间自定义输出格式吗（例如，设置 PDF 选项）？**

可以，Aspose.Slides 提供丰富的选项来自定义输出。例如，在保存为 PDF 时，您可以通过 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类控制压缩、图像质量、文本渲染等。

**Aspose.Slides 适用于服务器端或基于云的 ODP 处理吗？**

当然。Aspose.Slides for .NET 设计用于在桌面和服务器环境中运行，包括 Azure、AWS 和 Docker 容器等基于云的平台，且没有任何 UI 依赖。
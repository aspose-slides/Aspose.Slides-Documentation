---
title: 在 C# 中转换 OpenDocument 演示文稿 (ODP)
linktitle: 转换 OpenDocument
type: docs
weight: 10
url: /zh/net/convert-openoffice-odp/
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
description: "Aspose.Slides for .NET 可轻松将 ODP 转换为 PDF、HTML 和图像格式。通过快速且精准的演示文稿转换提升您的 .NET 应用程序。"
---

## **概述**

Aspose.Slides for .NET 提供了一个强大的 API，用于将 OpenDocument (ODP) 演示文稿转换为多种其他格式。采用与 PowerPoint (PPT 和 PPTX) 文件相似的方法，开发者可以轻松将 ODP 文档导出为 HTML、PDF、TIFF、JPG、XPS 等格式。

以下示例展示了如何将 ODP 文档转换为其他格式（只需将源文件更改为 ODP 文件）：

- [将 ODP 转换为 HTML](/slides/zh/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [将 ODP 转换为 PDF](/slides/zh/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [将 ODP 转换为 TIFF](/slides/zh/net/convert-powerpoint-to-tiff/)
- [将 ODP 转换为 SWF](/slides/zh/net/convert-powerpoint-to-swf-flash/)
- [将 ODP 转换为 XPS](/slides/zh/net/convert-powerpoint-to-xps/)
- [将 ODP 转换为带备注的 PDF](/slides/zh/net/convert-powerpoint-to-pdf-with-notes/)
- [将 ODP 转换为带备注的 TIFF](/slides/zh/net/convert-powerpoint-to-tiff-with-notes/)

例如，将 ODP 演示文稿转换为 PDF 仅需几行 C# 代码：
```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```


## **不同应用中的 OpenDocument 演示文稿**

在 PowerPoint 中打开 OpenDocument 演示文稿 (ODP) 文件时，可能无法保留其原始创建应用程序中的格式。这是因为 OpenDocument 演示文稿应用程序与 PowerPoint 应用程序提供的功能和渲染行为不同。

一些差异包括：

- 在 PowerPoint 中，表格通常最后渲染，可能会覆盖其他形状，无论它们在 ODP 幻灯片上的顺序如何。
- PowerPoint 不支持 ODP 表格的图片填充。
- LibreOffice/OpenOffice Impress 不支持文本的垂直旋转（270°，堆叠）和分散对齐。
- LibreOffice/OpenOffice Impress 不支持文本的图片填充、渐变填充和图案填充。

MS PowerPoint 与 LibreOffice/OpenOffice Impress 也在列表处理上有所不同。用 PowerPoint 创建的 ODP 文件在 LibreOffice/OpenOffice Impress 中可能显示不正确，反之亦然。

以下图片显示了在 LibreOffice Impress 中创建的列表效果：

![ODP 列表示例](odp-list-example.png)

Aspose.Slides 以一种能够在 LibreOffice/OpenOffice Impress 中正确显示的方式保存 ODP 列表。

[了解有关 OpenDocument 格式和 PowerPoint 的更多信息](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0)。

## **常见问题解答**

**如果我的 ODP 文件在转换后格式发生变化该怎么办？**

ODP 与 PowerPoint 使用不同的演示模型，一些元素——如表格、自定义字体或填充样式——可能无法完全相同地渲染。建议检查输出结果，并在必要时通过代码调整布局或格式。

**使用 ODP 转换是否需要安装 OpenOffice 或 LibreOffice？**

不需要，Aspose.Slides for .NET 是独立库，无需在系统上安装 OpenOffice 或 LibreOffice。

**在 ODP 转换过程中可以自定义输出格式吗（例如设置 PDF 选项）？**

可以，Aspose.Slides 提供丰富的选项来自定义输出。例如，保存为 PDF 时，可通过 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类控制压缩、图像质量、文本渲染等。

**Aspose.Slides 适用于服务器端或基于云的 ODP 处理吗？**

完全适用。Aspose.Slides for .NET 旨在在桌面和服务器环境中运行，包括 Azure、AWS 和 Docker 容器等云平台，且不依赖任何 UI。
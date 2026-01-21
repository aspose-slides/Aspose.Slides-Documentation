---
title: 在 .NET 中转换 OpenDocument 演示文稿
linktitle: 转换 OpenDocument
type: docs
weight: 10
url: /zh/net/convert-openoffice-odp/
keywords:
- 转换 ODP
- ODP 转图像
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 可轻松将 ODP 转换为 PDF、HTML 和图像格式。通过快速、精准的演示文稿转换，提升 .NET 应用的性能。"
---

[**Aspose.Slides API**](https://products.aspose.com/slides/net/) 允许您将 OpenDocument (ODP) 演示文稿转换为多种格式（HTML、PDF、TIFF、SWF、XPS 等）。用于将 ODP 文件转换为其他文档格式的 API 与用于 PowerPoint（PPT 和 PPTX）转换操作的 API 相同。

例如，如果您需要将 ODP 演示文稿转换为 PDF，可以按以下方式操作：
```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```


## **在不同应用程序中打开 OpenDocument 演示文稿**

当在 PowerPoint 中打开 OpenDocument 演示文稿（ODP）文件时，可能无法保留其在创建应用程序中的原始格式。这是因为 OpenDocument 演示文稿应用程序和 PowerPoint 应用程序提供的功能和渲染行为不同。

以下是一些差异：

- 在 PowerPoint 中，表格通常最后渲染，可能会覆盖其他形状，而不管它们在 ODP 幻灯片上的顺序。
- PowerPoint 不支持 ODP 表格的图片填充。
- LibreOffice/OpenOffice Impress 不支持文本的垂直旋转（270°、堆叠）和分散对齐。
- LibreOffice/OpenOffice Impress 不支持文本的图片填充、渐变填充和图案填充。

MS PowerPoint 和 LibreOffice/OpenOffice Impress 也对列表的处理不同。使用 PowerPoint 创建的 ODP 文件在 LibreOffice/OpenOffice Impress 中可能显示不正确，反之亦然。

下面的图片展示了在 LibreOffice Impress 中创建的列表效果：

![ODP list example](odp-list-example.png)

Aspose.Slides 以一种能够在 LibreOffice/OpenOffice Impress 中正确显示的方式保存 ODP 列表。

[了解更多关于 OpenDocument 格式和 PowerPoint 的信息](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0)。

## **FAQ**

**如果我的 ODP 文件在转换后格式发生变化怎么办？**

ODP 和 PowerPoint 使用不同的演示模型，某些元素——例如表格、 自定义字体或填充样式——可能无法完全相同地渲染。建议您检查输出结果，并在代码中根据需要调整布局或格式。

**使用 ODP 转换是否需要安装 OpenOffice 或 LibreOffice？**

不需要，Aspose.Slides for .NET 是一个独立的库，系统上无需安装 OpenOffice 或 LibreOffice。

**我可以在 ODP 转换期间自定义输出格式吗（例如设置 PDF 选项）？**

可以，Aspose.Slides 提供丰富的选项来自定义输出。例如，保存为 PDF 时，您可以通过 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类控制压缩、图像质量、文本渲染等。

**Aspose.Slides 适用于服务器端或基于云的 ODP 处理吗？**

完全适用。Aspose.Slides for .NET 设计用于桌面和服务器环境，包括 Azure、AWS 和 Docker 容器等云平台，且无需任何 UI 依赖。
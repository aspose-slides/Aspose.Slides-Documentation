---
title: 将 PowerPoint 演示文稿转换为 .NET 中的 XML
linktitle: PowerPoint 转 XML
type: docs
weight: 145
url: /zh/net/convert-powerpoint-to-xml/
keywords:
- 将 PowerPoint 转换为 XML
- 将演示文稿转换为 XML
- PPT 转 XML
- PPTX 转 XML
- ODP 转 XML
- PowerPoint XML 演示文稿
- SaveFormat.Xml
- 将演示文稿保存为 XML
- 将演示文稿导出为 XML
- XML 流
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 C# 中将 PowerPoint 和 OpenDocument 演示文稿转换为 PowerPoint XML 文件或流。"
---
## **概述**

Aspose.Slides for .NET 可以将 PowerPoint 演示文稿转换为 PowerPoint XML 演示文稿格式。XML 输出在需要文本形式的表示来检查演示结构、排查生成的文档、在自动化测试中比较输出，或在需要 XML 而非演示包的工作流中进行集成时非常有用。

使用 [Presentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/) 方法，并传入来自 [SaveFormat](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveformat/) 枚举的 `Xml` 值。你可以将结果直接写入文件或流。

{{% alert color="info" title="注意" %}}
`SaveFormat.Xml` 会创建 PowerPoint XML 演示文稿。它不会提取 PPTX 包内部存储的单个 Office Open XML 部件。如果需要确切的 PPTX 包部件，如 `ppt/presentation.xml` 或单独的幻灯片 XML 文件，请检查 PPTX 包本身。
{{% /alert %}}

## **将演示文稿转换为 XML 文件**

使用 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类加载源演示文稿，然后将输出路径和 `SaveFormat.Xml` 传递给 [Presentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/)。源文件可以是任何受支持的加载格式，例如 PPT、PPTX 或 ODP。

以下示例将 PPTX 演示文稿转换为 XML 文件：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **将 XML 输出写入流**

当 XML 必须保持在内存中或传递给其他组件（如 Web 服务、存储提供程序或 XML 处理管道）时，使用 [Presentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/) 的流重载。以下示例将结果写入 [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) 并将其回退，以便后续读取：

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// 将 xmlStream 传递给工作流中的下一个组件。
```

## **将 XML 与演示文稿和导出格式进行比较**

根据结果的使用方式选择输出格式：

| 格式 | 输出 | 典型用例 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML 演示文稿 | 检查结构、排查问题、比较生成输出、基于 XML 的集成 |
| PPT (`.ppt`) | 传统二进制演示文件 | 与旧版 PowerPoint 工作流的兼容性 |
| PPTX (`.pptx`) | 包含多个部件的 Office Open XML 包 | 常规 PowerPoint 编辑和演示文稿交换 |
| PDF 或 TIFF | 固定布局页面或多页图像 | 查看、打印和归档 |
| PNG、JPEG 或 SVG | 单个幻灯片的渲染表示 | 缩略图、预览和图像资产 |
| HTML 或 HTML5 | 面向 Web 的演示输出 | 浏览器查看和网页发布 |

与 PPT 和 PPTX 不同，XML 输出主要用于检查和面向数据的工作流。与 PDF、TIFF、HTML 和幻灯片图像格式不同，XML 表示的是演示数据，而不是将幻灯片渲染为页面或视觉资产。[受支持的文件格式](/slides/zh/net/supported-file-formats/) 表格将 PowerPoint XML 演示文稿列为仅用于保存的格式，因此在工作流必须将导出的文件重新加载回 Aspose.Slides 进行后续编辑时，请勿使用该格式。

## **常见问题**

**`SaveFormat.Xml` 与保存 PPTX 文件是同一回事吗？**

不。PPTX 是一个包含多个 Office Open XML 部件的包，而 `SaveFormat.Xml` 会创建 PowerPoint XML 演示文稿文件。

**可以在不在磁盘上创建文件的情况下保存 XML 输出吗？**

可以。将可写流传递给 [Presentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/)。例如，使用 [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) 进行内存处理。

**Aspose.Slides 能再次加载导出的 XML 文件吗？**

不能。PowerPoint XML 演示文稿目前仅支持保存，不支持加载。当需要往返编辑时，请使用 PPTX 或其他受支持的演示文稿格式。

**XML 转换会将每张幻灯片渲染为页面或图像吗？**

不会。XML 转换写入结构化的演示数据。若需要页面式输出，请使用 PDF 或 TIFF；若需要单张幻灯片图像，请使用 PNG、JPEG 或 SVG。
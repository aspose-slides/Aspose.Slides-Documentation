---
title: 常见问题解答
type: docs
weight: 340
url: /zh/net/faqs/
keywords:
- 常见问题
- PowerPoint
- 演示文稿格式
- 内存不足异常
- 幻灯片大小
- 提取文本
- 检索文本
- 段落大小
- 格式化表格
- 字体
- C#
- .NET
- Aspose.Slides for .NET
---

## **支持的文件格式**

**问：Aspose.Slides for .NET 支持哪些文件格式？**

**答**：Aspose.Slides for .NET 支持在 [支持的文件格式](/slides/zh/net/supported-file-formats/) 中描述的文件格式。

## **异常**

**问：在加载一个大 PPT 文件时我遇到了 OutOfMemoryException。Aspose.Slides 对文件大小有什么限制吗？**

**答**：Aspose.Slides 对演示文稿支持的大小没有具体的计算公式。内存中应该有足够的空间来容纳整个演示文稿结构和图像。通常，内存中的图像占用的空间比硬盘大，特别是当图像有附加效果时。

一般来说，Aspose.Slides for .NET 可以轻松处理大约 300 MB 的演示文稿文件，前提是服务器有 4 GB 的 RAM。

## **处理幻灯片**

**问：我可以改变演示文稿中幻灯片的大小吗？**

**答**：您可以使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类暴露的 `SlideSize` 属性来定义演示文稿中幻灯片的大小。

**问：有没有办法在演示文稿中定义不同大小的幻灯片？**

**答**：由于幻灯片的大小是在 Microsoft PowerPoint 文档中的演示文稿级别定义的，因此无法做到这一点。

**问：Aspose.Slides for .NET 支持在保存之前预览幻灯片吗？**

**答**：您可以将演示文稿幻灯片渲染为图像，并可以使用这些图像来预览幻灯片。

## **处理文本**

**问：是否可以检索演示文稿中的所有文本？**

**答**：Aspose.Slides for .NET 在 `Aspose.Slides.Util` 命名空间下提供了 [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) 类，该类提供了多种方法来检索演示文稿中的整段文本。

**问：为什么在 Windows 和 Linux 操作系统上段落大小不同？**

**答**：段落大小的计算是基于表示给定段落的文本大小的计算。文本大小的计算基于 PowerPoint 演示文稿中指定的字体的指标。如果指定的字体缺失，它会被最相似的字体替代，但这个字体的指标与原始字体不同。因此，在不同系统中段落大小的计算会根据安装的字体集导致不同的结果。为了在不同操作系统上获得相同的结果，您需要在系统上安装相同的字体，或者在运行时将其加载为 [外部字体](/slides/zh/net/custom-font/)。

## **格式化和图像**

**问：我如何设置表格边框的颜色？**

**答**：您可以更改所有表格边框的颜色或仅更改整个表格周围的边框。要更改所有边框，请使用 [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) 接口中的 `CellFormat` 属性。对于整个表格的边框，您应该遍历单元格并更改外部边框的颜色。

**问：Aspose.Slides for .NET 用什么度量单位来放置图片？**

**答**：幻灯片上所有形状的坐标和尺寸以点为单位测量（72 dpi）。

## **处理字体**

**问：在将 PPT 转换为 PDF 或图像时，为什么输出文档中的字体不同？**

**答**：此问题可能表示演示文稿中使用的字体在执行代码的操作系统中缺失。您应该在操作系统上安装字体，或使用 [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) 类将其作为外部字体加载，如下所示：
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```
---
title: 常见问题
type: docs
weight: 340
url: /zh/net/faqs/
keywords:
- 常见问题
- PowerPoint
- 演示文稿格式
- 内存不足错误
- 幻灯片大小
- 提取文本
- 检索文本
- 段落大小
- 表格格式化
- 字体
- .NET
- C#
- Aspose.Slides
description: "获取 Aspose.Slides for .NET 的常见问题解答，涵盖 PowerPoint 和 OpenDocument 支持、安装指南、授权、故障排除。"
---

## **支持的文件格式**

**Q: Aspose.Slides for .NET 支持哪些文件格式？**

**A:** Aspose.Slides for .NET 支持在[支持的文件格式](/slides/zh/net/supported-file-formats/)中描述的文件格式。

## **异常**

**Q: 在加载包含图像的大型 PPT 文件时出现 OutOfMemoryException。Aspose.Slides 对文件大小有限制吗？**

**A:** Aspose.Slides 并没有用于计算支持的演示文稿大小的具体公式。需要有足够的空间在内存中容纳整个演示文稿结构和图像。通常，内存中的图像占用的空间比硬盘上的要大，尤其是图像带有额外效果时。

一般来说，Aspose.Slides for .NET 在 4 GB RAM 的服务器上可以轻松处理约 300 MB 的演示文稿文件。

## **幻灯片操作**

**Q: 我可以更改演示文稿中幻灯片的尺寸吗？**

**A:** 您可以使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类公开的 `SlideSize` 属性来定义演示文稿中幻灯片的尺寸。

**Q: 是否可以在同一演示文稿中定义不同尺寸的幻灯片？**

**A:** 由于幻灯片的尺寸在 Microsoft PowerPoint 文档中是按演示文稿级别定义的，无法实现此功能。

**Q: Aspose.Slides for .NET 支持在保存之前预览幻灯片吗？**

**A:** 您可以将演示文稿的幻灯片渲染为图像，并使用这些图像来预览幻灯片。

## **文本操作**

**Q: 能够检索演示文稿中的所有文本吗？**

**A:** Aspose.Slides for .NET 在 `Aspose.Slides.Util` 命名空间下提供了 [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) 类，提供了多种检索演示文稿全文本的方法。

**Q: 为什么在 Windows 和 Linux 操作系统上段落大小不同？**

**A:** 段落大小的计算基于给定段落的文本大小。文本大小的计算依赖于 PowerPoint 演示文稿中指定的字体度量。如果指定的字体缺失，会被替换为最相似的字体，但该字体的度量与原始字体不同。因此，在不同系统中段落大小的计算会因已安装字体的不同而产生差异。要在不同操作系统上获得相同的结果，需要在系统上安装相同的字体，或在运行时像[外部字体](/slides/zh/net/custom-font/)那样加载它们。

## **格式化和图像**

**Q: 如何设置表格边框的颜色？**

**A:** 您可以更改所有表格边框的颜色，或仅更改整个表格的外边框颜色。要更改所有边框，请使用来自 [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) 接口的 `CellFormat` 属性。若要更改整个表格的边框，需要遍历单元格并更改外侧边框的颜色。

**Q: Aspose.Slides for .NET 使用什么度量单位来放置图片？**

**A:** 幻灯片上所有形状的坐标和尺寸均以点 (points) 为单位进行衡量（72 dpi）。

## **字体操作**

**Q: 将 PPT 转换为 PDF 或图像时，输出文档中的字体为何不同？**

**A:** 该问题可能表明演示文稿中使用的字体在执行代码的操作系统上缺失。您应在操作系统上安装这些字体，或使用 [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) 类如下面所示加载外部字体：

```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```

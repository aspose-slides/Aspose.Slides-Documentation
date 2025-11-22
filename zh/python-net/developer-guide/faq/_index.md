---
title: 常见问题
type: docs
weight: 340
url: /zh/python-net/faq/
keywords:
- 常见问题
- PowerPoint
- 演示文稿格式
- 内存不足错误
- 幻灯片尺寸
- 提取文本
- 检索文本
- 段落尺寸
- 表格格式化
- 字体
- Python
- Aspose.Slides
description: "获取关于 Aspose.Slides for Python via .NET 的常见问题解答，涵盖 PowerPoint 和 OpenDocument 支持、安装指南、授权以及故障排除。"
---

## **受支持的文件格式**

**Q: Aspose.Slides for Python via .NET 支持哪些文件格式？**

**A**: Aspose.Slides for Python via .NET 支持在[受支持的文件格式](/slides/zh/python-net/supported-file-formats/)中描述的文件格式。

## **异常**

**Q: 在加载带有图像的大型 PPT 文件时出现内存不足异常。Aspose.Slides 对文件大小有何限制？**

**A**: 没有用于计算 Aspose.Slides 支持的演示文稿大小的具体公式。内存中应有足够的空间容纳整个演示文稿结构和图像。通常，内存中的图像占用的空间比硬盘上更大，尤其是图像具有额外效果时。

一般来说，Aspose.Slides for Python via .NET 可以在拥有 4 GB RAM 的服务器上轻松处理约 300 MB 的演示文稿文件。

## **使用幻灯片**

**Q: 我可以更改演示文稿中幻灯片的尺寸吗？**

**A**: 您可以使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类公开的 `slide_size` 属性来定义演示文稿中幻灯片的尺寸。

**Q: 在同一演示文稿中定义不同尺寸的幻灯片有办法吗？**

**A**: 由于幻灯片的尺寸在 Microsoft PowerPoint 文档中是在演示文稿级别定义的，无法实现此操作。

**Q: Aspose.Slides for Python via .NET 是否支持在保存前预览幻灯片？**

**A**: 您可以将演示文稿的幻灯片渲染为图像，并使用这些图像进行幻灯片预览。

## **使用文本**

**Q: 是否可以检索演示文稿中的所有文本？**

**A**: Aspose.Slides for Python via .NET 在 `aspose.slides.util` 命名空间下提供了 [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) 类，提供多种方法用于检索演示文稿中的完整文本。

**Q: 为什么在 Windows 和 Linux 操作系统上段落大小不同？**

**A**: 段落大小的计算基于表示给定段落的文本大小。文本大小的计算依据 PowerPoint 演示文稿中指定的字体度量。如果指定的字体缺失，则会替换为最相似的字体，但该字体的度量与原始字体不同。因此，在不同系统上计算段落大小会得到不同的结果，这取决于已安装的字体集合。要在不同操作系统上获得相同的结果，需要在系统上安装相同的字体，或者在运行时像[外部字体](/slides/zh/python-net/custom-font/)那样加载它们。

## **格式化和图像**

**Q: 如何设置表格边框的颜色？**

**A**: 您可以更改所有表格边框的颜色，也可以仅更改整个表格的外边框颜色。要更改所有边框，请使用 [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) 类的 `cell_format` 属性。要更改整个表格的外边框，需要遍历单元格并更改外部边框的颜色。

**Q: Aspose.Slides for Python via .NET 使用什么度量单位来定位图片？**

**A**: 坐标和所有形状的尺寸以点为单位（72 dpi）进行测量。

## **使用字体**

**Q: 将 PPT 转换为 PDF 或图像时，为什么输出文档中的字体不同？**

**A**: 该问题可能表明演示文稿中使用的字体在执行代码的操作系统上缺失。应在操作系统上安装这些字体，或使用 [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) 类将其作为外部字体加载，如下所示：
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```

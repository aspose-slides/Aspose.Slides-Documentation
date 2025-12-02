---
title: 常见问题
type: docs
weight: 340
url: /zh/python-net/faq/
keywords:
- 常见问题
- 演示文稿格式
- 内存不足错误
- 幻灯片大小
- 提取文本
- 检索文本
- 段落大小
- 表格格式化
- 字体
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "获取 Aspose.Slides for Python via .NET 的常见问题解答，涵盖 PowerPoint 和 OpenDocument 支持、安装指南、授权、故障排除。"
---

## **支持的文件格式**

**问：Aspose.Slides for Python via .NET 支持哪些文件格式？**
**答**: Aspose.Slides for Python via .NET 支持在[Supported File Formats](/slides/zh/python-net/supported-file-formats/)中描述的文件格式。

## **异常**

**问：在加载带有图像的大型 PPT 文件时出现内存不足异常。Aspose.Slides 对文件大小有何限制？**
**答**: 没有特定的公式来计算 Aspose.Slides 支持的演示文稿大小。内存中必须有足够的空间来容纳完整的演示文稿结构和图像。通常，内存中的图像占用的空间比硬盘上的更大，尤其是当图像具有额外效果时。

一般来说，Aspose.Slides for Python via .NET 可以在 4 GB RAM 的服务器上轻松处理约 300 MB 的演示文稿文件。

## **操作幻灯片**

**问：我可以更改演示文稿中幻灯片的大小吗？**
**答**: 您可以使用[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类公开的 `slide_size` 属性来定义演示文稿中幻灯片的大小。

**问：是否可以在同一演示文稿中定义不同大小的幻灯片？**
**答**: 由于幻灯片的大小在 Microsoft PowerPoint 文档中是以演示文稿级别定义的，无法实现此操作。

**问：Aspose.Slides for Python via .NET 是否支持在保存前预览幻灯片？**
**答**: 您可以将演示文稿幻灯片渲染为图像，并使用这些图像进行幻灯片预览。

## **操作文本**

**问：是否可以检索演示文稿中的所有文本？**
**答**: Aspose.Slides for Python via .NET 在 `aspose.slides.util` 命名空间下提供了[SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/)类，可用于检索演示文稿中的全部文本。

**问：为什么在 Windows 和 Linux 操作系统上段落大小不同？**
**答**: 段落大小的计算基于表示给定段落的文本大小。文本大小的计算依赖于 PowerPoint 演示文稿中指定字体的度量。如果指定的字体缺失，会被最相似的字体替代，但该字体的度量与原始字体不同。结果是，不同系统上段落大小的计算会因已安装的字体集合不同而产生不同的结果。要在不同操作系统上获得相同的效果，需要在各系统上安装相同的字体，或在运行时将其加载为[external fonts](/slides/zh/python-net/custom-font/)。

## **格式与图像**

**问：如何设置表格边框的颜色？**
**答**: 您可以更改所有表格边框的颜色，或仅更改整个表格的外边框。若要更改所有边框，请使用[Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)类的 `cell_format` 属性。若要更改整个表格的外边框，需要遍历单元格并更改外部边框的颜色。

**问：Aspose.Slides for Python via .NET 使用什么度量单位来定位图片？**
**答**: 幻灯片上所有形状的坐标和尺寸均以点 (points) 为单位（72 dpi）。

## **操作字体**

**问：将 PPT 转换为 PDF 或图像时，输出文档中的字体为何不同？**
**答**: 此问题可能表明演示文稿中使用的字体在运行代码的操作系统上缺失。您应在操作系统上安装这些字体，或使用下面示例中的[FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/)类将其加载为外部字体：

```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```

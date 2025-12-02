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
description: "获取 Aspose.Slides for Python via .NET 常见问题的答案，涵盖 PowerPoint 和 OpenDocument 支持、安装指南、授权、故障排除。"
---

## **受支持的文件格式**

**Q: Aspose.Slides for Python via .NET 支持哪些文件格式？**

**A**: Aspose.Slides for Python via .NET 支持在 [受支持的文件格式](/slides/zh/python-net/supported-file-formats/) 中描述的文件格式。

## **异常**

**Q: 在加载包含图像的大型 PPT 文件时，我收到内存不足异常。Aspose.Slides 对文件大小有何限制？**

**A**: Aspose.Slides 没有用于计算支持的演示文稿大小的特定公式。内存中应有足够的空间来容纳整个演示文稿结构和图像。通常，内存中的图像占用的空间比硬盘上的更大，尤其是当图像具有额外效果时。

一般而言，Aspose.Slides for Python via .NET 可以在配备 4 GB RAM 的服务器上轻松处理约 300 MB 的演示文稿文件。

## **使用幻灯片**

**Q: 我可以更改演示文稿中幻灯片的尺寸吗？**

**A**: 您可以使用由 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类公开的 `slide_size` 属性来定义演示文稿中幻灯片的尺寸。

**Q: 在同一演示文稿中是否可以定义尺寸不同的幻灯片？**

**A**: 由于在 Microsoft PowerPoint 文档中，幻灯片的尺寸是在演示文稿级别定义的，因此无法实现此操作。

**Q: Aspose.Slides for Python via .NET 是否支持在保存之前预览幻灯片？**

**A**: 您可以将演示文稿幻灯片渲染为图像，并使用这些图像进行幻灯片预览。

## **使用文本**

**Q: 是否可以检索演示文稿中的所有文本？**

**A**: Aspose.Slides for Python via .NET 在 `aspose.slides.util` 命名空间下提供了 [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) 类，提供了多种检索演示文稿整体文本的方法。

**Q: 为什么在 Windows 和 Linux 操作系统上段落大小不同？**

**A**: 段落大小的计算基于表示给定段落的文本尺寸计算。文本尺寸的计算依赖于 PowerPoint 演示文稿中指定字体的度量。如果指定的字体缺失，系统会使用最相似的字体进行替代，但该字体的度量与原始字体不同。于是，在不同系统上进行段落大小计算时，由于已安装字体集合不同，结果会有所差异。要在不同操作系统上获得相同的结果，需要在各系统上安装相同的字体，或在运行时将其加载为 [外部字体](/slides/zh/python-net/custom-font/)。

## **格式化与图像**

**Q: 如何设置表格边框的颜色？**

**A**: 您可以更改所有表格边框的颜色，或仅更改整个表格周围的边框颜色。若要更改所有边框，请使用来自 [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) 类的 `cell_format` 属性。若要更改整个表格的边框，您应遍历单元格并更改外边框的颜色。

**Q: Aspose.Slides for Python via .NET 使用什么度量单位来放置图片？**

**A**: 幻灯片上所有形状的坐标和尺寸均以点（72 dpi）为单位进行度量。

## **使用字体**

**Q: 将 PPT 转换为 PDF 或图像时，输出文档中的字体为何不同？**

**A**: 此问题可能表明演示文稿中使用的字体在执行代码的操作系统上缺失。您应在操作系统上安装这些字体，或使用 [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) 类将其作为外部字体加载，如下所示：
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```

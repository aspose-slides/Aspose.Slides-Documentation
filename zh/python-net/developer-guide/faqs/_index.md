---
title: 常见问题解答
type: docs
weight: 340
url: /zh/python-net/faqs/
keywords:
- 常见问题
- PowerPoint
- 演示文稿格式
- 内存不足错误
- 幻灯片大小
- 提取文本
- 取回文本
- 段落大小
- 格式化表格
- 字体
- Python
- Aspose.Slides for Python via .NET
---

## **支持的文件格式**

**问：Aspose.Slides for Python via .NET 支持哪些文件格式？**

**答**：Aspose.Slides for Python via .NET 支持 [支持的文件格式](/slides/zh/python-net/supported-file-formats/) 中描述的文件格式。

## **异常**

**问：在加载带有图像的大型 PPT 文件时，我遇到了内存不足异常。Aspose.Slides 在文件大小上有任何限制吗？**

**答**：没有专门的公式来计算 Aspose.Slides 支持的演示文稿大小。应有足够的空间来容纳整个演示文稿结构和图像在内存中。通常，内存中的图像占用的空间比硬盘更大，特别是当图像具有额外效果时。

一般来说，Aspose.Slides for Python via .NET 可以轻松处理大约 300 MB 的演示文稿文件，前提是服务器有 4 GB RAM。

## **处理幻灯片**

**问：我可以更改演示文稿中幻灯片的大小吗？**

**答**：您可以使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类暴露的 `slide_size` 属性来定义演示文稿中幻灯片的大小。

**问：有什么方法可以在演示文稿中定义不同大小的幻灯片吗？**

**答**：由于幻灯片的大小是在 Microsoft PowerPoint 文档的演示文稿级别定义的，因此没有办法做到这一点。

**问：Aspose.Slides for Python via .NET 支持在保存之前预览幻灯片吗？**

**答**：您可以将演示文稿幻灯片渲染为图像，并可以使用这些图像预览幻灯片。

## **处理文本**

**问：是否可以从演示文稿中检索所有文本？**

**答**：Aspose.Slides for Python via .NET 提供 `aspose.slides.util` 命名空间下的 [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) 类，该类提供多种方法来检索演示文稿中的全部文本。

**问：为什么 Windows 和 Linux 操作系统上的段落大小不同？**

**答**：段落大小的计算是基于表示给定段落的文本大小的计算。文本大小的计算基于 PowerPoint 演示文稿中指定字体的度量。如果指定的字体缺失，它将被替换为最相似的字体，但该字体的度量与原始字体不同。因此，不同系统中段落大小的计算将导致不同的结果，具体取决于安装的字体集合。要在不同操作系统上实现相同的结果，您需要在系统上安装相同的字体，或者像 [外部字体](/slides/zh/python-net/custom-font/) 一样在运行时加载它们。

## **格式化和图像**

**问：我如何设置表格边框的颜色？**

**答**：您可以更改所有表格边框的颜色或仅更改整个表格周围的边框颜色。要更改所有边框，请使用 [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) 类中的 `cell_format` 属性。对于整个表格的边框，您应该遍历单元格并更改外边框的颜色。

**问：Aspose.Slides for Python via .NET 使用什么度量来放置图片？**

**答**：幻灯片上所有形状的坐标和大小以点（72 dpi）为单位进行测量。

## **处理字体**

**问：在将 PPT 转换为 PDF 或图像时，为什么输出文档中的字体不同？**

**答**：此问题可能表明在执行代码的操作系统中，演示文稿中使用的字体缺失。您应该在操作系统中安装这些字体，或者像外部字体一样使用 [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) 类加载它们，示例如下：
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```
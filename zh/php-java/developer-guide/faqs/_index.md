---
title: 常见问题解答
type: docs
weight: 340
url: /php-java/faqs/
keywords:
- 常见问题
- PowerPoint
- 演示文稿格式
- 内存不足错误
- 幻灯片大小
- 提取文本
- 检索文本
- 段落大小
- 格式化表格
- 字体
- PHP
- Java
- Aspose.Slides for PHP via Java
---

## **支持的文件格式**

**问：Aspose.Slides for PHP via Java 支持什么文件格式？**

**答**：Aspose.Slides for PHP via Java 支持在 [支持的文件格式](/slides/php-java/supported-file-formats/) 中描述的文件格式。

## **异常**

**问：在加载一个大型包含图像的 PPT 文件时，我遇到了内存不足的异常。Aspose.Slides 对文件大小有限制吗？**

**答**：没有特定的公式来计算 Aspose.Slides 支持的演示文稿大小。内存中应该有足够的空间来容纳整个演示文稿结构和图像。通常，内存中的图像占用的空间比硬盘要大，尤其是当图像有额外效果时。

一般来说，Aspose.Slides for PHP via Java 可以轻松处理在 4 GB RAM 的服务器上约 300 MB 的演示文稿文件。

## **处理幻灯片**

**问：我可以更改演示文稿中幻灯片的大小吗？**

**答**：您可以使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类公开的 `getSlideSize` 方法来定义演示文稿中幻灯片的大小。

**问：有没有办法在演示文稿中定义不同大小的幻灯片？**

**答**：由于幻灯片的大小是在 Microsoft PowerPoint 文档的演示文稿级别定义的，因此没有办法做到这一点。

**问：Aspose.Slides for PHP via Java 支持在保存之前预览幻灯片吗？**

**答**：您可以将演示文稿幻灯片呈现为图像，并可以使用这些图像来预览幻灯片。

## **处理文本**

**问：是否可以从演示文稿中检索所有文本？**

**答**：Aspose.Slides for PHP via Java 提供了 [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/) 类，该类提供了从演示文稿中检索全部文本的各种方法。

**问：为什么在 Windows 和 Linux 操作系统上段落大小不同？**

**答**：段落大小的计算是基于表示给定段落的文本大小的计算。文本大小的计算是基于在 PowerPoint 演示文稿中指定的字体的度量。如果指定的字体缺失，则用最相似的字体替换，但此字体的度量与原始字体不同。因此，不同系统中段落大小的计算将导致不同的结果，具体取决于已安装字体的集合。要在不同操作系统上获得相同的结果，您需要在系统上安装相同的字体或将其作为 [外部字体](/slides/php-java/custom-font/) 在运行时加载。

## **格式化和图像**

**问：如何设置表格边框的颜色？**

**答**：您可以更改所有表格边框的颜色或仅更改整个表格周围的边框颜色。要更改所有边框，请使用 [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) 类中的 `getCellFormat` 方法。对于整个表格的边框，您应该遍历单元格并更改外边框的颜色。

**问：Aspose.Slides for PHP via Java 使用什么测量单位来放置图像？**

**答**：幻灯片上所有形状的坐标和大小以点为单位（72 dpi）进行测量。

## **处理字体**

**问：在将 PPT 转换为 PDF 或图像时，为什么输出文档中的字体不同？**

**答**：此问题可能表明演示文稿中使用的字体在执行代码的操作系统中缺失。您应该在操作系统上安装字体或使用 [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) 类将其作为外部字体加载，如下所示：
```cs
$folders = ["path_to_a_folder_with_fonts"];
FontsLoader::loadExternalFonts($folders);
```
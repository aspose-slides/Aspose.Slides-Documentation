---
title: 常见问题解答
type: docs
weight: 340
url: /androidjava/faqs/
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
- Android
- Java
- Aspose.Slides for Android via Java
---

## **支持的文件格式**

**问：Aspose.Slides for Android via Java 支持哪些文件格式？**

**答**：Aspose.Slides for Android via Java 支持在 [支持的文件格式](/slides/androidjava/supported-file-formats/) 中描述的文件格式。

## **异常**

**问：在加载带图像的大型 PPT 文件时，我遇到了内存不足的异常。Aspose.Slides 对文件大小有任何限制吗？**

**答**：没有具体的公式来计算 Aspose.Slides 支持的演示文稿大小。内存中必须有足够的空间来容纳整个演示文稿结构和图像。通常情况下，内存中的图像占用的空间比硬盘大，尤其是当图像具有附加效果时。

一般来说，在 4 GB RAM 的服务器上，Aspose.Slides for Android via Java 可以轻松处理约 300 MB 的演示文稿文件。

## **处理幻灯片**

**问：我可以更改演示文稿中幻灯片的大小吗？**

**答**：您可以使用 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类提供的 `getSlideSize` 方法来定义演示文稿中幻灯片的大小。

**问：有没有方法可以在演示文稿中定义不同大小的幻灯片？**

**答**：由于幻灯片的大小是在 Microsoft PowerPoint 文档的演示文稿级别定义的，因此没有方法可以这样做。

**问：Aspose.Slides for Android via Java 是否支持在保存之前预览幻灯片？**

**答**：您可以将演示文稿幻灯片呈现为图像，并可以使用这些图像来预览幻灯片。

## **处理文本**

**问：是否可以从演示文稿中提取所有文本？**

**答**：Aspose.Slides for Android via Java 提供了 [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideutil/) 类，该类提供了多种方法用于从演示文稿中提取完整的文本。

**问：为什么 PC 和 Android 上段落大小不同？**

**答**：段落大小的计算基于表示给定段落的文本大小的计算。文本大小的计算是基于 PowerPoint 演示文稿中指定的字体的指标。如果指定的字体丢失，它将被替换为最相似的字体，但该字体的指标与原始字体不同。因此，不同系统中段落大小的计算将导致不同的结果，具体取决于已安装字体的集合。要在不同操作系统上实现相同的结果，您需要在系统上安装相同的字体或在运行时将其加载为 [外部字体](/slides/androidjava/custom-font/)。

## **格式化和图像**

**问：如何设置表格边框的颜色？**

**答**：您可以更改所有表格边框的颜色或仅更改围绕整个表格的边框颜色。要更改所有边框，请使用 [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) 接口中的 `getCellFormat` 方法。对于整个表格的边框，您应迭代单元格并更改外边框的颜色。

**问：Aspose.Slides for Android via Java 使用什么度量来放置图片？**

**答**：幻灯片上所有形状的坐标和大小以点为单位测量（72 dpi）。

## **处理字体**

**问：在将 PPT 转换为 PDF 或图像时，为什么输出文档中的字体不同？**

**答**：这个问题可能表明演示文稿中使用的字体在执行代码的操作系统中缺失。您应该在操作系统上安装字体，或者使用 [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) 类将其加载为外部字体，如下所示：
```java
String[] folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```
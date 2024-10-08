---
title: 常见问题解答
type: docs
weight: 340
url: /zh/cpp/faqs/
keywords:
- 常见问题
- PowerPoint
- 演示文稿格式
- 内存溢出异常
- 幻灯片大小
- 提取文本
- 检索文本
- 段落大小
- 格式化表格
- 字体
- С++
- Aspose.Slides for С++
---

## **支持的文件格式**

**Q: Aspose.Slides for C++ 支持哪些文件格式？**

**A**: Aspose.Slides for C++ 支持在 [支持的文件格式](/slides/zh/cpp/supported-file-formats/) 中描述的文件格式。

## **异常**

**Q: 在加载一个带有图片的大型 PPT 文件时，我遇到了内存溢出异常。Aspose.Slides 对文件大小有有限制吗？**

**A**: Aspose.Slides 对演示文稿大小的支持没有具体的计算公式。内存中必须有足够的空间来容纳整个演示文稿结构和图片。通常，内存中的图片占用的空间大于硬盘，尤其是在图片有额外效果时。

一般来说，Aspose.Slides for C++ 可以在拥有 4 GB RAM 的服务器上轻松处理约 300 MB 的演示文稿文件。

## **幻灯片操作**

**Q: 我可以改变演示文稿中幻灯片的大小吗？**

**A**: 您可以使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类暴露的 `get_SlideSize` 方法来定义演示文稿中幻灯片的大小。

**Q: 有没有办法在演示文稿中定义不同大小的幻灯片？**

**A**: 由于幻灯片的大小是在 Microsoft PowerPoint 文档的演示文稿级别定义的，因此没有办法这样做。

**Q: Aspose.Slides for C++ 是否支持在保存之前预览幻灯片？**

**A**: 您可以将演示文稿的幻灯片渲染为图片，并可以使用这些图片来预览幻灯片。

## **文本操作**

**Q: 是否可以检索演示文稿中的所有文本？**

**A**: Aspose.Slides for C++ 提供了 `Aspose::Slides::Util` 命名空间下的 [SlideUtil](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/) 类，该类提供了多种方法来检索演示文稿中的所有文本。

**Q: 为什么在 Windows 和 Linux 操作系统上的段落大小不同？**

**A**: 段落大小的计算是基于表示给定段落的文本大小的计算。文本大小的计算是基于 PowerPoint 演示文稿中指定字体的度量。如果指定的字体缺失，它会被替换为最相似的字体，但该字体的度量与原来的不同。因此，不同系统中的段落大小计算将导致不同的结果，具体取决于已安装字体的组合。要在不同操作系统上获得相同的结果，您需要在系统上安装相同的字体或在运行时将其作为 [外部字体](/slides/zh/cpp/custom-font/) 加载。

## **格式化和图像**

**Q: 如何设置表格边框的颜色？**

**A**: 您可以更改所有表格边框的颜色或仅更改整个表格周围的边框颜色。要更改所有边框，请使用 [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) 接口中的 `get_CellFormat` 方法。对于整个表格的边框，您应该遍历单元格并更改外部边框的颜色。

**Q: Aspose.Slides for C++ 使用什么度量来放置图片？**

**A**: 幻灯片上所有形状的坐标和大小是以点为单位测量的（72 dpi）。

## **字体操作**

**Q: 在将 PPT 转换为 PDF 或图像时，为什么输出文档中的字体不同？**

**A**: 此问题可能表明演示文稿中使用的字体在执行代码的操作系统上缺失。您应该在操作系统上安装字体或使用 [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) 类将其作为外部字体加载，如下所示：
```cpp
auto folders = MakeObject<Array<String>>(1, "path_to_a_folder_with_fonts");
FontsLoader::LoadExternalFonts(folders);
```
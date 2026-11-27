---
title: 压缩演示文稿
description: 通过压缩图像和删除未使用的内容来减小演示文稿大小。
type: docs
url: /zh/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **概述**

压缩图片，在不再需要时删除已裁剪的图像区域，并在保存之前选择演示文稿的压缩设置。这对包含大量照片或重复媒体的幻灯片非常有用。节省的数量取决于您选择的内容和设置。

## **使用示例**

此 C# 示例加载 `input.pptx`，压缩演示文稿，并将其保存为 `compressed.pptx`。

使用 Aspose.Slides for .NET 26.11 或更高版本。有关设置，请参阅[安装 Aspose.Slides for .NET](/slides/zh/net/installation/)。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```


<!-- visual-explanation:compress-presentations:start -->
[![压缩前后相同比例的图片渲染，随后显示测量的 PPTX 文件大小条和存储的图像尺寸。](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*在一个合成细节网格装置上测量：584,030 → 128,323 字节。两个渲染使用相同的比例和 252 × 336 点的框架。压缩去除裁剪的边距，并将存储的图像降至 525 × 700 像素；节省的大小取决于输入。*
<!-- visual-explanation:compress-presentations:end -->

## **常见问题**

### **这是一键式的整文件优化开关吗？**

Aspose.Slides for .NET 26.11 添加了 [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/)，它结合了未使用的布局/母版删除、嵌入字体子集化以及 150 DPI 的图片压缩。它会永久删除裁剪的图片区域。针对仅图片处理，请使用 [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/)；如需更细粒度的控制，请参阅[单独图片压缩示例](/slides/zh/net/examples/optimization-batch/compression/)。自 26.11 版起，同样的整演示调用也在 Java、通过 Java 的 Node.js、通过 .NET 的 Python 和 C++ 中可用。本示例以及本页的链接均针对 .NET。

### **图片压缩会更改可编辑的文本或图表吗？**

图片压缩针对的是图片数据，而非可编辑的文本或图表数据。请检查图像，因为调整大小或重新压缩可能会降低其细节。

### **我应该如何为演示文稿图像选择分辨率？**

根据显示的图片尺寸以及预期的屏幕或打印用途来确定目标分辨率。对大屏幕、打印和详细图表保留更高分辨率，并在丢弃原始文件前比较渲染输出。

## **指南**

- [在 .NET 中压缩整个演示文稿](/slides/zh/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [在 .NET 中优化演示文稿的图像管理](/slides/zh/net/image/)

相关功能：[移除未使用的母版、布局和媒体](/slides/zh/features/remove-unused-content/).

## 可运行的 .NET 示例

- [减小演示文稿大小](/slides/zh/net/examples/optimization-batch/compression/)
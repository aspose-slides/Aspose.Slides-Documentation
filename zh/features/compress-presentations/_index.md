---
title: 压缩演示文稿
description: 通过压缩图像和删除未使用的内容来减小演示文稿的大小。
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

压缩图片，在不再需要时移除已裁剪的图像区域，并在保存前选择演示文稿的压缩设置。这对于包含大量照片或重复媒体的幻灯片文稿非常有用。节省的数量取决于您的内容和所选设置。

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

## **常见问题**

### **这是一个单一的全文件优化开关吗？**

Aspose.Slides for .NET 26.11 添加了 [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/)，它将未使用的布局/母版删除、嵌入字体子集化和 150 DPI 图片压缩结合在一起。它会永久删除已裁剪的图片区域。仅处理图片时，请使用 [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/)；如需更精细的控制，请参阅[单张图片压缩示例](/slides/zh/net/examples/optimization-batch/compression/)。这些新帮助程序特定于所述的 .NET 版本；请查阅其他 SDK 的相应指南。

### **图片压缩会更改可编辑的文本或图表吗？**

图片压缩针对图片数据，而不是可编辑的文本或图表数据。请检查图片，因为重新调整大小或重新压缩可能会降低其细节。

### **我应该如何为演示文稿图片选择分辨率？**

根据显示的图片尺寸以及预期的屏幕或打印用途选择目标分辨率。对大屏幕、打印和细节图表保留更高的分辨率，并在舍弃原始文件前比较渲染结果。

## **指南**

- [在 .NET 中压缩整个演示文稿](/slides/zh/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [在 .NET 中优化演示文稿的图像管理](/slides/zh/net/image/)

相关功能：[删除未使用的母版、布局和媒体](/slides/zh/features/remove-unused-content/)。

## 可运行的 .NET 示例

- [减小演示文稿大小](/slides/zh/net/examples/optimization-batch/compression/)
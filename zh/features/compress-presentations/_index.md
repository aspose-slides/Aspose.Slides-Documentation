---
title: 压缩演示文稿
description: 使用图像压缩和保存设置来减小演示文稿大小。
type: docs
url: /zh/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **概述**

压缩图片，在不再需要时删除裁剪的图像区域，并在保存前选择演示文稿的压缩设置。这对于包含大量照片或重复媒体的幻灯片组非常有用。节省的量取决于您选择的内容和设置。

## **使用示例**

此 C# 示例使用 Aspose.Slides for .NET。它可视化地生成一个 1600 × 900 像素的渐变 PNG，将其插入一个小图片框中，并保存为 *before.pptx*。随后将该图片压缩至 96 DPI 的目标分辨率并保存为 *compressed.pptx*。比较两个文件的大小和预览：节省取决于输入图片和显示尺寸。For setup, see [安装 Aspose.Slides for .NET](/slides/zh/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **常见问题**

### **这是一个单文件整体优化开关吗？**

Aspose.Slides for .NET 26.11 添加了 [Compress.CompressPresentation](/slides/zh/net/low-code-presentation-operations/#compress-the-whole-presentation)，该功能结合了未使用的布局/母版删除、嵌入字体子集化和 150 DPI 图片压缩。它会永久删除已裁剪的图片区域。仅处理图片时，请使用 Compress.CompressImages；如需更精细的控制，保留上述按图片的工作流。这些新助手特定于上述 .NET 版本；请查阅相应指南以获取其他 SDK 的信息。

### **图像压缩会改变可编辑文本或图表吗？**

图片压缩针对图片数据，而非可编辑的文本或图表数据。请检查图像，因为重新调整大小或再次压缩可能会降低其细节。

### **我应该如何为演示文稿图像选择分辨率？**

根据显示的图片尺寸以及预期的屏幕或打印用途选择目标分辨率。对大屏幕、打印和细节图表保留更高分辨率，并在丢弃原始文件前比较渲染后的输出。

## **指南**

- [在 .NET 中优化演示文稿的图像管理](/slides/zh/net/image/)

Related feature: [移除未使用的母版、布局和媒体](/slides/zh/features/remove-unused-content/).

## 可运行的 .NET 示例

- [减小演示文稿大小](/slides/zh/net/examples/optimization-batch/compression/)
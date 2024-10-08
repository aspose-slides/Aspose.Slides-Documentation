---
title: 创建形状缩略图
type: docs
weight: 70
url: /net/create-shape-thumbnails/
keywords: 
- 形状缩略图
- 形状图像
- PowerPoint
- 演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: "从 PowerPoint 演示文稿中提取形状缩略图，使用 C# 或 .NET"
---

Aspose.Slides for .NET 用于创建演示文稿文件，其中每一页是一个幻灯片。这些幻灯片可以通过使用 Microsoft PowerPoint 打开演示文稿文件来查看。但是有时，开发人员可能需要在图像查看器中单独查看形状的图像。在这种情况下，Aspose.Slides for .NET 可以帮助您生成幻灯片形状的缩略图。如何使用此功能在本文中进行描述。
本文解释了如何以不同方式生成幻灯片缩略图：

- 在幻灯片内生成形状缩略图。
- 为具有用户定义维度的幻灯片形状生成形状缩略图。
- 在形状外观的边界内生成形状缩略图。
- 生成 SmartArt 子节点的缩略图。

## **从幻灯片生成形状缩略图**
要使用 Aspose.Slides for .NET 从任何幻灯片生成形状缩略图：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用其 ID 或索引获取任何幻灯片的引用。
1. 获取引用幻灯片的形状缩略图图像，使用默认缩放。
1. 将缩略图图像保存为所需的任何图像格式。

下面的示例生成形状缩略图。

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **生成用户定义缩放因子缩略图**
要使用 Aspose.Slides for .NET 生成任何幻灯片形状的形状缩略图：

1. 创建 `Presentation` 类的实例。
1. 使用其 ID 或索引获取任何幻灯片的引用。
1. 获取引用幻灯片的形状边界的缩略图图像。
1. 将缩略图图像保存为所需的任何图像格式。

下面的示例生成具有用户定义缩放因子的缩略图。

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // 在 X 和 Y 轴上的缩放。

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **创建形状外观的边界缩略图**
此创建形状缩略图的方法允许开发人员在形状外观的边界内生成缩略图。它考虑了所有的形状效果。生成的形状缩略图受到幻灯片边界的限制。要在形状外观的边界内生成任何幻灯片形状的缩略图，请使用以下示例代码：

1. 创建 `Presentation` 类的实例。
1. 使用其 ID 或索引获取任何幻灯片的引用。
1. 获取引用幻灯片的形状边界作为外观的缩略图图像。
1. 将缩略图图像保存为所需的任何图像格式。

下面的示例生成具有用户定义缩放因子的缩略图。

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // 在 X 和 Y 轴上的缩放。

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```
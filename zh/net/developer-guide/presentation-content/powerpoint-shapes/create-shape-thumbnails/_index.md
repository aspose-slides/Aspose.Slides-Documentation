---
title: 在 .NET 中创建演示文稿形状的缩略图
linktitle: 形状缩略图
type: docs
weight: 70
url: /zh/net/create-shape-thumbnails/
keywords:
- 形状缩略图
- 形状图像
- 渲染形状
- 形状渲染
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 从 PowerPoint 幻灯片生成高质量的形状缩略图 – 轻松创建并导出演示文稿缩略图。"
---

Aspose.Slides for .NET 用于创建演示文稿文件，每页即为幻灯片。这些幻灯片可以通过 Microsoft PowerPoint 打开进行查看。但有时，开发人员可能需要在图像查看器中单独查看形状的图像。在这种情况下，Aspose.Slides for .NET 可帮助您生成幻灯片形状的缩略图。本文介绍了如何使用此功能。

本文说明了以不同方式生成幻灯片缩略图：

- 在幻灯片内部生成形状缩略图。
- 使用用户定义的尺寸为幻灯片形状生成形状缩略图。
- 在形状外观的边界内生成形状缩略图。
- 为 SmartArt 子节点生成缩略图。


## **从幻灯片生成形状缩略图**
使用 Aspose.Slides for .NET 从任意幻灯片生成形状缩略图：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用其 ID 或索引获取任意幻灯片的引用。
1. 获取所引用幻灯片的默认比例形状缩略图图像。
1. 将缩略图图像保存为任意所需的图像格式。

下面的示例演示了生成形状缩略图。
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



## **生成用户定义缩放因子的缩略图**
使用 Aspose.Slides for .NET 为任意幻灯片形状生成形状缩略图：

1. 创建 `Presentation` 类的实例。
1. 使用其 ID 或索引获取任意幻灯片的引用。
1. 获取带有形状边界的所引用幻灯片的缩略图图像。
1. 将缩略图图像保存为任意所需的图像格式。

下面的示例演示了使用用户定义的缩放因子生成缩略图。
```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // 沿 X 和 Y 轴的缩放。

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```



## **创建基于边界的形状外观缩略图**
此方法用于创建形状缩略图，允许开发人员在形状外观的边界内生成缩略图。它考虑了所有形状效果。生成的形状缩略图受幻灯片边界限制。要在形状外观的边界内为任意幻灯片形状生成缩略图，请使用以下示例代码：

1. 创建 `Presentation` 类的实例。
1. 使用其 ID 或索引获取任意幻灯片的引用。
1. 获取以外观形式的形状边界的所引用幻灯片的缩略图图像。
1. 将缩略图图像保存为任意所需的图像格式。

下面的示例演示了创建基于边界的形状外观缩略图。
```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // 沿 X 和 Y 轴的缩放。

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```


## **常见问题**

**保存形状缩略图时可以使用哪些图像格式？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)，以及其他格式。形状也可以通过将形状内容保存为 SVG 来[导出为矢量 SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)。

**在渲染缩略图时，Shape 与 Appearance 边界有什么区别？**

`Shape` 使用形状的几何信息；`Appearance` 会考虑[视觉效果](/slides/zh/net/shape-effect/)(阴影、光晕等)。

**如果形状被标记为隐藏，会怎样？它仍会渲染为缩略图吗？**

隐藏的形状仍然是模型的一部分且可以渲染；隐藏标记仅影响幻灯片放映的显示，但不会阻止生成形状的图像。

**是否支持组形状、图表、SmartArt 和其他复杂对象？**

是的。任何以[Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/)表示的对象（包括[GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/)和[SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)）都可以保存为缩略图或 SVG。

**系统已安装的字体会影响文本形状缩略图的质量吗？**

会。您应当[提供所需的字体](/slides/zh/net/custom-font/)（或[配置字体替代](/slides/zh/net/font-substitution/)），以避免不必要的回退和文本重排。
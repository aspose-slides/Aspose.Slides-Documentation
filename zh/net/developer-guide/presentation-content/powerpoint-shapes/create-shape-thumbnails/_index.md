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
description: "使用 Aspose.Slides for .NET 从 PowerPoint 幻灯片生成高质量的形状缩略图——轻松创建和导出演示文稿缩略图。"
---

Aspose.Slides for .NET 用于创建每页为幻灯片的演示文稿文件。这些幻灯片可以通过 Microsoft PowerPoint 打开进行查看。但有时，开发人员可能需要在图像查看器中单独查看形状的图像。此时，Aspose.Slides for .NET 可帮助生成幻灯片形状的缩略图。本文介绍了如何使用此功能。

本文说明了以不同方式生成幻灯片缩略图的方法：

- 在幻灯片中生成形状缩略图。
- 为幻灯片形状生成具有用户自定义尺寸的缩略图。
- 在形状外观的边界内生成形状缩略图。
- 为 SmartArt 子节点生成缩略图。

## **从幻灯片生成形状缩略图**
要使用 Aspose.Slides for .NET 从任意幻灯片生成形状缩略图：

1. 创建 `Presentation` 类的实例。
1. 使用 ID 或索引获取任意幻灯片的引用。
1. 获取引用幻灯片上默认比例的形状缩略图图像。
1. 将缩略图图像保存为任意所需的图像格式。

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
要使用 Aspose.Slides for .NET 为任意幻灯片形状生成缩略图：

1. 创建 `Presentation` 类的实例。
1. 使用 ID 或索引获取任意幻灯片的引用。
1. 获取带有形状边界的引用幻灯片的缩略图图像。
1. 将缩略图图像保存为任意所需的图像格式。

下面的示例生成带有用户定义缩放因子的缩略图。
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


## **创建形状外观边界缩略图**
此方法用于创建形状缩略图，允许开发人员在形状外观的边界内生成缩略图。它会考虑所有形状效果。生成的形状缩略图受幻灯片边界限制。要在形状外观边界内生成任意幻灯片形状的缩略图，请使用以下示例代码：

1. 创建 `Presentation` 类的实例。
1. 使用 ID 或索引获取任意幻灯片的引用。
1. 获取带有外观边界的引用幻灯片的缩略图图像。
1. 将缩略图图像保存为任意所需的图像格式。

下面的示例创建了带有用户定义缩放因子的缩略图。
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


## **FAQ**

**保存形状缩略图时可以使用哪些图像格式？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)，以及其他格式。形状还可以通过将形状内容保存为 SVG 来[导出为矢量 SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)。

**在渲染缩略图时，Shape 边界和 Appearance 边界有什么区别？**

`Shape` 使用形状的几何边界；`Appearance` 会考虑[视觉效果](/slides/zh/net/shape-effect/)（阴影、发光等）。

**如果形状被标记为隐藏，会仍然生成缩略图吗？**

隐藏的形状仍然是模型的一部分，可以渲染；隐藏标记仅影响幻灯片放映显示，不会阻止生成该形状的图像。

**是否支持组形状、图表、SmartArt 以及其他复杂对象？**

支持。任何作为[Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/)表示的对象（包括[GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/)、以及[SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)）均可保存为缩略图或 SVG。

**系统安装的字体会影响文本形状缩略图的质量吗？**

会。应当[提供所需字体](/slides/zh/net/custom-font/)（或[配置字体替代](/slides/zh/net/font-substitution/)），以避免不必要的回退和文本重排。
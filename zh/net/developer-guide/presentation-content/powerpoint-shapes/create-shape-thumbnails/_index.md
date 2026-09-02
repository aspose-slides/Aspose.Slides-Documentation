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
- 可视边界
- 形状边界
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 从 PowerPoint 幻灯片生成高质量的形状缩略图 —— 轻松创建和导出演示文稿缩略图。"
---
## **简介**

Aspose.Slides for .NET 用于创建每页都是幻灯片的演示文稿文件。可以通过 Microsoft PowerPoint 打开这些演示文稿文件进行查看。但有时，开发人员可能需要在图像查看器中单独查看形状的图像。在这种情况下，Aspose.Slides for .NET 可以帮助您生成幻灯片形状的缩略图。本文档描述了如何使用此功能。
本文解释了以不同方式生成幻灯片缩略图的方法：

- 在幻灯片内生成形状缩略图。
- 为幻灯片形状生成具有用户定义尺寸的缩略图。
- 在形状外观的边界内生成形状缩略图。

## **从幻灯片生成形状缩略图**
要使用 Aspose.Slides for .NET 从任意幻灯片生成形状缩略图：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。
1. 使用其 ID 或索引获取任意幻灯片的引用。
1. 获取所引用幻灯片的形状缩略图（默认比例）。
1. 将缩略图保存为任意所需的图像格式。

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

## **生成用户定义缩放因子的缩略图**
要使用 Aspose.Slides for .NET 为任意幻灯片形状生成形状缩略图：

1. 创建一个 `Presentation` 类的实例。
1. 使用其 ID 或索引获取任意幻灯片的引用。
1. 获取所引用幻灯片带有形状边界的缩略图。
1. 将缩略图保存为任意所需的图像格式。

下面的示例使用用户定义的缩放因子生成缩略图。

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
此方法允许开发人员在形状外观的边界内生成缩略图。它会考虑所有形状效果。生成的形状缩略图受幻灯片边界限制。要在外观边界内生成任意幻灯片形状的缩略图，请使用以下示例代码：

1. 创建一个 `Presentation` 类的实例。
1. 使用其 ID 或索引获取任意幻灯片的引用。
1. 获取所引用幻灯片的缩略图，使用形状边界作为外观。
1. 将缩略图保存为任意所需的图像格式。

下面的示例创建基于外观的缩略图。

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

## **获取形状的实际可视边界**

[IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/) 的框架属性——其 `X`、`Y`、`Width` 和 `Height` 属性——描述了存储在演示文稿模型中的矩形。实际渲染的内容可能会超出该框架或占据不同的轴对齐矩形。旋转、轮廓、箭头、文字布局与溢出、生成的 SmartArt 几何以及其他渲染效果都可能改变占用的区域。

使用 [GetVisualBounds](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/getvisualbounds/) 可在不创建图像的情况下计算该占用区域。该方法返回一个以幻灯片坐标表示的 [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef)。返回的矩形不会被裁剪到幻灯片内，因此当内容超出幻灯片原点时，其坐标可能为负。

[GetVisualBounds](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/getvisualbounds/) 目前并未在 [IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/) 接口中声明。因此，请将从幻灯片形状集合中获取的形状保留为接口值，并仅在调用该方法时进行强制转换。

下面的示例获取并比较框架和可视边界：

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

相同的 [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) 可用于将相邻形状对齐到其 `Left`、`Right`、`Top` 或 `Bottom` 边缘；在生成的布局中预留足够空间；或检测超出允许区域的内容。可视边界对 SmartArt、文本框、箭头、图片、旋转形状和组合形状尤其有用，因为存储的框架可能并未表示完整的渲染结果。

当您需要布局或验证的坐标且不需要位图时，请使用 [GetVisualBounds](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/getvisualbounds/)。当需要渲染形状时，请使用 [IShape.GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/getimage/)。使用 [ShapeThumbnailBounds](https://reference.aspose.com/slides/zh/net/aspose.slides/shapethumbnailbounds/)，`ShapeThumbnailBounds.Shape` 根据形状边界（包括轮廓设置）调整图像大小，而 `ShapeThumbnailBounds.Appearance` 根据形状的外观调整大小并将结果限制在幻灯片边界内。相比之下，[GetVisualBounds](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/getvisualbounds/) 仅返回计算得到的矩形且不裁剪到幻灯片。

## **FAQ**

**保存形状缩略图时可以使用哪些图像格式？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/zh/net/aspose.slides/imageformat/)，以及其他格式。形状也可以通过将形状内容保存为 SVG 来 [exported as vector SVG](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/writeassvg/)。

**在渲染缩略图时，Shape 边界与 Appearance 边界有何区别？**

`Shape` 使用形状的几何；`Appearance` 会考虑 [visual effects](/slides/zh/net/shape-effect/)（阴影、辉光等）。

**如果形状被标记为隐藏会怎样？它仍会渲染为缩略图吗？**

隐藏的形状仍然是模型的一部分并且可以渲染；隐藏标记只影响放映显示，不会阻止生成形状图像。

**是否支持组合形状、图表、SmartArt 和其他复杂对象？**

是的。任何表示为 [Shape](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/) 的对象（包括 [GroupShape](https://reference.aspose.com/slides/zh/net/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/chart/) 和 [SmartArt](https://reference.aspose.com/slides/zh/net/aspose.slides.smartart/smartart/)）都可以保存为缩略图或 SVG。

**系统安装的字体会影响文本形状缩略图的质量吗？**

会。您应当 [provide the required fonts](/slides/zh/net/custom-font/)（或 [configure font substitutions](/slides/zh/net/font-substitution/)）以避免不必要的回退和文本重新换行。
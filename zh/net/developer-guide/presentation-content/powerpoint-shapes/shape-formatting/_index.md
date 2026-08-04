---
title: 在 .NET 中格式化 PowerPoint 形状
linktitle: 形状格式化
type: docs
weight: 20
url: /zh/net/shape-formatting/
keywords:
- 格式化形状
- 格式化线条
- 草图效果
- 草图形状线条
- 格式化连接样式
- 渐变填充
- 图案填充
- 图片填充
- 纹理填充
- 纯色填充
- 形状透明度
- 旋转形状
- 3D 倒角效果
- 3D 旋转效果
- 重置格式
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何在 C# 中使用 Aspose.Slides 对 PowerPoint 形状进行格式化——为 PPT 和 PPTX 文件精确且完全控制地设置填充、线条和效果样式。"
---
## **介绍**

在 PowerPoint 中，您可以向幻灯片添加形状。由于形状由线组成，您可以通过修改或应用效果来格式化其轮廓。此外，您还可以通过指定控制内部填充方式的设置来格式化形状。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET 提供了接口和属性，允许您使用 PowerPoint 中可用的相同选项来格式化形状。

## **格式化线条**

使用 Aspose.Slides，您可以为形状指定自定义线条样式。以下步骤概述了该过程：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。  
1. 设置形状的 [line style](https://reference.aspose.com/slides/zh/net/aspose.slides/linestyle/)。  
1. 设置线宽。  
1. 设置线的 [dash style](https://reference.aspose.com/slides/zh/net/aspose.slides/linedashstyle/)。  
1. 为形状设置线条颜色。  
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的 C# 代码演示了如何格式化矩形 `AutoShape`：

```c#
// 实例化表示演示文稿文件的 Presentation 类。
using (Presentation presentation = new Presentation())
{
    // 获取第一张幻灯片。
    ISlide slide = presentation.Slides[0];

    // 添加一个矩形类型的自动形状。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 设置矩形形状的填充颜色。
    shape.FillFormat.FillType = FillType.NoFill;

    // 对矩形的线条应用格式化。
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // 设置矩形线条的颜色。
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // 将 PPTX 文件保存到磁盘。
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

结果：

![The formatted lines in the presentation](formatted-lines.png)

## **对形状线条应用草图效果**

草图效果使形状线条看起来像手绘。使用 [IShape.LineFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/lineformat/) 访问线条设置，使用 [ILineFormat.SketchFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ilineformat/sketchformat/) 访问草图设置，并使用 [ISketchFormat.SketchType](https://reference.aspose.com/slides/zh/net/aspose.slides/isketchformat/sketchtype/) 从 [LineSketchType](https://reference.aspose.com/slides/zh/net/aspose.slides/linesketchtype/) 枚举中选择值。

下面的 C# 代码展示了如何应用 [LineSketchType.Curved](https://reference.aspose.com/slides/zh/net/aspose.slides/linesketchtype/) 效果、读取显式分配的值以及使用 [LineSketchType.None](https://reference.aspose.com/slides/zh/net/aspose.slides/linesketchtype/) 移除该效果：

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

`ISketchFormat.SketchType` 返回的值表示直接分配给形状的设置。如果线条格式可以从主题、母版幻灯片或版式幻灯片继承，请使用 [ILineFormat.GetEffective](https://reference.aspose.com/slides/zh/net/aspose.slides/ilineformat/geteffective/)，访问 [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ilineformateffectivedata/sketchformat/)，并读取 [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/zh/net/aspose.slides/isketchformateffectivedata/sketchtype/)。有效值反映了继承解析后实际应用的格式：

```csharp
using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **格式化连接样式**

以下是三种连接类型选项：

* Round  
* Miter  
* Bevel  

默认情况下，当 PowerPoint 在角度处（例如形状的拐角）连接两条线时，会使用 **Round** 设置。然而，如果您绘制的是尖角形状，可能更倾向于使用 **Miter** 选项。

![The join style in the presentation](join-style-powerpoint.png)

下面的 C# 代码演示了如何使用 Miter、Bevel 和 Round 连接类型设置创建上图中的三个矩形：

```c#
// 实例化表示演示文稿文件的 Presentation 类。
using (Presentation presentation = new Presentation())
{
    // 获取第一张幻灯片。
    ISlide slide = presentation.Slides[0];

    // 添加三个矩形类型的自动形状。
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // 为每个矩形形状设置填充颜色。
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // 设置线宽。
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // 为每个矩形的线条设置颜色。
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // 设置连接样式。
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // 为每个矩形添加文本。
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // 将 PPTX 文件保存到磁盘。
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **渐变填充**

在 PowerPoint 中，渐变填充是一种格式化选项，允许您对形状应用连续的颜色混合。例如，您可以以一种颜色逐渐淡化到另一种颜色的方式应用两种或多种颜色。

以下是使用 Aspose.Slides 为形状应用渐变填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。  
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/net/aspose.slides/filltype/) 设置为 `Gradient`。  
1. 使用 [IGradientFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/igradientformat/) 接口公开的渐变停止集合的 `Add` 方法，按定义的位置添加您偏好的两种颜色。  
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的 C# 代码演示了如何对椭圆应用渐变填充效果：

```c#
// 实例化表示演示文稿文件的 Presentation 类。
using (Presentation presentation = new Presentation())
{
    // 获取第一张幻灯片。
    ISlide slide = presentation.Slides[0];

    // 添加一个椭圆类型的自动形状。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // 对椭圆应用渐变格式化。
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // 设置渐变的方向。
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // 添加两个渐变停止点。
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // 将 PPTX 文件保存到磁盘。
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

结果：

![The ellipse with gradient fill](gradient-fill.png)

## **图案填充**

在 PowerPoint 中，图案填充是一种格式化选项，允许您向形状应用两色设计——例如点、条纹、交叉阴影或格子。您可以为图案的前景色和背景色选择自定义颜色。

Aspose.Slides 提供了超过 45 种预定义图案样式，您可以将其应用于形状，以提升演示文稿的视觉效果。即使选择了预定义图案，仍然可以指定其使用的确切颜色。

以下是使用 Aspose.Slides 为形状应用图案填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。  
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/net/aspose.slides/filltype/) 设置为 `Pattern`。  
1. 从预定义选项中选择一种图案样式。  
1. 设置图案的 [Background Color](https://reference.aspose.com/slides/zh/net/aspose.slides/ipatternformat/backcolor/)。  
1. 设置图案的 [Foreground Color](https://reference.aspose.com/slides/zh/net/aspose.slides/ipatternformat/forecolor/)。  
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的 C# 代码演示了如何对矩形应用图案填充：

```c#
// 实例化表示演示文稿文件的 Presentation 类。
using (Presentation presentation = new Presentation())
{
    // 获取第一张幻灯片。
    ISlide slide = presentation.Slides[0];

    // 添加一个矩形类型的自动形状。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 将填充类型设置为 Pattern。
    shape.FillFormat.FillType = FillType.Pattern;

    // 设置图案样式。
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // 设置图案的背景色和前景色。
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // 将 PPTX 文件保存到磁盘。
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

结果：

![The rectangle with pattern fill](pattern-fill.png)

## **图片填充**

在 PowerPoint 中，图片填充是一种格式化选项，允许您在形状内部插入图像——实际上将图像用作形状的背景。

以下是使用 Aspose.Slides 为形状应用图片填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。  
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/net/aspose.slides/filltype/) 设置为 `Picture`。  
1. 将图片填充模式设置为 `Tile`（或其他首选模式）。  
1. 使用要使用的图像创建一个 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 对象。  
1. 将该图像分配给形状的 `PictureFillFormat` 的 `Picture.Image` 属性。  
1. 将修改后的演示文稿保存为 PPTX 文件。

假设我们有一个名为 "lotus.png" 的文件，其图片如下所示：

![The lotus picture](lotus.png)

下面的 C# 代码演示了如何使用图片填充形状：

```c#
// 实例化表示演示文稿文件的 Presentation 类。
using (Presentation presentation = new Presentation())
{
    // 获取第一张幻灯片。
    ISlide slide = presentation.Slides[0];

    // 添加一个矩形类型的自动形状。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // 将填充类型设置为 Picture。
    shape.FillFormat.FillType = FillType.Picture;

    // 设置图片填充模式。
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // 加载图像并将其添加到演示文稿资源中。
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 设置图片。
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // 将 PPTX 文件保存到磁盘。
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

结果：

![The shape with picture fill](picture-fill.png)

### **将图片作为纹理平铺**

如果您想将平铺的图片设为纹理并自定义平铺行为，可以使用 [IPictureFillFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/) 接口和 [PictureFillFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/picturefillformat/) 类的以下属性：

- [PictureFillMode](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/picturefillmode/)：设置图片填充模式——`Tile` 或 `Stretch`。  
- [TileAlignment](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/tilealignment/)：指定平铺在形状内部的对齐方式。  
- [TileFlip](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/tileflip/)：控制平铺是否水平、垂直或同时翻转。  
- [TileOffsetX](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/tileoffsetx/)：设置平铺相对于形状原点的水平偏移（单位：点）。  
- [TileOffsetY](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/tileoffsety/)：设置平铺相对于形状原点的垂直偏移（单位：点）。  
- [TileScaleX](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/tilescalex/)：以百分比定义平铺的水平缩放。  
- [TileScaleY](https://reference.aspose.com/slides/zh/net/aspose.slides/ipicturefillformat/tilescaley/)：以百分比定义平铺的垂直缩放。  

下面的代码示例展示了如何添加一个带有平铺图片填充的矩形形状并配置平铺选项：

```c#
// 实例化表示演示文稿文件的 Presentation 类。
using (Presentation presentation = new Presentation())
{
    // 获取第一张幻灯片。
    ISlide firstSlide = presentation.Slides[0];

    // 添加一个矩形自动形状。
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // 将形状的填充类型设置为 Picture。
    shape.FillFormat.FillType = FillType.Picture;

    // 加载图像并将其添加到演示文稿资源中。
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // 将图像分配给形状。
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // 配置图片填充模式和平铺属性。
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // 将 PPTX 文件保存到磁盘。
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

结果：

![The tile options](tile-options.png)

## **纯色填充**

在 PowerPoint 中，纯色填充是一种格式化选项，使用单一、均匀的颜色填充形状。这种纯背景颜色不含渐变、纹理或图案。

使用 Aspose.Slides 为形状应用纯色填充的步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。  
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/net/aspose.slides/filltype/) 设置为 `Solid`。  
1. 为形状分配您偏好的填充颜色。  
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的 C# 代码演示了如何在 PowerPoint 幻灯片中的矩形上应用纯色填充：

```c#
// 实例化表示演示文稿文件的 Presentation 类。
using (Presentation presentation = new Presentation())
{
    // 获取第一张幻灯片。
    ISlide slide = presentation.Slides[0];

    // 添加一个矩形类型的自动形状。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 将填充类型设置为 Solid。
    shape.FillFormat.FillType = FillType.Solid;

    // 设置填充颜色。
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // 将 PPTX 文件保存到磁盘。
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

结果：

![The shape with solid color fill](solid-color-fill.png)

## **设置透明度**

在 PowerPoint 中，当您对形状使用纯色、渐变、图片或纹理填充时，还可以设置透明度级别以控制填充的透明度。更高的透明度值会使形状更透，从而部分显示背景或底层对象。

Aspose.Slides 通过调整用于填充的颜色的 Alpha 值来设置透明度。操作步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。  
1. 将 [FillType](https://reference.aspose.com/slides/zh/net/aspose.slides/filltype/) 设置为 `Solid`。  
1. 使用 `Color.FromArgb(alpha, baseColor)` 定义具有透明度的颜色（`alpha` 分量控制透明度）。  
1. 保存演示文稿。

下面的 C# 代码演示了如何为矩形应用透明填充颜色：

```c#
const int alpha = 128;

// 实例化表示演示文稿文件的 Presentation 类。
using (Presentation presentation = new Presentation())
{
    // 获取第一张幻灯片。
    ISlide slide = presentation.Slides[0];

    // 添加一个实心矩形自动形状。
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 在实心形状上添加一个透明的矩形自动形状。
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // 将 PPTX 文件保存到磁盘。
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

结果：

![The transparent shape](shape-transparency.png)

## **旋转形状**

Aspose.Slides 允许您在 PowerPoint 演示文稿中旋转形状。这在需要特定对齐或设计的视觉元素时非常有用。

在幻灯片上旋转形状的步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。  
1. 将形状的 `Rotation` 属性设置为所需的角度。  
1. 保存演示文稿。

下面的 C# 代码演示了如何将形状旋转 5 度：

```c#
// 实例化表示演示文稿文件的 Presentation 类。
using (Presentation presentation = new Presentation())
{
    // 获取第一张幻灯片。
    ISlide slide = presentation.Slides[0];

    // 添加一个矩形类型的自动形状。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 将形状旋转 5 度。
    shape.Rotation = 5;

    // 将 PPTX 文件保存到磁盘。
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

结果：

![The shape rotation](shape-rotation.png)

## **添加 3D 倒角效果**

Aspose.Slides 允许您通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/threedformat/) 属性来应用 3D 倒角效果。

为形状添加 3D 倒角效果的步骤如下：

1. 实例化一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类。  
1. 通过索引获取幻灯片的引用。  
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。  
1. 配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/threedformat/) 以定义倒角设置。  
1. 保存演示文稿。

下面的 C# 代码展示了如何对形状应用 3D 倒角效果：

```c#
// 创建 Presentation 类的实例。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 向幻灯片添加一个形状。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // 设置形状的 ThreeDFormat 属性。
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // 将演示文稿保存为 PPTX 文件。
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

结果：

![The 3D bevel effect](3D-bevel-effect.png)

## **添加 3D 旋转效果**

Aspose.Slides 允许您通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/threedformat/) 属性来应用 3D 旋转效果。

为形状应用 3D 旋转的步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/)。  
1. 设置形状的 [CameraType](https://reference.aspose.com/slides/zh/net/aspose.slides/icamera/cameratype/) 和 [LightType](https://reference.aspose.com/slides/zh/net/aspose.slides/ilightrig/lighttype/) 以定义 3D 旋转。  
1. 保存演示文稿。

下面的 C# 代码演示了如何对形状应用 3D 旋转效果：

```c#
// 创建 Presentation 类的实例。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // 将演示文稿保存为 PPTX 文件。
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

结果：

![The 3D rotation effect](3D-rotation-effect.png)

## **重置格式**

下面的 C# 代码展示了如何重置幻灯片的格式，并将 [LayoutSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/layoutslide/) 上所有占位符形状的位置、大小和格式恢复为默认设置：

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 重置幻灯片上在布局中具有占位符的每个形状。
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **常见问题解答**

**形状格式化会影响最终演示文稿的文件大小吗？**

影响极小。嵌入的图像和媒体占据了文件的大部分空间，而形状参数（如颜色、效果和渐变）仅作为元数据存储，几乎不增加额外大小。

**如何检测幻灯片上具有相同格式的形状以便对其进行分组？**

比较每个形状的关键格式属性——填充、线条和效果设置。如果所有对应值相匹配，则视为样式相同，可在逻辑上将这些形状分组，这样后续的样式管理会更简便。

**我可以将一套自定义形状样式保存为单独的文件，以便在其他演示文稿中重复使用吗？**

可以。将带有所需样式的示例形状存放在模板幻灯片集或 .POTX 模板文件中。创建新演示文稿时，打开该模板，克隆所需的已样式化形状，并在需要的地方重新应用其格式。
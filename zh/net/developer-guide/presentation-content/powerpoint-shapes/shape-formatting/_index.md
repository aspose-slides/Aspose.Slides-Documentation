---
title: 形状格式化
type: docs
weight: 20
url: /zh/net/shape-formatting/
keywords:
- 格式化形状
- 格式化线条
- 格式化连接样式
- 渐变填充
- 图案填充
- 图片填充
- 实心颜色填充
- 旋转形状
- 3D 斜角效果
- 3D 旋转效果
- PowerPoint演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: "在 C# 或 .NET 中格式化 PowerPoint 演示文稿中的形状"
---

在 PowerPoint 中，您可以向幻灯片添加形状。由于形状是由线条构成的，因此您可以通过修改或应用某些效果来格式化形状。此外，您还可以通过指定设置来格式化形状，确定它们的填充方式（即其中的区域如何填充）。

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides for .NET** 提供接口和属性，允许您根据 PowerPoint 中已知的选项格式化形状。

## **格式化线条**

使用 Aspose.Slides，您可以为形状指定首选的线条样式。以下是该过程的概述：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)。
4. 为形状线条设置颜色。
5. 为形状线条设置宽度。
6. 为形状线条设置 [线条样式](https://reference.aspose.com/slides/net/aspose.slides/linestyle)。
7. 为形状线条设置 [线段样式](http://aspose.com/api/net/slides/aspose.slides/linedashstyle)。
8. 将修改后的演示文稿写入 PPTX 文件。

以下 C# 代码演示了格式化矩形 `AutoShape` 的操作：

```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation())
{
    // 获取第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 添加矩形类型的自动形状
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // 为矩形形状设置填充颜色
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.White;

    // 对矩形的线条应用一些格式
    shp.LineFormat.Style = LineStyle.ThickThin;
    shp.LineFormat.Width = 7;
    shp.LineFormat.DashStyle = LineDashStyle.Dash;

    // 设置矩形线条的颜色
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // 将 PPTX 文件保存到磁盘
    pres.Save("RectShpLn_out.pptx", SaveFormat.Pptx);
}
```

## **格式化连接样式**
以下是 3 种连接类型选项：

* 圆形
* 斜接
* 斜角

默认情况下，当 PowerPoint 在角度处连接两条线（或形状的角）时，它使用 **圆形** 设置。然而，如果您希望绘制具有非常锐利角度的形状，您可能想选择 **斜接**。

![join-style-powerpoint](join-style-powerpoint.png)

以下 C# 代码演示了创建具有斜接、斜角和圆形连接类型设置的 3 个矩形（如上图）：

```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation())
{

	// 获取第一张幻灯片
	ISlide sld = pres.Slides[0];

	// 添加 3 个矩形自动形状
	IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
	IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
	IShape shp3 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);

	// 为矩形形状设置填充颜色
	shp1.FillFormat.FillType = FillType.Solid;
	shp1.FillFormat.SolidFillColor.Color = Color.Black;
	shp2.FillFormat.FillType = FillType.Solid;
	shp2.FillFormat.SolidFillColor.Color = Color.Black;
	shp3.FillFormat.FillType = FillType.Solid;
	shp3.FillFormat.SolidFillColor.Color = Color.Black;

	// 设置线条的宽度
	shp1.LineFormat.Width = 15;
	shp2.LineFormat.Width = 15;
	shp3.LineFormat.Width = 15;

	// 设置矩形线条的颜色
	shp1.LineFormat.FillFormat.FillType = FillType.Solid;
	shp1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
	shp2.LineFormat.FillFormat.FillType = FillType.Solid;
	shp2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
	shp3.LineFormat.FillFormat.FillType = FillType.Solid;
	shp3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	// 设置连接样式
	shp1.LineFormat.JoinStyle = LineJoinStyle.Miter;
	shp2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
	shp3.LineFormat.JoinStyle = LineJoinStyle.Round;

	// 为每个矩形添加文本
	((IAutoShape)shp1).TextFrame.Text = "斜接连接样式";
	((IAutoShape)shp2).TextFrame.Text = "斜角连接样式";
	((IAutoShape)shp3).TextFrame.Text = "圆形连接样式";

	// 将 PPTX 文件保存到磁盘
	pres.Save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
}
```

## **渐变填充**
在 PowerPoint 中，渐变填充是一种格式化选项，允许您对形状应用连续的颜色混合。例如，您可以应用两种或更多颜色的设置，其中一种颜色逐渐消失并变为另一种颜色。

以下是使用 Aspose.Slides 对形状应用渐变填充的方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) 设置为 `Gradient`。
5. 使用与 `GradientFormat` 类关联的 `GradientStops` 集合所公开的 `Add` 方法添加您选择的 2 种颜色及其定义位置。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 C# 代码演示了在椭圆上使用渐变填充效果的操作：

```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation())
{
    // 获取第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 添加椭圆自动形状
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // 对椭圆应用渐变格式
    shp.FillFormat.FillType = FillType.Gradient;
    shp.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // 设置渐变的方向
    shp.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // 添加 2 个渐变停止点
    shp.FillFormat.GradientFormat.GradientStops.Add((float)1.0, PresetColor.Purple);
    shp.FillFormat.GradientFormat.GradientStops.Add((float)0, PresetColor.Red);

    // 将 PPTX 文件保存到磁盘
    pres.Save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
}
```

## **图案填充**
在 PowerPoint 中，图案填充是一种格式化选项，允许您对形状应用由点、条纹、交叉阴影或方格组成的两种颜色的设计。此外，您可以选择图案的前景和背景的首选颜色。

Aspose.Slides 提供了超过 45 种预定义样式，可用于格式化形状并丰富演示文稿。即使在您选择了预定义图案后，您仍然可以指定图案应包含的颜色。

以下是使用 Aspose.Slides 对形状应用图案填充的方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) 设置为 `Pattern`。
5. 为形状设置首选的图案样式。
6. 为 [PatternFormat](http://www.aspose.com/api/net/slides/aspose.slides/patternformat) 设置 [背景颜色](http://www.aspose.com/api/net/slides/aspose.slides/patternformat/properties/backcolor)。
7. 为 [PatternFormat](http://www.aspose.com/api/net/slides/aspose.slides/patternformat) 设置 [前景颜色](http://www.aspose.com/api/net/slides/aspose.slides/patternformat/properties/forecolor)。
8. 将修改后的演示文稿写入 PPTX 文件。

以下 C# 代码演示了在矩形上使用图案填充进行美化的操作：

```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation())
{

    // 获取第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 添加矩形自动形状
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // 将填充类型设置为图案
    shp.FillFormat.FillType = FillType.Pattern;

    // 设置图案样式
    shp.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // 设置图案的背景和前景颜色
    shp.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shp.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // 将 PPTX 文件保存到磁盘
    pres.Save("RectShpPatt_out.pptx", SaveFormat.Pptx);
}
```

## **图片填充**
在 PowerPoint 中，图片填充是一种格式化选项，允许您在形状内部放置一张图片。实质上，您可以使用图片作为形状的背景。

以下是使用 Aspose.Slides 用图片填充形状的方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) 设置为 `Picture`。
5. 将图片填充模式设置为 Tile。
6. 使用将用于填充形状的图像创建 `IPPImage` 对象。
7. 将 `Picture.Image` 属性设置为最近创建的 `IPPImage`。
8. 将修改后的演示文稿写入 PPTX 文件。

以下 C# 代码演示了如何用图片填充形状：

```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation presentation = new Presentation())
{
    // 获取第一张幻灯片
    ISlide slide = presentation.Slides[0];

    // 添加矩形自动形状
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // 将填充类型设置为图片
    shape.FillFormat.FillType = FillType.Picture;

    // 设置图片填充模式
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // 加载图像并将其添加到演示文稿资源中
    IImage image = Images.FromFile("Tulips.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 设置图片
    shape.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // 将 PPTX 文件保存到磁盘
    presentation.Save("RectShpPic_out.pptx", SaveFormat.Pptx);
}
```

## **实心颜色填充**
在 PowerPoint 中，实心颜色填充是一种格式化选项，允许您用单一颜色填充形状。所选择的颜色通常是纯色。该颜色应用于形状背景，无需任何特殊效果或修改。

以下是使用 Aspose.Slides 对形状应用实心颜色填充的方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) 设置为 `Solid`。
5. 为形状设置您选择的颜色。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 C# 代码演示了如何将实心颜色填充应用于 PowerPoint 中的一个框：

```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation presentation = new Presentation())
{

// 获取第一张幻灯片
    ISlide slide = presentation.Slides[0];

// 添加矩形自动形状
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

// 将填充类型设置为实心
    shape.FillFormat.FillType = FillType.Solid;

// 设置矩形的颜色
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

// 将 PPTX 文件保存到磁盘
    presentation.Save("RectShpSolid_out.pptx", SaveFormat.Pptx);
}
```

## **设置透明度**

在 PowerPoint 中，当您用实心颜色、渐变、图片或纹理填充形状时，您可以指定透明度级别，从而确定填充的透明度。例如，如果您设置较低的透明度级别，则后面的幻灯片对象或背景（形状）将显示出来。

Aspose.Slides 允许您以以下方式为形状设置透明度级别：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)。
4. 使用 `Color.FromArgb` 并设置 alpha 分量。
5. 将对象保存为 PowerPoint 文件。

以下 C# 代码演示了此过程：

```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // 添加一个实心形状
    IShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // 在实心形状上方添加一个透明形状
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.FromArgb(128, 204, 102, 0);
    
    // 将 PPTX 文件保存到磁盘
    presentation.Save("ShapeTransparentOverSolid_out.pptx", SaveFormat.Pptx);
}
```

## **旋转形状**
Aspose.Slides 允许您按以下方式旋转添加到幻灯片的形状：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)。
4. 按需要的度数旋转形状。
5. 将修改后的演示文稿写入 PPTX 文件。

以下 C# 代码演示了如何将形状旋转 90 度：

```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation())
{
    // 获取第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 添加矩形自动形状
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // 将形状旋转 90 度
    shp.Rotation = 90;

    // 将 PPTX 文件保存到磁盘
    pres.Save("RectShpRot_out.pptx", SaveFormat.Pptx);
}
```

## **添加 3D 斜角效果**
Aspose.Slides 允许您通过以下方式修改形状的 [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) 属性来添加 3D 斜角效果：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)。
3. 为形状的 [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) 属性设置首选参数。
4. 将演示文稿写入磁盘。

以下 C# 代码演示了如何为形状添加 3D 斜角效果：

```c#
// 创建 Presentation 类的实例
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    
    // 向幻灯片添加一个形状
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    ILineFillFormat format = shape.LineFormat.FillFormat;
    format.FillType = FillType.Solid;
    format.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;
    
    // 设置形状的 ThreeDFormat 属性
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    
    // 将演示文稿保存为 PPTX 文件
    pres.Save("Bavel_out.pptx", SaveFormat.Pptx);
}
```

## **添加 3D 旋转效果**
Aspose.Slides 允许您通过修改其 [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) 属性将 3D 旋转效果应用于形状：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)。
3. 为 [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/properties/cameratype) 和 [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/properties/lighttype) 指定您的首选图形。
4. 将演示文稿写入磁盘。

以下 C# 代码演示了如何将 3D 旋转效果应用于形状：

```c#
// 创建 Presentation 类的实例
using (Presentation pres = new Presentation())
{
    IShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 200, 200);
    
    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    
    autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Line, 30, 300, 200, 200);
    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(0, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    
    // 将演示文稿保存为 PPTX 文件
    pres.Save("Rotation_out.pptx", SaveFormat.Pptx);
}
```

## **重置格式**

以下 C# 代码演示了如何重置幻灯片中的格式，并将每个在 [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) 上有占位符的形状的位置、大小和格式恢复到其默认值：

```c#
using (Presentation pres = new Presentation())
{
    foreach (ISlide slide in pres.Slides)
    {
        // 将幻灯片上的每个具有占位符的形状恢复
        slide.Reset();
    }
}
```
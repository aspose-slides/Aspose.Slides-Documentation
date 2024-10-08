---
title: 3D 演示
type: docs
weight: 232
url: /net/3d-presentation/
keywords:
- 3D
- 3D PowerPoint
- 3D 演示
- 3D 旋转
- 3D 深度
- 3D 拉伸
- 3D 渐变
- 3D 文本
- PowerPoint 演示
- C#
- Csharp
- Aspose.Slides for .NET
description: "使用 C# 或 .NET 制作的 3D PowerPoint 演示"
---


## 概述
您通常如何创建 3D PowerPoint 演示？
Microsoft PowerPoint 使我们能够创建 3D 演示，这意味着我们可以在其中添加 3D 模型，对形状应用 3D 效果， 
创建 3D 文本，将 3D 图形上传到演示中，制作 PowerPoint 3D 动画。

创建 3D 效果对改进您的演示为 3D 演示有很大影响，并且可能是实现 3D 演示的最简单方式。
自 Aspose.Slides 20.9 版本以来，新增了 **跨平台 3D 引擎**。新 3D 引擎能够 
导出和栅格化带有 3D 效果的形状和文本。在之前的版本中， 
应用了 3D 效果的幻灯片形状是以平面形式呈现的。但是，现在可以 
渲染出 **完整的 3D**。
此外，现在可以通过 Slides 公共 API 创建带有 3D 效果的形状。

在 Aspose.Slides API 中，要使 
形状成为 PowerPoint 3D 形状，请使用 [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) 属性， 
该属性继承了 [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat) 接口的特性：
- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) 
和 [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop)：设置形状的斜角，定义斜角类型（例如：Angle, Circle, SoftRound），定义斜角的高度和宽度。
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera)：用于模拟相机围绕对象的移动。换句话说，通过设置相机的旋转、缩放和其他属性 - 您可以像操作 PowerPoint 中的 3D 模型一样操纵您的 
形状。
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) 
和 [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth)：设置轮廓属性，使形状看起来像 3D PowerPoint 形状。
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth)， 
[ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 
和 [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight)：用于使形状具有立体感，这意味着将 2D 形状转换为 3D 形状， 
通过设置其深度或拉伸它。
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig)：可以在 3D 形状上创建光效。该属性的逻辑与相机相似，您可以设置光源的旋转 
相对于 3D 形状，并选择光源类型。
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material)：设置 3D 形状材料的类型可以带来更生动的效果。该属性提供了一组预定义材料，例如： 
金属、塑料、粉末、哑光等。  

所有 3D 特性都可以应用于形状和文本。让我们看看如何访问上面提到的属性，然后逐步详细了解它们：
``` csharp 
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.TextFrame.Text = "3D";
    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    shape.ThreeDFormat.Material = MaterialPresetType.Flat;
    shape.ThreeDFormat.ExtrusionHeight = 100;
    shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

    using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
    {
        thumbnail.Save("sample_3d.png");
    }

    presentation.Save("sandbox_3d.pptx", SaveFormat.Pptx);
}
```

生成的缩略图如下所示：

![todo:image_alt_text](img_01_01.png)

## 3D 旋转
可以在 3D 平面中旋转 PowerPoint 3D 形状，从而带来更多的交互性。要在 PowerPoint 中旋转 3D 形状，通常使用以下菜单：

![todo:image_alt_text](img_02_01.png)

在 Aspose.Slides API 中，可以使用 [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) 属性管理 3D 形状的旋转：

``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... 设置其他 3D 场景参数

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```

## 3D 深度和拉伸
要为形状带来第三维并使其成为 3D 形状，请使用 [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) 
和 [IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 属性：

``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
// ... 设置其他 3D 场景参数

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```

通常，您会在 PowerPoint 中使用深度菜单为 PowerPoint 3D 形状设置深度：

![todo:image_alt_text](img_02_02.png)


## 3D 渐变
渐变可以用于填充 PowerPoint 3D 形状的颜色。让我们创建一个形状并应用渐变填充颜色以及 3D 效果：

``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.TextFrame.Text = "3D 渐变";
    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
    shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);
    
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    shape.ThreeDFormat.ExtrusionHeight = 150;
    shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

    using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
    {
        thumbnail.Save("sample_3d.png");
    }
}
```

结果如下所示：

![todo:image_alt_text](img_02_03.png)

除了渐变填充颜色外，还可以用图像填充形状：
``` csharp
byte[] imageData = File.ReadAllBytes("image.jpg");
IPPImage image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
// ... 设置 3D：shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* 属性

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```

它的样子如下：

![todo:image_alt_text](img_02_04.png)

## 3D 文本 (WordArt)
Aspose.Slides 还允许在文本上应用 3D 效果。要创建 3D 文本，可以使用 WordArt 变换效果：

``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.TextFrame.Text = "3D 文本";

    Portion portion = (Portion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

    ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
    // 设置 "弧形向上" WordArt 变换效果
    textFrameFormat.Transform = TextShapeType.ArchUp;

    textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
    textFrameFormat.ThreeDFormat.Depth = 3;
    textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
    textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

    using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
    {
        thumbnail.Save("text3d.png");
    }

    presentation.Save("text3d.pptx", SaveFormat.Pptx);
}
```

这是结果：

![todo:image_alt_text](img_02_05.png)


## 不支持 - 即将推出
以下 PowerPoint 3D 特性尚不支持：
- 斜角
- 材料
- 轮廓
- 照明

我们将继续改进我们的 3D 引擎，这些功能将是进一步实现的主题。
---
title: 在 .NET 中创建 3D 演示文稿
linktitle: 3D 演示文稿
type: docs
weight: 232
url: /zh/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 演示文稿
- 3D 旋转
- 3D 深度
- 3D 拉伸
- 3D 渐变
- 3D 文本
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中轻松生成交互式 3D 演示文稿。快速导出为 PowerPoint 和 OpenDocument 格式，用途广泛。"
---

## **概述**
您通常如何创建 3D PowerPoint 演示文稿？  
Microsoft PowerPoint 使您能够以添加 3D 模型、对形状应用 3D 效果、创建 3D 文本、将 3D 图形上传到演示文稿以及创建 PowerPoint 3D 动画等方式创建 3D 演示文稿。

创建 3D 效果对提升演示文稿为 3D 演示文稿具有重大影响，并且可能是实现 3D 演示文稿的最简单方式。  
自 Aspose.Slides 20.9 版起，新增了 **跨平台 3D 引擎**。该 3D 引擎支持导出并光栅化具有 3D 效果的形状和文本。在以前的版本中，应用了 3D 效果的 Slides 形状会被平面渲染。而现在可以 **完整渲染 3D**。  
此外，现在可以通过 Slides 公共 API 使用 3D 效果创建形状。

在 Aspose.Slides API 中，若要使形状成为 PowerPoint 3D 形状，请使用 [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) 属性，该属性继承了 [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat) 接口的功能：
- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) 和 [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop)：为形状设置倒角，定义倒角类型（例如 Angle、Circle、SoftRound），以及倒角的高度和宽度。
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera)：用于模拟相机围绕对象的运动。换句话说，通过设置旋转、缩放和其他属性，您可以像操作 PowerPoint 中的 3D 模型一样操控形状。
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) 和 [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth)：设置轮廓属性，使形状看起来像 3D PowerPoint 形状。
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth)、[ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 和 [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight)：用于让形状具备三维效果，即通过设置深度或拉伸将 2D 形状转换为 3D 形状。
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig)：可以在 3D 形状上创建光照效果。该属性的逻辑类似于 Camera，您可以设置光源相对于 3D 形状的旋转并选择光源类型。
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material)：设置 3D 形状的材质类型，可为其带来更真实的效果。该属性提供了一组预定义材质，例如 Metal、Plastic、Powder、Matte 等。

所有 3D 功能均可应用于形状和文本。下面让我们逐步查看如何访问上述属性并详细了解它们的用法：
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


渲染的缩略图如下：

![todo:image_alt_text](img_01_01.png)

## **3D 旋转**
可以在 3D 平面上旋转 PowerPoint 3D 形状，从而提升交互性。要在 PowerPoint 中旋转 3D 形状，通常使用以下菜单：

![todo:image_alt_text](img_02_01.png)

在 Aspose.Slides API 中，3D 形状的旋转可以通过 [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) 属性进行管理：
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... 设置其他 3D 场景参数

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


## **3D 深度和拉伸**
要为形状添加第三维度并将其转换为 3D 形状，请使用 [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) 和 [IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 属性：
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


通常，您会在 PowerPoint 中使用 Depth 菜单为 PowerPoint 3D 形状设置深度：

![todo:image_alt_text](img_02_02.png)

## **3D 渐变**
渐变可用于填充 PowerPoint 3D 形状的颜色。让我们创建一个具有渐变填充颜色并在其上应用 3D 效果的形状：

``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.TextFrame.Text = "3D Gradient";
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


结果如下：

![todo:image_alt_text](img_02_03.png)

除了渐变填充颜色外，还可以使用图像填充形状：

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


效果如下：

![todo:image_alt_text](img_02_04.png)

## **3D 文本 (WordArt)**
Aspose.Slides 也支持对文本应用 3D 效果。要创建 3D 文本，可以使用 WordArt 变换效果：

``` csharp
const float imageScale = 2;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.TextFrame.Text = "3D Text";

    Portion portion = (Portion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

    shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

    ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
    // 设置“Arch Up”WordArt 变换效果
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


结果如下：

![todo:image_alt_text](img_02_05.png)

## **常见问题**

**将演示文稿导出为图像/PDF/HTML 时，3D 效果会被保留吗？**

是的。Slides 3D 引擎在导出为受支持的格式时会渲染 3D 效果（[images](/slides/zh/net/convert-powerpoint-to-png/)、[PDF](/slides/zh/net/convert-powerpoint-to-pdf/)、[HTML](/slides/zh/net/convert-powerpoint-to-html/) 等）。

**我能检索考虑主题、继承等因素的“有效”（最终）3D 参数值吗？**

可以。Slides 提供了 APIs 用于 [read effective values](/slides/zh/net/shape-effective-properties/)（包括 3D 的灯光、倒角等），以便查看最终应用的设置。

**将演示文稿转换为视频时，3D 效果是否有效？**

是的。在 [generating frames for the video](/slides/zh/net/convert-powerpoint-to-video/) 时，3D 效果会像导出图像一样被渲染。
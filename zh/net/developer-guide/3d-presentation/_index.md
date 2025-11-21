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
description: "使用 Aspose.Slides 在 .NET 中轻松生成交互式 3D 演示文稿。快速导出为 PowerPoint 和 OpenDocument 格式，以实现多种用途。"
---

## **概述**
您通常如何创建 3D PowerPoint 演示文稿？  
Microsoft PowerPoint 允许创建 3D 演示文稿，例如可以添加 3D 模型、对形状应用 3D 效果、创建 3D 文本、将 3D 图形上传到演示文稿以及创建 PowerPoint 3D 动画。

创建 3D 效果对提升演示文稿的视觉冲击力有很大帮助，而且是实现 3D 演示文稿的最简便方式。  
自 Aspose.Slides 20.9 版起，新增了 **跨平台 3D 引擎**。该引擎支持导出并光栅化带有 3D 效果的形状和文本。 在以前的版本中，带有 3D 效果的 Slides 形状会被平面渲染。 但现在可以 **完整渲染 3D**。  
此外，现在可以通过 Slides 公共 API 创建带有 3D 效果的形状。

在 Aspose.Slides API 中，要使形状成为 PowerPoint 3D 形状，请使用 [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) 属性，该属性继承自 [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat) 接口：
- [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) 和 [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop): 为形状设置斜角，定义斜角类型（例如 Angle、Circle、SoftRound），并定义斜角的高度和宽度。  
- [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera): 用于模拟相机围绕对象的运动。 换句话说，通过设置旋转、缩放等属性，可以像在 PowerPoint 中操作 3D 模型一样操作形状。  
- [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) 和 [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth): 设置轮廓属性，使形状看起来像 3D PowerPoint 形状。  
- [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth)、[ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 和 [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight): 用于使形状具备三维效果，即通过设置深度或拉伸将 2D 形状转换为 3D 形状。  
- [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig): 可以在 3D 形状上创建光照效果。其逻辑类似于 Camera，您可以设置光源相对于 3D 形状的旋转并选择光源类型。  
- [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material): 设置 3D 形状的材质类型，可使效果更逼真。该属性提供了一组预定义材质，如 Metal、Plastic、Powder、Matte 等。

所有 3D 功能均可应用于形状和文本。下面演示如何访问上述属性并逐步详细说明它们的用法：
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


渲染后的缩略图如下：

![todo:image_alt_text](img_01_01.png)

## **3D 旋转**
可以在 3D 平面上旋转 PowerPoint 3D 形状，从而提升交互性。 在 PowerPoint 中旋转 3D 形状时，通常使用以下菜单：

![todo:image_alt_text](img_02_01.png)

在 Aspose.Slides API 中，可通过 [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) 属性管理 3D 形状的旋转：
``` csharp
IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
// ... 设置其他 3D 场景参数

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


## **3D 深度与拉伸**
要为形状添加第三维度并使其成为 3D 形状，请使用 [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) 和 [IThreeDFormat.ExtrusionColor.Color](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 属性：
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


通常，您可以在 PowerPoint 中使用 **Depth** 菜单为 PowerPoint 3D 形状设置深度：

![todo:image_alt_text](img_02_02.png)


## **3D 渐变**
渐变可以用于填充 PowerPoint 3D 形状的颜色。 下面创建一个带有渐变填充颜色并应用 3D 效果的形状：
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
// ... 设置 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* 属性

using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
{
    thumbnail.Save("sample_3d.png");
}
```


效果如下：

![todo:image_alt_text](img_02_04.png)

## **3D 文本（WordArt）**
Aspose.Slides 也支持对文本应用 3D 效果。 要创建 3D 文本，可使用 WordArt 变换效果：
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
    // 设置 "Arch Up" WordArt 变换效果
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

**导出演示文稿为图像/PDF/HTML 时，3D 效果会被保留吗？**  

是的。Slides 3D 引擎在导出支持的格式（[图像](/slides/zh/net/convert-powerpoint-to-png/)、[PDF](/slides/zh/net/convert-powerpoint-to-pdf/)、[HTML](/slides/zh/net/convert-powerpoint-to-html/)...）时会渲染 3D 效果。

**我可以检索考虑主题、继承等因素的“有效”(最终) 3D 参数值吗？**  

是的。Slides 提供了用于 [读取有效值](/slides/zh/net/shape-effective-properties/) 的 API（包括 3D 的照明、斜角等），您可以查看最终应用的设置。

**3D 效果在将演示文稿转换为视频时是否有效？**  

是的。在 [生成视频帧](/slides/zh/net/convert-powerpoint-to-video/) 时，3D 效果会像导出图像时一样被渲染。
---
title: 在 .NET 中创建演示文稿的 3D 效果
linktitle: 3D 演示文稿
type: docs
weight: 232
url: /zh/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 演示文稿
- 3D 旋转
- 3D 深度
- 3D 挤压
- 3D 渐变
- 3D 文本
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中使用 Aspose.Slides 为 PowerPoint 形状和文本应用并渲染 3D 效果。配置摄像机、照明、材质、挤压、填充和 3D 文本。"
---
## **概述**

Aspose.Slides for .NET 可以创建、编辑、保留并呈现 PowerPoint 样式的形状和文本的 3D 格式化。本文介绍旋转、挤压、斜角、照明、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="info" title="Note" %}}
此文章涉及 PowerPoint 形状和文本的 3D 格式化效果。不涉及插入或编辑独立的 3D 模型文件。当您将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染到导出的二维输出中。
{{% /alert %}}

## **3D 格式化概念**

使用 [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) 属性对形状应用 3D 格式化。该属性公开 [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat)，用于控制该形状的 3D 场景。

对于文本，使用 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) 属性。此属性对文本框而不是形状本体应用 3D 格式化。

以下是最重要的属性：

| 属性 | 控制内容 | 使用时机 |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) | 视点、预设摄像机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 3D 旋转预设。 |
| [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) | 光源预设、方向以及光旋转。 | 更改 3D 表面上高光和阴影的呈现方式。 |
| [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) | 表面材质，例如平面、哑光、塑料或金属。 | 使相同几何体看起来更平坦、柔软、光亮或金属化。 |
| [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) | 形状从正面向后延伸的距离。 | 将平面形状变为可见的厚 3D 对象。 |
| [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) | 挤压侧面的颜色。 | 使深度可见或将侧面颜色与正面填充匹配。 |
| [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3D 格式化使用的额外 3D 深度。 | 对形状或文本的深度进行微调，尤其是与斜角和材质设置一起使用时。 |
| [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) 和 [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) | 正面和背面上的凸起或圆角边缘。 | 添加柔和或成型的边缘，而不是尖锐的平面。 |
| [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) 和 [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D 对象的轮廓。 | 在渲染输出中强调对象边界。 |

## **创建 3D 形状**

形状在看起来逼真的 3D 之前通常需要四种设置：

- 摄像机设置，因为默认的正面视图可能会隐藏挤压效果。
- 灯光设置，因为光照使各面和侧面更易识别。
- 材质设置，因为表面影响光线的渲染方式。
- 挤压或深度设置，因为平面形状需要厚度。

以下示例创建一个矩形，在其正面添加文本，并应用 3D 格式化。摄像机旋转值以度为单位，挤压高度为 100 点。示例将幻灯片渲染为尺寸为默认两倍的 PNG 图像，并将演示文稿保存为 PPTX。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

![渲染的蓝色 3D 矩形，正面带白色 3D 文本](img_01_01.png)

## **使用摄像机旋转形状**

在 PowerPoint 中，3D 旋转在“3-D 旋转”窗格中配置。X、Y、Z 旋转值对应通过摄像机 API 设置的旋转。

![PowerPoint “3-D 旋转”窗格，突出显示 X、Y、Z 旋转值](img_02_01.png)

在 Aspose.Slides 中，访问摄像机通过 [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera)。此示例创建一个矩形，选择正交前视图，并将其 X、Y、Z 旋转分别设置为 20、30、40 度。它在内存中配置形状而不保存文件：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

当需要更改观看者看到对象的方式时使用摄像机。它不会更改幻灯片上 2D 形状的几何形状，而是更改 PowerPoint 和 Aspose.Slides 在渲染时使用的 3D 视点。

### **从模板形状复制摄像机方向**

要匹配模板中的形状，请复制其 [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) 预设并使用 [GetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/getrotation/) 读取其角度。示例打开 `template.pptx`，读取第一张幻灯片上第一个形状的摄像机，并将其方向应用于第二个形状。两个形状已拥有 3D 灯光，第二个形状没有显式摄像机旋转。

角度以度为单位。索引 `0` 为纬度，索引 `1` 为经度，索引 `2` 为旋转。按该顺序传递给 [SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/)。如果源返回 `null`，则表示没有显式旋转，保持第二个形状的角度未设置。显式旋转 `(0, 0, 0)` 会返回三个零，应予以复制。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var shapes = presentation.Slides[0].Shapes;

var sourceCamera = shapes[0].ThreeDFormat.Camera;
var destinationCamera = shapes[1].ThreeDFormat.Camera;

destinationCamera.CameraType = sourceCamera.CameraType;
var angles = sourceCamera.GetRotation();
if (angles != null)
{
    destinationCamera.SetRotation(angles[0], angles[1], angles[2]);
}

presentation.Save("camera-copy.pptx", SaveFormat.Pptx);
```

当您重新打开 `camera-copy.pptx` 时，两个形状拥有相同的摄像机预设和旋转。在 PowerPoint 中，右侧的箭头使用左侧矩形复制的摄像机方向。两个形状使用相同的灯光和挤压深度。

![一个蓝色 3D 矩形和一个右箭头，摄像机方向匹配，从上方和右侧观看](camera-orientation.png)

## **添加挤压和深度**

挤压通过在正面后方延伸形状，使其看起来更厚。PowerPoint 中的深度控制设置可见厚度，颜色控制设置侧面的颜色。

![PowerPoint 深度控制映射到挤压颜色和挤压高度属性](img_02_02.png)

设置 [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) 以确定厚度，并使用 [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 设置侧面颜色。此示例为矩形设置 100 点的挤压，侧面为紫色，并旋转摄像机以显示其厚度。它在内存中配置形状而不保存文件：

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

[IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) 属性设置 3D 形状的深度。[ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) 属性控制挤压效果的高度，如本例所示。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化独立于形状填充。您可以对正面应用纯色、渐变、图案或图片填充，并仍然使用相同的摄像机、灯光、材质和挤压设置。

此示例对正面应用蓝到橙的渐变，对 150 点的挤压使用深橙色。渐变在 0 和 100 处分别标记起始和结束。摄像机旋转值以度为单位。幻灯片渲染为尺寸为默认两倍的 PNG 图像：

```csharp
using System.Drawing;
using Aspose.Slides;

const float imageScale = 2;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

![渲染的 3D 矩形，蓝到橙的渐变填充和橙色挤压](img_02_03.png)

如果改为使用图片填充，请将图像添加到演示文稿并分配给形状填充。此示例需要工作目录中已有名为 "image.jpg" 的文件。它将图片拉伸填满矩形，应用 150 点挤压，并以度为单位设置摄像机旋转。它在内存中配置形状而不保存或渲染文件：

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

![渲染的 3D 矩形，正面使用照片填充，橙色挤压](img_02_04.png)

## **将 3D 格式化应用于文本**

形状的 3D 格式化影响形状本体。文本的 3D 格式化影响文本框。这对于需要对字母本身进行挤压、材质、灯光和摄像机设置的 WordArt 类效果非常有用。

以下示例创建带有橙白网格图案的文本，应用向上拱形，并通过 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) 配置 3D 设置。挤压高度和深度以点为单位，灯光旋转以度为单位。形状填充和轮廓被隐藏，只保留文本可见。示例将 PNG 图像渲染为默认幻灯片尺寸的两倍，并将演示文稿保存为 PPTX：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

![渲染的 3D 文本，带弧形 WordArt 变换、橙色图案填充和深色挤压](img_02_05.png)

## **在 3D 形状上保持文本平面**

要在保留形状的 3D 外观的同时保持文本可读，请通过 [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframe/textframeformat/) 设置 [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/keeptextflat/)。当值为 `true` 时，文本保持在 3D 场景之外；为 `false` 时，文本参与场景并遵循其 3D 朝向。

此设置不会移除形状的 3D 格式化：其摄像机、灯光、材质和挤压仍通过 [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) 配置。它也不同于普通旋转。[IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) 在幻灯片平面中旋转形状，而 [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) 控制文本在其边界框内的自定义旋转。将文本保持在 3D 场景之外不会重置这两个角度。

以下独立示例创建一个带文本的蓝色矩形并在其旁边克隆一份。两个形状拥有相同的 3D 格式化；仅文本设置不同：左侧为 `false`，右侧为 `true`。摄像机角度以度为单位，挤压高度为 40 点。示例将演示文稿保存为 PPTX，并将比较幻灯片渲染为默认尺寸的两倍 PNG。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

shape.TextFrame.Text = "Readable text";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 28;
shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(30, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 40;
shape.ThreeDFormat.ExtrusionColor.Color = Color.RoyalBlue;
shape.TextFrame.TextFrameFormat.KeepTextFlat = false;

var flatTextShape = (IAutoShape)slide.Shapes.AddClone(shape, 400, 160);
flatTextShape.TextFrame.TextFrameFormat.KeepTextFlat = true;

presentation.Save("keep_text_flat.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(2, 2);
image.Save("keep_text_flat.png");
```

左侧的文本遵循 3D 朝向。右侧的文本保持平面，更易阅读。两个矩形保留相同的可见挤压和 3D 朝向。

![并排的 3D 矩形：左侧 KeepTextFlat 为 false，右侧为 true](keep_text_flat.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时保留 3D 格式化。渲染或导出为固定布局格式时，3D 场景会被光栅化或绘制为 2D 结果。此行为适用于将幻灯片渲染为 [PNG](/slides/zh/net/convert-powerpoint-to-png/)、导出为 [PDF](/slides/zh/net/convert-powerpoint-to-pdf/)、导出为 [HTML](/slides/zh/net/convert-powerpoint-to-html/)，或生成用于 [video conversion](/slides/zh/net/convert-powerpoint-to-video/) 的帧。

- 导出的图像和 PDF 不是交互式的。导出后，观看者无法旋转对象。
- 最终外观取决于摄像机、灯光装置、材质、挤压、填充和幻灯片缩放的组合。
- 如果需要检查继承或基于主题的格式化值，请读取[有效形状属性](/slides/zh/net/shape-effective-properties/)。
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉结果会被渲染，而不是保留为可编辑的 3D 设置。

## **常见问题**

**Aspose.Slides 能创建交互式 3D 演示文稿吗？**

Aspose.Slides 为形状和文本创建并渲染 PowerPoint 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为观看者可以旋转的交互式 3D 场景。在 PPTX 中，3D 格式化在 PowerPoint 中仍然是可编辑的（前提是格式支持）。

**3D 模型和 3D 效果有什么区别？**

3D 模型是插入到演示文稿中的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本进行的格式化，如旋转、挤压、斜角、照明和材质。本文讨论的是 3D 效果。

**可见的 3D 形状需要哪些设置？**

至少需要设置摄像机旋转以及挤压或深度。实际使用时，还应设置灯光装置和材质，以便渲染的面具有清晰的高光和阴影。

**我可以将 3D 效果应用于形状和文本吗？**

是的。对形状体使用[IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) ，对文本使用[ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat)。

**导出为图像、PDF、HTML 或视频帧时，3D 效果会出现吗？**

会。Aspose.Slides 在生成幻灯片图像、PDF 输出、HTML 输出以及用于视频转换的帧时会渲染 3D 效果。导出的输出包含渲染后的外观，而不是可编辑的 3D 对象。

**在应用继承和主题设置后，我能读取最终的 3D 值吗？**

是的。使用在[有效形状属性](/slides/zh/net/shape-effective-properties/)中描述的有效格式化 API 来读取最终的摄像机、灯光装置、斜角和相关 3D 值。
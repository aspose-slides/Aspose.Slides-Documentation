---
title: 使用 .NET 在演示文稿中创建 3D 效果
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
description: "使用 Aspose.Slides 在 .NET 中为 PowerPoint 形状和文本应用并渲染 3D 效果。配置相机、照明、材质、挤压、填充以及 3D 文本。"
---
## **概述**

Aspose.Slides for .NET 可以创建、编辑、保留并呈现类似 PowerPoint 的形状和文本的 3D 格式化。本文涵盖了旋转、挤压、斜角、照明、材质、渐变或图片填充以及 3D 文本等 3D 效果。

{{% alert color="info" title="Note" %}}

本文讨论的是 PowerPoint 形状和文本的 3D 格式化效果。它不涉及插入或编辑独立的 3D 模型文件。当您将幻灯片导出为图像、PDF 或 HTML 时，Aspose.Slides 会将这些 3D 效果渲染到导出的 2D 输出中。

{{% /alert %}}

## **3D 格式化概念**

使用 [IShape.ThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/properties/threedformat) 属性为形状应用 3D 格式化。该属性公开 [IThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat)，用于控制该形状的 3D 场景。

对于文本，使用 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/properties/threedformat) 属性。这会将 3D 格式化应用于文本框，而不是形状主体。

最重要的属性如下：

| 属性 | 控制内容 | 何时使用 |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/camera) | 视点、预设相机类型、旋转、缩放和透视。 | 在 3D 空间中旋转对象或匹配 PowerPoint 的 3D 旋转预设。 |
| [LightRig](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/lightrig) | 光照预设、方向和光线旋转。 | 更改 3D 表面上高光和阴影的显示方式。 |
| [Material](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/material) | 表面材质，如平面、哑光、塑料或金属。 | 使相同的几何体呈现更平坦、柔和、光亮或金属感。 |
| [ExtrusionHeight](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/extrusionheight) | 形状从正面向后延伸的距离。 | 将平面形状转换为可视的厚度 3D 对象。 |
| [ExtrusionColor](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/extrusioncolor) | 挤压侧面的颜色。 | 显示深度或使侧面颜色与正面填充协调。 |
| [Depth](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3D 格式化使用的附加深度。 | 对形状或文本进行微调，尤其是在使用斜角和材质设置时。 |
| [BevelTop](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/beveltop) 和 [BevelBottom](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/bevelbottom) | 正面和背面的凸起或圆角边缘。 | 添加柔化或模塑的边缘，而不是锐利的平面。 |
| [ContourColor](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/contourcolor) 和 [ContourWidth](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D 对象的轮廓线。 | 在渲染输出中强调对象边界。 |

## **创建 3D 形状**

形状通常需要四类设置才能呈现出可信的 3D 效果：

- 相机设置，因为默认的正视图可能会隐藏挤压效果。
- 光照设置，因为光线使各面和侧面可辨识。
- 材质设置，因为表面材质影响光线的渲染方式。
- 挤压或深度设置，因为平面形状需要厚度。

下面的示例创建一个矩形，在其正面添加文本，并应用 3D 格式化。相机旋转值以度为单位，挤压高度为 100 点。示例将幻灯片渲染为 PNG 图像（尺寸为默认的两倍），并将演示文稿保存为 PPTX。

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

渲染后的幻灯片图像显示矩形为一个厚实的 3D 块：

![渲染的蓝色 3D 矩形，正面有白色 3D 文本](img_01_01.png)

## **使用相机旋转形状**

在 PowerPoint 中，3D 旋转在“3‑D 旋转”窗格中配置。X、Y、Z 旋转值对应通过相机 API 设置的旋转。

![PowerPoint 3‑D 旋转窗格，突出显示 X、Y 和 Z 旋转值](img_02_01.png)

在 Aspose.Slides 中，通过 [IThreeDFormat.Camera](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/camera) 访问相机。此示例创建一个矩形，选择正交正面视图，并将其 X、Y、Z 旋转分别设置为 20、30、40 度。它在内存中配置形状，而不保存文件：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

需要改变观察者看到对象方式时使用相机。它不改变幻灯片上 2D 形状的几何结构，只改变 PowerPoint 和 Aspose.Slides 渲染时使用的 3D 视点。

## **添加挤压和深度**

挤压通过在正面后方延伸来使形状看起来更厚。在 PowerPoint 中，深度控件设置此可见厚度，颜色控件设置侧面的颜色。

![PowerPoint 深度控件映射到挤压颜色和挤压高度属性](img_02_02.png)

使用 [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/extrusionheight) 设置厚度，使用 [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/extrusioncolor) 设置侧面颜色。此示例为矩形设置 100 点的紫色侧面挤压，并旋转相机以展示其厚度。它在内存中配置形状，而不保存文件：

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

[IThreeDFormat.Depth](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/depth) 属性设置 3D 形状的深度。[ExtrusionHeight](https://reference.aspose.com/slides/zh/net/aspose.slides/ithreedformat/properties/extrusionheight) 属性控制挤压效果的高度，如本示例所示。

## **在 3D 效果中使用渐变或图片填充**

3D 格式化独立于形状填充。您可以对正面使用纯色、渐变、图案或图片填充，同时仍使用相同的相机、光照、材质和挤压设置。

此示例对正面应用蓝到橙的渐变，对 150 点的挤压使用深橙颜色。渐变停止点 0 与 100 标记渐变的起始和结束。相机旋转值以度为单位。幻灯片渲染为 PNG 图像（尺寸为默认的两倍）：

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

渲染输出保留正面的渐变，并单独渲染挤压侧面：

![渲染的 3D 矩形，正面为蓝到橙的渐变填充，侧面为橙色挤压](img_02_03.png)

若使用图片填充，请将图片添加到演示文稿并分配给形状填充。此示例要求工作目录中已有名为 "image.jpg" 的文件。它将图片拉伸填满矩形，应用 150 点挤压，并以度为单位设置相机旋转。它在内存中配置形状，而不保存或渲染文件：

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

图片渲染在正面，挤压则渲染为 3D 侧面表面：

![渲染的 3D 矩形，正面为照片填充，侧面为橙色挤压](img_02_04.png)

## **对文本应用 3D 格式化**

形状的 3D 格式化影响形状主体。文本的 3D 格式化影响文本框。这对于需要挤压、材质、照明和相机设置的 WordArt 类效果非常有用。

下面的示例创建带有橙白网格图案的文本，应用向上弧形，并通过 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/properties/threedformat) 配置 3D 设置。挤压高度和深度以点为单位，光线旋转以度为单位。形状填充和轮廓被隐藏，仅显示文本。示例将 PNG 图像渲染为默认幻灯片尺寸的两倍，并将演示文稿保存为 PPTX：

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

文本被渲染为弯曲、挤压的 3D 字体：

![渲染的 3D 文本，带有拱形 WordArt 变换、橙色图案填充和深色挤压](img_02_05.png)

## **在 3D 形状上保持文本平面**

若要在保持形状的 3D 外观的同时保持文本可读，请通过 [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/textframeformat/) 的 [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/keeptextflat/) 设置。当值为 `true` 时，文本保持在 3D 场景之外；当为 `false` 时，文本参与场景并遵循其 3D 方向。

此设置不会移除形状的 3D 格式化：其相机、照明、材质和挤压仍通过 [IShape.ThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/threedformat/) 配置。它也不同于普通旋转。[IShape.Rotation](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/rotation/) 在幻灯片平面内旋转形状，而 [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/rotationangle/) 控制文本在其边界框内的自定义旋转。保持文本不进入 3D 场景不会重置上述任一角度。

下面的独立示例创建一个带文本的蓝色矩形，并在原始矩形旁边克隆它。两个形状具有相同的 3D 格式化；仅文本设置不同：左侧为 `false`，右侧为 `true`。相机角度以度为单位，挤压高度为 40 点。示例将演示文稿保存为 PPTX，并将比较幻灯片渲染为 PNG（尺寸为默认的两倍）。

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

左侧的文本遵循 3D 方向；右侧的文本保持平面，更易阅读。两个矩形保留相同的可见挤压和 3D 方向。

![并排比较的 3D 矩形：左侧 KeepTextFlat 为 false，右侧为 true](keep_text_flat.png)

## **导出和渲染行为**

Aspose.Slides 在保存为 PPTX 等 PowerPoint 格式时会保留 3D 格式化。渲染或导出为固定布局格式时，3D 场景会光栅化或绘制为 2D 结果。这适用于将幻灯片渲染为 [PNG](/slides/zh/net/convert-powerpoint-to-png/)、导出为 [PDF](/slides/zh/net/convert-powerpoint-to-pdf/)、导出为 [HTML](/slides/zh/net/convert-powerpoint-to-html/)，或为 [视频转换](/slides/zh/net/convert-powerpoint-to-video/) 生成帧。

请注意以下要点：

- 导出的图像和 PDF 为静态的，导出后对象无法被观看者旋转。
- 最终外观取决于相机、光照、材质、挤压、填充和幻灯片缩放的组合。
- 若需检查继承或主题基的格式化值，请读取 [effective shape properties](/slides/zh/net/shape-effective-properties/)。
- 某些输出格式无法存储可编辑的 PowerPoint 3D 格式化。在这些格式中，视觉结果会被渲染，而不是以可编辑的 3D 设置保存。

## **常见问答**

**Aspose.Slides 能创建交互式 3D 演示文稿吗？**

Aspose.Slides 创建并渲染 PowerPoint 形状和文本的 3D 效果。它不会使导出的图像、PDF 或 HTML 页面成为可交互的 3D 场景，供观看者旋转。在 PPTX 中，3D 格式化在 PowerPoint 中仍保持可编辑（前提是格式支持）。

**3D 模型和 3D 效果有什么区别？**

3D 模型是插入演示文稿的独立 3D 对象。3D 效果是对普通 PowerPoint 形状或文本应用的格式化，如旋转、挤压、斜角、照明和材质。本文关注的是 3D 效果。

**可见的 3D 形状需要哪些设置？**

至少需要设置相机旋转以及挤压或深度。实际使用中，通常还会设置光照和材质，以便渲染出的面有明显的高光和阴影。

**我可以同时对形状和文本应用 3D 效果吗？**

可以。对形状主体使用 [IShape.ThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/properties/threedformat)，对文本使用 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframeformat/properties/threedformat)。

**导出为图像、PDF、HTML 或视频帧时会出现 3D 效果吗？**

会。Aspose.Slides 在生成幻灯片图像、PDF、HTML 以及用于视频转换的帧时会渲染 3D 效果。导出的输出包含渲染后的外观，而不是可编辑的 3D 对象。

**我能在继承和主题设置应用后读取最终的 3D 值吗？**

可以。使用文档中描述的有效格式化 API（[Shape Effective Properties](/slides/zh/net/shape-effective-properties/)）读取最终的相机、光照、斜角以及相关的 3D 值。